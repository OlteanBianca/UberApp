using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace UberApp.Behaviors
{
    [Preserve(AllMembers = true)]
    public class BehaviorBase<T> : Behavior<T> where T : BindableObject
    {
        #region Public Properties

        public T AssociatedObject { get; private set; }

        #endregion

        #region Private Methods

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Invoked when adding Entry to the view.
        /// </summary>
        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
            if (bindable?.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }

            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        /// <summary>
        /// Invoked when exiting from the view.
        /// </summary>
        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);

            if (bindable != null)
            {
                bindable.BindingContextChanged -= OnBindingContextChanged;
                AssociatedObject = null;
            }
        }

        /// <summary>
        /// Invoked when Entry binding context is changed.
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }

        /// <summary>
        /// Invoked when BindingContext is changed
        /// </summary>

        #endregion
    }
}
