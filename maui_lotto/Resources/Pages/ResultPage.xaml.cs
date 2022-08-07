namespace maui_lotto.Resources.Pages;

public partial class ResultPage : ContentPage
{
	public ResultPage(ResultViewModel viewMdoel)
	{
		InitializeComponent();
		BindingContext = viewMdoel;
	}
}