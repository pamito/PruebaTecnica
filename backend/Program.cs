using backend.AccesoDatos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PruebaTecnica01Context>(options =>
    //options.UseSqlServer(builder.Configuration["AppConfigs:connectionString"])
    options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:PruebaTecnica01"))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
);

var app = builder.Build();

// Configure the HTTP request pipeline.

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
