#nullable enable

using DungMoHinh.Repositories;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DungMoHinh.Extensions;

public static class RepositoryServiceCollectionExtensions
{
    public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
    {
        services.AddScoped<IDonViCongViec, DonViCongViec>();
        services.AddScoped<IKhoNhanVat, KhoNhanVat>();
        services.AddScoped<IKhoMauNhanVat, KhoMauNhanVat>();
        services.AddScoped<IKhoTaiNguyen, KhoTaiNguyen>();
        services.AddScoped<IKhoTaiNguyenNhanVat, KhoTaiNguyenNhanVat>();
        services.AddScoped<IKhoTuyChinh, KhoTuyChinh>();
        services.AddScoped<IKhoAnhTaiLen, KhoAnhTaiLen>();
        services.AddScoped<IKhoPhanTichAnh, KhoPhanTichAnh>();
        services.AddScoped<IKhoXuatNhanVat, KhoXuatNhanVat>();
        services.AddScoped<IKhoGoiMau, KhoGoiMau>();
        services.AddScoped<IKhoHoSoNguoiDung, KhoHoSoNguoiDung>();
        services.AddScoped<IKhoQuanTri, KhoQuanTri>();

        return services;
    }
}


