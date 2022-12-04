using Syncfusion.XForms.Buttons;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.Triggers
{
    /// <summary>
    /// This class extends the behavior of the SfButton control to invoke a command when a click event triggers.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ButtonTextTriggerAction : TriggerAction<SfButton>
    {
        #region Protected Methods

        protected override void Invoke(SfButton button)
        {
            if (button != null)
            {
                if (button.Text == "CHOOSE")
                {
                    button.Text = "CHOOSEN";
                }
                else if (button.Text == "CHOOSEN")
                {
                    button.Text = "CHOOSE";
                }
            }
        }

        #endregion
    }
}
