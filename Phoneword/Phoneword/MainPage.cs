using Phoneword.Utils;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Phoneword
{
    public class MainPage : ContentPage
    {
        private Entry phoneEntry;
        private Button translateButton;
        private Button callButton;
        private string phoneNumber;

        public MainPage()
        {
            Padding = 20;

            var layout = new StackLayout { Spacing = 15 };

            layout.Children.Add(new Label { Text = "Enter a Phoneword:" });

            phoneEntry = new Entry { Text = "1-855-XAMARIN" };
            layout.Children.Add(phoneEntry);

            translateButton = new Button { Text = "Translate" };
            translateButton.Clicked += OnTranslate;
            layout.Children.Add(translateButton);

            callButton = new Button { Text = "Call", IsEnabled = false };
            callButton.Clicked += OnCall;
            layout.Children.Add(callButton);

            Content = layout;
        }

        private async void OnCall(object sender, EventArgs e)
        {
            if(await DisplayAlert("Dial a Number", 
                $"Would you like to call {phoneNumber}?", 
                "Yes", 
                "No"))
            {
                PhoneDialer.Open(phoneNumber);
            }
        }

        public void OnTranslate(object sender, EventArgs e)
        {
            phoneNumber = PhonewordTranslator.ToNumber(phoneEntry.Text);

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
