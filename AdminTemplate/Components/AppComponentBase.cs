using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorTemplate.Components
{
    public partial class AppComponentBase : ComponentBase
    {
        [Inject] protected IJSRuntime JsRuntime { get; set; } = default!;
        [Inject] protected IWebServiceClient WebServiceClient { get; set; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;
        [Inject] protected IAuthTokenProvider AuthTokenProvider { get; set; } = default!;
        [Inject] protected IAuthenticationService AuthenticationService { get; set; } = default!;
        [Inject] protected AppAuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;


    }
}
