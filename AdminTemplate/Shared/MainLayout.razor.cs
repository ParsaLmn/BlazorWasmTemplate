using Application.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace BlazorTemplate.Shared;
public partial class MainLayout : IDisposable
{
    [Inject]
    private IJSRuntime _jsRuntime { get; set; } = default!;
    [Inject]
    private AppAuthenticationStateProvider _authStateProvider { get; set; } = default!;

    private bool _disposed;
    private bool _isMenuOpen;
    private bool _isUserAuthenticated = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _authStateProvider.AuthenticationStateChanged += VerifyUserIsAuthenticatedOrNot;

            //_isUserAuthenticated = await _stateService.GetValue($"{nameof(MainLayout)}-IsUserAuthenticated", _authStateProvider.IsUserAuthenticatedAsync);

            await base.OnInitializedAsync();
        }
        catch (Exception exp)
        {
            throw new Exception();
        }
    }
    async void VerifyUserIsAuthenticatedOrNot(Task<AuthenticationState> task)
    {
        try
        {
            _isUserAuthenticated = await _authStateProvider.IsUserAuthenticatedAsync();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
        finally
        {
            StateHasChanged();
        }
    }
    private async Task ToggleMenuHandler()
    {
        _isMenuOpen = !_isMenuOpen;

        await _jsRuntime.SetBodyOverflow(_isMenuOpen);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed || disposing is false) return;

        _authStateProvider.AuthenticationStateChanged -= VerifyUserIsAuthenticatedOrNot;

        _disposed = true;
    }
}
