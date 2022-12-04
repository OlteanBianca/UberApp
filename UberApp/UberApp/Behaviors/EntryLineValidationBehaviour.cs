using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.Behaviors
{
    [Preserve(AllMembers = true)]
    public class EntryLineValidationBehaviour : BehaviorBase<Entry>
    {
        #region Public Fields

        /// <summary>
        /// Gets or sets the IsValidProperty, and it is a bindable property.
        /// </summary>
        public static readonly BindableProperty IsValidProperty = BindableProperty.Create(nameof(IsValid),
            typeof(bool), typeof(EntryLineValidationBehaviour), true, BindingMode.TwoWay, null);

        #endregion

        #region Public Properties

        public bool IsValid
        {
            get => (bool)GetValue(IsValidProperty);
            set
            {
                SetValue(IsValidProperty, value);
            }
        }

        #endregion

        #region Private Methods

        private void AssociatedObject_Focused(object sender, FocusEventArgs e)
        {
            IsValid = true;
        }

        #endregion

        #region Protected Methods

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            AssociatedObject.Focused += AssociatedObject_Focused;
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            AssociatedObject.Focused -= AssociatedObject_Focused;
        }

        #endregion
    }
}
