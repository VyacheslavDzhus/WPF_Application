using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GameDTO
    {
        public int GameId { get; set; }
        public string GameName { get; set; }

        public int? ManufacturerId { get; set; }

        public int? CategoryId { get; set; }

        public double Price { get; set; }
      
        public string Description { get; set; }

        public double Popularity { get; set; }     
        public string ReleaseDate { get; set; }           
        public string ImagePath { get; set; }

        public string ManufacturerName { get; set; }
        public string CategoryName { get; set; }

        public override string ToString()
        {
            return GameName;
        }
    }
}
