using BUH.Domain.Services.Abstraction;
using BUH.Domain.Services.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUH.Config.AutoMapper
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFirstRunService>().To<FirstRunService>();
        }
    }
}
