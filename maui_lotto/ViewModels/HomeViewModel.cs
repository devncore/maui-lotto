using VijayAnand.MauiToolkit.Core.Services;
using VijayAnand.MauiToolkit.Services;
using VijayAnand.Toolkit.ObjectModel;

namespace maui_lotto.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        LottoService lottoService;
        public ICommand SelectionCommand { get; set; }

        public HomeViewModel(LottoService lottoService)
        {
            Title = "Maui-Lotto";
            this.lottoService = lottoService;

            InitializeMainMenuList();

            AppearingCommand = new AsyncRelayCommand(async () =>
            {
                // 로드 이벤트를 최초에 한번만 하게 한다.
                if (isAppearing)
                    return;

                isAppearing = true;

                IsBusy = true;
                lottoResult = await lottoService.GetLottoResult();
                LastResult = lottoResult.LastOrDefault();
                IsBusy = false;
            });

            SelectionCommand = new AsyncRelayCommand<object>(GoToMenuItemCommand);
        }
        
        private LottoResult _LastResult;
        public LottoResult LastResult
        {
            get { return _LastResult; }
            set { _LastResult = value; OnPropertyChanged(); }
        }

        private List<object> _MenuItemList;
        public List<object> MenuItemList
        {
            get { return _MenuItemList; }
            set { _MenuItemList = value; OnPropertyChanged(); }
        }

        private MainMenuItem _MenuItemListSelected;
        public MainMenuItem MenuItemListSelected
        {
            get { return _MenuItemListSelected; }
            set
            {
                _MenuItemListSelected = value;
                OnPropertyChanged();                
            }
        }

        async Task GoToMenuItemCommand(object obj)
        {
            if (obj == null)
                return;

            if(obj is MainMenuItem MenuItem)
            {
                switch(MenuItem.Route)
                {
                    
                }
            }
            var item = obj as MainMenuItem;
           
            if (item == null)
                return;

            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(ResultPage), true);
            IsBusy = false;

            //await Shell.Current.GoToAsync(nameof(ResultPage), true, new Dictionary<string, object>
            //{
            //    {"Item", item }
            //});
        }


    


        private void InitializeMainMenuList()
        {
            MenuItemList = new List<object>();
            MenuItemList.Add(new MainMenuItemHeader { Name = "나의 로또" });
            MenuItemList.Add(new MainMenuItem { Name = "당첨번호 & 당첨금", ImageUrl = "magnifier.png", Route = "//result" });
            MenuItemList.Add(new MainMenuItem { Name = "구입번호 직접입력", ImageUrl = "write_pen.png", Route = "//result" });
            MenuItemList.Add(new MainMenuItem { Name = "휴지통", ImageUrl = "trash.png", Route = "//result" });

            MenuItemList.Add(new MainMenuItemHeader { Name = "번호 생성기" });
            MenuItemList.Add(new MainMenuItem { Name = "생성번호목록", ImageUrl = "hamburger_menu.png", Route = "//result" });
            MenuItemList.Add(new MainMenuItem { Name = "랜덤생성", ImageUrl = "random.png", Route = "//result" });
            MenuItemList.Add(new MainMenuItem { Name = "직접생성", ImageUrl = "create.png", Route = "//result" });

            MenuItemList.Add(new MainMenuItemHeader { Name = "번호 분석" });
            MenuItemList.Add(new MainMenuItem { Name = "반복출현번호", ImageUrl = "patten.png", Route = "//result" });
            MenuItemList.Add(new MainMenuItem { Name = "동반출현번호", ImageUrl = "same.png", Route = "//result" });
            MenuItemList.Add(new MainMenuItem { Name = "번호별 출현횟수", ImageUrl = "count.png", Route = "//result" });
            MenuItemList.Add(new MainMenuItem { Name = "패턴분석표", ImageUrl = "table.png", Route = "//result" });
        }


      


    }
}
