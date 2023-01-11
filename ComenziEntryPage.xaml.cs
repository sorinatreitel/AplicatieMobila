using AplicatieMobila.Models;

namespace AplicatieMobila;

public partial class ComenziEntryPage : ContentPage
{
	public ComenziEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetComenzisAsync();
    }
    async void OnComenziAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ComenziPage
        {
            BindingContext = new Comenzi()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ComenziPage
            {
                BindingContext = e.SelectedItem as Comenzi
            });
        }
    }
}