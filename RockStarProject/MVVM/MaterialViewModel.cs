using RockStarProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RockStarProject.MVVM
{
    public class MaterialViewModel : Notifiable
    {

        public MaterialModel MaterialModel { get; set; } = new MaterialModel();

        private ICommand selectedMaterialChangedCommand;
        public ICommand SelectedMaterialChangedCommand
        {
            get
            {
                if (selectedMaterialChangedCommand == null)
                    selectedMaterialChangedCommand = new RelayCommand(p => MaterialChanged(p));
                return selectedMaterialChangedCommand;
            }
        }

        private bool isFavoriteChecked;
        public bool IsFavoriteChecked
        {
            get
            {
                return isFavoriteChecked;
            }
            set
            {
                isFavoriteChecked = value;
                OnPropertyChanged();
                MaterialModel.Name = MaterialName;
                MaterialModel.IsFavorite = value;
                XMLReaderAndWriter.WriteXmlFile(MaterialModel);
            }
        }

        private string materialName = "defualt";
        public string MaterialName
        {
            get
            {
                return materialName;
            }
            set
            {
                materialName = value;
                OnPropertyChanged();
            }
        }
        private string imageSource = "defualt";
        public string ImageSource
        {
            get
            {
                return imageSource;
            }
            set
            {
                imageSource = value;
                OnPropertyChanged();
            }
        }

        private void MaterialChanged(object param)
        {
            MaterialName = (string)param;
            switch (MaterialName)
            {
                case "Blue Agate":
                    imageSource = "add/path/here";
                        break;
                case "Copper":
                    imageSource = "add/path/here";
                    break;
            }
        }

        public MaterialViewModel()
        {

        }

        
    }
}
