#nullable enable

namespace DungMoHinh.Models;

public class CauHinhKhuonMatNhanVat : ThucTheCoSo
{
    public int NhanVatId { get; set; }

    public NhanVat NhanVat { get; set; } = null!;

    public decimal KhuonMatWidth { get; set; } = 1.00m;

    public decimal KhuonMatLength { get; set; } = 1.00m;

    public decimal EyeSize { get; set; } = 1.00m;

    public decimal EyeDistance { get; set; } = 1.00m;

    public decimal EyeAngle { get; set; } = 0.00m;

    public decimal NoseHeight { get; set; } = 1.00m;

    public decimal NoseWidth { get; set; } = 1.00m;

    public decimal MouthWidth { get; set; } = 1.00m;

    public decimal LipThickness { get; set; } = 1.00m;

    public decimal EarScale { get; set; } = 1.00m;

    public decimal ChinScale { get; set; } = 1.00m;

    public decimal CheekScale { get; set; } = 1.00m;

    public decimal EyebrowAngle { get; set; } = 0.00m;

    [System.ComponentModel.DataAnnotations.MaxLength(32)]
    public string MauDa { get; set; } = "#f2c6a0";

    [System.ComponentModel.DataAnnotations.MaxLength(32)]
    public string MauMat { get; set; } = "#4b2e1f";

    [System.ComponentModel.DataAnnotations.MaxLength(32)]
    public string MauToc { get; set; } = "#2d211b";
}


