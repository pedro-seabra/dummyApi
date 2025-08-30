using dummyApi.src.Application.Services.MarketService;
using dummyApi.src.Infrastructure.Contexts;
using dummyApi.src.Infrastructure.Repositories.LocationRepository;
using dummyApi.src.Infrastructure.Repositories.MarketRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
    ));

// Market registration
builder.Services.AddScoped<IMarketService, MarketService>();
builder.Services.AddScoped<IMarketRepository, MarketRepository>();

//Location registration
builder.Services.AddScoped<ILocationRepository, LocationRepository>();


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var dbContext = services.GetRequiredService<ApplicationDbContext>();
//    dbContext.Database.Migrate();
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
