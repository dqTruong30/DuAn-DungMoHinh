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

        ViewBag.TaiNguyens = await _unitOfWork.TaiNguyens.GetActiveTaiNguyensAsync();

        return View(nhanVat);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Maus = await _unitOfWork.MauNhanVats.LayMauDangHoatDongAsync();

        return View(new YeuCauTaoNhanVat());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(YeuCauTaoNhanVat request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            ModelState.AddModelError(nameof(request.Name), "Tên nhân vật là bắt buộc.");
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

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var nhanVat = await LoadNhanVatAsync(id);
        if (nhanVat is null)
        {
            return NotFound();
        }

        ViewBag.Maus = await _unitOfWork.MauNhanVats.LayMauDangHoatDongAsync();

        return View(TaoYeuCauSuaNhanVat(nhanVat));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, YeuCauSuaNhanVat request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            ModelState.AddModelError(nameof(request.Name), "Tên nhân vật là bắt buộc.");
        }

        var nhanVat = await LoadNhanVatAsync(id);
        if (nhanVat is null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            ViewBag.Maus = await _unitOfWork.MauNhanVats.LayMauDangHoatDongAsync();

            return View(request);
        }

        nhanVat.Name = request.Name.Trim();
        nhanVat.MoTa = request.MoTa;
        nhanVat.MauNhanVatId = request.MauNhanVatId;
        nhanVat.Kind = request.Kind;
        nhanVat.Style = request.Style;
        nhanVat.UpdatedAt = DateTime.UtcNow;

        nhanVat.CauHinhCoThe ??= new CauHinhCoTheNhanVat { NhanVatId = nhanVat.Id };
        nhanVat.CauHinhCoThe.OverallHeight = request.CoThe.OverallHeight;
        nhanVat.CauHinhCoThe.DauScale = request.CoThe.DauScale;
        nhanVat.CauHinhCoThe.CoScale = request.CoThe.CoScale;
        nhanVat.CauHinhCoThe.ShoulderWidth = request.CoThe.ShoulderWidth;
        nhanVat.CauHinhCoThe.NgucScale = request.CoThe.NgucScale;
        nhanVat.CauHinhCoThe.EoScale = request.CoThe.EoScale;
        nhanVat.CauHinhCoThe.HipScale = request.CoThe.HipScale;
        nhanVat.CauHinhCoThe.ArmLength = request.CoThe.ArmLength;
        nhanVat.CauHinhCoThe.ArmWidth = request.CoThe.ArmWidth;
        nhanVat.CauHinhCoThe.HandScale = request.CoThe.HandScale;
        nhanVat.CauHinhCoThe.LegLength = request.CoThe.LegLength;
        nhanVat.CauHinhCoThe.LegWidth = request.CoThe.LegWidth;
        nhanVat.CauHinhCoThe.FootScale = request.CoThe.FootScale;
        nhanVat.CauHinhCoThe.CoTheMass = request.CoThe.CoTheMass;

        nhanVat.CauHinhKhuonMat ??= new CauHinhKhuonMatNhanVat { NhanVatId = nhanVat.Id };
        nhanVat.CauHinhKhuonMat.KhuonMatWidth = request.KhuonMat.KhuonMatWidth;
        nhanVat.CauHinhKhuonMat.KhuonMatLength = request.KhuonMat.KhuonMatLength;
        nhanVat.CauHinhKhuonMat.EyeSize = request.KhuonMat.EyeSize;
        nhanVat.CauHinhKhuonMat.EyeDistance = request.KhuonMat.EyeDistance;
        nhanVat.CauHinhKhuonMat.EyeAngle = request.KhuonMat.EyeAngle;
        nhanVat.CauHinhKhuonMat.NoseHeight = request.KhuonMat.NoseHeight;
        nhanVat.CauHinhKhuonMat.NoseWidth = request.KhuonMat.NoseWidth;
        nhanVat.CauHinhKhuonMat.MouthWidth = request.KhuonMat.MouthWidth;
        nhanVat.CauHinhKhuonMat.LipThickness = request.KhuonMat.LipThickness;
        nhanVat.CauHinhKhuonMat.EarScale = request.KhuonMat.EarScale;
        nhanVat.CauHinhKhuonMat.ChinScale = request.KhuonMat.ChinScale;
        nhanVat.CauHinhKhuonMat.CheekScale = request.KhuonMat.CheekScale;
        nhanVat.CauHinhKhuonMat.EyebrowAngle = request.KhuonMat.EyebrowAngle;
        nhanVat.CauHinhKhuonMat.MauDa = request.KhuonMat.MauDa;
        nhanVat.CauHinhKhuonMat.MauMat = request.KhuonMat.MauMat;
        nhanVat.CauHinhKhuonMat.MauToc = request.KhuonMat.MauToc;

        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction(nameof(Details), new { id = nhanVat.Id });
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var nhanVat = await LoadNhanVatAsync(id);
        if (nhanVat is null)
        {
            return NotFound();
        }

        return View(nhanVat);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LuuCauHinhEditor(int id, YeuCauSuaNhanVat request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        var nhanVat = await LoadNhanVatAsync(id);
        if (nhanVat is null)
        {
            return NotFound();
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            request.Name = nhanVat.Name;
        }

        nhanVat.Name = request.Name.Trim();
        nhanVat.MoTa = request.MoTa;
        nhanVat.MauNhanVatId = request.MauNhanVatId;
        nhanVat.Kind = request.Kind;
        nhanVat.Style = request.Style;
        nhanVat.UpdatedAt = DateTime.UtcNow;

        nhanVat.CauHinhCoThe ??= new CauHinhCoTheNhanVat { NhanVatId = nhanVat.Id };
        nhanVat.CauHinhCoThe.OverallHeight = request.CoThe.OverallHeight;
        nhanVat.CauHinhCoThe.DauScale = request.CoThe.DauScale;
        nhanVat.CauHinhCoThe.CoScale = request.CoThe.CoScale;
        nhanVat.CauHinhCoThe.ShoulderWidth = request.CoThe.ShoulderWidth;
        nhanVat.CauHinhCoThe.NgucScale = request.CoThe.NgucScale;
        nhanVat.CauHinhCoThe.EoScale = request.CoThe.EoScale;
        nhanVat.CauHinhCoThe.HipScale = request.CoThe.HipScale;
        nhanVat.CauHinhCoThe.ArmLength = request.CoThe.ArmLength;
        nhanVat.CauHinhCoThe.ArmWidth = request.CoThe.ArmWidth;
        nhanVat.CauHinhCoThe.HandScale = request.CoThe.HandScale;
        nhanVat.CauHinhCoThe.LegLength = request.CoThe.LegLength;
        nhanVat.CauHinhCoThe.LegWidth = request.CoThe.LegWidth;
        nhanVat.CauHinhCoThe.FootScale = request.CoThe.FootScale;
        nhanVat.CauHinhCoThe.CoTheMass = request.CoThe.CoTheMass;

        nhanVat.CauHinhKhuonMat ??= new CauHinhKhuonMatNhanVat { NhanVatId = nhanVat.Id };
        nhanVat.CauHinhKhuonMat.KhuonMatWidth = request.KhuonMat.KhuonMatWidth;
        nhanVat.CauHinhKhuonMat.KhuonMatLength = request.KhuonMat.KhuonMatLength;
        nhanVat.CauHinhKhuonMat.EyeSize = request.KhuonMat.EyeSize;
        nhanVat.CauHinhKhuonMat.EyeDistance = request.KhuonMat.EyeDistance;
        nhanVat.CauHinhKhuonMat.EyeAngle = request.KhuonMat.EyeAngle;
        nhanVat.CauHinhKhuonMat.NoseHeight = request.KhuonMat.NoseHeight;
        nhanVat.CauHinhKhuonMat.NoseWidth = request.KhuonMat.NoseWidth;
        nhanVat.CauHinhKhuonMat.MouthWidth = request.KhuonMat.MouthWidth;
        nhanVat.CauHinhKhuonMat.LipThickness = request.KhuonMat.LipThickness;
        nhanVat.CauHinhKhuonMat.EarScale = request.KhuonMat.EarScale;
        nhanVat.CauHinhKhuonMat.ChinScale = request.KhuonMat.ChinScale;
        nhanVat.CauHinhKhuonMat.CheekScale = request.KhuonMat.CheekScale;
        nhanVat.CauHinhKhuonMat.EyebrowAngle = request.KhuonMat.EyebrowAngle;
        nhanVat.CauHinhKhuonMat.MauDa = request.KhuonMat.MauDa;
        nhanVat.CauHinhKhuonMat.MauMat = request.KhuonMat.MauMat;
        nhanVat.CauHinhKhuonMat.MauToc = request.KhuonMat.MauToc;

        await _unitOfWork.SaveChangesAsync();

        TempData["EditorMessage"] = "Đã lưu cấu hình nhân vật.";
        return RedirectToAction(nameof(Editor), new { id = nhanVat.Id });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> GanTaiNguyen(int id, YeuCauGanTaiNguyenNhanVat request)
    {
        var nhanVat = await LoadNhanVatAsync(id);
        if (nhanVat is null)
        {
            return NotFound();
        }

        var taiNguyen = await _unitOfWork.TaiNguyens.LayTaiNguyenDangHoatDongKemDiemAsync(request.TaiNguyen3DId);
        if (taiNguyen is null)
        {
            TempData["EditorMessage"] = "Tài nguyên không tồn tại hoặc đã bị khóa.";
            return RedirectToAction(nameof(Editor), new { id });
        }

        var nhanVatTaiNguyen = new TaiNguyenNhanVat
        {
            NhanVatId = nhanVat.Id,
            TaiNguyen3DId = taiNguyen.Id,
            DiemGan = request.DiemGan,
            TenDiemGanTuyChinh = request.TenDiemGanTuyChinh,
            MauSac = string.IsNullOrWhiteSpace(request.MauSac) ? taiNguyen.MauSacMacDinh : request.MauSac
        };

        await _unitOfWork.TaiNguyenNhanVats.AddAsync(nhanVatTaiNguyen);
        nhanVat.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();

        TempData["EditorMessage"] = "Đã gắn tài nguyên vào nhân vật.";
        return RedirectToAction(nameof(Editor), new { id = nhanVat.Id });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CapNhatPhuKien(YeuCauCapNhatPhuKienNhanVat request)
    {
        var nhanVatTaiNguyen = await _unitOfWork.TaiNguyenNhanVats.LayTaiNguyenNhanVatCuaNguoiDungAsync(
            request.TaiNguyenNhanVatId,
            CurrentUserId);

        if (nhanVatTaiNguyen is null || nhanVatTaiNguyen.NhanVatId != request.NhanVatId)
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

        TempData["EditorMessage"] = "Đã lưu thông số phụ kiện.";
        return RedirectToAction(nameof(Editor), new { id = request.NhanVatId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> GoTaiNguyen(int nhanVatId, int taiNguyenNhanVatId)
    {
        var nhanVatTaiNguyen = await _unitOfWork.TaiNguyenNhanVats.LayTaiNguyenNhanVatCuaNguoiDungAsync(
            taiNguyenNhanVatId,
            CurrentUserId);

        if (nhanVatTaiNguyen is null || nhanVatTaiNguyen.NhanVatId != nhanVatId)
        {
            return NotFound();
        }

        nhanVatTaiNguyen.NhanVat.UpdatedAt = DateTime.UtcNow;
        _unitOfWork.TaiNguyenNhanVats.Remove(nhanVatTaiNguyen);
        await _unitOfWork.SaveChangesAsync();

        TempData["EditorMessage"] = "Đã gỡ tài nguyên khỏi nhân vật.";
        return RedirectToAction(nameof(Editor), new { id = nhanVatId });
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
    [ValidateAntiForgeryToken]
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
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
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

    private static YeuCauSuaNhanVat TaoYeuCauSuaNhanVat(NhanVat nhanVat)
    {
        return new YeuCauSuaNhanVat
        {
            Id = nhanVat.Id,
            Name = nhanVat.Name,
            MoTa = nhanVat.MoTa,
            MauNhanVatId = nhanVat.MauNhanVatId,
            Kind = nhanVat.Kind,
            Style = nhanVat.Style,
            CoThe = nhanVat.CauHinhCoThe is null ? new YeuCauCauHinhCoThe() : new YeuCauCauHinhCoThe
            {
                OverallHeight = nhanVat.CauHinhCoThe.OverallHeight,
                DauScale = nhanVat.CauHinhCoThe.DauScale,
                CoScale = nhanVat.CauHinhCoThe.CoScale,
                ShoulderWidth = nhanVat.CauHinhCoThe.ShoulderWidth,
                NgucScale = nhanVat.CauHinhCoThe.NgucScale,
                EoScale = nhanVat.CauHinhCoThe.EoScale,
                HipScale = nhanVat.CauHinhCoThe.HipScale,
                ArmLength = nhanVat.CauHinhCoThe.ArmLength,
                ArmWidth = nhanVat.CauHinhCoThe.ArmWidth,
                HandScale = nhanVat.CauHinhCoThe.HandScale,
                LegLength = nhanVat.CauHinhCoThe.LegLength,
                LegWidth = nhanVat.CauHinhCoThe.LegWidth,
                FootScale = nhanVat.CauHinhCoThe.FootScale,
                CoTheMass = nhanVat.CauHinhCoThe.CoTheMass
            },
            KhuonMat = nhanVat.CauHinhKhuonMat is null ? new YeuCauCauHinhKhuonMat() : new YeuCauCauHinhKhuonMat
            {
                KhuonMatWidth = nhanVat.CauHinhKhuonMat.KhuonMatWidth,
                KhuonMatLength = nhanVat.CauHinhKhuonMat.KhuonMatLength,
                EyeSize = nhanVat.CauHinhKhuonMat.EyeSize,
                EyeDistance = nhanVat.CauHinhKhuonMat.EyeDistance,
                EyeAngle = nhanVat.CauHinhKhuonMat.EyeAngle,
                NoseHeight = nhanVat.CauHinhKhuonMat.NoseHeight,
                NoseWidth = nhanVat.CauHinhKhuonMat.NoseWidth,
                MouthWidth = nhanVat.CauHinhKhuonMat.MouthWidth,
                LipThickness = nhanVat.CauHinhKhuonMat.LipThickness,
                EarScale = nhanVat.CauHinhKhuonMat.EarScale,
                ChinScale = nhanVat.CauHinhKhuonMat.ChinScale,
                CheekScale = nhanVat.CauHinhKhuonMat.CheekScale,
                EyebrowAngle = nhanVat.CauHinhKhuonMat.EyebrowAngle,
                MauDa = nhanVat.CauHinhKhuonMat.MauDa,
                MauMat = nhanVat.CauHinhKhuonMat.MauMat,
                MauToc = nhanVat.CauHinhKhuonMat.MauToc
            }
        };
    }
}


