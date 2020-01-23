using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;

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

        // ToDo Bindable Properties for colors should be removed after Xamarin.Forms upgrade to 4.5.0 https://github.com/xamarin/Xamarin.Forms/pull/9157
        // Label Color should be changed with StyleClass property change e.g. NoLabel.StyleClass = new List<string>{"noActiveLabelClass"}
        public static readonly BindableProperty NoLabelActiveColorProperty =
            BindableProperty.Create(nameof(NoLabelActiveColor), typeof(Color), typeof(RecordingConsentView), null,
                BindingMode.Default, null, OnColorPropertyChanged);

        public static readonly BindableProperty YesLabelActiveColorProperty =
            BindableProperty.Create(nameof(YesLabelActiveColor), typeof(Color), typeof(RecordingConsentView), null,
                BindingMode.Default, null, OnColorPropertyChanged);

        public static readonly BindableProperty InactiveColorProperty =
            BindableProperty.Create(nameof(InactiveColor), typeof(Color), typeof(RecordingConsentView), null,
                BindingMode.Default, null, OnColorPropertyChanged);

        private static void OnColorPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((RecordingConsentView)bindable).SetLabelColors();
        }

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

        public Color NoLabelActiveColor
        {
            get => (Color)GetValue(NoLabelActiveColorProperty);
            set => SetValue(NoLabelActiveColorProperty, value);
        }

        public Color YesLabelActiveColor
        {
            get => (Color)GetValue(YesLabelActiveColorProperty);
            set => SetValue(YesLabelActiveColorProperty, value);
        }

        public Color InactiveColor
        {
            get => (Color)GetValue(InactiveColorProperty);
            set => SetValue(InactiveColorProperty, value);
        }

        public RecordingConsentView()
        {
            InitializeComponent();
            SetLabelColors();
        }

        private void OnSwitchToggled(object sender, ToggledEventArgs e) => SetLabelColors();

        public event EventHandler OnConfirmed;

        public void ConfirmationClicked(object sender, EventArgs e)
        {
            OnConfirmed?.Invoke(sender, e);
        }

        private void SetLabelColors()
        {
            if (ConsentGiven)
            {
                NoLabel.TextColor = InactiveColor;
                YesLabel.TextColor = YesLabelActiveColor;
            }
            else
            {
                NoLabel.TextColor = NoLabelActiveColor;
                YesLabel.TextColor = InactiveColor;
            }
        }
    }
}