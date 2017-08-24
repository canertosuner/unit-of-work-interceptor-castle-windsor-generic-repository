using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using UoW_Sample.IoC;

namespace UoW_Sample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<UnitOfWorkInterceptor>().LifestyleSingleton());
            container.Install(new ServiceInstaller());
            container.Install(new RepositoryInstaller());
            container.Install(new NHibernateInstaller());
            container.Install(new WebApiControllerInstaller());
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new ApiControllerActivator(container));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
