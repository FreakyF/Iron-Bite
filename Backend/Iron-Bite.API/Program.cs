using Iron_Bite.API.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IAppDbContext, AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IronBiteDb"));
});

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();