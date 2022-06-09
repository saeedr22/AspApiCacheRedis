using System;
using System.Reflection;

namespace AspApiCacheRedis.Util
{
    public interface IServiceInstaller
    {
        void InstallServices(IServiceCollection services,  Assembly startupProjectAssembly);
    }
}