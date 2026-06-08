#nullable enable

using DungMoHinh.Data;
using DungMoHinh.Models;
using DungMoHinh.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DungMoHinh.Repositories;

public abstract class KhoDuLieuCoSo<T> : IKhoDuLieu<T> where T : ThucTheCoSo
{
    protected KhoDuLieuCoSo(ApplicationDbContext context)
    {
        Context = context;
        Set = context.Set<T>();
    }

    protected ApplicationDbContext Context { get; }

    protected DbSet<T> Set { get; }

    public virtual IQueryable<T> Query()
    {
        return Set.AsQueryable();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await Set.FindAsync(id);
    }

    public virtual async Task AddAsync(T entity)
    {
        await Set.AddAsync(entity);
    }

    public virtual void Remove(T entity)
    {
        Set.Remove(entity);
    }
}

