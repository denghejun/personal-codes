using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIConsumer.Authorization;
using Newegg.API.Client;

namespace APIConsumer.Consumer
{
    public abstract class Consumer
    {
        private RestAPIClient _proxy;
        protected Authorizer _authorizer;
        protected abstract string BaseUri { get; }

        protected RestAPIClient Proxy
        {
            get
            {
                return this._proxy ?? (this._proxy = this._authorizer.Authorize(this.BaseUri));
            }
        }

        public Consumer(Authorizer authorizer)
        {
            this._authorizer = authorizer;
        }

        public TResponse Post<TResponse>(string uri, object request)
        {
            return this.Proxy.Post<TResponse>(uri, request);
        }

        public TResponse Get<TResponse>(string uri, object request)
        {
            return this.Proxy.Get<TResponse>(uri, request);
        }

        public TResponse Delete<TResponse>(string uri, object request)
        {
            return this.Proxy.Delete<TResponse>(uri, request);
        }

        public TResponse Put<TResponse>(string uri, object request)
        {
            return this.Proxy.Put<TResponse>(uri, request);
        }
    }
}
