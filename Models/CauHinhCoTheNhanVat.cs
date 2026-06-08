#nullable enable

namespace DungMoHinh.Models;

public class CauHinhCoTheNhanVat : ThucTheCoSo
{
    public int NhanVatId { get; set; }

    public NhanVat NhanVat { get; set; } = null!;

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


