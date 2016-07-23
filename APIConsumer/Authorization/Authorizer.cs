using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIConsumer.Token;
using Newegg.API.Client;

namespace APIConsumer.Authorization
{
    public abstract class Authorizer
    {
        protected string _accessToken;
        protected TokenProcessor _tokenProcessor;
        public Authorizer(TokenProcessor tokenProcessor)
        {
            this._tokenProcessor = tokenProcessor;
        }
        protected abstract string GetToken();
        public virtual RestAPIClient Authorize(string baseUri)
        {
            var token = this.GetToken();
            var restApiClient = new RestAPIClient(baseUri);
            restApiClient.SetOAuthToken(token);
            return restApiClient;
        }
    }
}
