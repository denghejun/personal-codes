using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIConsumer.Token;
using Newegg.API.Client;

namespace APIConsumer.Authorization
{
    public class RoleAuthorizer : Authorizer
    {
        private string _appkey;
        private string _userId;
        public RoleAuthorizer(string tokenUri, string appkey, string userId)
            : base(new RoleTokenProcessor(tokenUri))
        {
            this._appkey = appkey;
            this._userId = userId;
        }

        public override RestAPIClient Authorize(string baseUri)
        {
            var restApiClient = new RestAPIClient(baseUri);
            restApiClient.SetAuthorizationInfo(this._appkey, this.GetToken());
            return restApiClient;
        }

        protected override string GetToken()
        {
            var token = this._tokenProcessor.Instance<RoleTokenProcessor>().Request(new RoleTokenRequest()
            {
                UserID = this._userId
            });

            return token == null ? null : token.Token;
        }
    }
}
