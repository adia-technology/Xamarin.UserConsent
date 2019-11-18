using System;
using System.Collections.Generic;
using System.Linq;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.UserConsent.ViewModels;

namespace Xamarin.UserConsent.UI
{
    public partial class ConsentFormPage : PopupPage
    {
        private readonly Action<ConsentFormResult> onConfirm;
        private readonly Dictionary<string, bool> results;

        public ConsentFormPage(ConsentForm form, Action<ConsentFormResult> onConfirm)
        {
            InitializeComponent();

            this.onConfirm = onConfirm;
            this.results = form.Requests.ToDictionary(request => request.ConsentKey, request => request.IsGranted ?? false);
            form.Requests.ToList().ForEach(request => this.ConsentRequests.Children.Add(CreateConsentView(request, form.PopupStyles)));

            this.BindingContext = form;
            this.CloseWhenBackgroundIsClicked = false;
        }

        private async void OnClose(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
            onConfirm(new ConsentFormResult(this.results));
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var source = (Switch)sender;
            var item = (ConsentRequest)source.BindingContext;

            this.results[item.ConsentKey] = e.Value;
        }

        private void UpdateConsent(string consentKey, bool granted) => this.results[consentKey] = granted;

        private View CreateConsentView(ConsentRequest request, PopupStyles styles)
        {
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(10)
            };

            var @switch = new Switch
            {
                IsToggled = request.IsGranted ?? false,
                VerticalOptions = LayoutOptions.Center
            };

            @switch.Toggled += (s, e) => UpdateConsent(request.ConsentKey, e.Value);
            layout.Children.Add(@switch);

            var label = new Label
            {
                Text = request.Description,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                LineBreakMode = LineBreakMode.WordWrap,
                Style = Device.Styles.ListItemDetailTextStyle,
                TextColor = styles.TextColor
            };
            layout.Children.Add(label);

            return layout;
        }
    }
}
