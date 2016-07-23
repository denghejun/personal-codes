using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newegg.API.Client;

namespace APIConsumer.Token
{
    public class ClientCredentialsTokenProcessor : TokenProcessor<ClientCredentialsTokenRequest, ClientCredentialsTokenResponse>
    {
        public ClientCredentialsTokenProcessor(string tokenUri)
            : base(tokenUri)
        {
        }

        public override ClientCredentialsTokenResponse Request(ClientCredentialsTokenRequest param)
        {
            return new RestAPIClient(this._tokenUri, ContentTypes.Json).Post<ClientCredentialsTokenResponse>(this._tokenUri + "?trusted=true", param);
        }
    }

    public class ClientCredentialsTokenResponse 
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }
    }

    public class ClientCredentialsTokenRequest 
    {
        public ClientCredentialsTokenRequest()
        {
            this.grant_type = "clientcredentials";
        }

        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string grant_type { get; private set; }
    }

}
