#nullable enable

using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using DungMoHinh.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DungMoHinh.Controllers;

public class NhanVatsController : ControllerCoSo
{
    private readonly IDonViCongViec _unitOfWork;

    public NhanVatsController(IDonViCongViec unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var nhanVats = await _unitOfWork.NhanVats.LayNhanVatTheoNguoiDungAsync(CurrentUserId);
        return View(nhanVats);
    }

    public async Task<IActionResult> Details(int id)
    {
        var nhanVat = await LoadNhanVatAsync(id);
        if (nhanVat is null)
        {
            return NotFound();
        }

        return View(nhanVat);
    }

    public async Task<IActionResult> Editor(int id)
    {
        var nhanVat = await LoadNhanVatAsync(id);
        if (nhanVat is null)
        {
            return NotFound();
        }

        return View(nhanVat);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Maus = await _unitOfWork.MauNhanVats.LayMauDangHoatDongAsync();

        return View(new YeuCauTaoNhanVat());
    }

    [HttpPost]
    public async Task<IActionResult> Create(YeuCauTaoNhanVat request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            ModelState.AddModelError(nameof(request.Name), "Ten nhan vat la bat buoc.");
        }

        if (!ModelState.IsValid)
        {
            ViewBag.Maus = await _unitOfWork.MauNhanVats.LayMauDangHoatDongAsync();

            return View(request);
        }

        var nhanVat = new NhanVat
        {
            Name = request.Name.Trim(),
            MoTa = request.MoTa,
            UserId = CurrentUserId,
            MauNhanVatId = request.MauNhanVatId,
            Kind = request.Kind,
            Style = request.Style,
            CauHinhCoThe = new CauHinhCoTheNhanVat(),
            CauHinhKhuonMat = new CauHinhKhuonMatNhanVat()
        };

