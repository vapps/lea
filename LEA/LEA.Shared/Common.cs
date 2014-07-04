using System;
using System.Collections.Generic;
using System.Text;
using Vapps;
using Windows.ApplicationModel.Background;

namespace LEA
{
    class Common
    {
        public static void RegisterLiveBackGroundTask()
        {
            TimeTrigger minTrigger = new TimeTrigger(15, false);
            //SystemTrigger sysTrigger = new SystemTrigger(SystemTriggerType.InternetAvailable, false);

#if WINDOWS_PHONE_APP
            BackgroundExecutionManager.RequestAccessAsync();
#endif
            string entryPoint = "Tasks.LiveBackgroundTask";
            string taskName = "LEA background task";

            BackgroundTaskRegistration task = Helper.RegisterBackgroundTask(entryPoint, taskName, minTrigger, null);
        }
    }
}
