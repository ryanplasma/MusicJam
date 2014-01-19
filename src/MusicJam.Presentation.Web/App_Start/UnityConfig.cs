using Microsoft.Practices.Unity;
using System.Web.Http;
using MusicJam.Core.Domain.Repositories;
using Unity.WebApi;

namespace MusicJam.Presentation.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IBandRepository, BandRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}