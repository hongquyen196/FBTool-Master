using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using FBTool.App.Extensions;
using FBTool.App.Views;
using System;
using System.Windows.Forms;

namespace FBTool.App
{
    static class Program
    {
        private static IWindsorContainer container = new WindsorContainer();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            container.Install(FromAssembly.This());
            container.Register(Component.For<MainForm>());
            container.RegisterService();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<MainForm>());
        }

        public static T GetService<T>()
        {
            return container.Resolve<T>();
        }
    }
}