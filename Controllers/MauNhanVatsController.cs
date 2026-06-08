#nullable enable

using DungMoHinh.Repositories.Interfaces;
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
        var maus = await _unitOfWork.MauNhanVats.LayMauDangHoatDongAsync();
        return View(maus);
    }

    public async Task<IActionResult> Details(int id)
    {
        var mau = await _unitOfWork.MauNhanVats.LayMauDangHoatDongAsync(id);

        if (mau is null)
        {
            return NotFound();
        }

        return View(mau);
    }
}


