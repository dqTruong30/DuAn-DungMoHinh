#nullable enable

using DungMoHinh.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DungMoHinh.Data;

public class ApplicationDbContext : IdentityDbContext<NguoiDungUngDung>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<HoSoNguoiDung> HoSoNguoiDungs => Set<HoSoNguoiDung>();

    public DbSet<NhanVat> NhanVats => Set<NhanVat>();

    public DbSet<MauNhanVat> MauNhanVats => Set<MauNhanVat>();

    public DbSet<CauHinhCoTheNhanVat> CauHinhCoTheNhanVat => Set<CauHinhCoTheNhanVat>();

    public DbSet<CauHinhKhuonMatNhanVat> CauHinhKhuonMatNhanVat => Set<CauHinhKhuonMatNhanVat>();

    public DbSet<TaiNguyen3D> TaiNguyens3D => Set<TaiNguyen3D>();

    public DbSet<TaiNguyenNhanVat> TaiNguyenNhanVats => Set<TaiNguyenNhanVat>();

    public DbSet<DiemChinhPhuKien> DiemChinhPhuKiens => Set<DiemChinhPhuKien>();

    public DbSet<GiaTriPhanPhuKienNhanVat> GiaTriPhanPhuKienNhanVats => Set<GiaTriPhanPhuKienNhanVat>();

    public DbSet<ThamSoTuyChinh> ThamSoTuyChinhs => Set<ThamSoTuyChinh>();

    public DbSet<GiaTriTuyChinhNhanVat> GiaTriTuyChinhNhanVats => Set<GiaTriTuyChinhNhanVat>();

    public DbSet<AnhTaiLen> AnhTaiLens => Set<AnhTaiLen>();

    public DbSet<KetQuaPhanTichAnh> KetQuaPhanTichAnhs => Set<KetQuaPhanTichAnh>();

    public DbSet<XuatNhanVat> XuatNhanVats => Set<XuatNhanVat>();

    public DbSet<GoiMauThietLap> GoiMauThietLaps => Set<GoiMauThietLap>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(entityType => entityType.GetProperties())
            .Where(property => property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?)))
        {
            property.SetPrecision(18);
            property.SetScale(4);
        }

        modelBuilder.Entity<HoSoNguoiDung>()
            .HasIndex(user => user.UserId)
            .IsUnique();

        modelBuilder.Entity<NhanVat>()
            .HasOne(nhanVat => nhanVat.CauHinhCoThe)
            .WithOne(settings => settings.NhanVat)
            .HasForeignKey<CauHinhCoTheNhanVat>(settings => settings.NhanVatId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<NhanVat>()
            .HasOne(nhanVat => nhanVat.CauHinhKhuonMat)
            .WithOne(settings => settings.NhanVat)
            .HasForeignKey<CauHinhKhuonMatNhanVat>(settings => settings.NhanVatId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<NhanVat>()
            .HasMany(nhanVat => nhanVat.AnhThamChieus)
            .WithOne(image => image.NhanVat)
            .HasForeignKey(image => image.NhanVatId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<AnhTaiLen>()
            .HasOne(image => image.AnalysisResult)
            .WithOne(result => result.AnhTaiLen)
            .HasForeignKey<KetQuaPhanTichAnh>(result => result.AnhTaiLenId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ThamSoTuyChinh>()
            .HasIndex(parameter => parameter.Key)
            .IsUnique();

        modelBuilder.Entity<GiaTriTuyChinhNhanVat>()
            .HasIndex(value => new { value.NhanVatId, value.ThamSoTuyChinhId })
            .IsUnique();

        modelBuilder.Entity<GiaTriPhanPhuKienNhanVat>()
            .HasIndex(value => new { value.TaiNguyenNhanVatId, value.DiemChinhPhuKienId })
            .IsUnique();

        modelBuilder.Entity<GiaTriPhanPhuKienNhanVat>()
            .HasOne(value => value.DiemChinhPhuKien)
            .WithMany(point => point.GiaTriPhanPhuKienNhanVats)
            .HasForeignKey(value => value.DiemChinhPhuKienId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}


