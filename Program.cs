using FileProcessingSystem.Data.Context;
using FileProcessingSystem.Data.Interface;
using FileProcessingSystem.Data.Repository;
using FileProcessingSystem.Service.Interface;
using FileProcessingSystem.Service.Services;
using Microsoft.EntityFrameworkCore;
using static FileProcessingSystem.Data.Interface.IFileRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IFileUploadProcessingServices, FileUploadProcessingServices>();
builder.Services.AddScoped<IUserLoginServices, UserLoginServices>();


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

app.Run();
