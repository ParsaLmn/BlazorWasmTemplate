using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace BlazorTemplate.Shared;
public partial class CultureSelector
{
    [Inject]
    public NavigationManager NavManager { get; set; }
    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    string text="";

    CultureInfo[] cultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("fa-IR")
    };
    CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                var js = (IJSInProcessRuntime)JSRuntime;
                js.InvokeVoid("setBlazorCulture", value.Name);
                NavManager.NavigateTo(NavManager.Uri, forceLoad: true);
            }
        }
    }
}
