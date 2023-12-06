using APIWedfy.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var WedfyOrigins = "_WedfyOrigins";

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: WedfyOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000").AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WedfyContext>(
    options =>
    {
        options.UseMySql(builder.Configuration.GetConnectionString("WedfyDB"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(WedfyOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
