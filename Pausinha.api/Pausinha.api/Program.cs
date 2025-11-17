using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Pausinha.Application.Interfaces;
using Pausinha.Application.Services;
using Pausinha.Infrastructure.Persistence;
using Pausinha.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// DbContext
var connectionString = builder.Configuration.GetConnectionString("PausinhaConnection");
builder.Services.AddDbContext<PausinhaDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IBreakSessionRepository, BreakSessionRepository>();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IBreakSessionService, BreakSessionService>();

builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pausinha API",
        Version = "v1",
        Description = "API do projeto Pausinha - Futuro do Trabalho"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
