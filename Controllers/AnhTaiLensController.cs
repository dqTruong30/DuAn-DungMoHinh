#nullable enable

using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DungMoHinh.Controllers;

public class AnhTaiLensController : ControllerCoSo
{
    private readonly IDonViCongViec _unitOfWork;
    private readonly IWebHostEnvironment _environment;

    public AnhTaiLensController(IDonViCongViec unitOfWork, IWebHostEnvironment environment)
    {
        _unitOfWork = unitOfWork;
        _environment = environment;
    }

    public async Task<IActionResult> Index()
    {
        var anhTaiLens = await _unitOfWork.AnhTaiLens.GetUserAnhTaiLensAsync(CurrentUserId);
        return View(anhTaiLens);
    }

    [HttpPost]
    public async Task<IActionResult> TaiLenImage(IFormFile file, LoaiTaiLen anhTaiLenType, int? nhanVatId)
    {
        if (file is null || file.Length == 0)
        {
            return BadRequest(new { success = false, message = "File anhTaiLen bi rong." });
        }

        if (nhanVatId.HasValue)
        {
            var ownsNhanVat = await _unitOfWork.NhanVats.NguoiDungSoHuuNhanVatAsync(nhanVatId.Value, CurrentUserId);

            if (!ownsNhanVat)
            {
                return NotFound();
            }
        }

        var anhTaiLenFolder = Path.Combine(_environment.WebRootPath ?? "wwwroot", "anhTaiLens", CurrentUserId);
        Directory.CreateDirectory(anhTaiLenFolder);

        var extension = Path.GetExtension(file.FileName);
        var safeTenFile = $"{Guid.NewGuid():N}{extension}";
        var filePath = Path.Combine(anhTaiLenFolder, safeTenFile);

        await using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }

        var relativeUrl = $"/anhTaiLens/{CurrentUserId}/{safeTenFile}";
        var anhTaiLen = new AnhTaiLen
        {
            UserId = CurrentUserId,
            NhanVatId = nhanVatId,
            LoaiTaiLen = anhTaiLenType,
            Status = TrangThaiXuLy.HoanTat,
            DuongDanAnhGoc = relativeUrl,
            TenFile = Path.GetFileName(file.FileName),
            LoaiNoiDung = file.ContentType,
            KichThuocFile = file.Length
        };

        await _unitOfWork.AnhTaiLens.AddAsync(anhTaiLen);
        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true, anhTaiLen.Id, anhTaiLen.DuongDanAnhGoc });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var anhTaiLen = await _unitOfWork.AnhTaiLens.LayAnhTaiLenCuaNguoiDungAsync(id, CurrentUserId);

        if (anhTaiLen is null)
        {
            return NotFound();
        }

        _unitOfWork.AnhTaiLens.Remove(anhTaiLen);
        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true });
    }
}


