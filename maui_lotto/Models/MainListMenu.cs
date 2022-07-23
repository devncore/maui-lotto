using maui_lotto.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_lotto.Models
{
    public class MainListMenu : ViewModelBase
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Route { get; set; }

        private Color selectedBackgroundColor = Color.FromHex("#f0f0f0");

        public Color SelectedBackgroundColor
        {
            set
            {
                if (selectedBackgroundColor != value)
                {
                    selectedBackgroundColor = value;
                    OnPropertyChanged("SelectedBackgroundColor");
                }
            }
            get
            {
                return selectedBackgroundColor;
            }
        }
      
    }
}
