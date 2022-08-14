namespace maui_lotto.Views;

public partial class ResultPage : ContentPage
{
	public ResultPage(ResultViewModel viewMdoel)
	{
		InitializeComponent();
		BindingContext = viewMdoel;
	}
}