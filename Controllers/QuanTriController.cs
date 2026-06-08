#nullable enable

using DungMoHinh.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DungMoHinh.Controllers;

public class QuanTriController : ControllerCoSo
{
    private readonly IDonViCongViec _unitOfWork;

    public QuanTriController(IDonViCongViec unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Dashboard()
    {
        var overview = await _unitOfWork.QuanTri.LayTongQuanBangDieuKhienAsync();
        return View(overview);
    }

    public async Task<IActionResult> NhanVats()
    {
        var nhanVats = await _unitOfWork.QuanTri.LayNhanVatGanDayAsync();
        return View(nhanVats);
    }

    public async Task<IActionResult> TaiNguyens()
    {
        var taiNguyens = await _unitOfWork.QuanTri.GetTaiNguyensAsync();
        return View(taiNguyens);
    }

    public async Task<IActionResult> AnhTaiLens()
    {
        var anhTaiLens = await _unitOfWork.QuanTri.GetRecentAnhTaiLensAsync();
        return View(anhTaiLens);
    }
}


