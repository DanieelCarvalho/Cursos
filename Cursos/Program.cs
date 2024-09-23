
using Cursos.Context;
using Cursos.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cursos;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


        builder.Services.AddControllers();


        var deafultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<CursosDbContext>(opitions =>
        {
            opitions.UseSqlite(deafultConnectionString);
        });

        builder.Services.AddScoped(typeof(IRepository<>), typeof(AlunoRepository));

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
