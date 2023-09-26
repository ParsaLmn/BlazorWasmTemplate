using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace BlazorTemplate.Shared;
public partial class NotAuthorizedComponent
{
    private ClaimsPrincipal _user = default!;

    [CascadingParameter] public Task<AuthenticationState> AuthenticationState { get; set; } = default!;

    protected override async Task OnParametersSetAsync()
    {
        _user = (await AuthenticationState).User;

        await base.OnParametersSetAsync();
    }
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (firstRender is false) return;

        try
        {
            if (_user.Identity?.IsAuthenticated is false)
            {
                RedirectToSignInPage();
            }
        }
        catch (Exception exp)
        {
            throw new Exception();
        }
    }
    private async Task SignIn()
    {
        await AuthenticationService.SignOut();

        RedirectToSignInPage();
    }

    private void RedirectToSignInPage()
    {
        var redirectUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);

        NavigationManager.NavigateTo($"/sign-in?redirectUrl={redirectUrl}");
    }
}
