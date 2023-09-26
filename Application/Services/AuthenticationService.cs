using Application.Interfaces;
using Blazored.LocalStorage;
using Shared.Dtos;
using Shared.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient = default!;
        private ILocalStorageService _localStorageService = default!;
        private AppAuthenticationStateProvider _authenticationStateProvider = default!;

        public AuthenticationService(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService, AppAuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClientFactory.CreateClient(AppConstants.FirstHttpClient);
            _localStorageService = localStorageService;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task SignIn(SignInRequestDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Account/Login", dto);
            var result = await response.Content.ReadAsStringAsync();
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
