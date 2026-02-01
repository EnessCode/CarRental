using CarRental.Application.Features.CQRS.Handlers.AboutHandlers;
using CarRental.Application.Interfaces;
using CarRental.Application.Interfaces.CarInterfaces;
using CarRental.Persistence.Context;
using CarRental.Persistence.Repositories;
using CarRental.Persistence.Repositories.CarRepositories;
using CarRental.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarRentalContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();

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
