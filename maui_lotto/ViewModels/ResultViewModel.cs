﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_lotto.Models;
using System.Windows.Input;
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

            LoadCommand = new AsyncRelayCommand(async () =>
            {
                await Task.Delay(500);
                if(_resultList == null)
                    ResultList = Initialize();                
            });
        }
      

        List<LottoResult> Initialize()
        {            
            var list = lottoResult.OrderByDescending(x => x.drwNo).ToList();

            Brush NumberToBrushConvert(int num)
            {
                Brush brush = Colors.White;
                if (num <= 10)
                    brush = Color.FromArgb("#FBC400");
                else if (num <= 20)
                    brush = Color.FromArgb("#1E47D6");
                else if (num <= 30)
                    brush = Color.FromArgb("#FF7272");
                else if (num <= 40)
                    brush = Color.FromArgb("#1E1E1E");
                else
                    brush = Color.FromArgb("#55B155");

                return brush;
            }

            int index = 0;
            foreach (var row in list)
            {
                row.color1 = NumberToBrushConvert(row.drwtNo1);
                row.color2 = NumberToBrushConvert(row.drwtNo2);
                row.color3 = NumberToBrushConvert(row.drwtNo3);
                row.color4 = NumberToBrushConvert(row.drwtNo4);
                row.color5 = NumberToBrushConvert(row.drwtNo5);
                row.color6 = NumberToBrushConvert(row.drwtNo6);
                row.colorBonus = NumberToBrushConvert(row.bnusNo);

                if (index % 2 == 0)
                    row.bgColor = Color.FromArgb("#D3D3D3");
                else
                    row.bgColor = Colors.White;

                index++;
            }

            return list;
        }

        public ICommand LoadCommand { get; protected set; }


        private static List<LottoResult> _resultList;
        public List<LottoResult> ResultList
        {
            get { return _resultList; }
            set { _resultList = value; OnPropertyChanged(); }
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
