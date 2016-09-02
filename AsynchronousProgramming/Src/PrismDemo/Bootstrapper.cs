using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using ModuleA;
using PrismDemo.Infrastructure;

namespace PrismDemo
{
    public class Bootstrapper: UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window) Shell;
            App.Current.MainWindow.Show();
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel),Container.Resolve<StackPanelRegionAdapter>());
            return mappings;
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = (ModuleCatalog) this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(ModuleAModule));


            //Type moduleAType = typeof(ModuleAModule);
            //ModuleCatalog.AddModule(new ModuleInfo()
            //{
            //    ModuleName = moduleAType.Name,
            //    ModuleType = moduleAType.AssemblyQualifiedName,
            //    InitializationMode = InitializationMode.OnDemand

            //});
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    //return new DirectoryModuleCatalog()
        //    //{
        //    //    ModulePath = @".\Modules"
        //    //};


        //    //create model catalog using XAMML
        //    //return Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(
        //    //    new Uri("/PrismDemo;component/xamlCatalog.xaml",UriKind.Relative));
        //}
    }
}
