using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIConsumer.Consumer;

namespace APIConsumer.Factory
{
    public static class ConsumerFactory
    {
        private static Consumer.Consumer _wmsApi;

        public static Consumer.Consumer WMSAPI
        {
            get
            {
                return _wmsApi ?? (_wmsApi = new WMSAPIConsumer());
            }
        }
    }
}
