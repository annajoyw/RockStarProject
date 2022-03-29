using RockStarProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockStarProject.MVVM
{
    public class PropertiesViewModel : Notifiable
    {
        #region Slider Values
        private int metalnessSliderValue = 5;
        public int MetalnessSliderValue
        {
            get { return metalnessSliderValue; }
            set { metalnessSliderValue = value; OnPropertyChanged(); }
        }
        private int sheenSliderValue = 5;
        public int SheenSliderValue
        {
            get { return sheenSliderValue; }
            set { sheenSliderValue = value; OnPropertyChanged(); }
        }
        private int porositySliderValue = 5;
        public int PorositySliderValue
        {
            get { return porositySliderValue; }
            set { porositySliderValue = value; OnPropertyChanged(); }
        }
        private int translucencySliderValue = 5;
        public int TranslucencySliderValue
        {
            get { return translucencySliderValue; }
            set { translucencySliderValue = value; OnPropertyChanged(); }
        }
        #endregion

        public PropertiesViewModel()
        {

        }
    }
}
