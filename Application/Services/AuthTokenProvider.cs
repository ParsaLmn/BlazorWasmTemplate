using Application.Interfaces;
using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public partial class AuthTokenProvider : IAuthTokenProvider
    {
        private readonly ILocalStorageService _localStorageService;
        public async Task<string?> GetAcccessTokenAsync()
        {
            return await _localStorageService.GetItemAsStringAsync("token");
        }
    }
}
