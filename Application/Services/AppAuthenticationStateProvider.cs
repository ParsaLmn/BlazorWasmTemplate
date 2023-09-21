﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public partial class AppAuthenticationStateProvider : AuthenticationStateProvider
    {
        [AutoInject] private readonly AuthTokenProvider _tokenProvider = new();
        public async Task RaiseAuthenticationStateHasChanged()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(await GetAuthenticationStateAsync()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var access_token = await _tokenProvider.GetAcccessTokenAsync();

            if (string.IsNullOrWhiteSpace(access_token)) return NotSignedIn();

            var identity = new ClaimsIdentity(claims: ParseTokenClaims(access_token), authenticationType: "Bearer", nameType: "name", roleType: "role");

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public async Task<bool> IsUserAuthenticatedAsync()
        {
            return (await GetAuthenticationStateAsync()).User.Identity?.IsAuthenticated == true;
        }

        private static AuthenticationState NotSignedIn()
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        private static IEnumerable<Claim> ParseTokenClaims(string access_token)
        {
            return Jose.JWT.Payload<Dictionary<string, object>>(access_token)
                .Select(keyValue => new Claim(keyValue.Key, keyValue.Value.ToString() ?? string.Empty))
                .ToArray();
        }
    }
}
