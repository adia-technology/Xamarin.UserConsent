using System.Collections.Generic;

namespace Xamarin.UserConsent
{
    /// <summary>
    /// Represents a request to display a popup prompting the user for consents.
    /// </summary>
    public class DisplayConsentFormRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayConsentFormRequest"/> class.
        /// </summary>
        /// <param name="title">Popup title.</param>
        /// <param name="rationale">Rationale explaining the reason for asking for the consents.</param>
        /// <param name="confirmationButtonText">Text displayed on the confirmation button.</param>
        /// <param name="requests">Specific requests for consent.</param>
        public DisplayConsentFormRequest(string title, string rationale, string confirmationButtonText, IEnumerable<ConsentDescription> requests)
        {
            Title = title;
            Rationale = rationale;
            ConfirmationButtonText = confirmationButtonText;
            Requests = requests;
        }

        /// <summary>
        /// Gets the popup title text.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets the rationale text.
        /// </summary>
        public string Rationale { get; }

        /// <summary>
        /// Gets the text displayed on the confirmation button.
        /// </summary>
        public string ConfirmationButtonText { get; }

        /// <summary>
        /// Gets the requests for user consent.
        /// </summary>
        public IEnumerable<ConsentDescription> Requests { get; }
    }
}
