using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TallerAPI.Xamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TallerAPI.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public ListViewPage1()
        {
            InitializeComponent();
            CargarPublicaciones();
        }
        private async Task CargarPublicaciones()
        {
            HttpClient cliente = new HttpClient();

            //Se especifica el al cual se le realizaran los request
            cliente.BaseAddress = new Uri("http://172.16.21.9");
            var request =  await cliente.GetAsync("/Publicacion/api/Publicacion");
            if (request.IsSuccessStatusCode)
            {
                var responseJSON = await request.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<List<Publicacion>>(responseJSON);
                MyListView.ItemsSource = respuesta;
            }
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Elemento seleccionado", ":)", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;        
        }
    }
}
