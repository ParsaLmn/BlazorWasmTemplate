using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorTemplate.Components
{
    public class AppComponentBase : ComponentBase
    {
        protected IJSRuntime JsRuntime = default!;
        protected HttpClient HttpClient = default!;
        protected NavigationManager NavigationManager = default!;
        protected IAuthTokenProvider AuthTokenProvider = default!;
        protected IAuthenticationService AuthenticationService = default!;
        protected AppAuthenticationStateProvider AuthenticationStateProvider = default!;

        public AppComponentBase(IJSRuntime jsRuntime, NavigationManager navigationManager, IAuthTokenProvider authTokenProvider, IAuthenticationService authenticationService, AppAuthenticationStateProvider authenticationStateProvider = null)
        {
            JsRuntime = jsRuntime;
            NavigationManager = navigationManager;
            AuthTokenProvider = authTokenProvider;
            AuthenticationService = authenticationService;
            AuthenticationStateProvider = authenticationStateProvider;
        }

    }
}
