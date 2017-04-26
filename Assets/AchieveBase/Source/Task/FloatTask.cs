public class FloatTask : Task, ITask{
    public TaskCondition<float> taskCondition;

    public bool ClearConditionChecked()
    {
        return false;
    }
}
