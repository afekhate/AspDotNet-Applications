
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using SportsMarket.Domain.Abstract;
using SportsMarket.Domain.Entities;
using SportsMarket.Domain.Concrete;
using System.Configuration;


namespace SportsMarket.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver{

            private IKernel kernel;

            public NinjectDependencyResolver(IKernel kernelParam)
            {
                kernel = kernelParam;
                AddBindings();
            }
            public object GetService(Type serviceType)
            {
                return kernel.TryGet(serviceType);
            }
            public IEnumerable<object> GetServices(Type serviceType)
            {
                return kernel.GetAll(serviceType);
            }
            private void AddBindings()
            {
              

                kernel.Bind<IProductRespository>().To<EFProductRepository>();

                EmailSettings emailSettings = new EmailSettings
                {
                    WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
                };

                kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                    .WithConstructorArgument("settings", emailSettings);

            }
        }
}
