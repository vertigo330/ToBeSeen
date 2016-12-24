using System;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ToBeSeen.Controllers;

namespace ToBeSeen.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(FindControllers().Configure(ConfigureControllers()));
        }

        private static BasedOnDescriptor FindControllers()
        {
            return AllTypes.FromThisAssembly()
                .BasedOn<IController>()
                .If(Component.IsInSameNamespaceAs<HomeController>())
                .If(t => t.Name.EndsWith("Controller"));
        }

        private static ConfigureDelegate ConfigureControllers()
        {
            return c => c.Named(c.ServiceType.Name)
                            .LifeStyle.Transient;
        }
    }
}