using BlazorApp;
using BlazorApp.Auth;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:5217") 
});

// Assignment 5 – API services
builder.Services.AddScoped<IUsersService, UsersHttpClient>();
builder.Services.AddScoped<IPostsService, PostsHttpClient>();
builder.Services.AddScoped<ICommentsService, CommentsHttpClient>();

// Assignment 6 – auth
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<SimpleAuthState>();
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthProvider>();
builder.Services.AddScoped<IAuthService, AuthHttpClient>();

await builder.Build().RunAsync();
