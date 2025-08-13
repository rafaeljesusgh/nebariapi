using Microsoft.EntityFrameworkCore;
using NebariApi.Infrastructure;
using NebariApi.Models;

namespace NebariApi.Services;

public class TreeService : ITreeService
{
    private readonly AppDbContext _db;

    public TreeService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Tree>> GetAllAsync() =>
        await _db.Tress.ToListAsync();

    public async Task<Tree?> GetByIdAsync(int id) =>
        await _db.Tress.FindAsync(id);

    public async Task<Tree> CreateAsync(Tree tree)
    {
        _db.Tress.Add(tree);
        await _db.SaveChangesAsync();
        return tree;
    }

    public async Task<bool> UpdateAsync(int id, Tree tree)
    {
        var existing = await _db.Tress.FindAsync(id);
        if (existing is null) return false;

        existing.Name = tree.Name;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var tree = await _db.Tress.FindAsync(id);
        if (tree is null) return false;

        _db.Tress.Remove(tree);
        await _db.SaveChangesAsync();
        return true;
    }
}