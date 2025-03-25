using Microsoft.EntityFrameworkCore;
using Visitors.Infra.Context;
using Visitors.Infra;
using Visitors.Server.Middlewares;


var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container

// Add DbContext
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add repositories, services and middlewares
builder.Services.AddRepositories();
builder.Services.AddServices();

// Add CORS
builder.Services.AddCors(corsOptions => {
    corsOptions.AddPolicy("policy",
   builder => {
       builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
   });
});

// Add controllers
builder.Services.AddControllers();

// Add OpenAPI and Swagger
builder.Services.AddOpenApi(); // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

// 2. Build the application
var app = builder.Build();

// Use the middleware
app.UseMiddleware<SaveChangesMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

// 3. Configure the HTTP request pipeline

// Serve default files (like index.html)
app.UseDefaultFiles();

// Serve static files
app.MapStaticAssets();

// Enable Swagger in development environment
if (app.Environment.IsDevelopment())
{
    // Apply any pending migrations and update the database at startup
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();  // This applies any pending migrations
    }

    // OpenAPI mapping
    // https://localhost:8200/openapi/v1.json
    app.MapOpenApi();

    // Swagger UI
    // https://localhost:8200/swagger/index.html
    app.UseSwagger();
    app.UseSwaggerUI();

}

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable CORS
app.UseCors("policy");


// Map controllers
app.MapControllers();

// Map fallback for SPA (Single Page Application)
app.MapFallbackToFile("/index.html");

// 4. Run the application
app.Run();
