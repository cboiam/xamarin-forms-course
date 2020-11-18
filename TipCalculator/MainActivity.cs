using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace TipCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText valueInput;
        private TextView tipValue;
        private TextView totalValue;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var calculatebutton = FindViewById<Button>(Resource.Id.calculateButton);
            calculatebutton.Click += OnCalculateClicked;

            valueInput = FindViewById<EditText>(Resource.Id.valueInput);
            tipValue = FindViewById<TextView>(Resource.Id.tipValueText);
            totalValue = FindViewById<TextView>(Resource.Id.totalValueText);
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (double.TryParse(valueInput.Text, out double bill))
            {
                var tip = bill * 0.15;
                var total = bill + tip;

                tipValue.Text = tip.ToString();
                totalValue.Text = total.ToString();
            }
        }
    }
}
