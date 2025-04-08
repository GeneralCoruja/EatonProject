using EatonAPI.Database;
using EatonAPI.Database.Clients;
using EatonAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database configuration
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("Database"));
builder.Services.AddSingleton<MongoDatabase>();

// Add Services
builder.Services.AddSingleton<IDeviceService, DeviceService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection();

app.MapControllers();
app.Run();
