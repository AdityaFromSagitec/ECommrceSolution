using ECommerece.Infrastructure;
using ECommerce.Core;
using ECommrce.API.Middlewares;
using System.Text.Json.Serialization;
using ECommerce.Core.Mappers;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container services
builder.Services.AddInfrastructure(); // Extension method from ECommerece.Infrastructure
builder.Services.AddCore(); // Extension method from ECommerce.Core
builder.Services.AddFluentValidationAutoValidation();

// Add controllers to the services collection
builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
// Register AutoMapper, a single instance of IMapper is created and shared throughout the application's lifetime
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//to enable swagger add below 2 lines
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option => option.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyHeader()));
var app = builder.Build();
app.UseExceptionHandlingMiddleware(); // Custom exception handling middleware from ECommrce.API.Middlewares
app.UseSwagger(); // Enable Swagger middleware
app.UseSwaggerUI(); // Enable Swagger UI middleware
app.UseCors();
app.UseRouting(); // Enable routing middleware
app.UseAuthorization(); // Enable authorization middleware
app.MapControllers(); // Map controller routes
app.Run();
