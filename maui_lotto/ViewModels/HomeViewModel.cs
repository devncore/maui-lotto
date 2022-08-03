using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_lotto.Models;
using maui_lotto.Util;
using maui_lotto.Resources.Pages;
using VijayAnand.MauiToolkit.Core.Services;
using VijayAnand.MauiToolkit.Services;
using VijayAnand.Toolkit.ObjectModel;

namespace maui_lotto.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        readonly IDialogService? dialogService;

        public HomeViewModel()
        {
            Title = "Maui-Lotto";
            dialogService = AppService.GetService<IDialogService>();

            InitializeMainMenuList();

            lottoResult = LottoUtil.GetAllLottoResult();
            lastResult = lottoResult.LastOrDefault();
        }

        [ObservableProperty]
        private LottoResult lastResult;


        [ObservableProperty]
        private List<MainListMenu> menuMyLotto;
        [ObservableProperty]
        private List<MainListMenu> menuGenerateLotto;
        [ObservableProperty]
        private List<MainListMenu> menuAnalysisLotto;


        private MainListMenu _MenuMyLottoSelected;
        public MainListMenu MenuMyLottoSelected
        {
            get { return _MenuMyLottoSelected; }
            set 
            { 
                _MenuMyLottoSelected = value; 
                if(value != null)
                {
                    string route = value.Route;
                    _MenuMyLottoSelected = null;
                    OnPropertyChanged();
                    NavigationPage(route);
                }
            }
        }

        void NavigationPage(string route)
        {
            switch(route)
            {
                case "//result":
                    App.Current.MainPage.Navigation.PushAsync(new ResultPage());
                    //Shell.Current.GoToAsync(route);
                    break;
                default:
                    break;
            }
        }



        private void InitializeMainMenuList()
        {
            menuMyLotto = new List<MainListMenu>();
            menuGenerateLotto = new List<MainListMenu>();
            menuAnalysisLotto = new List<MainListMenu>();

            menuMyLotto.Add(new MainListMenu { Name = "당첨번호 & 당첨금", ImageUrl = "magnifier.png", Route = "//result" });
            menuMyLotto.Add(new MainListMenu { Name = "구입번호 직접입력", ImageUrl = "write_pen.png" });
            menuMyLotto.Add(new MainListMenu { Name = "휴지통", ImageUrl = "trash.png" });

            menuGenerateLotto.Add(new MainListMenu { Name = "생성번호목록", ImageUrl = "hamburger_menu.png" });
            menuGenerateLotto.Add(new MainListMenu { Name = "랜덤생성", ImageUrl = "random.png" });
            menuGenerateLotto.Add(new MainListMenu { Name = "직접생성", ImageUrl = "create.png" });


            menuAnalysisLotto.Add(new MainListMenu { Name = "반복출현번호", ImageUrl = "patten.png" });
            menuAnalysisLotto.Add(new MainListMenu { Name = "동반출현번호", ImageUrl = "same.png" });
            menuAnalysisLotto.Add(new MainListMenu { Name = "번호별 출현횟수", ImageUrl = "count.png" });
            menuAnalysisLotto.Add(new MainListMenu { Name = "패턴분석표", ImageUrl = "table.png" });
        }


        //[RelayCommand]
        //async void Test()
        //{
        //    if (dialogService is not null)
        //    {
        //        if (await dialogService.DisplayAlertAsync("Quit!", "Are you sure?", "Yes", "No"))
        //        {
        //            Application.Current?.Quit();
        //        }
        //    }
        //}

        //[RelayCommand]
        //private async Task Quit()
        //{
        //    //if (dialogService is not null)
        //    //{
        //    //    if (await dialogService.DisplayAlertAsync("Quit!", "Are you sure?", "Yes", "No"))
        //    //    {
        //    //        Application.Current?.Quit();
        //    //    }
        //    //}
        //}



    }
}
