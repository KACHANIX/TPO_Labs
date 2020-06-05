using System;
using System.IO;
using TPO_Lab3_Mobile.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPO_Lab3_Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlmsgivingPage : ContentPage
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DisplayPhone { get; set; }
        public string BearerNickname { get; set; }

        private readonly int _id;
        private readonly string _phone;
        private readonly int _bearerId;
        private bool _isPhoneShowed;

        public AlmsgivingPage(int id)
        {
            var asd = HttpService.Get<AlmsgivingEntity>(Links.AlmsLink + $"get-almsgiving/{id}");
            int displayPartLength = 5;
            _phone = asd.Phone;
            _id = asd.Id;
            _bearerId = asd.BearerId;
            string displayPart = _phone.Substring(0, displayPartLength);
            string hiddenPart = new string('*', _phone.Length - displayPartLength);

            Name = asd.Name;
            Description = asd.Description;
            DisplayPhone = displayPart + hiddenPart;
            BearerNickname = asd.Nickname;

            InitializeComponent();
            BindingContext = this;

            Stream stream = new MemoryStream(Convert.FromBase64String(asd.Photo));
            this.FindByName<Image>("Image").Source = ImageSource.FromStream(() => stream);

            if (!CurrentUser.IsSigned || CurrentUser.CurrentId != _bearerId)
            {
                this.FindByName<Button>("DeleteBtn").IsVisible = false;
            }

            this.FindByName<Label>("phone").GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnPhoneClicked()),
            });

            this.FindByName<Label>("bearerNickname").GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => OnBearerClicked()),
            });
        }

        private async void OnBearerClicked()
        {
            await Navigation.PushAsync(new BearerPage(_bearerId));
        }

        private void OnPhoneClicked()
        {
            if (!_isPhoneShowed)
            {
                this.FindByName<Label>("phone").Text = _phone;
                _isPhoneShowed = true;
            }
        }

        private   void DeleteBtn_OnClicked(object sender, EventArgs e)
        {
            overlayDelete.IsVisible = true;
        }

        private async void DeleteConfirmBtn_OnClicked(object sender, EventArgs e)
        { 
            HttpService.Get<bool>(Links.AlmsLink + $"delete/{_id}");
            await Navigation.PopAsync();
        }

        private void GoBackButton_OnClicked(object sender, EventArgs e)
        {
            overlayDelete.IsVisible = false;
        }
    }
}