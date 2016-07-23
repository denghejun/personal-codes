using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIConsumer.Token;
using Newegg.API.Client;

namespace APIConsumer.Authorization
{
    public class PasswordAuthorizer : Authorizer
    {
        private string _clientId;
        private string _userId;
        public PasswordAuthorizer(string tokenUri, string clientId, string userId)
            : base(new PasswordTokenProcessor(tokenUri))
        {
            this._clientId = clientId;
            this._userId = userId;
        }

        protected override string GetToken()
        {
            var token = this._tokenProcessor.Instance<PasswordTokenProcessor>().Request(new PasswordTokenRequest()
            {
                client_id = this._clientId,
                username = this._userId
            });

            return token == null ? null : token.access_token;
        }
    }
}
