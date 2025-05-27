using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskBoard.Domain.Interfaces;
using TaskBoard.Infrastructure.Db;
using TaskBoard.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Entity Framework & DbContext
builder.Services.AddDbContext<TaskBoardDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

//Mediator
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAllTasksQueryHandler).Assembly);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskBoard API V1");
        c.RoutePrefix = string.Empty; // To show Swagger UI at root (localhost:5278/)
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
