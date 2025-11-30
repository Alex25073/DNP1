using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RepositoryContracts;
using EfcRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// EF Core DbContext
builder.Services.AddDbContext<AppContext>(options =>
{
    options.UseSqlite("Data Source=app.db");
});

// Repositories: use EF instead of FileRepositories
builder.Services.AddScoped<IUserRepository, UserEfcRepository>();
builder.Services.AddScoped<IPostRepository, PostEfcRepository>();
builder.Services.AddScoped<ICommentRepository, CommentEfcRepository>();

// OpenAPI / Swagger (assuming this is what the comment was about)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
