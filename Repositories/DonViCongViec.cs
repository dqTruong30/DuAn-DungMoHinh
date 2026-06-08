#nullable enable

using DungMoHinh.Data;
using DungMoHinh.Repositories.Interfaces;

namespace DungMoHinh.Repositories;

public class DonViCongViec : IDonViCongViec
{
    private readonly ApplicationDbContext _context;

    public DonViCongViec(ApplicationDbContext context)
    {
        _context = context;
        NhanVats = new KhoNhanVat(context);
        MauNhanVats = new KhoMauNhanVat(context);
        TaiNguyens = new KhoTaiNguyen(context);
        TaiNguyenNhanVats = new KhoTaiNguyenNhanVat(context);
        TuyChinhs = new KhoTuyChinh(context);
        AnhTaiLens = new KhoAnhTaiLen(context);
        ImageAnalyses = new KhoPhanTichAnh(context);
        Xuats = new KhoXuatNhanVat(context);
        GoiMaus = new KhoGoiMau(context);
        HoSoNguoiDungs = new KhoHoSoNguoiDung(context);
        QuanTri = new KhoQuanTri(context);
    }

    public IKhoNhanVat NhanVats { get; }

    public IKhoMauNhanVat MauNhanVats { get; }

    public IKhoTaiNguyen TaiNguyens { get; }

    public IKhoTaiNguyenNhanVat TaiNguyenNhanVats { get; }

    public IKhoTuyChinh TuyChinhs { get; }

    public IKhoAnhTaiLen AnhTaiLens { get; }

    public IKhoPhanTichAnh ImageAnalyses { get; }

    public IKhoXuatNhanVat Xuats { get; }

    public IKhoGoiMau GoiMaus { get; }

    public IKhoHoSoNguoiDung HoSoNguoiDungs { get; }

    public IKhoQuanTri QuanTri { get; }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}


