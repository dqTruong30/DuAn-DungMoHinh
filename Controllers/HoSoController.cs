#nullable enable

using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using DungMoHinh.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DungMoHinh.Controllers;

public class HoSoController : ControllerCoSo
{
    private readonly IDonViCongViec _unitOfWork;

    public HoSoController(IDonViCongViec unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var hoSo = await GetOrCreateHoSoAsync();
        return View(hoSo);
    }

    public async Task<IActionResult> MyNhanVats()
    {
        var nhanVats = await _unitOfWork.NhanVats.LayNhanVatTheoNguoiDungAsync(CurrentUserId);

        return View(nhanVats);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] HoSoNguoiDungUpdateRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.TenHienThi))
        {
            return BadRequest(new { success = false, message = "Ten hien thi la bat buoc." });
        }

        var hoSo = await GetOrCreateHoSoAsync();
        hoSo.TenHienThi = request.TenHienThi.Trim();
        hoSo.AvatarUrl = request.AvatarUrl;
        hoSo.Bio = request.Bio;
        hoSo.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true });
    }

    private async Task<HoSoNguoiDung> GetOrCreateHoSoAsync()
    {
        var hoSo = await _unitOfWork.HoSoNguoiDungs.LayHoacTaoMoiAsync(
            CurrentUserId,
            User.Identity?.Name ?? "Demo User");

        await _unitOfWork.SaveChangesAsync();

        return hoSo;
    }
}


