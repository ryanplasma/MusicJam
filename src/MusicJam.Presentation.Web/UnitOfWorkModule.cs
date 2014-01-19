using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MusicJam.Core.Domain.Interfaces;

namespace MusicJam.Presentation.Web
{
    public class UnitOfWorkModule : IHttpModule
    {
        private static IUnityContainer Container;

        public void Dispose()
        {

        }

        public static void SetContainer(IUnityContainer container)
        {
            Container = container;
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            var uow = (IUnitOfWork) HttpContext.Current.Items["UnitOfWork"];
            uow.Commit();
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            var uow = Container.Resolve<IUnitOfWork>();
            HttpContext.Current.Items.Add("UnitOfWork", uow);
            uow.Begin();
        }
    }
}
