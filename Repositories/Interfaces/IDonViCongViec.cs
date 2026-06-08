#nullable enable

namespace DungMoHinh.Repositories.Interfaces;

public interface IDonViCongViec
{
    IKhoNhanVat NhanVats { get; }

    IKhoMauNhanVat MauNhanVats { get; }

    IKhoTaiNguyen TaiNguyens { get; }

    IKhoTaiNguyenNhanVat TaiNguyenNhanVats { get; }

    IKhoTuyChinh TuyChinhs { get; }

    IKhoAnhTaiLen AnhTaiLens { get; }

    IKhoPhanTichAnh ImageAnalyses { get; }

    IKhoXuatNhanVat Xuats { get; }

    IKhoGoiMau GoiMaus { get; }

    IKhoHoSoNguoiDung HoSoNguoiDungs { get; }

    IKhoQuanTri QuanTri { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}


