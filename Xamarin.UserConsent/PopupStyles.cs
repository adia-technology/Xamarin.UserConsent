using Xamarin.Forms;

namespace Xamarin.UserConsent
{
    /// <summary>
    /// Defines styles used in the consent popup.
    /// </summary>
    public class PopupStyles
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PopupStyles"/> class.
        /// </summary>
        /// <param name="backgroundColor">Popup background color.</param>
        /// <param name="textColor">Text color.</param>
        /// <param name="buttonColor">Confirmation button background color.</param>
        public PopupStyles(Color backgroundColor, Color textColor, Color buttonColor)
        {
            BackgroundColor = backgroundColor;
            TextColor = textColor;
            ButtonColor = buttonColor;
        }

        /// <summary>
        /// Gets the default popup styles.
        /// </summary>
        public static PopupStyles Default => new PopupStyles(Color.White, Color.Default, Color.Default);

        /// <summary>
        /// Gets the popup background color.
        /// </summary>
        public Color BackgroundColor { get; }

        /// <summary>
        /// Gets the text color.
        /// </summary>
        public Color TextColor { get; }

        /// <summary>
        /// Getst the button color.
        /// </summary>
        public Color ButtonColor { get; }
    }
}
