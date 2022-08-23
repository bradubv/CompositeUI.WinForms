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

using Cnt.CompositeUI.SmartParts;
using System.ComponentModel;

namespace Cnt.CompositeUI.WinForms
{
    /// <summary>
    /// Specifies the position of the tab page on a <see cref="TabWorkspace"/>.
    /// </summary>
    public enum TabPosition
    {
        /// <summary>
        /// Place tab page at begining.
        /// </summary>
        Beginning,
        /// <summary>
        /// Place tab page at end.
        /// </summary>
        End,
    }

    /// <summary>
    /// A <see cref="SmartPartInfo"/> that describes how a specific smartpart
    /// will be shown in a tab workspace.
    /// </summary>
    [ToolboxBitmap(typeof(TabSmartPartInfo), "TabSmartPartInfo")]
    public class TabSmartPartInfo : SmartPartInfo
    {
        private TabPosition position = TabPosition.End;
        private bool activateTab = true;

        /// <summary>
        /// Specifies whether the tab will get focus when shown.
        /// </summary>
        [Category("Layout")]
        [DefaultValue(true)]
        public bool ActivateTab
        {
            get { return activateTab; }
            set { activateTab = value; }
        }

        /// <summary>
        /// Specifies the position of the tab page.
        /// </summary>
        [Category("Layout")]
        [DefaultValue(TabPosition.End)]
        public TabPosition Position
        {
            get { return position; }
            set { position = value; }
        }


    }
}