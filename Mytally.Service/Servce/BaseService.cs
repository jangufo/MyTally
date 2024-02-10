using Mytally.Repository.IRepository;
using Mytally.Service.IService;
using SqlSugar;
using System.Linq.Expressions;

namespace Mytally.Service.Servce;

public class BaseService<TEntity> : IBaseService<TEntity>
    where TEntity : class, new()
{
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
    /// <summary>
    /// 从子类的构造函数中传入
    /// </summary>
    protected IBaseRepository<TEntity> _repository;
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
    public async Task<bool> CreatAsync(TEntity entity)
    {
        return await _repository.CreatAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<bool> EditAsync(TEntity entity)
    {
        return await _repository.EditAsync(entity);
    }

    public async Task<TEntity> FindAsync(int id)
    {
        return await _repository.FindAsync(id);
    }

    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func)
    {
        return await _repository.FindAsync(func);
    }

    public virtual async Task<List<TEntity>> QueryAsync()
    {
        return await _repository.QueryAsync();
    }

    public virtual async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
    {
        return await _repository.QueryAsync(func);
    }

    public virtual async Task<List<TEntity>> QueryAsync(int page, int pageSize, RefAsync<int> total)
    {
        return await _repository.QueryAsync(page, pageSize, total);
    }

    public virtual async Task<List<TEntity>> QueryAsync(
        Expression<Func<TEntity, bool>> func,
        int page,
        int pageSize,
        RefAsync<int> total
    )
    {
        return await _repository.QueryAsync(func, page, pageSize, total);
    }
}
