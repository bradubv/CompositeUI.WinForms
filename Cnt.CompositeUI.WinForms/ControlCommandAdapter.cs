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

using Cnt.CompositeUI.Commands;

namespace Cnt.CompositeUI.WinForms
{
    /// <summary>
    /// An EventCommandAdapter{Control} <see cref="Control"/> based on the changes to 
    /// the Command.Status property value.
    /// </summary>
    public class ControlCommandAdapter : EventCommandAdapter<Control>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlCommandAdapter"/> class.
        /// </summary>
        public ControlCommandAdapter()
            : base()
        {
        }

        /// <summary>
        /// Initializes the adapter with the given <see cref="Control"/>.
        /// </summary>
        public ControlCommandAdapter(Control control, string eventName)
            : base(control, eventName)
        {
        }

        /// <summary>
        /// Handles the changes in the Command by refreshing 
        /// the controls properties.
        /// </summary>
        /// <param name="command"></param>
        protected override void OnCommandChanged(Command command)
        {
            base.OnCommandChanged(command);
            foreach (KeyValuePair<Control, List<string>> pair in Invokers)
            {
                pair.Key.Enabled = (command.Status == CommandStatus.Enabled);
                pair.Key.Visible = (command.Status != CommandStatus.Unavailable);
            }
        }

    }
}