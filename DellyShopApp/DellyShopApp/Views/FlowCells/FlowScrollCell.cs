using System;
using Xamarin.Forms;

namespace DellyShopApp.Views.FlowCells
{
    [Helpers.Preserve(AllMembers = true)]
    public class FlowScrollCell : ScrollView, IFlowViewCell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DLToolkit.Forms.Controls.FlowScrollCell"/> class.
        /// </summary>
        public FlowScrollCell()
        {
        }

        /// <summary>
        /// Raised when cell is tapped.
        /// </summary>
        public virtual void OnTapped()
        {
        }
    }
}
