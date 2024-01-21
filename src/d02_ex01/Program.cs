using d02_ex01;
using System;
using Task = d02_ex01.Task;

class Program
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            string? command = Console.ReadLine();
            if (command is null)
            {
                continue;
            }

            switch (command.ToLower())
            {
                case "add":
                    CreateTask(taskManager);
                    break;
                case "list":
                    taskManager.ListTasks();
                    break;
               case "done":
                   CompleteTask(taskManager);
                   break;
                case "wontdo":
                    MarkAsIrrelevant(taskManager);
                    break;
                case "quit":
                case "q":
                    return;
                default:
                    break;
            }
        }
    }

    static void CreateTask(TaskManager taskManager)
    {
        try
        {
            Console.WriteLine("Enter a title");
            string? title = Console.ReadLine();
            if (title is null)
            {
                throw new ArgumentNullException(nameof(title), "Title cannot be null.");
            }

            Console.WriteLine("Enter a description");
            string? summary = Console.ReadLine();
            if (summary is null)
            {
                throw new ArgumentNullException(nameof(summary), "Summary cannot be null.");
            }

            Console.WriteLine("Enter the deadline");
            DateTime? dueDate = DateTime.TryParse(Console.ReadLine(), out DateTime date) ? date : (DateTime?)null;

            Console.WriteLine("Enter the type");
            Enum.TryParse<TaskType>(Console.ReadLine(), out TaskType type);

            Console.WriteLine("Assign the priority");
            Enum.TryParse<TaskPriority>(Console.ReadLine(), out TaskPriority priority);
            
            Task newTask = new Task(title, summary, dueDate, type, priority);
            taskManager.AddTask(newTask);
            Console.WriteLine(newTask);
        }
        catch (Exception)
        {
            Console.WriteLine("Input error. Check the input data and repeat the request.");
        }
    }
    
    static void CompleteTask(TaskManager taskManager)
    {
        Console.WriteLine("Enter a title");
        string? title = Console.ReadLine();

        try
        {
            taskManager.CompleteTask(title);
            Console.WriteLine($"The task [{title}] is completed!");
        }
        catch (Exception)
        {
            Console.WriteLine("Input error. The task with this title was not found");
        }
    }
    
    static void MarkAsIrrelevant(TaskManager taskManager)
    {
        try
        {
            Console.WriteLine("Enter a title:");
            string? title = Console.ReadLine();

            Task? task = taskManager.Tasks.Find(t => t.Title == title);

            if (task == null)
            {
                Console.WriteLine("Input error. The task with this title was not found.");
            }
            else
            {
                task.MarkAsIrrelevant();
                Console.WriteLine($"The task [{title}] is no longer relevant!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Input error. Check the input data and repeat the request.");
        }
    }
}

