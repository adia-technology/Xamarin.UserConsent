namespace Xamarin.UserConsent
{
    public static class UserConsentSDK
    {
        public static void Init()
        {
            Rg.Plugins.Popup.Popup.Init();
            if (!Forms.Forms.IsInitialized)
            {
                Forms.Forms.Init();
            }
        }
    }
}
