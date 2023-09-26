using Bit.BlazorUI;
using Microsoft.AspNetCore.Components;
using Shared.Dtos;

namespace BlazorTemplate.Pages;
public partial class SignInPage
{
    public bool _isLoading;
    public string? _signInMessage;
    public BitMessageBarType _signInMessageType;
    public SignInRequestDto _signInModel = new();

    string ShowHidePass = BitIconName.View;
    string _passInputType = "password";

    [Parameter]
    [SupplyParameterFromQuery]
    public string? RedirectUrl { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender is false) return;

        if (await AuthenticationStateProvider.IsUserAuthenticatedAsync())
        {
            NavigationManager.NavigateTo("/");
        }
    }
    private async Task DoSignIn()
    {
        if (_isLoading) return;

        _isLoading = true;
        _signInMessage = null;

        try
        {
            await AuthenticationService.SignIn(_signInModel);

            NavigationManager.NavigateTo(RedirectUrl ?? "/");
        }
        catch (Exception ex)
        {
            _signInMessage = ex.Message;
            _signInMessageType = BitMessageBarType.Error;
        }
        finally
        {
            _isLoading = false;
        }
    }
    private void ShowPassword()
    {
        if (ShowHidePass == BitIconName.View)
        {
            ShowHidePass = BitIconName.Hide3;
            _passInputType = "text";
        }
        else
        {
            _passInputType = "password";
            ShowHidePass = BitIconName.View;
        }
    }
}
