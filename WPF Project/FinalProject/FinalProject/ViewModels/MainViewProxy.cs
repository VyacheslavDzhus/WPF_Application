using BLL.DTO;
using FinalProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.ViewModels
{
    class MainViewProxy 
    {
        private static MainViewProxy proxy;

        public string StartUpKey { get; set; }
        public string Language { get; set; }
        public List<int> RemovedElements { get; set; } = new List<int>();
        public GameDTO SelectedGame { get; set; }


        public ObservableCollection<GameDTO> Games { get; set; }
      

        public ObservableCollection<CategoryDTO> Categories { get; set; }
        
    
        public ObservableCollection<ManufacturerDTO> Manufacturers { get; set; }
       

        public static MainViewProxy Proxy => proxy ?? (proxy = new MainViewProxy());
    }
}
