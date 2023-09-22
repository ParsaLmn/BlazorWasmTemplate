using Application.Interfaces;
using Blazored.LocalStorage;
using Shared.Dtos;
using System.Net.Http.Json;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private HttpClient _httpClient = default!;
        private ILocalStorageService _localStorageService = default!;
        private AppAuthenticationStateProvider _authenticationStateProvider = default!;

        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorageService, AppAuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _authenticationStateProvider = authenticationStateProvider;
        }

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
