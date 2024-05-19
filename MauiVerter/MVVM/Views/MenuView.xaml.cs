using MauiVerter.MVVM.ViewModels;

namespace MauiVerter.MVVM.Views;

public partial class MenuView : ContentPage
{

	public MenuView()
	{
		InitializeComponent();

		BindingContext = new MenuViewModel();
	}

	public void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		var element = (Grid)sender;

		var option = ((Label)element.Children.LastOrDefault()).Text;

		var ConverterView = new ConverterView
		{
			BindingContext = new ConverterViewModel(option)
		};

		Navigation.PushAsync(ConverterView);
	}
}

