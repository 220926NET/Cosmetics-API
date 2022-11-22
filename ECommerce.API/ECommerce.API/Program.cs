using Data;
using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.DataProtection.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
});


builder.Services.AddDbContext<Data.Entities.CosmeticsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CosmeticsDB")));
//added this line in to counter "Cannot instantiate implementation type" error
//builder.Services.AddScoped<IRepository, SQLRepository>();
//builder.Services.AddSingleton<IRepository>();
//builder.Services.AddSingleton<SQLRepository>();

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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
