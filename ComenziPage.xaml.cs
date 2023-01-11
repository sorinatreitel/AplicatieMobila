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