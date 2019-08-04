using System;

namespace MemeRSity.Services.Abstracts
{
    public interface ISeed
    {
        void Seed(IServiceProvider provider);
    }
}