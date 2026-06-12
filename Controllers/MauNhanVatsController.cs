#nullable enable

using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using DungMoHinh.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DungMoHinh.Controllers;

public class MauNhanVatsController : ControllerCoSo
{
    private readonly IDonViCongViec _unitOfWork;

    public MauNhanVatsController(IDonViCongViec unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var maus = User.IsInRole(VaiTroHeThong.Admin)
            ? await _unitOfWork.MauNhanVats.LayTatCaMauAsync()
            : await _unitOfWork.MauNhanVats.LayMauDangHoatDongAsync();

        return View(maus);
    }

    public async Task<IActionResult> Details(int id)
    {
        var mau = User.IsInRole(VaiTroHeThong.Admin)
            ? await _unitOfWork.MauNhanVats.GetByIdAsync(id)
            : await _unitOfWork.MauNhanVats.LayMauDangHoatDongAsync(id);

        if (mau is null)
        {
            return NotFound();
        }

        return View(mau);
    }

    [Authorize(Roles = VaiTroHeThong.Admin)]
    public IActionResult Create()
    {
        return View(new YeuCauMauNhanVat());
    }

    [HttpPost]
    [Authorize(Roles = VaiTroHeThong.Admin)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(YeuCauMauNhanVat request)
    {
        KiemTraYeuCauMau(request);
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var mau = new MauNhanVat
        {
            Name = request.Name.Trim(),
            MoTa = request.MoTa,
            Kind = request.Kind,
            Style = request.Style,
            ModelUrl = request.ModelUrl.Trim(),
            AnhDaiDienUrl = request.AnhDaiDienUrl,
            IsActive = request.IsActive
        };

        await _unitOfWork.MauNhanVats.AddAsync(mau);
        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction(nameof(Details), new { id = mau.Id });
    }

    [Authorize(Roles = VaiTroHeThong.Admin)]
    public async Task<IActionResult> Edit(int id)
    {
        var mau = await _unitOfWork.MauNhanVats.GetByIdAsync(id);
        if (mau is null)
        {
            return NotFound();
        }

        return View(TaoYeuCau(mau));
    }

    [HttpPost]
    [Authorize(Roles = VaiTroHeThong.Admin)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, YeuCauMauNhanVat request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        KiemTraYeuCauMau(request);
        if (!ModelState.IsValid)
        {
            return View(request);
        }

        var mau = await _unitOfWork.MauNhanVats.GetByIdAsync(id);
        if (mau is null)
        {
            return NotFound();
        }

        mau.Name = request.Name.Trim();
        mau.MoTa = request.MoTa;
        mau.Kind = request.Kind;
        mau.Style = request.Style;
        mau.ModelUrl = request.ModelUrl.Trim();
        mau.AnhDaiDienUrl = request.AnhDaiDienUrl;
        mau.IsActive = request.IsActive;
        mau.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction(nameof(Details), new { id = mau.Id });
    }

    [Authorize(Roles = VaiTroHeThong.Admin)]
    public async Task<IActionResult> Delete(int id)
    {
        var mau = await _unitOfWork.MauNhanVats.GetByIdAsync(id);
        if (mau is null)
        {
            return NotFound();
        }

        return View(mau);
    }

    [HttpPost]
    [ActionName("Delete")]
    [Authorize(Roles = VaiTroHeThong.Admin)]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var mau = await _unitOfWork.MauNhanVats.GetByIdAsync(id);
        if (mau is null)
        {
            return NotFound();
        }

        mau.IsActive = false;
        mau.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private void KiemTraYeuCauMau(YeuCauMauNhanVat request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            ModelState.AddModelError(nameof(request.Name), "Tên mẫu nhân vật là bắt buộc.");
        }

        if (string.IsNullOrWhiteSpace(request.ModelUrl))
        {
            ModelState.AddModelError(nameof(request.ModelUrl), "Đường dẫn model là bắt buộc.");
        }
    }

    private static YeuCauMauNhanVat TaoYeuCau(MauNhanVat mau)
    {
        return new YeuCauMauNhanVat
        {
            Id = mau.Id,
            Name = mau.Name,
            MoTa = mau.MoTa,
            Kind = mau.Kind,
            Style = mau.Style,
            ModelUrl = mau.ModelUrl,
            AnhDaiDienUrl = mau.AnhDaiDienUrl,
            IsActive = mau.IsActive
        };
    }
}


