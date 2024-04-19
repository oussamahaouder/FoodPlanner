using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Domain.Interfaces;
using TaskManagerApp.Domain.Services;
using TaskManagerApp.Infrastructure;
using TaskManagerApp.Infrastructure.Adapters;
using TaskManagerApp.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataBaseContext>(options=> {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnexionString"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddControllers();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IFoodAdapter, FoodAdapter>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
