using System;
using System.Collections.Generic;
using System.Text;
using Univapps;
using Windows.ApplicationModel.Background;

namespace LEA
{
    class Common
    {
        public static async void RegisterLiveBackGroundTask()
        {
            TimeTrigger minTrigger = new TimeTrigger(15, false);
            //SystemTrigger sysTrigger = new SystemTrigger(SystemTriggerType.InternetAvailable, false);

            BackgroundAccessStatus result = await BackgroundExecutionManager.RequestAccessAsync();

            if (result == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity || result == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
            {
                string entryPoint = "Tasks.LiveBackgroundTask";
                string taskName = "LEA background task";

                BackgroundTaskRegistration task = Helper.RegisterBackgroundTask(entryPoint, taskName, minTrigger, null);
            }
        }
    }
}
