#nullable enable

namespace DungMoHinh.Models;

public class GiaTriPhanPhuKienNhanVat : ThucTheCoSo
{
    public int TaiNguyenNhanVatId { get; set; }

    public TaiNguyenNhanVat TaiNguyenNhanVat { get; set; } = null!;

    public int DiemChinhPhuKienId { get; set; }

    public DiemChinhPhuKien DiemChinhPhuKien { get; set; } = null!;

    public decimal GiaTri { get; set; } = 1.00m;
}