        await _unitOfWork.NhanVats.AddAsync(nhanVat);
        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction(nameof(Editor), new { id = nhanVat.Id });
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCoThe(int id, [FromBody] YeuCauCauHinhCoThe request)
    {
        var nhanVat = await _unitOfWork.NhanVats.LayNhanVatChoTrinhSuaAsync(id, CurrentUserId);

        if (nhanVat is null)
        {
            return NotFound();
        }

        nhanVat.CauHinhCoThe ??= new CauHinhCoTheNhanVat { NhanVatId = nhanVat.Id };
        nhanVat.CauHinhCoThe.OverallHeight = request.OverallHeight;
        nhanVat.CauHinhCoThe.DauScale = request.DauScale;
        nhanVat.CauHinhCoThe.CoScale = request.CoScale;
        nhanVat.CauHinhCoThe.ShoulderWidth = request.ShoulderWidth;
        nhanVat.CauHinhCoThe.NgucScale = request.NgucScale;
        nhanVat.CauHinhCoThe.EoScale = request.EoScale;
        nhanVat.CauHinhCoThe.HipScale = request.HipScale;
        nhanVat.CauHinhCoThe.ArmLength = request.ArmLength;
        nhanVat.CauHinhCoThe.ArmWidth = request.ArmWidth;
        nhanVat.CauHinhCoThe.HandScale = request.HandScale;
        nhanVat.CauHinhCoThe.LegLength = request.LegLength;
        nhanVat.CauHinhCoThe.LegWidth = request.LegWidth;
        nhanVat.CauHinhCoThe.FootScale = request.FootScale;
        nhanVat.CauHinhCoThe.CoTheMass = request.CoTheMass;
        nhanVat.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true, nhanVatId = nhanVat.Id });
    }

    [HttpPost]
    public async Task<IActionResult> UpdateKhuonMat(int id, [FromBody] YeuCauCauHinhKhuonMat request)
    {
        var nhanVat = await _unitOfWork.NhanVats.LayNhanVatChoTrinhSuaAsync(id, CurrentUserId);

        if (nhanVat is null)
        {
            return NotFound();
        }

        nhanVat.CauHinhKhuonMat ??= new CauHinhKhuonMatNhanVat { NhanVatId = nhanVat.Id };
        nhanVat.CauHinhKhuonMat.KhuonMatWidth = request.KhuonMatWidth;
        nhanVat.CauHinhKhuonMat.KhuonMatLength = request.KhuonMatLength;
        nhanVat.CauHinhKhuonMat.EyeSize = request.EyeSize;
        nhanVat.CauHinhKhuonMat.EyeDistance = request.EyeDistance;
        nhanVat.CauHinhKhuonMat.EyeAngle = request.EyeAngle;
        nhanVat.CauHinhKhuonMat.NoseHeight = request.NoseHeight;
        nhanVat.CauHinhKhuonMat.NoseWidth = request.NoseWidth;
        nhanVat.CauHinhKhuonMat.MouthWidth = request.MouthWidth;
        nhanVat.CauHinhKhuonMat.LipThickness = request.LipThickness;
        nhanVat.CauHinhKhuonMat.EarScale = request.EarScale;
        nhanVat.CauHinhKhuonMat.ChinScale = request.ChinScale;
        nhanVat.CauHinhKhuonMat.CheekScale = request.CheekScale;
        nhanVat.CauHinhKhuonMat.EyebrowAngle = request.EyebrowAngle;
        nhanVat.CauHinhKhuonMat.MauDa = request.MauDa;
        nhanVat.CauHinhKhuonMat.MauMat = request.MauMat;
        nhanVat.CauHinhKhuonMat.MauToc = request.MauToc;
        nhanVat.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true, nhanVatId = nhanVat.Id });
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTuyChinh(int id, [FromBody] YeuCauGiaTriTuyChinh request)
    {
        var nhanVatExists = await _unitOfWork.NhanVats.NguoiDungSoHuuNhanVatAsync(id, CurrentUserId);

        if (!nhanVatExists)
        {
            return NotFound();
        }

        var parameter = await _unitOfWork.TuyChinhs.GetActiveParameterAsync(request.ThamSoTuyChinhId);

        if (parameter is null)
        {
            return BadRequest(new { success = false, message = "Thong so tuy chinh khong ton tai." });
        }

        var safeGiaTri = Math.Clamp(request.GiaTri, parameter.GiaTriNhoNhat, parameter.GiaTriLonNhat);
        var value = await _unitOfWork.TuyChinhs.GetNhanVatGiaTriAsync(id, parameter.Id);

        if (value is null)
        {
            value = new GiaTriTuyChinhNhanVat
            {
                NhanVatId = id,
                ThamSoTuyChinhId = parameter.Id,
                GiaTri = safeGiaTri
            };
            await _unitOfWork.TuyChinhs.AddNhanVatGiaTriAsync(value);
        }
        else
        {
            value.GiaTri = safeGiaTri;
            value.UpdatedAt = DateTime.UtcNow;
        }

        await _unitOfWork.NhanVats.TouchAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true, parameter.Key, value = safeGiaTri });
    }

    [HttpPost]
    public async Task<IActionResult> Duplicate(int id)
    {
        var source = await LoadNhanVatAsync(id);
        if (source is null)
        {
            return NotFound();
        }

        var clone = new NhanVat
        {
            Name = $"{source.Name} Copy",
            MoTa = source.MoTa,
            UserId = CurrentUserId,
            MauNhanVatId = source.MauNhanVatId,
            Kind = source.Kind,
            Style = source.Style,
            CheDoHienThi = CheDoHienThi.RiengTu,
            AnhDaiDienUrl = source.AnhDaiDienUrl,
            AnhXemTruocUrl = source.AnhXemTruocUrl,
            CauHinhCoThe = source.CauHinhCoThe is null ? new CauHinhCoTheNhanVat() : new CauHinhCoTheNhanVat
            {
                OverallHeight = source.CauHinhCoThe.OverallHeight,
                DauScale = source.CauHinhCoThe.DauScale,
                CoScale = source.CauHinhCoThe.CoScale,
                ShoulderWidth = source.CauHinhCoThe.ShoulderWidth,
                NgucScale = source.CauHinhCoThe.NgucScale,
                EoScale = source.CauHinhCoThe.EoScale,
                HipScale = source.CauHinhCoThe.HipScale,
                ArmLength = source.CauHinhCoThe.ArmLength,
                ArmWidth = source.CauHinhCoThe.ArmWidth,
                HandScale = source.CauHinhCoThe.HandScale,
                LegLength = source.CauHinhCoThe.LegLength,
                LegWidth = source.CauHinhCoThe.LegWidth,
                FootScale = source.CauHinhCoThe.FootScale,
                CoTheMass = source.CauHinhCoThe.CoTheMass
            },
            CauHinhKhuonMat = source.CauHinhKhuonMat is null ? new CauHinhKhuonMatNhanVat() : new CauHinhKhuonMatNhanVat
            {
                KhuonMatWidth = source.CauHinhKhuonMat.KhuonMatWidth,
                KhuonMatLength = source.CauHinhKhuonMat.KhuonMatLength,
                EyeSize = source.CauHinhKhuonMat.EyeSize,
                EyeDistance = source.CauHinhKhuonMat.EyeDistance,
                EyeAngle = source.CauHinhKhuonMat.EyeAngle,
                NoseHeight = source.CauHinhKhuonMat.NoseHeight,
                NoseWidth = source.CauHinhKhuonMat.NoseWidth,
                MouthWidth = source.CauHinhKhuonMat.MouthWidth,
                LipThickness = source.CauHinhKhuonMat.LipThickness,
                EarScale = source.CauHinhKhuonMat.EarScale,
                ChinScale = source.CauHinhKhuonMat.ChinScale,
                CheekScale = source.CauHinhKhuonMat.CheekScale,
                EyebrowAngle = source.CauHinhKhuonMat.EyebrowAngle,
                MauDa = source.CauHinhKhuonMat.MauDa,
                MauMat = source.CauHinhKhuonMat.MauMat,
                MauToc = source.CauHinhKhuonMat.MauToc
            }
        };

        foreach (var taiNguyen in source.TaiNguyenNhanVats)
        {
            clone.TaiNguyenNhanVats.Add(new TaiNguyenNhanVat
            {
                TaiNguyen3DId = taiNguyen.TaiNguyen3DId,
                DiemGan = taiNguyen.DiemGan,
                TenDiemGanTuyChinh = taiNguyen.TenDiemGanTuyChinh,
                ViTriX = taiNguyen.ViTriX,
                ViTriY = taiNguyen.ViTriY,
                ViTriZ = taiNguyen.ViTriZ,
                XoayX = taiNguyen.XoayX,
                XoayY = taiNguyen.XoayY,
                XoayZ = taiNguyen.XoayZ,
                TiLeX = taiNguyen.TiLeX,
                TiLeY = taiNguyen.TiLeY,
                TiLeZ = taiNguyen.TiLeZ,
                MauSac = taiNguyen.MauSac,
                DoKimLoai = taiNguyen.DoKimLoai,
                DoNham = taiNguyen.DoNham
            });
        }

        await _unitOfWork.NhanVats.AddAsync(clone);
        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction(nameof(Editor), new { id = clone.Id });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var nhanVat = await _unitOfWork.NhanVats.LayNhanVatCuaNguoiDungAsync(id, CurrentUserId);

        if (nhanVat is null)
        {
            return NotFound();
        }

        _unitOfWork.NhanVats.Remove(nhanVat);
        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private async Task<NhanVat?> LoadNhanVatAsync(int id)
    {
        return await _unitOfWork.NhanVats.LayNhanVatChoTrinhSuaAsync(id, CurrentUserId);
    }
}


