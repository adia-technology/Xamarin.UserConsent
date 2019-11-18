using Android.Content;
using Android.OS;

namespace Xamarin.UserConsent
{
    public static class UserConsentSDK
    {
        public static void Init(Context context, Bundle bundle)
        {
            Rg.Plugins.Popup.Popup.Init(context, bundle);
            if (!Forms.Forms.IsInitialized)
            {
                Forms.Forms.Init(context, bundle);
            }
        }
    }
}
