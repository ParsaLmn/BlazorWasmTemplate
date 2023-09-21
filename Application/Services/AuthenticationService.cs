using Application.Interfaces;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public partial class AuthenticationService: IAuthenticationService
    {
        private HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private AppAuthenticationStateProvider _authenticationStateProvider;
        public async Task SignIn(SignInRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("https://ticketing.razysoft.net/api/Account/Login", dto);
            var result = await response.Content.ReadFromJsonAsync<string>();
            await _localStorageService.SetItemAsStringAsync("token", result);
            await _authenticationStateProvider.RaiseAuthenticationStateHasChanged();
        }

        public async Task SignOut()
        {
            await _localStorageService.RemoveItemAsync("token");
            await _authenticationStateProvider.RaiseAuthenticationStateHasChanged();
        }
    }
}
