using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using TPO_Lab3_Mobile.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPO_Lab3_Mobile
{
    public enum Filter
    {
        None,
        Food,
        Clothes,
        Furniture,
        Other
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainAlmsgivingsPage : ContentPage
    {
        private readonly HttpClient _client = new HttpClient();
        public ObservableCollection<AlmsgivingsEntity> Alms { get; set; }
        private ObservableCollection<AlmsgivingsEntity> _initialAlms;
        private string _searchString;
        private Filter _currentFilter;
        public MainAlmsgivingsPage()
        {
            InitializeComponent();
            BindingContext = this;
            InitializeProperties();
        }

        private void InitializeProperties()
        {
            _initialAlms = HttpService.Get<ObservableCollection<AlmsgivingsEntity>>(Links.AlmsLink + "all");
            _currentFilter = Filter.None;
            Alms = _initialAlms;
            Update();
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _searchString = e.NewTextValue;
            if (string.IsNullOrWhiteSpace(_searchString))
            {
                InitializeProperties();
            }
        }

        private void Update() // MASSIVE FUCKING CRUTCH
        {
            var listView = this.FindByName<ListView>("ListView");
            listView.ItemsSource = null;
            listView.ItemsSource = Alms;
        }

        private async void SearchBar_OnSearchButtonPressed(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(_searchString))
            {
                return;
            }
            var asd = new StringCarrier()
            {
                SearchString = _searchString
            };
            var link = Links.AlmsLink + "search";
            _initialAlms = await HttpService.Post<ObservableCollection<AlmsgivingsEntity>, StringCarrier>(asd, link);
            Alms = _initialAlms;

            //
            // var json = JsonConvert.SerializeObject(asd);
            // var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            // var httpResponse = await _client.PostAsync(link, httpContent);
            // Alms = new ObservableCollection<AlmsgivingsEntity>();
            // Alms = JsonConvert.DeserializeObject<ObservableCollection<AlmsgivingsEntity>>(httpResponse.Content
            //     .ReadAsStringAsync()
            //     .Result);
            Update();
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelected = ((AlmsgivingsEntity) ((ListView) sender).SelectedItem).Id;
            await Navigation.PushAsync(new AlmsgivingPage(itemSelected));
        }

        private void SortBtn_OnClicked(object sender, EventArgs e)
        {
            overlaySort.IsVisible = true;
        }

        private void DescBtn_OnClicked(object sender, EventArgs e)
        {
            Alms = new ObservableCollection<AlmsgivingsEntity>(Alms.OrderByDescending(alm => alm.Date));
            overlaySort.IsVisible = false;
            Update();
        }

        private void AscBtn_OnClicked(object sender, EventArgs e)
        {
            Alms = new ObservableCollection<AlmsgivingsEntity>(Alms.OrderBy(alm => alm.Date));
            overlaySort.IsVisible = false;
            Update();
        }

        private void FilterBtn_OnClicked(object sender, EventArgs e)
        {
            overlayFilter.IsVisible = true;
        }


        private void ClothesBtn_OnClicked(object sender, EventArgs e)
        {
            if (_currentFilter != Filter.Clothes)
            {
                Alms = new ObservableCollection<AlmsgivingsEntity>(_initialAlms.Where(alm => alm.Type == "clothes"));
                _currentFilter = Filter.Clothes;
            }
            else
            {
                Alms = _initialAlms;
                _currentFilter = Filter.None;
            }
            overlayFilter.IsVisible = false;
            Update();
        }

        private void FoodBtn_OnClicked(object sender, EventArgs e)
        {
            if (_currentFilter != Filter.Food)
            {
                Alms = new ObservableCollection<AlmsgivingsEntity>(_initialAlms.Where(alm => alm.Type == "food"));
                _currentFilter = Filter.Food;
            }
            else
            {
                Alms = _initialAlms;
                _currentFilter = Filter.None;
            }
            overlayFilter.IsVisible = false;
            Update();
        }

        private void FurnitureBtn_OnClicked(object sender, EventArgs e)
        {
            if (_currentFilter != Filter.Furniture)
            {
                Alms = new ObservableCollection<AlmsgivingsEntity>(_initialAlms.Where(alm => alm.Type == "furniture"));
                _currentFilter = Filter.Furniture;
            }
            else
            {
                Alms = _initialAlms;
                _currentFilter = Filter.None;
            } 
            overlayFilter.IsVisible = false;
            Update();
        }

        private void OtherBtn_OnClicked(object sender, EventArgs e)
        {
            if (_currentFilter != Filter.Other)
            {
                Alms = new ObservableCollection<AlmsgivingsEntity>(_initialAlms.Where(alm => alm.Type == "other"));
                _currentFilter = Filter.Other;
            }
            else
            {
                Alms = _initialAlms;
                _currentFilter = Filter.None;
            }
            Alms = new ObservableCollection<AlmsgivingsEntity>(Alms.Where(alm => alm.Type == "other"));
            overlayFilter.IsVisible = false;
            Update();
        }
    }
}