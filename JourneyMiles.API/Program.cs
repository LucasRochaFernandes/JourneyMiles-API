using JourneyMiles.API.Application;
using JourneyMiles.API.Extensions;
using JourneyMiles.API.Filters;
using JourneyMiles.API.Infrastructure;
using JourneyMiles.API.Infrastructure.Migrations;
using JourneyMiles.API.Shared.Communication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt => opt.Filters.Add(typeof(ExceptionFilter)))
     .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JourneyMiles.API.Converters.StringConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCommunication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

MigrateDatabase();

await app.RunAsync();

void MigrateDatabase()
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
    var serviceProvider = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider;
    DatabaseMigration.Migrate(connectionString, serviceProvider);
}


public partial class Program
{
    protected Program() { }
}
