using System.Collections.Generic;

namespace Xamarin.UserConsent.ViewModels
{
    public class ConsentForm
    {
        public ConsentForm(string title, string description, string confirmationButtonText, IEnumerable<ConsentRequest> requests)
        {
            Title = title;
            Description = description;
            ConfirmationButtonText = confirmationButtonText;
            Requests = requests;
        }

        public string Title { get; }
        public string Description { get; }
        public string ConfirmationButtonText { get; }
        public IEnumerable<ConsentRequest> Requests { get; }
    }
}
