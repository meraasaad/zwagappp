using ZwagAPP.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<DataContext>(x=>x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
        //بنادي علي الكونستركتور فطلب الاوبشنز

        builder.Services.AddControllers();
        builder.Services.AddCors();


        // Learn more   about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //app is a middlware
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());//اي موقع يقدر يدخل

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}