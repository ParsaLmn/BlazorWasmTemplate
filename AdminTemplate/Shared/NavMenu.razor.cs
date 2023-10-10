using Bit.BlazorUI;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shared.Resources;

namespace BlazorTemplate.Shared;
public partial class NavMenu
{
    private bool isMenuOpen;

    private List<BitNavItem> _navItems = default!;

    [CascadingParameter] public Task<AuthenticationState> AuthenticationStateTask { get; set; } = default!;

    [Parameter]
    public bool IsMenuOpen
    {
        get => isMenuOpen;
        set
        {
            if (value == isMenuOpen) return;

            isMenuOpen = value;

            _ = IsMenuOpenChanged.InvokeAsync(value);
        }
    }

    [Parameter] public EventCallback<bool> IsMenuOpenChanged { get; set; }
    protected override async Task OnInitializedAsync()
    {
        _navItems = new()
        {
            new BitNavItem
            {
                Text = @Localizer[nameof(General.HomeBtn)],
                IconName = BitIconName.Home,
                Url = "/",
            }
            ,
           new BitNavItem
            {
                Text = "Counter",
                IconName = BitIconName.Count,
                Url = "/counter",
            }
        };
        await base.OnInitializedAsync();
    }
    private async Task HandleOnItemClick(BitNavItem item)
    {
        if (string.IsNullOrWhiteSpace(item.Url)) return;

        await CloseNavMenu();
    }

    private async Task CloseNavMenu()
    {
        IsMenuOpen = false;

        await JsRuntime.SetBodyOverflow(false);
    }
}
