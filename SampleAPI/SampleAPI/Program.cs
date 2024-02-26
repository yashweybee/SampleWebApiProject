using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SampleAPI.Configuration;
using SampleBLL.Interfaces;
using SampleCore.Mapper;
using SampleCore.Middlewares;
using SampleDAL.DbModels;
using SampleDAL.Repository;
using Serilog;
using Serilog.Core;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//var configuration = new ConfigurationBuilder()
//  .AddJsonFile("appsettings.json")
//  .Build();

Log.Logger = new LoggerConfiguration()
//.ReadFrom.Configuration(configuration)
//.CreateLogger();

.MinimumLevel.Information()
.WriteTo.File("SampleCore/Logs/BooksFetchData.txt")
//.MinimumLevel.Debug()
//.WriteTo.File("SampleCore/Logs/BooksDebugs.txt")
.CreateLogger();


//Yash Parmar : 21-2-24 : Instead of Program it self in dependency injection given MapperProfile class  
builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddRepositories();
builder.Services.AddRepoServices();
builder.Services.AddDbContext<BookStoreContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")),
                ServiceLifetime.Transient);

builder.Services.AddTransient<ExceptionMiddelware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}


//var logger = app.Services.GetRequiredService<ILogger>();
//app.ConfigureExceptionHandler(logger);
//app.UseMiddleware<ExceptionMiddlewareExtensions>();


//Exception middelware
app.ConfigureExceptionMiddelware();

app.UseAuthorization();

app.MapControllers();

app.Run();
