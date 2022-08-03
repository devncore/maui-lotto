using maui_lotto.Resources.Pages;

namespace maui_lotto;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //App.Current.UserAppTheme = AppTheme.Light;
        MainPage = new NavigationPage(new HomePage());
    }
}
