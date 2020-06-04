using System;
using System.Collections.ObjectModel;
using TPO_Lab3_Mobile.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPO_Lab3_Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BearerPage : ContentPage
    {
        private readonly int _bearerId;
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public ObservableCollection<AlmsgivingsEntity> Almsgivings { get; set; }

        public BearerPage(int id)
        {
            _bearerId = id;
            var asd = HttpService.Get<BearerProfile>(Links.BearerLink + $"get-profile/{id}");
            Nickname = asd.Nickname;
            Phone = asd.Phone;
            Almsgivings = new ObservableCollection<AlmsgivingsEntity>(asd.Almsgivings);

            InitializeComponent();
            BindingContext = this;


            if (!CurrentUser.IsSigned || CurrentUser.CurrentId != _bearerId)
            {
                this.FindByName<Button>("AddBtn").IsVisible = false;
            }
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelected = ((AlmsgivingsEntity) ((ListView) sender).SelectedItem).Id;
            await Navigation.PushAsync(new AlmsgivingPage(itemSelected));
        }

        private void Add_OnClicked(object sender, EventArgs e)
        {
            var a = _bearerId;
            throw new NotImplementedException(); //TODO: Add AddAlmsPage
        }
    }
}