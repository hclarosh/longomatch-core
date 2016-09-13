﻿//
//  Copyright (C) 2016 Fluendo S.A.
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
//
using System.Threading;
using ICSharpCode.SharpZipLib;
using LongoMatch;
using LongoMatch.Core.Store.Templates;
using LongoMatch.DB;
using NUnit.Framework;
using VAS.Core.Common;
using VAS.Core.Interfaces;
using VAS.Core.MVVMC;
using VAS.DB;
using LMConstants = LongoMatch.Core.Common.Constants;

namespace Tests
{
	[SetUpFixture]
	public class SetupClass
	{
		[SetUp]
		public void Setup ()
		{
			// Initialize LongoMath.Core by using a type, this will call the module initialization
			var st = new SportsTeam ();
			VFS.SetCurrent (new FileSystem ());
			VAS.App.Current = App.Current = new App ();
			App.Current.Keyboard = new Keyboard ();
			App.Current.Config = new Config ();
			App.Current.SoftwareName = LMConstants.SOFTWARE_NAME;

			//set the sync context
			/*
			var thisSyncContext = new MockSynchronizationContext ();
			SynchronizationContext.SetSynchronizationContext (thisSyncContext);
			*/
			App.Current.EventsBroker = new VAS.Core.Events.EventsBroker ();
			App.Current.DependencyRegistry = new Registry ("Dependencies");
			App.Current.DependencyRegistry.Register<IStorageManager, CouchbaseManagerLongoMatch> (1);
			App.Current.ControllerLocator = new ControllerLocator ();
			App.Current.Config.CurrentDatabase = "longomatch";
			App.Current.ProjectExtension = LMConstants.PROJECT_EXT;
			;
		}
	}

	/// <summary>
	/// Prism's UI thread option works by invoking Post on the current synchronization context.
	/// When we do that, base.Post actually looses SynchronizationContext.Current
	/// because the work has been delegated to ThreadPool.QueueUserWorkItem.
	/// This implementation makes our async-intended call behave synchronously,
	/// so we can preserve and verify sync contexts for callbacks during our unit tests.
	/// </summary>
	internal class MockSynchronizationContext : SynchronizationContext
	{
		public override void Post (SendOrPostCallback d, object state)
		{
			d (state);
		}

		public override void Send (SendOrPostCallback d, object state)
		{
			d (state);
		}
	}
}
