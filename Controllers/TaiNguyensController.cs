#nullable enable

using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using DungMoHinh.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        var taiNguyens = User.IsInRole(VaiTroHeThong.Admin)
            ? await _unitOfWork.TaiNguyens.LayTatCaTaiNguyenAsync(type)
            : await _unitOfWork.TaiNguyens.GetActiveTaiNguyensAsync(type);

        ViewBag.Type = type;
        return View(taiNguyens);
    }

    public async Task<IActionResult> Details(int id)
    {
        var taiNguyen = User.IsInRole(VaiTroHeThong.Admin)
            ? await _unitOfWork.TaiNguyens.LayTaiNguyenKemDiemAsync(id)
            : await _unitOfWork.TaiNguyens.LayTaiNguyenDangHoatDongKemDiemAsync(id);

        if (taiNguyen is null)
        {
            return NotFound();
        }

        return View(taiNguyen);
    }

    [Authorize(Roles = VaiTroHeThong.Admin)]
    public IActionResult Create()
    {
        return View(new YeuCauTaoTaiNguyen
        {
            Type = LoaiTaiNguyen.PhuKien,
            DefaultDiemGan = DiemGan.TuyChinh,
            MauSacMacDinh = "#ffffff"
        });
    }

    [HttpPost]
    [Authorize(Roles = VaiTroHeThong.Admin)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(YeuCauTaoTaiNguyen request)
    {
        KiemTraYeuCauTaiNguyen(request);
        if (!ModelState.IsValid)
        {
            return View(request);
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

        return RedirectToAction(nameof(Details), new { id = taiNguyen.Id });
    }

    [Authorize(Roles = VaiTroHeThong.Admin)]
    public async Task<IActionResult> Edit(int id)
    {
        var taiNguyen = await _unitOfWork.TaiNguyens.LayTaiNguyenKemDiemAsync(id);
        if (taiNguyen is null)
        {
            return NotFound();
        }

        return View(new YeuCauSuaTaiNguyen
        {
            Id = taiNguyen.Id,
            Name = taiNguyen.Name,
            MoTa = taiNguyen.MoTa,
            Type = taiNguyen.Type,
            DefaultDiemGan = taiNguyen.DefaultDiemGan,
            DuongDanFile = taiNguyen.DuongDanFile,
            AnhDaiDienUrl = taiNguyen.AnhDaiDienUrl,
            KetCauUrl = taiNguyen.KetCauUrl,
            MauSacMacDinh = taiNguyen.MauSacMacDinh,
            SupportsPartAdjustment = taiNguyen.SupportsPartAdjustment,
            IsUserGenerated = taiNguyen.IsUserGenerated,
            IsActive = taiNguyen.IsActive
        });
    }

    [HttpPost]
    [Authorize(Roles = VaiTroHeThong.Admin)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, YeuCauSuaTaiNguyen request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        KiemTraYeuCauTaiNguyen(request);
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var taiNguyen = await _unitOfWork.TaiNguyens.LayTaiNguyenKemDiemAsync(id);
        if (taiNguyen is null)
        {
            return NotFound();
        }

        taiNguyen.Name = request.Name.Trim();
        taiNguyen.MoTa = request.MoTa;
        taiNguyen.Type = request.Type;
        taiNguyen.DefaultDiemGan = request.DefaultDiemGan;
        taiNguyen.DuongDanFile = request.DuongDanFile.Trim();
        taiNguyen.AnhDaiDienUrl = request.AnhDaiDienUrl;
        taiNguyen.KetCauUrl = request.KetCauUrl;
        taiNguyen.MauSacMacDinh = request.MauSacMacDinh;
        taiNguyen.SupportsPartAdjustment = request.SupportsPartAdjustment;
        taiNguyen.IsUserGenerated = request.IsUserGenerated;
        taiNguyen.IsActive = request.IsActive;
        taiNguyen.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction(nameof(Details), new { id = taiNguyen.Id });
    }

    [Authorize(Roles = VaiTroHeThong.Admin)]
    public async Task<IActionResult> Delete(int id)
    {
        var taiNguyen = await _unitOfWork.TaiNguyens.LayTaiNguyenKemDiemAsync(id);
        if (taiNguyen is null)
        {
            return NotFound();
        }

        return View(taiNguyen);
    }

    [HttpPost]
    [ActionName("Delete")]
    [Authorize(Roles = VaiTroHeThong.Admin)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var disabled = await _unitOfWork.TaiNguyens.DisableAsync(id);
        if (!disabled)
        {
            return NotFound();
        }

        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [Authorize(Roles = VaiTroHeThong.Admin)]
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

    private void KiemTraYeuCauTaiNguyen(YeuCauTaoTaiNguyen request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            ModelState.AddModelError(nameof(request.Name), "Tên tài nguyên là bắt buộc.");
        }

        if (string.IsNullOrWhiteSpace(request.DuongDanFile))
        {
            ModelState.AddModelError(nameof(request.DuongDanFile), "Đường dẫn file tài nguyên là bắt buộc.");
        }
    }
}


