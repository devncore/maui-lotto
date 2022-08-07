

using System.Windows.Input;

namespace VijayAnand.Toolkit.ObjectModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;


        public ICommand AppearingCommand { get; set; }

        public bool isAppearing { get; set; }




        [ObservableProperty]
        public static List<LottoResult> lottoResult = new();
    }
}
