#nullable enable

using System.ComponentModel.DataAnnotations;

namespace DungMoHinh.Models;

public class DiemChinhPhuKien : ThucTheCoSo
{
    public int TaiNguyen3DId { get; set; }

    public TaiNguyen3D TaiNguyen3D { get; set; } = null!;

    [Required]
    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(120)]
    public string? MeshNodeName { get; set; }

    public decimal GiaTriNhoNhat { get; set; } = 0.50m;

    public decimal GiaTriLonNhat { get; set; } = 2.00m;

    public decimal GiaTriMacDinh { get; set; } = 1.00m;

    [MaxLength(1000)]
    public string? MoTa { get; set; }

    public ICollection<GiaTriPhanPhuKienNhanVat> GiaTriPhanPhuKienNhanVats { get; set; } = new HashSet<GiaTriPhanPhuKienNhanVat>();
}

