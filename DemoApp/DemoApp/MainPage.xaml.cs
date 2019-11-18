using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.UserConsent;

namespace DemoApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly UserConsent userConsent = new UserConsent();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Standard_Clicked(object sender, EventArgs e)
        {
            await ShowConsentPopup(PopupStyles.Default);
        }

        private async void Button_Custom_Clicked(object sender, EventArgs e)
        {
            await ShowConsentPopup(new PopupStyles(Color.White, Color.Black, Color.LightGreen));
        }

        private async Task ShowConsentPopup(PopupStyles styles)
        {
            await userConsent.DisplayConsentRequest(new DisplayConsentFormRequest(
                "We need your consent",
                "Help us improve your experience with the app by allowing us to collect anonymous data. This data will not be used for marketing or tracking purposes.",
                "Confirm",
                new[]
                {
                    new ConsentDescription("analytics", "Gather anonymous application usage data"),
                    new ConsentDescription("recording", "Record your sessions with the app"),
                    new ConsentDescription("telemetry", "Use your network connection to send data to our servers")
                }), styles);
        }
    }
}
