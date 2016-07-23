using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIConsumer.Authorization;

namespace APIConsumer.Consumer
{
    public class WMSAPIConsumer : Consumer
    {
        public WMSAPIConsumer()
            : base(new ClientCredentialsAuthorzier(ConfigurationManager.AppSettings["TokenUri"], ConfigurationManager.AppSettings["ClientID"], ConfigurationManager.AppSettings["ClientSecret"]))
        {
        }

        protected override string BaseUri
        {
            get
            {
                return ConfigurationManager.AppSettings["WMSAPI"];
            }
        }
    }
}
