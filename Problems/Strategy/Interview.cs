namespace Problems
{
    public class Interview
    {
        public string ActionName { get; set; }
        public Interview(string name)
        {
            ActionName = name;
        }
        public void DoAction(IInterviewTask task)
        {
            task.DoAction();
        }
    }
}
