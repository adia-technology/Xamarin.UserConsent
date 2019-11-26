using System.Threading.Tasks;
using Xamarin.Forms.StyleSheets;

namespace Xamarin.UserConsent
{
    public interface IUserConsent
    {
        Task<ConsentFormResult> DisplayConsentRequest(DisplayConsentFormRequest request, StyleSheet popupStyles = null);
        void Grant(string consentKey);
        bool? IsGranted(string consentKey);
        void Revoke(string consentKey);
    }
}