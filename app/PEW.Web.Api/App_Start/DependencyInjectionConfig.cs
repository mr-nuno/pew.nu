using System;
using System.Web;
using System.Web.Http;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using PEW.ApplicationServices;
using PEW.Core.Data;
using PEW.Core.Interfaces;
using PEW.Core.Interfaces.ApplicationServices;
using PEW.Core.Interfaces.Data;
using PEW.Core.Validation;
using PEW.Data;
using PEW.Repository;

namespace PEW.Web.Api
{
    public class PerWebRequestLifetimeManager : LifetimeManager
    {
        private readonly string _key = Guid.NewGuid().ToString();

        public override object GetValue()
        {
            return HttpContext.Current.Items[_key];
        }

        public override void RemoveValue()
        {
            HttpContext.Current.Items.Remove(_key);
        }
        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[_key] = newValue;
        }
        public void Dispose()
        {
            RemoveValue();
        }
    }

    public class DependencyInjectionConfig
    {
        public static void Initialize()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

            //container.RegisterType<IRavenDbDataContext, RavenDbContext>(new PerWebRequestLifetimeManager());
            //container.RegisterType<IUnitOfWork, UnitOfWork>(new PerWebRequestLifetimeManager());
            //container.RegisterType<IProfileRepository, ProfileRepository>(new PerWebRequestLifetimeManager());
            container.RegisterType<IEAStatisticsService, EAStatisticsService>(new PerWebRequestLifetimeManager());
            container.RegisterType<IMailService, GMailService>(new PerWebRequestLifetimeManager());
            container.RegisterType<ICryptoService, CryptoService>(new PerWebRequestLifetimeManager());
            //container.RegisterType(typeof(IRepository<>), typeof(Repository<>), new PerWebRequestLifetimeManager());

            container.RegisterType<IValidator, Validator>(new PerWebRequestLifetimeManager());
            container.RegisterType<IHockeyStatsService, HockeyStatsService>(new PerWebRequestLifetimeManager());

            return container;
        }
    }
}