using System.Collections;
using System.Collections.Generic;

namespace Xamarin.UserConsent
{
    /// <summary>
    /// Represents a result of displaying a consent popup to the user.
    /// </summary>
    public class ConsentFormResult : IEnumerable<KeyValuePair<string, bool>>
    {
        private readonly IReadOnlyDictionary<string, bool> responses;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsentFormResult"/> class.
        /// </summary>
        /// <param name="responses">A collection of user responses to consent requests.</param>
        public ConsentFormResult(IReadOnlyDictionary<string, bool> responses)
        {
            this.responses = responses;
        }

        /// <summary>
        /// Gets the status of a specific consent.
        /// </summary>
        /// <param name="consentKey">Consent identifier</param>
        /// <returns>True if consent was given, otherwise false.</returns>
        public bool this[string consentKey] => this.responses[consentKey];

        /// <summary>
        /// Gets the collection enumerator.
        /// </summary>
        /// <returns>An enumerator over all consents.</returns>
        public IEnumerator<KeyValuePair<string, bool>> GetEnumerator() => this.responses.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.responses.GetEnumerator();
    }
}
