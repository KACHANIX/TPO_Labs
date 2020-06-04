using System;
using TPO_Lab3_Mobile.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPO_Lab3_Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainBearersPage : ContentPage
    {
        public int BearerId { get; set; }

        public MainBearersPage()
        {
            InitializeComponent();
            BindingContext = this;
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

            BearerId = answerId;
            Update();

            overlaySign.IsVisible = false;
            overlayRegister.IsVisible = false;
            overlayWelcome.IsVisible = false;
        }

        private void Update()
        {
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
            var answer = await HttpService.Post<int, BearerInEntity>(bearerIn, Links.BearerLink + "add-bearer");
            
            BearerId = answer;
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