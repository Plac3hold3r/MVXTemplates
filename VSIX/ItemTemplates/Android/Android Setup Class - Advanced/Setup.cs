﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Android.Content;
using Android.Support.Design.Widget;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;

namespace $rootnamespace$
{
    public class $safeitemname$ : MvxAppCompatSetup
    {
        public $safeitemname$(Context applicationContext)
               : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp() => new App();

        // InitializeFirstChance is where MvvmCross initializes platform-specific services to which you would like App.Initialize to have access
        // Registering an Android implementation of an interface in your core project here allows for App.Initialize to reference that interface's members
        // If it's not necessary for a service to be available so early in the startup process, consider initializing it during InitializeLastChance instead
        protected override void InitializeFirstChance()
        {
            // No need to call base.InitializeFirstChance() - it's empty
        }

        // FillTargetFactories is where your applications custom bindings are registered
        // Custom bindings are a staple of MvvmCross apps, since they allow for two-way binding for platform-specific controls
        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);
        }

        // Use InitializeLastChance for platform-specific services that need only be available after App has been initialized
        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
        }

        // For apps that make use of custom Android views, you need to provide the assemblies in which MvvmCross should look to find the views
        // This is particularly useful for apps which make use of the Android support libraries
        // Below are some commonly used assemblies - remove the ones your app doesn't require
        protected override IEnumerable<Assembly> AndroidViewAssemblies 
            => new List<Assembly>(base.AndroidViewAssemblies)
            {
                typeof(FloatingActionButton).Assembly,
                typeof(MvxRecyclerView).Assembly
            };

        // Using Android fragments requires the use of MvxFragmentsPresenter, which will happen by default within MvxAppCompatSetup
        // If the use of fragments are not required you can remove this override, which will default to the use of MvxAndroidViewPresenter
        // Learn more about custom view presenters at https://slodge.blogspot.com/2013/06/presenter-roundup.html
        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxPresenter);
            return mvxPresenter;
        }
    }
}