﻿using System;
using Xamarin.Forms;

namespace DellyShopApp.Views.FlowCells
{
    [Helpers.Preserve(AllMembers = true)]
    public class FlowStackCell : StackLayout, IFlowViewCell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DLToolkit.Forms.Controls.FlowStackCell"/> class.
        /// </summary>
        public FlowStackCell()
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
