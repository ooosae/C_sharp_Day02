namespace d02_ex01;
using System;

public enum TaskType
{
    Work,
    Study,
    Personal
}

public enum TaskPriority
{
    Low,
    Normal,
    High
}

public enum TaskState
{
    New,
    Completed,
    Irrelevant
}

public class Task
{
    public string Title { get; private set; }
    public string Summary { get; private set; }
    public DateTime? DueDate { get; private set; }
    public TaskType Type { get; private set; }
    public TaskPriority Priority { get; private set; }
    public TaskState State { get; private set; }
    
    public Task(string title, string summary, DateTime? dueDate, TaskType type, TaskPriority priority = TaskPriority.Normal)
    {
        Title = title;
        Summary = summary;
        DueDate = dueDate;
        Type = type;
        Priority = priority;
        State = TaskState.New;
    }
    
    public void MarkAsCompleted()
    {
        if (State != TaskState.New)
        {
            throw new InvalidOperationException("The task cannot be marked as Completed. Check the state and repeat the request.");
        }

        State = TaskState.Completed;
    }

    public void MarkAsIrrelevant()
    {
        if (State != TaskState.New)
        {
            throw new InvalidOperationException("The task cannot be marked as Irrelevant. Check the state and repeat the request.");
        }

        State = TaskState.Irrelevant;
    }

    public override string ToString()
    {
        string dueDateStr = DueDate.HasValue ? DueDate.Value.ToString(", Due till MM/dd/yyyy") : "";

        return $"{Title}\n[{Type}] [{State}]\nPriority: {Priority}{dueDateStr}\n{Summary}";
    }
}

