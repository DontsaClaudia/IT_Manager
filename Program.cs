using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


using GesParck.Data;
//using Fluent.Infrastructure.FluentModel;
var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//
// configuration du service pour la connexion à la base de données
builder.Services.AddDbContext<GesParckContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GesParckContext") ?? throw new InvalidOperationException("Connection string 'GesParckContext' not found.")));


// Ajout du service pour l'entité users et rule
/*builder.Services.AddDefaultIdentity<User>(options =>
                                       options.SignIn.RequireConfirmedAccount = true)*/
   // .AddEntityFrameworkStores<DbContext>();
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

app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();
