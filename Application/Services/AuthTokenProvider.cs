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
    public partial class AuthTokenProvider : IAuthTokenProvider
    {
        [AutoInject] private readonly ILocalStorageService _localStorageService;
        public async Task<string?> GetAcccessTokenAsync()
        {
            return await _localStorageService.GetItemAsStringAsync("token");
        }
    }
}
