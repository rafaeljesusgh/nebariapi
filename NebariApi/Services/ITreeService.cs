using NebariApi.Models;

public interface ITreeService
{
    Task<IEnumerable<Tree>> GetAllAsync();
    Task<Tree?> GetByIdAsync(int id);
    Task<Tree> CreateAsync(Tree tree);
    Task<bool> UpdateAsync(int id, Tree tree);
    Task<bool> DeleteAsync(int id);
}