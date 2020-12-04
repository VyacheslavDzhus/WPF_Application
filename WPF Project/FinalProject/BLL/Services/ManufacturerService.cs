using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class ManufacturerService : IService<ManufacturerDTO>
    {

        IRepository<Manufacturer> manufacturerRepository;
        IUnitOfWork unitOfWork;
        IMapper mapper;
        public ManufacturerService(IRepository<Manufacturer> manufacturerRepository, IUnitOfWork unitOfWork)
        {
            this.manufacturerRepository = manufacturerRepository;
            this.unitOfWork = unitOfWork;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Manufacturer, ManufacturerDTO>().ReverseMap();
            });
            mapper = new Mapper(config);
        }
        public ManufacturerDTO CreateOrUpdate(ManufacturerDTO entity)
        {
            var manufacturer = mapper.Map<Manufacturer>(entity);
            manufacturerRepository.CreateOrUpdate(manufacturer);
            unitOfWork.Save();
            return mapper.Map<ManufacturerDTO>(manufacturer);
        }

        public ManufacturerDTO Get(int id)
        {
            return mapper.Map<ManufacturerDTO>(manufacturerRepository.Get(id));
        }

        public IEnumerable<ManufacturerDTO> GetAll()
        {
            return mapper.Map<IEnumerable<ManufacturerDTO>>(manufacturerRepository.GetAll());
        }

        public void Remove(ManufacturerDTO entity)
        {
            var manufacturer = manufacturerRepository.Get(entity.ManufacturerId);
            manufacturerRepository.Remove(manufacturer);
            unitOfWork.Save();
        }
    }
}
