#nullable enable

using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DungMoHinh.Controllers;

public class PhanTichAnhsController : ControllerCoSo
{
    private readonly IDonViCongViec _unitOfWork;

    public PhanTichAnhsController(IDonViCongViec unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> Analyze(int anhTaiLenId)
    {
        var anhTaiLen = await _unitOfWork.AnhTaiLens.LayAnhTaiLenKemPhanTichAsync(anhTaiLenId, CurrentUserId);

        if (anhTaiLen is null)
        {
            return NotFound();
        }

        anhTaiLen.AnalysisResult ??= new KetQuaPhanTichAnh
        {
            AnhTaiLenId = anhTaiLen.Id
        };

        anhTaiLen.Status = TrangThaiXuLy.HoanTat;
        anhTaiLen.AnalysisResult.Status = TrangThaiXuLy.HoanTat;
        anhTaiLen.AnalysisResult.SuggestedKind = LoaiNhanVat.TrungTinh;
        anhTaiLen.AnalysisResult.SuggestedStyle = PhongCachNhanVat.BinhThuong;
        anhTaiLen.AnalysisResult.SuggestedMauDa = "#f2c6a0";
        anhTaiLen.AnalysisResult.SuggestedMauToc = "#2d211b";
        anhTaiLen.AnalysisResult.SuggestedMauMat = "#4b2e1f";
        anhTaiLen.AnalysisResult.KhuonMatWidthScore = 1.00m;
        anhTaiLen.AnalysisResult.KhuonMatLengthScore = 1.00m;
        anhTaiLen.AnalysisResult.CoTheHeightScore = 1.00m;
        anhTaiLen.AnalysisResult.CoTheMassScore = 1.00m;
        anhTaiLen.AnalysisResult.Confidence = 0.50m;
        anhTaiLen.AnalysisResult.KetQuaThoJson = "{}";
        anhTaiLen.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync();

        return Ok(new
        {
            success = true,
            anhTaiLen.AnalysisResult.SuggestedKind,
            anhTaiLen.AnalysisResult.SuggestedStyle,
            anhTaiLen.AnalysisResult.Confidence
        });
    }

    [HttpPost]
    public async Task<IActionResult> ApplyToNhanVat(int anhTaiLenId, int nhanVatId)
    {
        var anhTaiLen = await _unitOfWork.AnhTaiLens.LayAnhTaiLenKemPhanTichAsync(anhTaiLenId, CurrentUserId);
        var nhanVat = await _unitOfWork.NhanVats.LayNhanVatChoTrinhSuaAsync(nhanVatId, CurrentUserId);

        if (anhTaiLen?.AnalysisResult is null || nhanVat is null)
        {
            return NotFound();
        }

        var result = anhTaiLen.AnalysisResult;
        nhanVat.Kind = result.SuggestedKind ?? nhanVat.Kind;
        nhanVat.Style = result.SuggestedStyle ?? nhanVat.Style;
        nhanVat.CauHinhCoThe ??= new CauHinhCoTheNhanVat { NhanVatId = nhanVat.Id };
        nhanVat.CauHinhKhuonMat ??= new CauHinhKhuonMatNhanVat { NhanVatId = nhanVat.Id };

        nhanVat.CauHinhCoThe.OverallHeight = result.CoTheHeightScore ?? nhanVat.CauHinhCoThe.OverallHeight;
        nhanVat.CauHinhCoThe.CoTheMass = result.CoTheMassScore ?? nhanVat.CauHinhCoThe.CoTheMass;
        nhanVat.CauHinhKhuonMat.KhuonMatWidth = result.KhuonMatWidthScore ?? nhanVat.CauHinhKhuonMat.KhuonMatWidth;
        nhanVat.CauHinhKhuonMat.KhuonMatLength = result.KhuonMatLengthScore ?? nhanVat.CauHinhKhuonMat.KhuonMatLength;
        nhanVat.CauHinhKhuonMat.MauDa = result.SuggestedMauDa ?? nhanVat.CauHinhKhuonMat.MauDa;
        nhanVat.CauHinhKhuonMat.MauToc = result.SuggestedMauToc ?? nhanVat.CauHinhKhuonMat.MauToc;
        nhanVat.CauHinhKhuonMat.MauMat = result.SuggestedMauMat ?? nhanVat.CauHinhKhuonMat.MauMat;
        nhanVat.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync();

        return Ok(new { success = true, nhanVat.Id });
    }
}


