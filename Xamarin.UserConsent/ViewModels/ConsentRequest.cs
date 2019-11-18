namespace Xamarin.UserConsent.ViewModels
{
    public class ConsentRequest
    {
        public ConsentRequest(string consentKey, string description, bool? isGranted = null)
        {
            ConsentKey = consentKey;
            Description = description;
            IsGranted = isGranted;
        }

        public string ConsentKey { get; }
        public string Description { get; }
        public bool? IsGranted { get; }
    }
}
