#nullable enable

using DungMoHinh.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DungMoHinh.Controllers;

public class GoiMausController : ControllerCoSo
{
    private readonly IDonViCongViec _unitOfWork;

    public GoiMausController(IDonViCongViec unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var goiMaus = await _unitOfWork.GoiMaus.GetActiveGoiMausAsync();
        return View(goiMaus);
    }

    public async Task<IActionResult> Details(int id)
    {
        var goiMau = await _unitOfWork.GoiMaus.LayGoiMauDangHoatDongAsync(id);

        if (goiMau is null)
        {
            return NotFound();
        }

        return View(goiMau);
    }
}


