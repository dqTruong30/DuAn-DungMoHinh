#nullable enable

using System.ComponentModel.DataAnnotations;

namespace DungMoHinh.Models;

public class ThamSoTuyChinh : ThucTheCoSo
{
    [Required]
    [MaxLength(120)]
    public string Key { get; set; } = string.Empty;

    [Required]
    [MaxLength(120)]
    public string TenHienThi { get; set; } = string.Empty;

    public KhuVucTuyChinh Area { get; set; }

    [MaxLength(120)]
    public string? TargetMeshNodeName { get; set; }

    public decimal GiaTriNhoNhat { get; set; } = 0.00m;

    public decimal GiaTriLonNhat { get; set; } = 2.00m;

    public decimal GiaTriMacDinh { get; set; } = 1.00m;

    public bool IsActive { get; set; } = true;

    public ICollection<GiaTriTuyChinhNhanVat> NhanVatGiaTris { get; set; } = new HashSet<GiaTriTuyChinhNhanVat>();
}


