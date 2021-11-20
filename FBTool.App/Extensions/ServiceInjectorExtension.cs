using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FBTool.BLL.Implement.Facebook;
using FBTool.BLL.Interface.Facebook;

namespace FBTool.App.Extensions
{
    public static class ServiceInjectorExtension
    {
        public static void RegisterService(this IWindsorContainer _windsorContainer)
        {
            _windsorContainer.Register(Component.For<IFacebookBussiness>().ImplementedBy<FacebookBussiness>().LifestyleTransient());
        }
    }
}
