using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using UnitsNet;

namespace MauiVerter.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ConverterViewModel
    {
        public string QuantityName { get; set; }
        public ObservableCollection<string> FromMeasures { get; set; }
        public ObservableCollection<string> ToMeasures { get; set; }

        public string CurrentFromMeasure { get; set; }
        public string CurrentToMeasure { get; set; }

        public double FromValue { get; set; } = 1;

        public double ToValue { get; set; }

        public ICommand ReturnCommand => new Command(() => Convert());

        public ConverterViewModel(string quiantiyName)
        {
            QuantityName = quiantiyName;
            FromMeasures = LoadMeasures();
            ToMeasures = LoadMeasures();

            CurrentFromMeasure = FromMeasures.FirstOrDefault();
            CurrentToMeasure = ToMeasures.Skip(1).FirstOrDefault();
            Convert();
        }

        public void Convert()
        {
            var result = UnitConverter.ConvertByName(FromValue, QuantityName, CurrentFromMeasure, CurrentToMeasure);
            ToValue = result;
        }

        private ObservableCollection<string> LoadMeasures()
        {
            var types = Quantity.Infos.FirstOrDefault(x => x.Name == QuantityName)?.UnitInfos.Select(u => u.Name).ToList();
            return types != null ? new ObservableCollection<string>(types) : new ObservableCollection<string>();
        }
    }
}