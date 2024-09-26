using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Repositories;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddDbContext<TripsContext>(options => options.UseSqlServer("Data Source=MAC\\SQLEXPRESS01;Initial Catalog=Trip;Integrated Security=True;Trust Server Certificate=True;"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();