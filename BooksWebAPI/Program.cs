using BooksWebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Startup.ConfigureServices(builder);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

Startup.Configure(app);
app.Run();
