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
    public class CategoryService : IService<CategoryDTO>
    {
        IRepository<Category> categoryRepository;
        IUnitOfWork unitOfWork;
        IMapper mapper;
        public CategoryService(IRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
            });
            mapper = new Mapper(config);
        }
        public CategoryDTO CreateOrUpdate(CategoryDTO entity)
        {
            var category = mapper.Map<Category>(entity);
            categoryRepository.CreateOrUpdate(category);
            unitOfWork.Save();
            return mapper.Map<CategoryDTO>(category);
        }

        public CategoryDTO Get(int id)
        {
            return mapper.Map<CategoryDTO>(categoryRepository.Get(id));
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            return mapper.Map<IEnumerable<CategoryDTO>>(categoryRepository.GetAll());
        }

        public void Remove(CategoryDTO entity)
        {
            var category = categoryRepository.Get(entity.CategoryId);
            categoryRepository.Remove(category);
            unitOfWork.Save();
        }
    }
}
