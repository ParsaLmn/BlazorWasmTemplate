using Application.Interfaces;
using Application.Services;
using Blazored.LocalStorage;
using BlazorTemplate;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string baseAddress = builder.Configuration.GetValue<string>("BaseUrl");

builder.Services.AddScoped(sp => new HttpClient(sp.GetRequiredService<AppHttpClientHandler>()) { BaseAddress = new Uri(baseAddress) });

builder.Services.AddScoped<AppHttpClientHandler>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AppAuthenticationStateProvider>();
builder.Services.AddScoped(sp => (AppAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAuthTokenProvider, AuthTokenProvider>();
builder.Services.AddScoped<IWebServiceClient, WebServiceClient>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddLocalization();
var host = builder.Build();
await host.SetDefaultCulture();
await host.RunAsync();

await builder.Build().RunAsync();
