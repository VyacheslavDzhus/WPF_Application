using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure
{
    public class JasonControl<T> where T:class
    {
        public static ObservableCollection<T> GetInfoJSON(string FileName) => new ObservableCollection<T>(JsonConvert.DeserializeObject<ObservableCollection<T>>(File.ReadAllText(FileName)));
        public static void SaveInfoJSON(ObservableCollection<T> data)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "json files (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == true)
            {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }
       
    }
}
