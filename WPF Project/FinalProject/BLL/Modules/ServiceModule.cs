using BLL.DTO;
using BLL.Services;
using DAL;
using DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Modules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IService<GameDTO>>().To<GameService>();
            Bind<IRepository<Game>>().To<GameRepository>();
            Bind<IService<CategoryDTO>>().To<CategoryService>();
            Bind<IRepository<Category>>().To<CategoryRepository>();
            Bind<IService<ManufacturerDTO>>().To<ManufacturerService>();
            Bind<IRepository<Manufacturer>>().To<ManufacturerRepository>();
            Bind<DbContext>().To<GameStoreContext>().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();

           
        }
    }
}
