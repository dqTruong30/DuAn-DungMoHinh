#nullable enable

using System.ComponentModel.DataAnnotations;

namespace DungMoHinh.Models;

public class KetQuaPhanTichAnh : ThucTheCoSo
{
    public int AnhTaiLenId { get; set; }

    public AnhTaiLen AnhTaiLen { get; set; } = null!;

    public TrangThaiXuLy Status { get; set; } = TrangThaiXuLy.ChoXuLy;

    public LoaiNhanVat? SuggestedKind { get; set; }

    public PhongCachNhanVat? SuggestedStyle { get; set; }

    [MaxLength(32)]
    public string? SuggestedMauDa { get; set; }

    [MaxLength(32)]
    public string? SuggestedMauToc { get; set; }

    [MaxLength(32)]
    public string? SuggestedMauMat { get; set; }

    [MaxLength(120)]
    public string? SuggestedTocStyleKey { get; set; }

    [MaxLength(120)]
    public string? SuggestedTrangPhucStyleKey { get; set; }

    public decimal? KhuonMatWidthScore { get; set; }

    public decimal? KhuonMatLengthScore { get; set; }

    public decimal? CoTheHeightScore { get; set; }

    public decimal? CoTheMassScore { get; set; }

    public decimal Confidence { get; set; }

    [MaxLength(4000)]
    public string? KetQuaThoJson { get; set; }

    [MaxLength(1000)]
    public string? ThongBaoLoi { get; set; }
}

