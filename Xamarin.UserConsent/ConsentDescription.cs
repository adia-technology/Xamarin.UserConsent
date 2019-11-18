namespace Xamarin.UserConsent
{
    /// <summary>
    /// Describes a single request for user consent.
    /// </summary>
    public class ConsentDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsentDescription"/> class.
        /// </summary>
        /// <param name="consentKey">Consent identifier</param>
        /// <param name="description">Description displayed to the user</param>
        public ConsentDescription(string consentKey, string description)
        {
            ConsentKey = consentKey;
            Description = description;
        }

        /// <summary>
        /// Gets the consent identifier
        /// </summary>
        public string ConsentKey { get; }

        /// <summary>
        /// Gets the description displayed to the user.
        /// </summary>
        public string Description { get; }
    }
}
