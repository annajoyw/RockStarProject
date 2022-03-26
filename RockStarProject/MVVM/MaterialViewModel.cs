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

        private string materialName = "Blue Agate";
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
        private string imageSourceMaterialBall = "../../Images/Blue_agate/material_ball.png";
        public string ImageSourceMaterialBall
        {
            get
            {
                return imageSourceMaterialBall;
            }
            set
            {
                imageSourceMaterialBall = value;
                OnPropertyChanged();
            }
        }

        private void MaterialChanged(object param)
        {
            MaterialName = (string)param;
            switch (MaterialName)
            {
                case "Blue Agate":
                    ImageSourceMaterialBall = "../../Images/Blue_agate/material_ball.png";
                        break;
                case "Copper":
                    ImageSourceMaterialBall = "../../Images/Copper/material_ball.png";
                    break;
                case "Gold":
                    ImageSourceMaterialBall = "../../Images/Gold/material_ball.png";
                    break;
                case "Onyx":
                    ImageSourceMaterialBall = "../../Images/Onyx/material_ball.png";
                    break;
                case "Stone":
                    ImageSourceMaterialBall = "../../Images/Stone/material_ball.png";
                    break;
            }
        }

        public MaterialViewModel()
        {

        }

        
    }
}
