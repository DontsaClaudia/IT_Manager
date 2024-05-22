using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using GesPark.Services;


using GesPark.Data;
//using Fluent.Infrastructure.FluentModel;
var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//Add service controllers
builder.services.AddControllers();

// Service configuration database connexion
builder.Services.AddDbContext<GesParckContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GesParckContext") ?? throw new InvalidOperationException("Connection string 'GesParckContext' not found.")));

// Add Models services
builder.Services.AddScoped<ServiceComputers>();
builder.services.AddScoped<ServiceNetwork>();

// communication with appblazor
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("https://localhost:7050"
                                              );
                      });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();
