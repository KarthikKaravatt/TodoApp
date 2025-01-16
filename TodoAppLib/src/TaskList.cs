﻿using Task = TodoAppLib.Internal.Task;

namespace TodoAppLib;

/// <summary>
/// A container that allows for the storage and manipulation of tasks.
/// </summary>
public class TaskList
{
    private SortedSet<Task> Tasks = new();
    private SortedSet<Task> CompletedTasks = new();

    /// <summary>
    /// Prints the Current Tasks that are not yet completed.
    /// </summary>
    public void PrintTasks()
    {
        foreach (Task task in Tasks)
        {
            Console.WriteLine(task.ToString());
        }
    }

    /// <summary>
    /// Prints the Current Tasks that are completed.
    /// </summary>
    public void PrintCompletedTasks()
    {
        foreach (Task task in CompletedTasks)
        {
            Console.WriteLine(task.ToString());
        }
    }

    /// <summary>
    /// Add a new task to the task list.
    /// </summary>
    /// <param name="title"> Title of the task</param>
    /// <param name="deadline"> When the task must be completed, cannot contain commas.</param>
    /// <returns>true for success, false for failure.</returns>
    public bool Add(string title, DateTime deadline)
    {
        Task task = Task.Create(title, deadline);
        // Don't want duplicates
        return CompletedTasks.Remove(task) || Tasks.Add(task);
    }

    /// <summary>
    /// Remove a task from the task list.
    /// </summary>
    /// <param name="title"> Title of the task</param>
    /// <param name="deadline"> When the task must be completed, cannot contain commas.</param>
    /// <returns>treu for success, false for failure.</returns>
    public bool Remove(string title, DateTime deadline)
    {
        Task task = Task.Create(title, deadline);
        return Tasks.Remove(task) || CompletedTasks.Remove(task);
    }

    /// <summary>
    /// Checks if a task that is yet to be completed is contained in the task list.
    /// </summary>
    /// <param name="title"> Title of the task</param>
    /// <param name="deadline"> When the task must be completed, cannot contain commas.</param>
    /// <returns>true for success, false for failure.</returns>
    public bool ContainsTask(string title, DateTime deadline)
    {
        Task task = Task.Create(title, deadline);
        return Tasks.Contains(task);
    }

    /// <summary>
    /// Checks if a task that is completed is contained in the task list.
    /// </summary>
    /// <param name="title"> Title of the task</param>
    /// <param name="deadline"> When the task must be completed, cannot contain commas.</param>
    /// <returns>true for success, false for failure.</returns>
    public bool ContainsCompletedTask(string title, DateTime deadline)
    {
        Task task = Task.Create(title, deadline);
        return CompletedTasks.Contains(task);
    }

    /// <summary>
    /// Modifies a task that is contained in the task list.
    /// </summary>
    /// <param name="currentTitle"></param>
    /// <param name="currentDeadline"></param>
    /// <param name="newTitle"></param>
    /// <param name="newDeadline"></param>
    /// <returns>True for success, false for failure.</returns>
    public bool ModifyTask(
        string currentTitle,
        DateTime currentDeadline,
        string newTitle,
        DateTime newDeadline
    )
    {
        var modify = (SortedSet<Task> tasks) =>
        {
            return Remove(currentTitle, currentDeadline) && Add(newTitle, newDeadline);
        };
        return modify(Tasks) || modify(CompletedTasks);
    }

    /// <summary>
    /// Changes the status of a task to be completed.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="deadline"></param>
    /// <returns>True for success, false for failure</returns>
    public bool CompleteTask(string title, DateTime deadline)
    {
        Task complted = Task.Create(title, deadline);
        if (Tasks.Remove(complted))
        {
            return CompletedTasks.Add(complted);
        }
        else
        {
            return false;
        }
    }
}
