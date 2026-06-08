#nullable enable

using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using DungMoHinh.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DungMoHinh.Controllers;

public class TaiNguyenNhanVatsController : ControllerCoSo
{
    private readonly IDonViCongViec _unitOfWork;

    public TaiNguyenNhanVatsController(IDonViCongViec unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> Add(int nhanVatId, [FromBody] TaiNguyenNhanVatCreateRequest request)
    {
        var nhanVat = await _unitOfWork.NhanVats.LayNhanVatCuaNguoiDungAsync(nhanVatId, CurrentUserId);

        if (nhanVat is null)
        {
            return NotFound();
        }

        var taiNguyen = await _unitOfWork.TaiNguyens.LayTaiNguyenDangHoatDongKemDiemAsync(request.TaiNguyen3DId);

        if (taiNguyen is null)
        {
            return BadRequest(new { success = false, message = "TaiNguyen khong ton tai hoac da bi khoa." });
        }

        var nhanVatTaiNguyen = new TaiNguyenNhanVat
        {
            NhanVatId = nhanVat.Id,
            TaiNguyen3DId = taiNguyen.Id,
            DiemGan = request.DiemGan,
            TenDiemGanTuyChinh = request.TenDiemGanTuyChinh,
            MauSac = request.MauSac ?? taiNguyen.MauSacMacDinh
        };

        await _unitOfWork.TaiNguyenNhanVats.AddAsync(nhanVatTaiNguyen);
        nhanVat.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true, nhanVatTaiNguyen.Id });
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTransform(int id, [FromBody] YeuCauBienDoiTaiNguyen request)
    {
        var nhanVatTaiNguyen = await _unitOfWork.TaiNguyenNhanVats.LayTaiNguyenNhanVatCuaNguoiDungAsync(id, CurrentUserId);

        if (nhanVatTaiNguyen is null)
        {
            return NotFound();
        }

        nhanVatTaiNguyen.ViTriX = request.ViTriX;
        nhanVatTaiNguyen.ViTriY = request.ViTriY;
        nhanVatTaiNguyen.ViTriZ = request.ViTriZ;
        nhanVatTaiNguyen.XoayX = request.XoayX;
        nhanVatTaiNguyen.XoayY = request.XoayY;
        nhanVatTaiNguyen.XoayZ = request.XoayZ;
        nhanVatTaiNguyen.TiLeX = request.TiLeX;
        nhanVatTaiNguyen.TiLeY = request.TiLeY;
        nhanVatTaiNguyen.TiLeZ = request.TiLeZ;
        nhanVatTaiNguyen.MauSac = request.MauSac;
        nhanVatTaiNguyen.DoKimLoai = request.DoKimLoai;
        nhanVatTaiNguyen.DoNham = request.DoNham;
        nhanVatTaiNguyen.UpdatedAt = DateTime.UtcNow;
        nhanVatTaiNguyen.NhanVat.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true });
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePartGiaTri(int id, [FromBody] YeuCauGiaTriPhanTaiNguyen request)
    {
        var nhanVatTaiNguyen = await _unitOfWork.TaiNguyenNhanVats.LayTaiNguyenNhanVatKemTaiNguyenAsync(id, CurrentUserId);

        if (nhanVatTaiNguyen is null)
        {
            return NotFound();
        }

        var point = await _unitOfWork.TaiNguyens.GetAdjustmentPointAsync(nhanVatTaiNguyen.TaiNguyen3DId, request.DiemChinhPhuKienId);

        if (point is null)
        {
            return BadRequest(new { success = false, message = "Diem chinh phu kien khong hop le." });
        }

        var safeGiaTri = Math.Clamp(request.GiaTri, point.GiaTriNhoNhat, point.GiaTriLonNhat);
        var existingGiaTri = await _unitOfWork.TaiNguyenNhanVats.GetPartGiaTriAsync(id, point.Id);

        if (existingGiaTri is null)
        {
            existingGiaTri = new GiaTriPhanPhuKienNhanVat
            {
                TaiNguyenNhanVatId = id,
                DiemChinhPhuKienId = point.Id,
                GiaTri = safeGiaTri
            };
            await _unitOfWork.TaiNguyenNhanVats.AddPartGiaTriAsync(existingGiaTri);
        }
        else
        {
            existingGiaTri.GiaTri = safeGiaTri;
            existingGiaTri.UpdatedAt = DateTime.UtcNow;
        }

        nhanVatTaiNguyen.UpdatedAt = DateTime.UtcNow;
        nhanVatTaiNguyen.NhanVat.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true, value = safeGiaTri });
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int id)
    {
        var nhanVatTaiNguyen = await _unitOfWork.TaiNguyenNhanVats.LayTaiNguyenNhanVatCuaNguoiDungAsync(id, CurrentUserId);

        if (nhanVatTaiNguyen is null)
        {
            return NotFound();
        }

        nhanVatTaiNguyen.NhanVat.UpdatedAt = DateTime.UtcNow;
        _unitOfWork.TaiNguyenNhanVats.Remove(nhanVatTaiNguyen);
        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true });
    }
}


