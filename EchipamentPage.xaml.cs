using AplicatieMobila.Models;

namespace AplicatieMobila;

public partial class EchipamentPage : ContentPage
{
    Comenzi sl;

    public EchipamentPage(Comenzi slist)
	{
		InitializeComponent();
        sl = slist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var product = (Echipament)BindingContext;
        await App.Database.SaveEchipamentAsync(product);
        listView.ItemsSource = await App.Database.GetEchipamenteAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var product = (Echipament)BindingContext;
        await App.Database.DeleteEchipamentAsync(product);
        listView.ItemsSource = await App.Database.GetEchipamenteAsync();
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetEchipamenteAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Echipament p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Echipament;
            var lp = new ListEchipament()
            {
                ComenziID = sl.ID,
                EchipamentID = p.ID
            };
            await App.Database.SaveListEchipamentAsync(lp);
            p.ListEchipamente = new List<ListEchipament> { lp };
            await Navigation.PopAsync();
        }
    }

}