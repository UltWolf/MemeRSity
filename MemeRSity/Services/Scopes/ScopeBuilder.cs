using System;
using MemeRSity.Services.Abstracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;

namespace MemeRSity.Services.Scopes
{
    public class ScopeBuilder:IBuilder<IServiceScope>
    {
        private IServiceProvider _provider;
        private IServiceScope _scope;
        public ScopeBuilder(IServiceProvider provider)
        {
            _provider = provider; 
        }

        public ScopeBuilder ServiceScopeFactory()
        {
         _scope  = this._provider.GetRequiredService<IServiceScopeFactory>().CreateScope();
         return this;
        }

        public IServiceScope Build()
        {
            return _scope;
        }
    }
}