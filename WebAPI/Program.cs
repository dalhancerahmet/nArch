using Application;
using Core.CrossCuttingConcerns.Exceptions;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
//builder.Services.AddSecurityServices();
builder.Services.AddPersistenceServices(builder.Configuration);
//builder.Services.AddInfrastructureServices();
//builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger Kullanýmý için.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//detaylý hata yakalamak için bu iþlemi yaptýk.
if (app.Environment.IsProduction())
{
    app.ConfigureCustomExceptionMiddleware();
}
    

app.UseAuthorization();

app.MapControllers();

app.Run();
