using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RepositoryContracts;
using FileRepositories;
using Microsoft.AspNetCore.OpenApi; // keep this

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// your repositories
builder.Services.AddScoped<IUserRepository, UserFileRepository>(); 
builder.Services.AddScoped<IPostRepository, PostFileRepository>();  
builder.Services.AddScoped<ICommentRepository, CommentFileRepository>();  

// 👇 NEW: built-in OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // 👇 NEW: maps /openapi/v1.json
    app.MapOpenApi();
}

// optional middlewares (https, etc.) if you want:
app.UseHttpsRedirection();

app.MapControllers();
app.Run();
