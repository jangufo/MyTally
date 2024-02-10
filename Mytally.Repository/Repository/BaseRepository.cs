using Mytally.Models;
using Mytally.Repository.IRepository;
using SqlSugar;
using SqlSugar.IOC;
using System.Linq.Expressions;

namespace Mytally.Repository.Repository;

public class BaseRepository<TEntity> : SimpleClient<TEntity>, IBaseRepository<TEntity>
    where TEntity : class, new()
{
    public BaseRepository(ISqlSugarClient context = null)
        : base(context)
    {
        base.Context = DbScoped.Sugar;
        // 创建表 不需要多次创建，只用第一次跑通之后就不用创建了
        //base.Context.DbMaintenance.CreateDatabase();
        //base.Context.CodeFirst.InitTables(
        //    typeof(AccountBookDef),
        //    typeof(Bill),
        //    typeof(ImageList),
        //    typeof(TagList),
        //    typeof(TagDef),
        //    typeof(TypeInfoDef)
        //);
    }

    public async Task<bool> CreatAsync(TEntity entity)
    {
        return await base.InsertAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await base.DeleteByIdAsync(id);
    }

    public async Task<bool> EditAsync(TEntity entity)
    {
        return await base.UpdateAsync(entity);
    }

    public async Task<TEntity> FindAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }

    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func)
    {
        return await base.GetSingleAsync(func);
    }

    public virtual async Task<List<TEntity>> QueryAsync()
    {
        return await base.GetListAsync();
    }

    public virtual async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
    {
        return await base.GetListAsync(func);
    }

    public virtual async Task<List<TEntity>> QueryAsync(int page, int pageSize, RefAsync<int> total)
    {
        return await base.Context.Queryable<TEntity>().ToPageListAsync(page, pageSize, total);
    }

    public virtual async Task<List<TEntity>> QueryAsync(
        Expression<Func<TEntity, bool>> func,
        int page,
        int pageSize,
        RefAsync<int> total
    )
    {
        return await base.Context
            .Queryable<TEntity>()
            .Where(func)
            .ToPageListAsync(page, pageSize, total);
    }
}
