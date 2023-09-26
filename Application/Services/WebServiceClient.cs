using Application.Interfaces;
using Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WebServiceClient : IWebServiceClient
    {
        private readonly HttpClient httpClient;

        public WebServiceClient(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient(AppConstants.FirstHttpClient);
        }
    }
}
