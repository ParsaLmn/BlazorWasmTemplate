using Application.Interfaces;
using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthTokenProvider : IAuthTokenProvider
    {
         private ILocalStorageService _localStorageService = default!;

        public AuthTokenProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<string?> GetAcccessTokenAsync()
        {
            return await _localStorageService.GetItemAsStringAsync("token");
        }
    }
}
