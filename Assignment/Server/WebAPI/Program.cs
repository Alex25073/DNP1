
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RepositoryContracts;
using FileRepositories;  // Import your file repositories

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register your file repositories with DI (Dependency Injection)
builder.Services.AddScoped<IUserRepository, UserFileRepository>();  // Registering the User repository
builder.Services.AddScoped<IPostRepository, PostFileRepository>();  // Registering the Post repository
builder.Services.AddScoped<ICommentRepository, CommentFileRepository>();  // Registering the Comment repository

// Add Swagger generation for OpenAPI
builder.Services.AddSwaggerGen(c =>  
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Enable OpenAPI and Swagger UI in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   // Serves OpenAPI spec at /swagger/v1/swagger.json
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;  // Serve Swagger UI at the root ("/")
    });
}

app.MapControllers();  // Map the API controllers
app.Run();  // Start the app
