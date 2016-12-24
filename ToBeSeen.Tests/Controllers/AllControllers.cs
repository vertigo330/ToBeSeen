using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToBeSeen.Installers;

namespace ToBeSeen.Tests.Controllers
{
    [TestClass]
    public class AllControllers
    {
        public IWindsorContainer containerWithControllers;

        [TestInitialize]
        public void Initialize()
        {
            containerWithControllers = new WindsorContainer()
                .Install(new ControllersInstaller());
        }
        
        [TestMethod]
        public void All_Controllers_Implement_IController()
        {
            var allHandlers = GetallHandlers(containerWithControllers);
        }
    }
}
