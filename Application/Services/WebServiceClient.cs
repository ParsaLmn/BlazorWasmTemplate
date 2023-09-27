using Application.Interfaces;
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

        public WebServiceClient( HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
