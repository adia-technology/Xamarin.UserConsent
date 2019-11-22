using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.UserConsent.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;

namespace Xamarin.UserConsent
{
    public class UserConsent
    {
        private ISettings Settings => CrossSettings.Current;

        /// <summary>
        /// Grants a specific user consent.
        /// </summary>
        /// <param name="consentKey">Consent identifier</param>
        public void Grant(string consentKey) => Set(consentKey, true.ToString());

        /// <summary>
        /// Revokes a specific user consent.
        /// </summary>
        /// <param name="consentKey">Consent identifier</param>
        public void Revoke(string consentKey) => Set(consentKey, false.ToString());

        /// <summary>
        /// Checks if a specific user consent has been granted.
        /// </summary>
        /// <param name="consentKey">Consent identifier</param>
        /// <returns>True if consent has been granted, false if not and null if the user was not asked before.</returns>
        public bool? IsGranted(string consentKey) => ToBool(Settings.GetValueOrDefault(consentKey, string.Empty));

        /// <summary>
        /// Displays a popup with prompt to grant specified consents.
        /// </summary>
        /// <param name="request">Requests for user consents</param>
        /// <param name="popupStyles">Styles to use for the popup</param>
        /// <returns>Result containing user consents</returns>
        public async Task<ConsentFormResult> DisplayConsentRequest(DisplayConsentFormRequest request, StyleSheet popupStyles = null)
        {
            var tcs = new TaskCompletionSource<ConsentFormResult>();
            void resultHandler(ConsentFormResult result)
            {
                Apply(result);
                tcs.SetResult(result);
            }

            var popup = new UI.ConsentFormPage(ToConsentForm(request), popupStyles, resultHandler);
            await PopupNavigation.Instance.PushAsync(popup);
            
            return await tcs.Task;
        }

        private void Set(string consentKey, string value) => Settings.AddOrUpdateValue(consentKey, value);

        private void Apply(ConsentFormResult consentResult)
            => consentResult.ToList().ForEach(kvp => Set(kvp.Key, kvp.Value.ToString()));

        private bool? ToBool(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return bool.Parse(value);
        }

        private ConsentForm ToConsentForm(DisplayConsentFormRequest request)
            => new ConsentForm(
                request.Title,
                request.Rationale,
                request.ConfirmationButtonText,
                request.Requests.Select(req => new ConsentRequest(req.ConsentKey, req.Description, IsGranted(req.ConsentKey))));
    }
}