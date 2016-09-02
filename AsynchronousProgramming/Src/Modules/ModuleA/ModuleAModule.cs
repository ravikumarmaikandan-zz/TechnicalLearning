using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using PrismDemo.Infrastructure;

namespace ModuleA
{
    //[Module(ModuleName = "ModuleA",OnDemand = true)]
    //[ModuleDependency("")]
    public class ModuleAModule: IModule
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        public ModuleAModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }
        public void Initialize()
        {
            //This code is for having the items control for toolbar in the shell,
            //the corresponding region injection will be done as given below.
            IRegion region = _regionManager.Regions[RegionNames.ToolbarRegion];
            region.Add(_container.Resolve<ToolBarview>());
            region.Add(_container.Resolve<ToolBarview>());
            region.Add(_container.Resolve<ToolBarview>());
            region.Add(_container.Resolve<ToolBarview>());
            region.Add(_container.Resolve<ToolBarview>());

            //This code is for having the content control for toolbar in the shell,
            //the corresponding region injection will be done as given below
            //Register regions here
            //_regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolBarview));

            _regionManager.RegisterViewWithRegion(RegionNames.ContentReion, typeof(ContentView));

        }
    }
}
