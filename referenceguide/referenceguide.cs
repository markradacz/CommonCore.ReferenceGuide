﻿using Xamarin.Forms.CommonCore;
using Xamarin.Forms;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using PushNotification.Plugin;

namespace referenceguide
{
	public class App : Application
	{
		public App()
		{
           
			if (string.IsNullOrEmpty(AppSettings.InstallationId))
				AppSettings.InstallationId = Guid.NewGuid().ToString();

			AppSettings.AESEncryptionKey = "8675309";
            
			AppData.Instance.NotificationTags.Add("referenceguide");
			
			MainPage = new MainPage();
		}

		private void ConnectivityChanged(object sender, ConnectivityChangedEventArgs args)
		{
			AppData.Instance.IsConnected = args.IsConnected;
		}

		protected override void OnStart()
		{
			//var mobileCenterKeys = $"android={AppData.Instance.MobileCenter_HockeyAppAndroid};ios={AppData.Instance.MobileCenter_HockeyAppiOS}";
			//MobileCenter.Start(mobileCenterKeys, typeof(Analytics), typeof(Crashes));
			
			CrossConnectivity.Current.ConnectivityChanged += ConnectivityChanged;
		}

		protected override void OnSleep()
		{
			CrossConnectivity.Current.ConnectivityChanged -= ConnectivityChanged;
		}

		protected override void OnResume()
		{
			CrossConnectivity.Current.ConnectivityChanged += ConnectivityChanged;
		}
	}
}
