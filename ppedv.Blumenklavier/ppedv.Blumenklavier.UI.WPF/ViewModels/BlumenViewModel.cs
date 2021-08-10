using ppedv.Blumenklavier.Logic;
using ppedv.Blumenklavier.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ppedv.Blumenklavier.UI.WPF.ViewModels
{
    public class BlumenViewModel : BaseViewModel
    {
        public ObservableCollection<Blume> BlumenList { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand SetColorToRedCommand { get; set; }

        public Blume SelectedBlume
        {
            get => _selectedBlume;
            set
            {
                _selectedBlume = value;
                OnPropertyChanged(nameof(SelectedBlume));
            }
        }

        Core _core;
        Blume _selectedBlume;

        public BlumenViewModel()
        {
            _core = new Core(new Data.EFCore.EfRepository());
            BlumenList = new ObservableCollection<Blume>(_core.Repository.GetAll<Blume>());
            SelectedBlume = BlumenList.First();

            SaveCommand = new RelayCommand(o => _core.Repository.SaveAll());
            SetColorToRedCommand = new RelayCommand(SetColorToRed);
        }

        private void SetColorToRed(object obj)
        {
            if (SelectedBlume != null)
            {
                SelectedBlume.Farbe = "Red";
                OnPropertyChanged(nameof(SelectedBlume));
            }
        }

    }

}
