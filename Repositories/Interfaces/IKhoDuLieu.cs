#nullable enable

using DungMoHinh.Models;

namespace DungMoHinh.Repositories.Interfaces;

public interface IKhoDuLieu<T> where T : ThucTheCoSo
{
    IQueryable<T> Query();

    Task<T?> GetByIdAsync(int id);

    Task AddAsync(T entity);

    void Remove(T entity);
}

