using bank;
using Solid.Core;
using Solid.Core.Repositories;
using Solid.Core.Services;
using Solid.Data;
using Solid.Data.Repositories;
using Solid.Service;
using System.Text.Json.Serialization;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProFile));
builder.Services.AddDbContext<DataContext>();
//builder.Services.AddSingleton<DataContext>();
builder.Services.AddScoped<ICustomerRepositories, CustomersRepository>();
builder.Services.AddScoped<IOfficialsRepositories, OfficialsRepository>();
builder.Services.AddScoped<ITurnsRepositories, TurnsRepository>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOfficialsServices, OfficialService>();
builder.Services.AddScoped<ITurnsServices, TurnService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
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
