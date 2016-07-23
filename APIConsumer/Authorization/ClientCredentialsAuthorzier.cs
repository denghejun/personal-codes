using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIConsumer.Token;
using Newegg.API.Client;

namespace APIConsumer.Authorization
{
    public class ClientCredentialsAuthorzier : Authorizer
    {
        private string _clientId;
        private string _clientSecret;
        public ClientCredentialsAuthorzier(string tokenUri, string clientId, string clientSecret)
            : base(new ClientCredentialsTokenProcessor(tokenUri))
        {
            this._clientId = clientId;
            this._clientSecret = clientSecret;
        }

        protected override string GetToken()
        {
            var token = this._tokenProcessor.Instance<ClientCredentialsTokenProcessor>().Request(new ClientCredentialsTokenRequest()
            {
                client_id = this._clientId,
                client_secret = this._clientSecret
            });

            return token == null ? null : token.access_token;
        }
    }
}
