using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIConsumer.Token
{

    public abstract class TokenProcessor
    {
        public T Instance<T>() where T : TokenProcessor
        {
            return this as T;
        }
    }

    public abstract class TokenProcessor<TRequest, TResponse> : TokenProcessor
    {
        protected string _tokenUri;

        public TokenProcessor(string tokenUri)
        {
            this._tokenUri = tokenUri;
        }

        public abstract TResponse Request(TRequest param);
    }
}
