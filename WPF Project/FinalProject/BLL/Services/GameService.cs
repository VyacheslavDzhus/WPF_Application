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
    public class GameService : IService<GameDTO>
    {
        IRepository<Game> gameRepository;
        IUnitOfWork unitOfWork;
        IMapper mapper;
        public GameService(IRepository<Game> gameRepository, IUnitOfWork unitOfWork)
        {
            this.gameRepository = gameRepository;
            this.unitOfWork = unitOfWork;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Game, GameDTO>()
                .ForMember(x=>x.ManufacturerName , y => y.MapFrom(source => source.Manufacturer.ManufacturerName))
                .ForMember(x => x.CategoryName, y => y.MapFrom(source => source.Category.CategoryName))
                .ReverseMap();               
            });
            mapper = new Mapper(config);
        }
        public GameDTO CreateOrUpdate(GameDTO entity)
        {
            var game = mapper.Map<Game>(entity);
            gameRepository.CreateOrUpdate(game);
            unitOfWork.Save();
            return mapper.Map<GameDTO>(game);
        }

        public GameDTO Get(int id)
        {
            return mapper.Map<GameDTO>(gameRepository.Get(id));
        }

        public IEnumerable<GameDTO> GetAll()
        {
            return mapper.Map<IEnumerable<GameDTO>>(gameRepository.GetAll());
        }

        public void Remove(GameDTO entity)
        {
           
            var game = gameRepository.Get(entity.GameId);
            gameRepository.Remove(game);
            unitOfWork.Save();
        }
    }
}
