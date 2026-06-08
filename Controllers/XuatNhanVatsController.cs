#nullable enable

using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using DungMoHinh.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DungMoHinh.Controllers;

public class XuatNhanVatsController : ControllerCoSo
{
    private readonly IDonViCongViec _unitOfWork;

    public XuatNhanVatsController(IDonViCongViec unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> Create(int nhanVatId, [FromBody] YeuCauTaoXuat request)
    {
        var nhanVat = await _unitOfWork.NhanVats.LayNhanVatCuaNguoiDungAsync(nhanVatId, CurrentUserId);

        if (nhanVat is null)
        {
            return NotFound();
        }

        var xuat = new XuatNhanVat
        {
            NhanVatId = nhanVat.Id,
            Format = request.Format,
            Status = TrangThaiXuLy.ChoXuLy
        };

        await _unitOfWork.Xuats.AddAsync(xuat);
        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true, xuat.Id, xuat.Status });
    }

    public async Task<IActionResult> Status(int id)
    {
        var xuat = await _unitOfWork.Xuats.LayXuatNhanVatCuaNguoiDungAsync(id, CurrentUserId);

        if (xuat is null)
        {
            return NotFound();
        }

        return Ok(new
        {
            xuat.Id,
            xuat.Status,
            xuat.Format,
            xuat.DuongDanFile,
            xuat.TenFile,
            xuat.KichThuocFile
        });
    }

    [HttpPost]
    public async Task<IActionResult> Complete(int id, [FromBody] YeuCauHoanTatXuat request)
    {
        var xuat = await _unitOfWork.Xuats.LayXuatNhanVatCuaNguoiDungAsync(id, CurrentUserId);

        if (xuat is null)
        {
            return NotFound();
        }

        xuat.Status = TrangThaiXuLy.HoanTat;
        xuat.DuongDanFile = request.DuongDanFile;
        xuat.TenFile = request.TenFile;
        xuat.KichThuocFile = request.KichThuocFile;
        xuat.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true, xuat.DuongDanFile });
    }
}


