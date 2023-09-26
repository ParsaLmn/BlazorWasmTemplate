using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using Shared.Dtos;

namespace BlazorTemplate.Shared;
public partial class Header : IDisposable
{
    [Parameter]
    public EventCallback OnToggleMenu { get; set; }
    public UserDto _user { get; set; }
    private bool _disposed;
    private string? _profileImageUrl;
    private string? _profileImageUrlBase;
    private bool _isUserAuthenticated;
    private bool _isHeaderDrpDownOpen;
    private bool _isSignOutModalOpen;
    private string _currentUrl = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            //userState.UserDto = await WebServiceClient.GetCurrentUser();
            _user = new UserDto()
            {
                FirstName = "firstname",
                LastName = "lastname",
                UserName = "username",
                PhoneNumber = "1234567890",
            };
        }
        catch (Exception e)
        {

        }
        SetProfileImageUrl();
        await base.OnInitializedAsync();
    }

    private void SetProfileImageUrl()
    {
        _profileImageUrl = "/images/avatar.png";
    }

    private async Task ToggleMenu()
    {
        await OnToggleMenu.InvokeAsync();
    }

    private async Task OpenSignOutModal()
    {
        ToggleHeaderDropdown();
        await JsRuntime.SetBodyOverflow(true);
        _isSignOutModalOpen = true;
    }

    private void ToggleHeaderDropdown()
    {
        _isHeaderDrpDownOpen = !_isHeaderDrpDownOpen;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed || disposing is false) return;
        _disposed = true;
    }
}
