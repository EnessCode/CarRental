using CarRental.Application.Features.CQRS.Handlers.AboutHandlers;
using CarRental.Application.Interfaces;
using CarRental.Application.Interfaces.BlogInterfaces;
using CarRental.Application.Interfaces.CarInterfaces;
using CarRental.Application.Interfaces.CarPricingInterfaces;
using CarRental.Application.Interfaces.CategoryInterfaces;
using CarRental.Application.Interfaces.CommentInterfaces;
using CarRental.Application.Interfaces.TagCloudInterfaces;
using CarRental.Application.Services;
using CarRental.Persistence.Context;
using CarRental.Persistence.Repositories;
using CarRental.Persistence.Repositories.BlogRepositories;
using CarRental.Persistence.Repositories.CarPricingRepositories;
using CarRental.Persistence.Repositories.CarRepositories;
using CarRental.Persistence.Repositories.CategoryRepositories;
using CarRental.Persistence.Repositories.CommentRepositories;
using CarRental.Persistence.Repositories.TagCloudRepositories;
using CarRental.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarRentalContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICarPricingRepository, CarPricingRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITagCloudRepository, TagCloudRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddApplicationService(builder.Configuration);

builder.Services.Scan(scan => scan
	.FromAssemblyOf<CreateAboutCommandHandler>()
	.AddClasses(classes => classes.Where(c => c.Name.EndsWith("Handler")))
	.AsSelf()
	.WithScopedLifetime());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
