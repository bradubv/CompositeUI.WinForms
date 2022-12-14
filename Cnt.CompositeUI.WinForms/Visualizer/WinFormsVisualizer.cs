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

using Cnt.ObjectBuilder;
using Cnt.CompositeUI.WinForms.Visualizer;

namespace Cnt.CompositeUI.WinForms
{
    /// <summary>
    /// Implements a <see cref="CabVisualizer"/> to be used with WinForms applications.
    /// </summary>
    public class WinFormsVisualizer : CabVisualizer
    {
        /// <summary>
        /// Added Windows Forms specific strategies to the builder.
        /// </summary>
        protected override void AddBuilderStrategies(Builder builder)
        {
            builder.Strategies.AddNew<WinFormServiceStrategy>(BuilderStage.Initialization);
            builder.Strategies.AddNew<ControlActivationStrategy>(BuilderStage.Initialization);
            builder.Strategies.AddNew<ControlSmartPartStrategy>(BuilderStage.Initialization);
        }

        /// <summary>
        /// See <see cref="CabApplication{TWorkItem}.AddServices"/>
        /// </summary>
        protected override void AddServices()
        {
            RootWorkItem.Services.AddNew<ControlActivationService, IControlActivationService>();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="VisualizerForm"/> and shows it.
        /// </summary>
        protected override sealed void CreateVisualizationShell()
        {
            RootWorkItem.Items.AddNew<VisualizerForm>("VisualizerForm").Show();
        }
    }
}
