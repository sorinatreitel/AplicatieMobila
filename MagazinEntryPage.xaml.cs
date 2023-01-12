using AplicatieMobila.Models;

namespace AplicatieMobila;

public partial class MagazinEntryPage : ContentPage
{
	public MagazinEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetMagazineAsync();
    }
    async void OnShopAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MagazinPage
        {
            BindingContext = new Magazin()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new MagazinPage
            {
                BindingContext = e.SelectedItem as Magazin
            });
        }
    }
}