using BET.Persistance;
using BET.Application;
using BET.WebAPI.Middleware;
using Serilog;
using OSI.OTT.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration) 
    .CreateLogger();

builder.Logging.AddSerilog(logger);

IdentityExtension.AddSwaggerGenConfiguration(builder.Services);
IdentityExtension.AddIdentityConfiguration(builder.Services, configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistanceService(builder.Configuration);
builder.Services.AddApplicationService();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
