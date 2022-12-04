using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.Controls
{
    /// <summary>
    /// This class is extended from Xamarin.Forms.Editor to extend the size and to remove the border 
    /// for the editor control in the Android and UWP platforms.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class BorderlessEditor : Editor
    {
        #region Constructors

        public BorderlessEditor()
        {
            TextChanged += ExtendableEditor_TextChanged;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Invoked when editor text is changed.
        /// </summary>
        private void ExtendableEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            InvalidateMeasure();
        }

        #endregion
    }
}