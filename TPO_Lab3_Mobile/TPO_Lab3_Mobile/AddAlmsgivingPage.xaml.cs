using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPO_Lab3_Mobile.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPO_Lab3_Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAlmsgivingPage : ContentPage
    {
        private readonly int _bearerId;
        private readonly string _nickname;
        private readonly string _phone;
        private string _type;
        private string _photo64;

        public AddAlmsgivingPage(int bearerId, string nickname, string phone)
        {
            _bearerId = bearerId;
            _nickname = nickname;
            _phone = phone;
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            var bytes = ReadToEnd(stream);
            _photo64 = Convert.ToBase64String(bytes);
        }

        private byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte) nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }

                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

        private void Picker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            _type = Picker.SelectedItem.ToString();
        }

        private async void SubmitBtn_OnClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Name.Text))
            {
                NameError.IsVisible = true;
                return;
            }

            if (String.IsNullOrWhiteSpace(Description.Text) )
            {
                DescriptionError.IsVisible = true;
                return;
            }

            if (String.IsNullOrWhiteSpace(_photo64))
            {
                PhotoError.IsVisible = true;
                return;
            }

            var alm = new AlmsgivingEntity
            {
                Type = _type,
                Name = Name.Text,
                Photo = _photo64,
                Description = Description.Text,
                BearerId = _bearerId,
                Nickname = _nickname,
                Phone = _phone
            };

            await HttpService.Post<bool, AlmsgivingEntity>(alm, Links.AlmsLink + "add");
            await Navigation.PopAsync();
        }
    }
}