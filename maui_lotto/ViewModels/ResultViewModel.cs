using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_lotto.Models;
using VijayAnand.MauiToolkit.Core.Services;
using VijayAnand.MauiToolkit.Services;
using VijayAnand.Toolkit.ObjectModel;

namespace maui_lotto.ViewModels
{
    public partial class ResultViewModel : BaseViewModel
    {
        readonly IDialogService? dialogService;

        public ResultViewModel()
        {
            Title = "당첨결과";
            dialogService = AppService.GetService<IDialogService>();

            resultList = lottoResult.OrderByDescending(x => x.drwNo).ToList();
        }


        [ObservableProperty]
        private List<LottoResult> resultList;

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
