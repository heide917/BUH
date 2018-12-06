using BUH.Domain.Providers.Abstraction;
using System.Configuration;

namespace BUH.Domain.Providers.Concrete
{
    public class ConfigProvider : IConfigProvider
    {
        public string GetAppKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}
