using Mytally.Repository.IRepository;
using Mytally.Repository.Repository;
using Mytally.Service.IService;
using Mytally.Service.Servce;
using SqlSugar;
using SqlSugar.IOC;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace MyTally.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        #region SqlSugar IOC

        SugarIocServices.AddSqlSugar(
            new IocConfig()
            {
                ConnectionString = "Server=localhost;Database=MyTallyDB;Integrated Security=True;",
                DbType = IocDbType.SqlServer,
                IsAutoCloseConnection = true // 自动释放
            }
        );

        #endregion

        #region 自身服务的IOC

        builder.Services.AddCustomIOC();

        #endregion


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

public static class IOCExtend
{
    public static IServiceCollection AddCustomIOC(this IServiceCollection service)
    {
        // 仓储层依赖注入
        service.AddScoped<IAccountBookDefRespository, AccountBookDefRespository>();
        service.AddScoped<IBillRespository, BillRespository>();
        service.AddScoped<ITagDefRespository, TagDefRepository>();
        service.AddScoped<ITagListRespository, TagListRepository>();
        service.AddScoped<ITypeInfoDefRespository, TypeInfoDefRepository>();

        // 服务层依赖注入
        service.AddScoped<IAccountBookDefService, AccountBookDefService>();
        service.AddScoped<IBillService, BillService>();
        service.AddScoped<ITagDefService, TagDefService>();
        service.AddScoped<ITagListService, TagListService>();
        service.AddScoped<ITypeInfoDefService, TypeInfoDefService>();

        return service;
    }
}
