﻿//===============================================================================
// Microsoft patterns & practices
// Smart Client Software Factory 2010
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===============================================================================
//===============================================================================
// Microsoft patterns & practices
// CompositeUI Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
// Copyright © cntsoftware.com


namespace Cnt.CompositeUI.WinForms
{
    /// <summary>
    /// Monitors a <see cref="Control"/> and when it is entered activates the
    /// <see cref="WorkItem"/> the <see cref="Control"/> is contained in.
    /// </summary>
    public class ControlActivationService : IControlActivationService
    {
        private WorkItem workItem;

        /// <summary>
        /// The <see cref="WorkItem"/> where this service lives.
        /// </summary>
        [ServiceDependency]
        public WorkItem WorkItem
        {
            set { workItem = value; }
        }

        /// <summary>
        /// Notifies that a <see cref="Control"/> has been added to the container.
        /// </summary>
        /// <param name="control">The <see cref="Control"/> in which to monitor the OnEnter event.</param>
        public void ControlAdded(Control control)
        {
            control.Enter += OnControlEntered;
            control.Disposed += OnControlDisposed;
        }

        /// <summary>
        /// Notifies that a <see cref="Control"/> has been removed from the container.
        /// </summary>
        /// <param name="control">The <see cref="Control"/> being monitored.</param>
        public void ControlRemoved(Control control)
        {
            control.Enter -= OnControlEntered;
            control.Disposed -= OnControlDisposed;
        }

        private void OnControlEntered(object sender, EventArgs e)
        {
            if (workItem != null)
                workItem.Activate();
        }

        private void OnControlDisposed(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.Enter -= OnControlEntered;
            control.Disposed -= OnControlDisposed;
        }
    }
}