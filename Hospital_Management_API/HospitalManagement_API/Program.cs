using HospitalManagement_API.DataContext;
using HospitalManagement_API.Interface;
using HospitalManagement_API.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Connection
builder.Services.AddDbContext<HospitalDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalDatabase")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//----------------------Dependency-------------------

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IAllergiesRepository, AllergiesDetailsRepository>();
builder.Services.AddScoped<INCDDetialsRepository, NCDDetailsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
