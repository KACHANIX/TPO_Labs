using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using TPO_Lab3_Mobile.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPO_Lab3_Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainAlmsgivingsPage : ContentPage
    { 
        private readonly HttpClient _client = new HttpClient();
        public ObservableCollection<AlmsgivingsEntity> Alms { get; set; }
        private string _searchString;

        public MainAlmsgivingsPage()
        {
            var httpResponse = _client.GetAsync(Links.AlmsLink + "all").Result;
            Alms = JsonConvert.DeserializeObject<ObservableCollection<AlmsgivingsEntity>>(httpResponse.Content.ReadAsStringAsync().Result); 
            InitializeComponent();
            BindingContext = this;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _searchString = e.NewTextValue;
        }

        private void Update() // MASSIVE FUCKING CRUTCH
        {
            var listView = this.FindByName<ListView>("ListView");
            var itemsSource = listView.ItemsSource;
            listView.ItemsSource = null;
            listView.ItemsSource = Alms;
        }

        private async void SearchBar_OnSearchButtonPressed(object sender, EventArgs e)
        {
            var json = JsonConvert.SerializeObject(new StringCarrier()
            {
                SearchString = _searchString
            });

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync(Links.AlmsLink + "search", httpContent);
            Alms = new ObservableCollection<AlmsgivingsEntity>();
            Alms = JsonConvert.DeserializeObject<ObservableCollection<AlmsgivingsEntity>>(httpResponse.Content.ReadAsStringAsync()
                .Result);
            Update();
        }
    }
}