namespace maui_lotto.Controls;

public partial class MainMenu : ContentView
{
	public MainMenu()
	{
		InitializeComponent();
	}
	
	private void MenuSelectedCommand(object sender, EventArgs e)
	{
		MainMenuItem menuItem = ((e as TappedEventArgs).Parameter) as MainMenuItem;
        (BindingContext as HomeViewModel).GoToMenuItemCommandCommand.Execute(menuItem);
	}
}