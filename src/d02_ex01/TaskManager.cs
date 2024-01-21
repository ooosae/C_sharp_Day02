namespace d02_ex01;

public class TaskManager
{
    private List<Task> tasks = new List<Task>();

    public List<Task> Tasks => tasks;
    
    public void AddTask(Task task)
    {
        tasks.Add(task);
    }
    
    public void ListTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("The task list is still empty.");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
                Console.WriteLine();
            }
        }
    }
    
    public void CompleteTask(string? title)
    {
        Task? task = tasks.Find(t => t.Title == title);

        if (task == null)
        {
            throw new InvalidOperationException("No such task.");
        }
        
        task.MarkAsCompleted();
    }
}