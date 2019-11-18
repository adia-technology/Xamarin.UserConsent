using System.Collections.Generic;

namespace Xamarin.UserConsent.ViewModels
{
    public class ConsentForm
    {
        public ConsentForm(string title, string description, string confirmationButtonText, PopupStyles popupStyles, IEnumerable<ConsentRequest> requests)
        {
            Title = title;
            Description = description;
            ConfirmationButtonText = confirmationButtonText;
            PopupStyles = popupStyles;
            Requests = requests;
        }

        public string Title { get; }
        public string Description { get; }
        public string ConfirmationButtonText { get; }
        public PopupStyles PopupStyles { get; }
        public IEnumerable<ConsentRequest> Requests { get; }
    }
}
