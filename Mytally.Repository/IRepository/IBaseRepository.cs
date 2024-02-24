using SqlSugar;
using System.Linq.Expressions;

namespace MyTally.Repository.IRepository;

public interface IBaseRepository<TEntity>
    where TEntity : class, new()
{
    #region 基础增删改查

    Task<bool> CreatAsync(TEntity entity);
    Task<bool> DeleteAsync(int id);
    Task<bool> EditAsync(TEntity entity);
    Task<TEntity> FindAsync(int id);
    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func);

    #endregion

    /// <summary>
    /// 查询全部的结果
    /// </summary>
    /// <returns></returns>
    Task<List<TEntity>> QueryAsync();

    /// <summary>
    /// 自定义查询
    /// </summary>
    /// <param name="func"></param>
    /// <returns></returns>
    Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func);

    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="total"></param>
    /// <returns></returns>
    Task<List<TEntity>> QueryAsync(int page, int pageSize, RefAsync<int> total);

    /// <summary>
    /// 自定义分页查询
    /// </summary>
    /// <param name="func"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"></param>
    /// <param name="total"></param>
    /// <returns></returns>
    Task<List<TEntity>> QueryAsync(
        Expression<Func<TEntity, bool>> func,
        int page,
        int pageSize,
        RefAsync<int> total
    );
}
