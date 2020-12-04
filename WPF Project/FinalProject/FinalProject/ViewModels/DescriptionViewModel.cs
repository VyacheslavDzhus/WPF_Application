using BLL.DTO;
using FinalProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinalProject.ViewModels
{ 
    
    class DescriptionViewModel : BaseNotifyPropertyChanged
    {
        private GameDTO selectedGame;
        public GameDTO SelectedGame
        {
            get => selectedGame;
            set
            {
                selectedGame = value;
                Notify();
            }
        }
        public DescriptionViewModel()
        {
            SelectedGame = MainViewProxy.Proxy.SelectedGame;
        }

    }
}
