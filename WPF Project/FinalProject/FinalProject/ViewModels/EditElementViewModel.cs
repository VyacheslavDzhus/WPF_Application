using BLL.DTO;
using FinalProject.Infrastructure;
using Microsoft.Win32;
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
using System.Windows.Input;

namespace FinalProject.ViewModels
{
    class EditElementViewModel : BaseNotifyPropertyChanged
    {

        #region Commands     
        public ICommand EditCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        #endregion

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
                Notify();
            }
        }

        ObservableCollection<ManufacturerDTO> manufacturers;
        ObservableCollection<CategoryDTO> categories;

        private ObservableCollection<double> popularityValues = new ObservableCollection<double>()
        { 0,0.1,0.2,0.3,0.4,0.5,0.6,0.7,0.8,0.9,
          1,1.1,1.2,1.3,1.4,1.5,1.6,1.7,1.8,1.9,
          2,2.1,2.2,2.3,2.4,2.5,2.6,2.7,2.8,2.9,
          3,3.1,3.2,3.3,3.4,3.5,3.6,3.7,3.8,3.9,
          4,4.1,4.2,4.3,4.4,4.5,4.6,4.7,4.8,4.9,
          5,5.1,5.2,5.3,5.4,5.5,5.6,5.7,5.8,5.9,
          6,6.1,6.2,6.3,6.4,6.5,6.6,6.7,6.8,6.9,
          7,7.1,7.2,7.3,7.4,7.5,7.6,7.7,7.8,7.9,
          8,8.1,8.2,8.3,8.4,8.5,8.6,8.7,8.8,8.9,
          9,9.1,9.2,9.3,9.4,9.5,9.6,9.7,9.8,9.9,
          10
        };
        public ObservableCollection<double> PopularityValues
        {
            get => popularityValues;
            set
            {

                popularityValues = value;

                Notify();
            }
        }


        private ObservableCollection<string> dayValues = new ObservableCollection<string>()
        { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10",
          "11", "12","13","14", "15","16","17", "18","19","20", "21",
          "22","23","24","25","26","27","28","29","30","31"
        };
        public ObservableCollection<string> DayValues
        {
            get => dayValues;
            set
            {
                dayValues = value;
                Notify();
            }
        }
        private ObservableCollection<string> monthValues = new ObservableCollection<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        public ObservableCollection<string> MonthValues
        {
            get => monthValues;
            set
            {

                monthValues = value;

                Notify();
            }
        }
        private ObservableCollection<string> yearValues = new ObservableCollection<string>()
        {
          "2000","2001","2002","2003","2004","2005","2006","2007","2008","2009",
          "2010","2011","2012","2013","2014","2015","2016","2017","2018","2020",
          "2021","2022","2023","2024","2025","2026","2027","2028","2029","2030"
        };
        public ObservableCollection<string> YearValues
        {
            get => yearValues;
            set
            {
                yearValues = value;
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


        private string releasedatePartOne;
        public string ReleaseDatePartOne
        {
            get => releasedatePartOne;
            set
            {
                releasedatePartOne = value;
                Notify();
            }
        }
        private string releasedatePartTwo;
        public string ReleaseDatePartTwo
        {
            get => releasedatePartTwo;
            set
            {
                releasedatePartTwo = value;
                Notify();
            }
        }

        private string releasedatePartThree;
        public string ReleaseDatePartThree
        {
            get => releasedatePartThree;
            set
            {
                releasedatePartThree = value;
                Notify();
            }
        }

        public EditElementViewModel()
        {
            Categories = MainViewProxy.Proxy.Categories;
            Manufacturers = MainViewProxy.Proxy.Manufacturers;
            --MainViewProxy.Proxy.SelectedGame.ManufacturerId;
            --MainViewProxy.Proxy.SelectedGame.CategoryId;
            SelectedGame = MainViewProxy.Proxy.SelectedGame;
            var parts = SelectedGame.ReleaseDate.Split('.');
            releasedatePartOne = parts[0];
            releasedatePartTwo = parts[1];
            releasedatePartThree = parts[2];
            InitCommands();                   
        }
        private void InitCommands()
        {


            LoadCommand = new RelayCommand(x =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "jpg (*.jpg)|*.jpg";
                if (openFileDialog.ShowDialog() == true)
                {
                    selectedGame.ImagePath = openFileDialog.FileName;
                }
            });
            EditCommand = new RelayCommand(x =>
            {
                selectedGame.ReleaseDate = $"{ReleaseDatePartOne}.{ReleaseDatePartTwo}.{ReleaseDatePartThree}";
                ++selectedGame.CategoryId;
                ++selectedGame.ManufacturerId;
                MainViewProxy.Proxy.SelectedGame = selectedGame;

                ResourceManager rm = new ResourceManager($"FinalProject.{MainViewProxy.Proxy.Language}", Assembly.GetExecutingAssembly());
                MessageBox.Show($"{rm.GetString("Sucсess", CultureInfo.CurrentCulture)}", $"{rm.GetString("EditData", CultureInfo.CurrentCulture)}");

            });

        }

    }
}
