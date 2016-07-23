using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newegg.API.Client;

namespace APIConsumer.Token
{
    public class PasswordTokenProcessor : TokenProcessor<PasswordTokenRequest, PasswordTokenResponse>
    {
        public PasswordTokenProcessor(string tokenUri)
            : base(tokenUri)
        {
        }

        public override PasswordTokenResponse Request(PasswordTokenRequest param)
        {
            return new RestAPIClient(this._tokenUri, ContentTypes.Json).Post<PasswordTokenResponse>(this._tokenUri + "?trusted=true", param);
        }
    }

    public class PasswordTokenResponse 
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }
    }

    public class PasswordTokenRequest 
    {
        public PasswordTokenRequest()
        {
            this.grant_type = "password";
        }

        public string username { get; set; }
        public string client_id { get; set; }
        public string grant_type { get; private set; }
    }
}
