//===============================================================================
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
    /// Defines a service to deal with the <see cref="WorkItem"/> activation and deactivation based
    /// on its contained <see cref="Control"/> state.
    /// </summary>
    public interface IControlActivationService
    {
        /// <summary>
        /// Notifies that a <see cref="Control"/> has been added to the container.
        /// </summary>
        /// <param name="control">The control in which to monitor the OnEnter event.</param>
        void ControlAdded(Control control);

        /// <summary>
        /// Notifies that a control has been removed from the container.
        /// </summary>
        /// <param name="control">The control being monitored.</param>
        void ControlRemoved(Control control);
    }
}