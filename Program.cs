using LolFantasy.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//// Creates a Serilog logger configuration
//Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.File("logs/userLogs.txt", rollingInterval: RollingInterval.Infinite).CreateLogger();
//// Tells program to use Serilog over the default logger.
//builder.Host.UseSerilog();

builder.Services.AddControllers(option =>
{
    // option.ReturnHttpNotAcceptable = true; // We can force an acceptable format type for Http requests (this only restricts to only json)
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters(); // adds use of Newtonsoft Json package for project.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILogging, Loggingv2>();
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
