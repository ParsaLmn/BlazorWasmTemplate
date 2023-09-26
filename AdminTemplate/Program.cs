using Application.Interfaces;
using Application.Services;
using Blazored.LocalStorage;
using BlazorTemplate;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared.Model;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient(AppConstants.FirstHttpClient, (provider, client) =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    ApiOptions apiOption = new();
    builder.Configuration.GetSection(ApiOptions.ApiName).Bind(apiOption);

    client.BaseAddress = new Uri(apiOption.BaseAddress);
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTransient<AppHttpClientHandler>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AppAuthenticationStateProvider>();
builder.Services.AddScoped(sp => (AppAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthTokenProvider, AuthTokenProvider>();
builder.Services.AddScoped<IWebServiceClient, WebServiceClient>();
builder.Services.AddBlazoredLocalStorage();


await builder.Build().RunAsync();
