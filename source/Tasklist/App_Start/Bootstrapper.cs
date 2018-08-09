using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using Tasklist.Data.Repository;
using Tasklist.Data.Infrastructure;
using Tasklist.Service;
using Tasklist.Mappings;
using Tasklist.Web.Core.Authentication;
using Microsoft.AspNet.Identity.EntityFramework;
using Tasklist.Model.Models;
using Tasklist.Data.Models;
using Microsoft.AspNet.Identity;

namespace Tasklist
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
            //Configure AutoMapper
            AutoMapperConfiguration.Configure();
        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();


            builder.RegisterAssemblyTypes(typeof(TaskRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerHttpRequest();

            builder.RegisterAssemblyTypes(typeof(TaskService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerHttpRequest();

            //builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>));
            //builder.RegisterType<TaskEntities>().InstancePerHttpRequest();

            builder.Register(c => new TasklistEntities()).InstancePerHttpRequest();

            //builder.RegisterAssemblyTypes(typeof(TaskService).Assembly)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces().InstancePerHttpRequest();

            //builder.RegisterAssemblyTypes(typeof(DefaultFormsAuthentication).Assembly)
            //    .Where(t => t.Name.EndsWith("Authentication"))
            //    .AsImplementedInterfaces()
            //    .InstancePerHttpRequest();

            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}