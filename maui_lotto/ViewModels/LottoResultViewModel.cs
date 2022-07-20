using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VijayAnand.MauiToolkit.Core.Services;
using VijayAnand.MauiToolkit.Services;
using VijayAnand.Toolkit.ObjectModel;

namespace maui_lotto.ViewModels
{
    public partial class LottoResultViewModel : BaseViewModel
    {
        readonly IDialogService? dialogService;

        public LottoResultViewModel()
        {
            Title = "당첨결과";
            dialogService = AppService.GetService<IDialogService>();
        }

        [RelayCommand]
        async void Test()
        {
            if (dialogService is not null)
            {
                if (await dialogService.DisplayAlertAsync("Quit!", "Are you sure?", "Yes", "No"))
                {
                    Application.Current?.Quit();
                }
            }
        }

        [RelayCommand]
        private async Task Quit()
        {
            //if (dialogService is not null)
            //{
            //    if (await dialogService.DisplayAlertAsync("Quit!", "Are you sure?", "Yes", "No"))
            //    {
            //        Application.Current?.Quit();
            //    }
            //}
        }



    }
}
