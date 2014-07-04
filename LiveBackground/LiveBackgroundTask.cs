using Windows.ApplicationModel.Background;

namespace Tasks
{
    public sealed class LiveBackgroundTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral _deferral = taskInstance.GetDeferral();

            var taskRegistered = false;
            var taskName = "LiveBackgroundTask";
            
            foreach( var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == taskName)
                {
                    taskRegistered = true;
                    break;
                }
            }

            var builder = new BackgroundTaskBuilder();

            builder.Name = taskName;
            builder.TaskEntryPoint = "Tasks.LiveBackgroundTask";
            builder.SetTrigger(new TimeTrigger(15, false));
            //builder.AddCondition(new SystemCondition(SystemConditionType.UserPresent));

            BackgroundTaskRegistration t = builder.Register();

            _deferral.Complete();
        }
    }
}
