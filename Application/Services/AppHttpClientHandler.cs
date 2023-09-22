using Application.Interfaces;
using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AppHttpClientHandler : HttpClientHandler
    {
         private IAuthTokenProvider _tokenProvider = default!;

        public AppHttpClientHandler(IAuthTokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Authorization is null)
            {
                var access_token = await _tokenProvider.GetAcccessTokenAsync();
                if (access_token is not null)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
                }
            }
            var response = await base.SendAsync(request, cancellationToken);

            //if (response.StatusCode is HttpStatusCode.Unauthorized)
            //{
            //    throw new UnauthorizedException();
            //}

            return response;
        }
    }
}
