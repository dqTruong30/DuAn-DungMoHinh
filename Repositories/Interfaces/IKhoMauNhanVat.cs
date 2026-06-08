#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.Repositories.Interfaces;

public interface IKhoMauNhanVat : IKhoDuLieu<MauNhanVat>
{
    Task<List<MauNhanVat>> LayMauDangHoatDongAsync();

    Task<MauNhanVat?> LayMauDangHoatDongAsync(int id);
}


