using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_lotto.Converters;
using maui_lotto.Models;
using System.Windows.Input;
using VijayAnand.MauiToolkit.Core.Services;
using VijayAnand.MauiToolkit.Services;
using VijayAnand.Toolkit.ObjectModel;

namespace maui_lotto.ViewModels
{
    public partial class ResultViewModel : BaseViewModel
    {
        PrizeMoneyToMillionConverter PrizeMoneyToMillionConverter = new PrizeMoneyToMillionConverter();
        LottoNumColorConverter LottoNumColorConverter = new LottoNumColorConverter();

        public ResultViewModel()
        {
            Title = "당첨결과";
            AppearingCommand = new AsyncRelayCommand(async () =>
            {
                if (isAppearing)
                    return;

                IsBusy = true;
                Initialize();
                IsBusy = false;

                isAppearing = true;
            });
        }


        void Initialize()
        {
            if(ResultList == null)
            {
                var list = lottoResult.OrderByDescending(x => x.drwNo).ToList();

                int count = 0;
                foreach (var row in list)
                {
                    row.color1 = (Brush)LottoNumColorConverter.Convert(row.drwtNo1, null, null, null);
                    row.color2 = (Brush)LottoNumColorConverter.Convert(row.drwtNo2, null, null, null);
                    row.color3 = (Brush)LottoNumColorConverter.Convert(row.drwtNo3, null, null, null);
                    row.color4 = (Brush)LottoNumColorConverter.Convert(row.drwtNo4, null, null, null);
                    row.color5 = (Brush)LottoNumColorConverter.Convert(row.drwtNo5, null, null, null);
                    row.color6 = (Brush)LottoNumColorConverter.Convert(row.drwtNo6, null, null, null);
                    row.colorBonus = (Brush)LottoNumColorConverter.Convert(row.bnusNo, null, null, null);

                    if (count % 2 == 0)
                        row.bgColor = Color.FromArgb("#D3D3D3");
                    else
                        row.bgColor = Colors.White;

                    row.prizeMoney = PrizeMoneyToMillionConverter.Convert(row.firstWinamnt, null, null, null)?.ToString();
                    count++;
                }

                ResultList = list;
            }
        }


        private static List<LottoResult> _resultList;
        public List<LottoResult> ResultList
        {
            get { return _resultList; }
            set { _resultList = value; OnPropertyChanged(); }
        }


        



    }
}
