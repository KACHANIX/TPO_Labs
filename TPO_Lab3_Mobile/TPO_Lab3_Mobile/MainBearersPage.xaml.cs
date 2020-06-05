using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using TPO_Lab3_Mobile.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPO_Lab3_Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainBearersPage : ContentPage
    {
        private int _bearerId;
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public ObservableCollection<AlmsgivingsEntity> Almsgivings { get; set; }
        public MainBearersPage()
        {

            InitializeComponent();
            if (CurrentUser.CurrentId != 0)
            {
                _bearerId = CurrentUser.CurrentId;
                overlayWelcome.IsVisible = false;
                AddBtn.IsVisible = true;
                Update();
            } 

            BindingContext = this;
        }

        private void Update()
        {
            var asd = HttpService.Get<BearerProfile>(Links.BearerLink + $"get-profile/{_bearerId}");
            Nickname = asd.Nickname;
            Phone = asd.Phone;
            Almsgivings = new ObservableCollection<AlmsgivingsEntity>(asd.Almsgivings);
            name.Text = asd.Nickname;
            phone.Text = asd.Phone;
            ListView.ItemsSource = asd.Almsgivings;
        }

        private async void Add_OnClicked(object sender, EventArgs e)
        { 
            await Navigation.PushAsync(new AddAlmsgivingPage(_bearerId, Nickname, Phone));
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemSelected = ((AlmsgivingsEntity)((ListView)sender).SelectedItem).Id;
            await Navigation.PushAsync(new AlmsgivingPage(itemSelected));
        }


        private void SignInBtn_OnClicked(object sender, EventArgs e)
        {
            overlayWelcome.IsVisible = false;
            overlaySign.IsVisible = true;
        }

        private void SignUpBtn_OnClicked(object sender, EventArgs e)
        {
            overlayWelcome.IsVisible = false;
            overlayRegister.IsVisible = true;
        }

        private async void SignBtn_OnClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(SignNickName.Text))
            {
                SignError.IsVisible = true;
                return;
            }

            var bearer = new BearerInEntity
            {
                Nickname = SignNickName.Text,
                Password = SignPassword.Text
            };
            var answerId = await HttpService.Post<int, BearerInEntity>(bearer, Links.BearerLink + "auth");
            if (answerId == 0)
            {
                SignError.IsVisible = true;
                return;
            }

            _bearerId = answerId;
            CurrentUser.CurrentId = _bearerId;
            CurrentUser.IsSigned = true;
            Update();

            overlaySign.IsVisible = false;
            overlayRegister.IsVisible = false;
            overlayWelcome.IsVisible = false;
        }

        private async void RegBtn_OnClicked(object sender, EventArgs e)
        {
            RegNicknameError.IsVisible = false;
            RegPasswordError.IsVisible = false;
            RegPhoneError.IsVisible = false;

            if (String.IsNullOrWhiteSpace(RegNickname.Text) ||
                RegNickname.Text.Contains(" ") ||
                RegNickname.Text.Contains("/"))
            {
                RegNicknameError.IsVisible = true;
                return;
            }

            var isFree = HttpService.Get<bool>(Links.BearerLink + $"is-free/{RegNickname.Text}");
            if (!isFree)
            {
                RegNicknameError.IsVisible = true;
                return;
            }

            if (String.IsNullOrWhiteSpace(RegPassword.Text) ||
                String.IsNullOrWhiteSpace(RegPasswordConfirmation.Text) ||
                RegPassword.Text != RegPasswordConfirmation.Text)
            {
                RegPasswordError.IsVisible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(RegPhone.Text) ||
                RegPhone.Text.Contains(" ") ||
                RegPhone.Text.Contains("/"))
            {
                RegPhoneError.IsVisible = true;
                return;
            }

            var bearerIn = new BearerInEntity
            {
                Nickname = RegNickname.Text,
                Password = RegPassword.Text,
                Phone = RegPhone.Text
            };
            var answerId = await HttpService.Post<int, BearerInEntity>(bearerIn, Links.BearerLink + "add-bearer");

            _bearerId = answerId;

            CurrentUser.CurrentId = _bearerId;
            CurrentUser.IsSigned = true;
            Update();

            overlaySign.IsVisible = false;
            overlayRegister.IsVisible = false;
            overlayWelcome.IsVisible = false;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            overlaySign.IsVisible = false;
            overlayRegister.IsVisible = false;
            overlayWelcome.IsVisible = true;
        }
    }
}