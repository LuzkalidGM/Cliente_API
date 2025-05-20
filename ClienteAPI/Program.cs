using ClienteAPI.Data;
using Microsoft.EntityFrameworkCore;
using Prometheus;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Conexión a base de datos
builder.Services.AddDbContext<BdClientesContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ClienteDB")));

// Swagger y API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HealthChecks y Prometheus
builder.Services.AddHealthChecks()
    .AddSqlServer(
        builder.Configuration.GetConnectionString("ClienteDB"),
        name: "sql",
        healthQuery: "SELECT 1"
    )
    .AddDbContextCheck<BdClientesContext>("database")
    .ForwardToPrometheus();

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Prometheus
app.UseMetricServer();  // Exponer métricas en /metrics
app.UseHttpMetrics();   // Métricas HTTP

app.UseAuthorization();

// Endpoints
app.MapControllers();
app.MapHealthChecks("/health");  // Endpoint de estado

app.Run();
