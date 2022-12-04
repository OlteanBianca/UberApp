using UberApp.Models;
using Xamarin.Forms.Internals;

namespace UberApp.Controls
{
    [Preserve(AllMembers = true)]
    public class SearchableSuggestionList : SearchableListView
    {
        #region Public Methods

        /// <summary>
        /// Filters the list view items based on the search text.
        /// </summary>
        public override bool FilterContacts(object obj)
        {
            if (base.FilterContacts(obj))
            {
                if (obj is not Request taskInfo || string.IsNullOrEmpty(taskInfo.DestinationLocation))
                {
                    return false;
                }
                return taskInfo.DestinationLocation.ToUpperInvariant().Contains(SearchText.ToUpperInvariant());
            }
            return false;
        }

        #endregion
    }
}
