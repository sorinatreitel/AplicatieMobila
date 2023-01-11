using AplicatieMobila.Models;
using SQLite;
using AplicatieMobila.Data;
namespace AplicatieMobila;

public partial class ComenziPage : ContentPage
{
	public ComenziPage()
	{
		InitializeComponent();
	}
    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        Echipament product;
        var shopList = (Comenzi)BindingContext;
        if (listView.SelectedItem != null)
        {
            product = listView.SelectedItem as Echipament;
            var listProductAll = await App.Database.GetListEchipamente();
            var listProduct = listProductAll.FindAll(x => x.EchipamentID == product.ID & x.ComenziID == shopList.ID);
            await App.Database.DeleteListEchipamentAsync(listProduct.FirstOrDefault());
            await Navigation.PopAsync();
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Comenzi)BindingContext;

        listView.ItemsSource = await App.Database.GetListEchipamenteAsync(shopl.ID);
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EchipamentPage((Comenzi)
       this.BindingContext)
        {
            BindingContext = new Echipament()
        });

    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Comenzi)BindingContext;
        slist.DateComanda = DateTime.UtcNow;
        await App.Database.SaveComenziAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Comenzi)BindingContext;
        await App.Database.DeleteComenziAsync(slist);
        await Navigation.PopAsync();
    }
}