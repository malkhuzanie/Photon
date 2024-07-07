namespace Photon.Interfaces;

public interface IEntityService<T, in TB>
{
  public Task<T?> GetById(int id);

  public Task<IEnumerable<T>> GetAll();

  public Task<T> Create(TB arg);

  public Task Update(int id, TB arg);

  public Task<bool> Delete(int id);
}