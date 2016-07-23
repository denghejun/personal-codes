using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newegg.API.Client;

namespace APIConsumer.Token
{
    public class RoleTokenProcessor : TokenProcessor<RoleTokenRequest, RoleTokenResponse>
    {
        public RoleTokenProcessor(string tokenUri)
            : base(tokenUri)
        {
        }

        public override RoleTokenResponse Request(RoleTokenRequest param)
        {
            var tokenUrl = this._tokenUri + param.UserID;
            return new RestAPIClient(tokenUrl, ContentTypes.Json).Get<RoleTokenResponse>(tokenUrl, null);
        }
    }

    public class RoleTokenRequest 
    {
        public string UserID { get; set; }
    }

    public class RoleTokenResponse 
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public DateTime Expired { get; set; }
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
