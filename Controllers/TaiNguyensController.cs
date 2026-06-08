#nullable enable

using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using DungMoHinh.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DungMoHinh.Controllers;

public class TaiNguyensController : ControllerCoSo
{
    private readonly IDonViCongViec _unitOfWork;

    public TaiNguyensController(IDonViCongViec unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index(LoaiTaiNguyen? type)
    {
        var taiNguyens = await _unitOfWork.TaiNguyens.GetActiveTaiNguyensAsync(type);
        return View(taiNguyens);
    }

    public async Task<IActionResult> Details(int id)
    {
        var taiNguyen = await _unitOfWork.TaiNguyens.LayTaiNguyenDangHoatDongKemDiemAsync(id);

        if (taiNguyen is null)
        {
            return NotFound();
        }

        return View(taiNguyen);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] YeuCauTaoTaiNguyen request)
    {
        if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.DuongDanFile))
        {
            return BadRequest(new { success = false, message = "Ten va duong dan file taiNguyen la bat buoc." });
        }

        var taiNguyen = new TaiNguyen3D
        {
            Name = request.Name.Trim(),
            MoTa = request.MoTa,
            Type = request.Type,
            DefaultDiemGan = request.DefaultDiemGan,
            DuongDanFile = request.DuongDanFile,
            AnhDaiDienUrl = request.AnhDaiDienUrl,
            KetCauUrl = request.KetCauUrl,
            MauSacMacDinh = request.MauSacMacDinh,
            SupportsPartAdjustment = request.SupportsPartAdjustment,
            IsUserGenerated = request.IsUserGenerated
        };

        await _unitOfWork.TaiNguyens.AddAsync(taiNguyen);
        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true, taiNguyen.Id });
    }

    [HttpPost]
    public async Task<IActionResult> Disable(int id)
    {
        var disabled = await _unitOfWork.TaiNguyens.DisableAsync(id);
        if (!disabled)
        {
            return NotFound();
        }

        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true });
    }
}


