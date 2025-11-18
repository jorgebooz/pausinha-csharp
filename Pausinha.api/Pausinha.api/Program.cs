using Microsoft.EntityFrameworkCore;
using Pausinha.Application.Interfaces;
using Pausinha.Application.Services;
using Pausinha.Infrastructure.Persistence;
using Pausinha.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<PausinhaDbContext>(options =>
    options.UseSqlite("Data Source=pausinha.db",
        b => b.MigrationsAssembly("Pausinha.api")));  // ← ADICIONE ESTA LINHA

// Seus serviços...
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IBreakSessionRepository, BreakSessionRepository>();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IBreakSessionService, BreakSessionService>();

builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ✅ SWAGGER SIMPLIFICADO - SEM ERROS
builder.Services.AddSwaggerGen();

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