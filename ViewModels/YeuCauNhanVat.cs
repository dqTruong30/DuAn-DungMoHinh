#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.ViewModels;

public class YeuCauTaoNhanVat
{
    public string Name { get; set; } = string.Empty;

    public string? MoTa { get; set; }

    public int? MauNhanVatId { get; set; }

    public LoaiNhanVat Kind { get; set; } = LoaiNhanVat.TrungTinh;

    public PhongCachNhanVat Style { get; set; } = PhongCachNhanVat.BinhThuong;
}

public class YeuCauSuaNhanVat
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? MoTa { get; set; }

    public int? MauNhanVatId { get; set; }

    public LoaiNhanVat Kind { get; set; } = LoaiNhanVat.TrungTinh;

    public PhongCachNhanVat Style { get; set; } = PhongCachNhanVat.BinhThuong;

    public YeuCauCauHinhCoThe CoThe { get; set; } = new();

    public YeuCauCauHinhKhuonMat KhuonMat { get; set; } = new();
}

public class YeuCauCauHinhCoThe
{
    public decimal OverallHeight { get; set; } = 1.00m;
    public decimal DauScale { get; set; } = 1.00m;
    public decimal CoScale { get; set; } = 1.00m;
    public decimal ShoulderWidth { get; set; } = 1.00m;
    public decimal NgucScale { get; set; } = 1.00m;
    public decimal EoScale { get; set; } = 1.00m;
    public decimal HipScale { get; set; } = 1.00m;
    public decimal ArmLength { get; set; } = 1.00m;
    public decimal ArmWidth { get; set; } = 1.00m;
    public decimal HandScale { get; set; } = 1.00m;
    public decimal LegLength { get; set; } = 1.00m;
    public decimal LegWidth { get; set; } = 1.00m;
    public decimal FootScale { get; set; } = 1.00m;
    public decimal CoTheMass { get; set; } = 1.00m;
}

public class YeuCauCauHinhKhuonMat
{
    public decimal KhuonMatWidth { get; set; } = 1.00m;
    public decimal KhuonMatLength { get; set; } = 1.00m;
    public decimal EyeSize { get; set; } = 1.00m;
    public decimal EyeDistance { get; set; } = 1.00m;
    public decimal EyeAngle { get; set; }
    public decimal NoseHeight { get; set; } = 1.00m;
    public decimal NoseWidth { get; set; } = 1.00m;
    public decimal MouthWidth { get; set; } = 1.00m;
    public decimal LipThickness { get; set; } = 1.00m;
    public decimal EarScale { get; set; } = 1.00m;
    public decimal ChinScale { get; set; } = 1.00m;
    public decimal CheekScale { get; set; } = 1.00m;
    public decimal EyebrowAngle { get; set; }
    public string MauDa { get; set; } = "#f2c6a0";
    public string MauMat { get; set; } = "#4b2e1f";
    public string MauToc { get; set; } = "#2d211b";
}

public class YeuCauGiaTriTuyChinh
{
    public int ThamSoTuyChinhId { get; set; }

    public decimal GiaTri { get; set; }
}

