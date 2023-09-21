using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorTemplate.Components
{
    public partial class AppComponentBase : ComponentBase
    {
        [AutoInject] protected IJSRuntime JsRuntime = default!;

        [AutoInject] protected HttpClient HttpClient = default!;
        [AutoInject] protected NavigationManager NavigationManager = default!;
        [AutoInject] protected IAuthTokenProvider AuthTokenProvider = default!;
        [AutoInject] protected IAuthenticationService AuthenticationService = default!;
        [AutoInject] protected AppAuthenticationStateProvider AuthenticationStateProvider = default!;
    }
}
