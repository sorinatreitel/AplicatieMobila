using AplicatieMobila.Models;
namespace AplicatieMobila;

public partial class MagazinPage : ContentPage
{
	public MagazinPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var shop = (Magazin)BindingContext;
        await App.Database.SaveMagazinAsync(shop);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var shop = (Magazin)BindingContext;
        await App.Database.DeleteMagazinAsync(shop);
        await Navigation.PopAsync();
    }
}