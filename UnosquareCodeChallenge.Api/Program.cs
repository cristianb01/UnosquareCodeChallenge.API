using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using UnosquareCodeChallege.Persistence;
using UnosquareCodeChallege.Persistence.Repositories;
using UnosquareCodeChallenge.Application.Features;
using UnosquareCodeChallenge.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var myAllowSpecificOrigins = "MyAllowedHosts";

builder.Services.AddCors(options =>
{
    options.AddPolicy(myAllowSpecificOrigins, policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("UnosquareDatabase"));
    options.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning)); // Had to add this warning supresion since EF Core 9 has a bug
});

builder.Services.AddTransient<IUnosquareTaskRespository, UnosquareTaskRepository>();
builder.Services.AddScoped<IUnosquareTaskService, UnosquareTaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(myAllowSpecificOrigins);

app.MapControllers();

app.Run();
