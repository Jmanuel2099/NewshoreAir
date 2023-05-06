using Microsoft.EntityFrameworkCore;
using NewshoreAirApplication.Interfaces.Persistance;
using NewshoreAirApplication.Interfaces.Services;
using NewshoreAirApplication.Journeys;
using NewshoreAirInfrastructure.NewshoreAir.Flights.Client;
using NewshoreAirInfrastructure.SQLServer;
using NewshoreAirInfrastructure.SQLServer.Journeys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IJourneyRespository, JourneyImplementation>();
builder.Services.AddScoped<INewshoreFlights, FlightClient>();
builder.Services.AddScoped<IJourneyHandler, JourneyHandler>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<NewshoreAirContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("NewshoreAirConection"))
//);

var app = builder.Build();

//using(var scope =  app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<NewshoreAirContext>();
//    context.Database.Migrate();
//}

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
