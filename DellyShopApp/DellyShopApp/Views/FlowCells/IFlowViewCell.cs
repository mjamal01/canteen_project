using System;
using Xamarin.Forms;

namespace DellyShopApp.Views.FlowCells
{
    [Helpers.Preserve(AllMembers = true)]
    public interface IFlowViewCell
    {
        /// <summary>
        /// Raised when cell is tapped.
        /// </summary>
        void OnTapped();
    }
}
