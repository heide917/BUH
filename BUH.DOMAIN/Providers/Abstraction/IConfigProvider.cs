using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.Domain.Providers.Abstraction
{
    public interface IConfigProvider
    {
        string GetAppKey(string key);
    }
}
