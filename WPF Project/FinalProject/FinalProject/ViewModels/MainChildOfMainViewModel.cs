using BLL.DTO;
using FinalProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FinalProject.ViewModels
{
    class MainChildOfMainViewModel : BaseNotifyPropertyChanged
    {

        #region Commands
        public ICommand SortCommand { get; set; }
        public ICommand ChangeThemeCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }

        #endregion

        ObservableCollection<ManufacturerDTO> manufacturers;
        ObservableCollection<CategoryDTO> categories;
        ObservableCollection<GameDTO> games;
        public ObservableCollection<GameDTO> Games
        {
            get => games;
            set
            {
                games = value;
                Notify();
            }
        }

        public ObservableCollection<CategoryDTO> Categories
        {
            get => categories;
            set
            {

                categories = value;
              
                Notify();
            }
        }
        public ObservableCollection<ManufacturerDTO> Manufacturers
        {
            get => manufacturers;
            set
            {
                manufacturers = value;
                Notify();
            }
        } 

        private GameDTO selectedGame;
        public GameDTO SelectedGame
        {
            get
            {               
                return selectedGame;
            }
            set
            {
                selectedGame = value;     
                MainViewProxy.Proxy.SelectedGame = selectedGame;
                Notify();
            }
        }

        ResourceDictionary theme;
        public MainChildOfMainViewModel()
        {
            Games = MainViewProxy.Proxy.Games;
            Categories = MainViewProxy.Proxy.Categories;
            Manufacturers = MainViewProxy.Proxy.Manufacturers;
            InitCommands();
        }
        private void InitCommands()
        {
            theme = new ResourceDictionary();
            ChangeThemeCommand = new RelayCommand(x =>
            {
                string themeName = x as string;
                theme.Source = new Uri($"{Environment.CurrentDirectory}\\{themeName}Theme.xaml");
                System.Windows.Application.Current.Resources = theme;
            });

            SortCommand = new RelayCommand(x =>
            {
                string param = x as string;
                if (param == "ID")
                {
                    Games = new ObservableCollection<GameDTO>(Games.OrderByDescending(y => y.GameId));
                    MainViewProxy.Proxy.Games = Games;
                }                   
                else if (param == "Title")
                {
                    Games = new ObservableCollection<GameDTO>(Games.OrderByDescending(y => y.GameName));
                    MainViewProxy.Proxy.Games = Games;
                }
                   
                else if (param == "Popularity")
                {
                    Games = new ObservableCollection<GameDTO>(Games.OrderByDescending(y => y.Popularity));
                    MainViewProxy.Proxy.Games = Games;
                }                 
                else if (param == "Price")
                {
                    Games = new ObservableCollection<GameDTO>(Games.OrderByDescending(y => y.Price));
                    MainViewProxy.Proxy.Games = Games;
                }
                   
            });
            AddCommand = new RelayCommand(x =>
            {
                Games.Add(new GameDTO { CategoryId = 1, ImagePath = "/images/gta5.jpg" });
            });
            RemoveCommand = new RelayCommand(x =>
            {                
                MainViewProxy.Proxy.RemovedElements.Add(SelectedGame.GameId);
                Games.Remove(SelectedGame);                
            });
        }

    }
}
