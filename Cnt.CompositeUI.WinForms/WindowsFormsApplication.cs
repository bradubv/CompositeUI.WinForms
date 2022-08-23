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

using Cnt.ObjectBuilder;
using Cnt.CompositeUI.UIElements;
using Cnt.CompositeUI.Commands;
using Cnt.CompositeUI.WinForms.UIElements;

namespace Cnt.CompositeUI.WinForms
{
	/// <summary>
	/// Extends <see cref="CabShellApplication{TWorkItem,TShell}"/> to support shell-based applications that
	/// use Windows Forms.
	/// </summary>
	/// <typeparam name="TWorkItem">The type of the root application work item.</typeparam>
	/// <typeparam name="TShell">The type for the shell to use.</typeparam>
	public abstract class WindowsFormsApplication<TWorkItem, TShell> : CabShellApplication<TWorkItem, TShell>
		where TWorkItem : WorkItem, new()
	{
		/// <summary>
		/// Initializes an instance of the <see cref="WindowsFormsApplication{TWorkItem,TShell}"/> class.
		/// </summary>
		protected WindowsFormsApplication()
		{
			Application.EnableVisualStyles();
			VisualizerType = typeof(WinFormsVisualizer);
		}

		/// <summary>
		/// Adds Windows Forms specific strategies to the builder.
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
		/// See <see cref="CabShellApplication{TWorkItem,TShell}.AfterShellCreated"/>
		/// </summary>
		protected override void AfterShellCreated()
		{
			RegisterUIElementAdapterFactories();
			RegisterCommandAdapters();
		}

		private void RegisterCommandAdapters()
		{
			ICommandAdapterMapService mapService = RootWorkItem.Services.Get<ICommandAdapterMapService>();
			mapService.Register(typeof(ToolStripItem), typeof(ToolStripItemCommandAdapter));
			mapService.Register(typeof(Control), typeof(ControlCommandAdapter));
		}

		private void RegisterUIElementAdapterFactories()
		{
			IUIElementAdapterFactoryCatalog catalog = RootWorkItem.Services.Get<IUIElementAdapterFactoryCatalog>();
			catalog.RegisterFactory(new ToolStripUIAdapterFactory());
		}
	}
}