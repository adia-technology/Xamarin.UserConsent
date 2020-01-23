using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using Xamarin.UserConsent.Resources;

namespace Xamarin.UserConsent.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordingConsentView : ContentView
    {
        public static readonly BindableProperty HeaderProperty =
            BindableProperty.Create(nameof(Header), typeof(string), typeof(RecordingConsentView));

        public static readonly BindableProperty ReasonProperty =
            BindableProperty.Create(nameof(Reason), typeof(string), typeof(RecordingConsentView));

        public static readonly BindableProperty HelpRequestProperty =
            BindableProperty.Create(nameof(HelpRequest), typeof(string), typeof(RecordingConsentView));

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create(nameof(Description), typeof(string), typeof(RecordingConsentView));

        public static readonly BindableProperty LearnMoreProperty =
            BindableProperty.Create(nameof(LearnMore), typeof(string), typeof(RecordingConsentView));

        public static readonly BindableProperty DetailsLinkProperty =
            BindableProperty.Create(nameof(DetailsLink), typeof(string), typeof(RecordingConsentView));

        public static readonly BindableProperty NoTextProperty =
            BindableProperty.Create(nameof(NoText), typeof(string), typeof(RecordingConsentView));

        public static readonly BindableProperty YesTextProperty =
            BindableProperty.Create(nameof(YesText), typeof(string), typeof(RecordingConsentView));

        public static readonly BindableProperty ConfirmationProperty =
            BindableProperty.Create(nameof(Confirmation), typeof(string), typeof(RecordingConsentView));

        public static readonly BindableProperty ConsentGivenProperty =
            BindableProperty.Create(nameof(ConsentGiven), typeof(bool), typeof(RecordingConsentView), true, BindingMode.TwoWay);

        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public string Reason
        {
            get => (string)GetValue(ReasonProperty);
            set => SetValue(ReasonProperty, value);
        }

        public string HelpRequest
        {
            get => (string)GetValue(HelpRequestProperty);
            set => SetValue(HelpRequestProperty, value);
        }

        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public string LearnMore
        {
            get => (string)GetValue(LearnMoreProperty);
            set => SetValue(LearnMoreProperty, value);
        }

        public string DetailsLink
        {
            get => (string)GetValue(DetailsLinkProperty);
            set => SetValue(DetailsLinkProperty, value);
        }

        public string NoText
        {
            get => (string)GetValue(NoTextProperty);
            set => SetValue(NoTextProperty, value);
        }

        public string YesText
        {
            get => (string)GetValue(YesTextProperty);
            set => SetValue(YesTextProperty, value);
        }

        public string Confirmation
        {
            get => (string)GetValue(ConfirmationProperty);
            set => SetValue(ConfirmationProperty, value);
        }

        public bool ConsentGiven
        {
            get => (bool)GetValue(ConsentGivenProperty);
            set => SetValue(ConsentGivenProperty, value);
        }

        public RecordingConsentView()
        {
            InitializeComponent();
            SetLabelColors();
        }

        private void OnSwitchToggled(object sender, ToggledEventArgs e) => SetLabelColors();

        public event EventHandler OnConfirmed;

        public event EventHandler OnDetailsLinkTap;

        public void ConfirmationClicked(object sender, EventArgs e)
        {
            OnConfirmed?.Invoke(sender, e);
        }

        private void SetLabelColors()
        {
            if (ConsentGiven)
            {
                NoLabel.TextColor = Colors.DisabledTextColor;
                YesLabel.TextColor = Colors.ActionableButtonColor;
            }
            else
            {
                NoLabel.TextColor = Color.Black;
                YesLabel.TextColor = Colors.DisabledTextColor;
            }
        }

        private void OnDetailsLinkTapped(object sender, EventArgs e)
        {
            OnDetailsLinkTap?.Invoke(sender, e);
        }
    }
}