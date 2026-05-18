namespace HMCTS_TaskManager.Constants
{
    public static class TaskStatuses
    {
        public const string ToDo = "ToDo";
        public const string InProgress = "InProgress";
        public const string Completed = "Completed";

        public static readonly List<string> All = new()
        {
            ToDo,
            InProgress,
            Completed
        };
    }
}
