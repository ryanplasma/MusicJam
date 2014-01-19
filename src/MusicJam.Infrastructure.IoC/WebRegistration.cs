using System;
using System.Runtime.Remoting.Messaging;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Practices.Unity;
using MusicJam.Core.Domain.Interfaces;
using MusicJam.Core.Domain.Repositories;
using MusicJam.Infrastructure.Repositories;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace MusicJam.Infrastructure.IoC
{
    public class WebRegistration
    {
        private static object _locker = new object();

        private static ISessionFactory Factory;

        static WebRegistration()
        {
            lock (_locker)
            {
                Factory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("Default")))
                    .Mappings(cfg => cfg.FluentMappings.AddFromAssemblyOf<BandRepository>())
                    .BuildConfiguration()
                    .CurrentSessionContext<WebSessionContext>().BuildSessionFactory();
            }
        }

        public static void Register(IUnityContainer container)
        {
            container.RegisterType<ISession>(new PerRequestLifetimeManager(), new InjectionFactory((c, t, s) =>
            {
                var session = Factory.OpenSession();
                session.FlushMode = FlushMode.Commit;
                return session;
            }));
            container.RegisterType<IUnitOfWork, UnitOfWork>(new InjectionFactory((c, t, s) => new UnitOfWork(c.Resolve<ISession>())));
            container.RegisterType<IBandRepository, BandRepository>();

        }
    }

    public class PerRequestLifetimeManager : LifetimeManager
    {
        private string _key = string.Format("PerCallContextLifeTimeManager_{0}", Guid.NewGuid());

        public override object GetValue()
        {
            return CallContext.GetData(_key);
        }

        public override void SetValue(object newValue)
        {
            CallContext.SetData(_key, newValue);
        }

        public override void RemoveValue()
        {
            CallContext.FreeNamedDataSlot(_key);
        }
    }
}
