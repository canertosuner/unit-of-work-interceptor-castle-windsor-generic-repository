using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using UoW_Sample.Mappings;

namespace UoW_Sample.IoC
{
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ISessionFactory>().UsingFactoryMethod(GetSessionFactory).LifestyleSingleton());
        }

        private ISessionFactory GetSessionFactory(IKernel kernel)
        {
            var fluentConfiguration = Fluently.Configure()
               .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("ConnString")).ShowSql())
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
               .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                        .ExposeConfiguration(cfg =>
                        {
                            cfg.CurrentSessionContext<CallSessionContext>();
                        })
               .BuildSessionFactory();

            return fluentConfiguration;
        }
    }
}