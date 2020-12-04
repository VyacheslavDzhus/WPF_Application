using BLL.DTO;
using BLL.Services;
using FinalProject.Infrastructure;
using FinalProject.Views.MainView.MainViewChildren;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace FinalProject.ViewModels
{
    public class MainViewModel : BaseNotifyPropertyChanged
    {

        #region Commands
        public ICommand FirstViewCommand { get; set; }
        public ICommand SecondViewCommand { get; set; }
        public ICommand ThirdViewCommand { get; set; }
        public ICommand FourthViewCommand { get; set; }
        public ICommand FifthViewCommand { get; set; }
        #endregion


        #region UserControls

        private UserControl currentView ; 
        public UserControl CurrentView 
        {
            get
            { 
                if(currentView == null)
                {
                    currentView = new MainChildOfMainView();
                }
                return currentView;
            } 
            set
            {             
                currentView = value;             
                Notify();           
            }
        }

        private UserControl firstView = null;
        #endregion     

        IService<GameDTO> gameService;
        IService<CategoryDTO> categoryService;
        IService<ManufacturerDTO> manufacturerService;


        private CategoryDTO selectedCategory;
        public CategoryDTO SelectedCategory
        {
            get => selectedCategory;

            set
            {
                selectedCategory = value;
                Notify();
            }
        }
        private ManufacturerDTO selectedManufacturer;
        public ManufacturerDTO SelectedManufacturer
        {
            get => selectedManufacturer;

            set
            {
                selectedManufacturer = value;
                Notify();
            }
        }

     
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

        

        public MainViewModel(IService<CategoryDTO> categoryService, IService<ManufacturerDTO> manufacturerService, IService<GameDTO> gameService)
        {
            this.gameService = gameService;
            this.categoryService = categoryService;
            this.manufacturerService = manufacturerService;
            InitCommands();
            InitCollections();

            MainViewProxy.Proxy.Games = Games;
            MainViewProxy.Proxy.Categories = Categories;
            MainViewProxy.Proxy.Manufacturers = Manufacturers;
        }
       
        

        public void InitCollections()
        {
            if(MainViewProxy.Proxy.StartUpKey == "DB")
            {
                Games = new ObservableCollection<GameDTO>(gameService.GetAll());
                Categories = new ObservableCollection<CategoryDTO>(categoryService.GetAll());
                Manufacturers = new ObservableCollection<ManufacturerDTO>(manufacturerService.GetAll());
            }
            else if(MainViewProxy.Proxy.StartUpKey == "File")
            {
                Games = JasonControl<GameDTO>.GetInfoJSON("Games.json");
                Categories = JasonControl<CategoryDTO>.GetInfoJSON("Categories.json");
                Manufacturers = JasonControl<ManufacturerDTO>.GetInfoJSON("Manufacturers.json");
            }        
        }


        private void InitCommands()
        {
            FirstViewCommand = new RelayCommand(x =>
            {              
               CurrentView = firstView ?? (firstView = new MainChildOfMainView());
            });
            SecondViewCommand = new RelayCommand(x =>
            {
                if (MainViewProxy.Proxy.SelectedGame != null)
                    CurrentView = new DescriptionView();
            });
            ThirdViewCommand = new RelayCommand(x =>
            {
                if (MainViewProxy.Proxy.SelectedGame != null)
                    CurrentView = new EditElementView();              
            });
            FourthViewCommand = new RelayCommand(x =>
            {
                CurrentView = new AddElementView();
            });
            FifthViewCommand = new RelayCommand(x =>
            {

                if (MainViewProxy.Proxy.StartUpKey == "DB")
                {
                    for (int i = 0; i < MainViewProxy.Proxy.RemovedElements.Count; i++)
                        gameService.Remove(gameService.Get(MainViewProxy.Proxy.RemovedElements[i]));

                    for (int i = 0; i < Games.Count; i++)
                        gameService.CreateOrUpdate(Games[i]);

                    MainViewProxy.Proxy.RemovedElements.Clear();

                    MessageBox.Show("Succsess");
                }
                else if (MainViewProxy.Proxy.StartUpKey == "File")
                    JasonControl<GameDTO>.SaveInfoJSON(Games);

                ResourceManager rm = new ResourceManager($"FinalProject.{MainViewProxy.Proxy.Language}", Assembly.GetExecutingAssembly());
                MessageBox.Show($"{rm.GetString("Sucсess", CultureInfo.CurrentCulture)}", $"{rm.GetString("SaveData", CultureInfo.CurrentCulture)}");
            });
        }
    }
}
