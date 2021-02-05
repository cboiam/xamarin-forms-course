using Phoneword.Utils;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Phoneword
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private string phoneNumber;

        public MainPage()
        {
            InitializeComponent();

            translateButton.Clicked += OnTranslate;
            callButton.Clicked += OnCall;
        }

        private async void OnCall(object sender, EventArgs e)
        {
            if (await DisplayAlert("Dial a Number",
                $"Would you like to call {phoneNumber}?",
                "Yes",
                "No"))
            {
                PhoneDialer.Open(phoneNumber);
                //await Sms.ComposeAsync(new SmsMessage("Teste sms", phoneNumber));
            }
        }

        public void OnTranslate(object sender, EventArgs e)
        {
            phoneNumber = PhonewordTranslator.ToNumber(phoneNumberText.Text);

            if (phoneNumber == null)
            {
                callButton.Text = "Call";
                callButton.IsEnabled = false;
                return;
            }

            callButton.Text = $"Call {phoneNumber}";
            callButton.IsEnabled = true;
        }
    }
}