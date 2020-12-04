using BLL.Modules;
using FinalProject.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure
{
    class ViewModelsLocator
    {
        IKernel kernel;
        public ViewModelsLocator() => kernel = new StandardKernel(new ServiceModule());
        public MainViewModel MainViewModel => kernel.Get<MainViewModel>();
       

    }
}
