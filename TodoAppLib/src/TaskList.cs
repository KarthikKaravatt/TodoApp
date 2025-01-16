using System.Security.Cryptography.X509Certificates;
using Task = TodoAppLib.Internal.Task;

namespace TodoAppLib;

/// <summary>
/// A container that allows for the storage and manipulation of tasks
/// </summary>
public class TaskList
{
    private SortedSet<Task> Tasks = new();
    private SortedSet<Task> Completed = new();

    public void PrintTasks()
    {
        foreach (Task task in Tasks)
        {
            Console.WriteLine(task.ToString());
        }
    }

    public void PrintCompletedTasks()
    {
        foreach (Task task in Completed)
        {
            Console.WriteLine(task.ToString());
        }
    }

    public void Add(string title, DateTime deadline)
    {
        Task task = Task.Create(title, deadline);
        // Don't want duplicates
        Completed.Remove(task);
        Tasks.Add(task);
    }

    public void Remove(string title, DateTime deadline)
    {
        Task task = Task.Create(title, deadline);
        Tasks.Remove(task);
        Completed.Remove(task);
    }

    public bool Contains(string title, DateTime deadline)
    {
        Task task = Task.Create(title, deadline);
        return Tasks.Contains(task) || Completed.Contains(task);
    }

    public void ModifyTask(
        string currentTitle,
        DateTime currentDeadline,
        string newTitle,
        DateTime newDeadline
    )
    {
        var modify = (SortedSet<Task> tasks) =>
        {
            Remove(currentTitle, currentDeadline);
            Add(newTitle, newDeadline);
        };
        modify(Tasks);
        modify(Completed);
    }

    public void Complete(string title, DateTime deadline)
    {
        Task complted = Task.Create(title, deadline);
        if (Tasks.Remove(complted))
        {
            Completed.Add(complted);
        }
    }
}
