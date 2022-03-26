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
        #region Commands

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

        private ICommand getNextTextureCommand;
        public ICommand GetNextTextureCommand
        {
            get
            {
                if (getNextTextureCommand == null)
                    getNextTextureCommand = new RelayCommand(p => GetNextTexture(p));
                return getNextTextureCommand;
            }
        }

        #endregion

        #region Model Properties

        public MaterialModel MaterialModel { get; set; } = new MaterialModel();

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

        private string materialName = "Blue Agate";
        public string MaterialName
        {
            get
            {
                return materialName;
            }
            set
            {
                if (materialName == value)
                    return;
                materialName = value;
                OnPropertyChanged();
                GetNextTexture(null);
            }
        }

        #endregion

        #region View Properties

        private string imageSourceMaterialBall = "../../Images/Blue_agate/material_ball.png";
        public string ImageSourceMaterialBall
        {
            get
            {
                return imageSourceMaterialBall;
            }
            set
            {
                if (imageSourceMaterialBall == value)
                    return;
                imageSourceMaterialBall = value;
                OnPropertyChanged();
            }
        }
        private string imageSourceTexture = "../../Images/Blue_agate/normal.png";
        public string ImageSourceTexture
        {
            get
            {
                return imageSourceTexture;
            }
            set
            {
                if (imageSourceTexture == value)
                    return;
                imageSourceTexture = value;
                OnPropertyChanged();
            }
        }

        private string textureLable = "Normal";
        public string TextureLable
        {
            get
            {
                return textureLable;
            }
            set
            {
                if (textureLable == value)
                    return;
                textureLable = value;
                OnPropertyChanged();

            }
        }

        #endregion

        #region Methods

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

        private void GetNextTexture(object param)
        {
            var material = MaterialName;
            if (material == "Blue Agate")
                material = "Blue_agate";

            var currentTexture = ImageSourceTexture.Substring(ImageSourceTexture.Length - 10);

            if (!ImageSourceTexture.Contains(material))
            {
                ImageSourceTexture = "../../Images/" + material + "/normal.png";
                TextureLable = "Normal";
                return;
            }
                
            if (currentTexture == "normal.png")
            {
                ImageSourceTexture = "../../Images/" + material + "/material.png";
                TextureLable = "Material";
                return;
            }

            else if (currentTexture == "terial.png")
            {
                ImageSourceTexture = "../../Images/" + material + "/albedo.png";
                TextureLable = "Albedo";
                return;
            }

            else if (currentTexture == "albedo.png")
            {
                ImageSourceTexture = "../../Images/" + material + "/normal.png";
                TextureLable = "Normal";
                return;
            }
        }

        #endregion

        #region Constructor

        public MaterialViewModel()
        {

        }

        #endregion
    }
}
