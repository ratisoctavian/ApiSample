using ApiSample.Access;
using ApiSample.Api.ErrorHandling.Extensions;
using ApiSample.BL.Handlers.Users;
using ApiSample.BL.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using System.Reflection;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
//builder.Logging.AddConsole();
builder.Host.UseNLog();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("1.0", new OpenApiInfo
    {
        Version = "1.0",
        Title = "User"
    });
    c.SwaggerDoc("2.0", new OpenApiInfo
    {
        Version = "2.0",
        Title = "User"
    });
    c.ResolveConflictingActions(aD => aD.First());
});

builder.Services.AddSingleton<IDataAccess, MockDataAccess>();
builder.Services.AddMediatR(typeof(GetUserListHandler).GetTypeInfo().Assembly);
builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
});
builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });


var app = builder.Build();
var logger = app.Logger;
app.ConfigureExceptionHandler(logger);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/1.0/swagger.json", "v1");
        c.SwaggerEndpoint($"/swagger/2.0/swagger.json", "v2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
