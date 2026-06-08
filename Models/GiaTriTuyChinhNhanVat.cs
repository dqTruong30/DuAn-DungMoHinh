#nullable enable

namespace DungMoHinh.Models;

public class GiaTriTuyChinhNhanVat : ThucTheCoSo
{
    public int NhanVatId { get; set; }

    public NhanVat NhanVat { get; set; } = null!;

    public int ThamSoTuyChinhId { get; set; }

    public ThamSoTuyChinh ThamSoTuyChinh { get; set; } = null!;

    public decimal GiaTri { get; set; }
}


