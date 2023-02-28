namespace Todo.MAUI.Client;

public partial class MainPage : ContentPage {

	public MainPage() {
		InitializeComponent();
		var dict = new Dictionary<string, object>();

		//Handle logged in user as web client??
		RootComponent.Parameters = dict;
	}
}
