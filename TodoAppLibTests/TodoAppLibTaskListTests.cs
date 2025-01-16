// Ignore Spelling: Todo

namespace TodoAppLibTests;

using TodoAppLib;
using Task = TodoAppLib.Internal.Task;

public class TodoAppLibTaskListTests
{
    private static readonly Dictionary<string, (string title, DateTime deadline)> _tasks = new()
    {
        { "TestTask", ("TestTask", DateTime.Now.AddYears(10)) },
        { "TestTaskTwo", ("TestTaskTwo", DateTime.Now.AddYears(10)) },
        { "TestTaskThree", ("TestTaskThree", DateTime.Now.AddYears(20)) },
        { "TestTaskBroken", ("TestTaskBroken,", new DateTime(1999, 1, 1)) },
    };

    [Theory]
    [InlineData("TestTask")]
    [InlineData("TestTaskTwo")]
    [InlineData("TestTaskThree")]
    public void Add_SingleTask_ReturnsTrue(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        Assert.True(taskList.Add(title, deadline));
    }

    [Theory]
    [InlineData("TestTaskBroken")]
    public void Add_SingleTask_ThrowsArgumentException(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        Assert.Throws<ArgumentException>(() => taskList.Add(title, deadline));
    }

    [Theory]
    [InlineData("TestTask")]
    [InlineData("TestTaskTwo")]
    [InlineData("TestTaskThree")]
    public void Remove_SingleTask_ReturnsTrue(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        taskList.Add(title, deadline);
        Assert.True(taskList.Remove(title, deadline));
    }

    [Theory]
    [InlineData("TestTask")]
    [InlineData("TestTaskTwo")]
    [InlineData("TestTaskThree")]
    public void Remove_SingleTask_ReturnsFalse(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        Assert.False(taskList.Remove(title, deadline));
    }

    [Theory]
    [InlineData("TestTaskBroken")]
    public void Remove_SingleTask_ThrowsArgumentException(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        Assert.Throws<ArgumentException>(() => taskList.Remove(title, deadline));
    }

    [Theory]
    [InlineData("TestTask")]
    [InlineData("TestTaskTwo")]
    [InlineData("TestTaskThree")]
    public void ContainsTask_SingleTask_ReturnsTrue(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        bool result = taskList.Add(title, deadline);
        Assert.True(taskList.ContainsTask(title, deadline));
    }

    [Theory]
    [InlineData("TestTask")]
    [InlineData("TestTaskTwo")]
    [InlineData("TestTaskThree")]
    public void ContainsCompletedTask_SingleTask_ReturnsFalse(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        Assert.False(taskList.ContainsCompletedTask(title, deadline));
    }

    [Theory]
    [InlineData("TestTaskBroken")]
    public void ContainsCompletedTask_SingleTask_ThrowsArgumentException(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        Assert.Throws<ArgumentException>(() => taskList.ContainsCompletedTask(title, deadline));
    }

    [Theory]
    [InlineData("TestTask")]
    [InlineData("TestTaskTwo")]
    [InlineData("TestTaskThree")]
    public void ContainsCompletedTask_SingleTask_ReturnsTrue(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        bool result = taskList.Add(title, deadline);
        Assert.True(taskList.ContainsTask(title, deadline));
    }

    [Theory]
    [InlineData("TestTask")]
    [InlineData("TestTaskTwo")]
    [InlineData("TestTaskThree")]
    public void ContainsTask_SingleTask_ReturnsFalse(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        Assert.False(taskList.ContainsTask(title, deadline));
    }

    [Theory]
    [InlineData("TestTaskBroken")]
    public void ContainsTask_SingleTask_ThrowsArgumentException(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        Assert.Throws<ArgumentException>(() => taskList.ContainsTask(title, deadline));
    }

    [Theory]
    [InlineData("TestTask")]
    [InlineData("TestTaskTwo")]
    [InlineData("TestTaskThree")]
    public void ModifyTask_SingleTask_ReturnsTrue(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        taskList.Add(title, deadline);
        Assert.True(taskList.ModifyTask(title, deadline, $"Modified{title}", deadline));
        taskList.Add(title, deadline);
        Assert.True(
            taskList.ModifyTask(title, deadline, $"Modified{title}", deadline.AddYears(10))
        );
        taskList.Add(title, deadline);
        Assert.True(taskList.ModifyTask(title, deadline, title, deadline.AddYears(10)));
    }

    [Theory]
    [InlineData("TestTask")]
    [InlineData("TestTaskTwo")]
    [InlineData("TestTaskThree")]
    public void ModifyTask_SingleTask_ReturnsFalse(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        Assert.False(taskList.ModifyTask(title, deadline, $"Modified{title}", deadline));
        Assert.False(
            taskList.ModifyTask(title, deadline, $"Modified{title}", deadline.AddYears(10))
        );
        Assert.False(taskList.ModifyTask(title, deadline, title, deadline.AddYears(10)));
    }

    [Theory]
    [InlineData("TestTaskBroken")]
    public void ModifyTask_SingleTask_ThrowsArgumentException(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        Assert.Throws<ArgumentException>(
            () => taskList.ModifyTask(title, deadline, title, deadline.AddYears(10))
        );
    }

    [Theory]
    [InlineData("TestTask")]
    [InlineData("TestTaskTwo")]
    [InlineData("TestTaskThree")]
    public void CompleteTask_SingleTask_ReturnsTrue(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        taskList.Add(title, deadline);
        taskList.CompleteTask(title, deadline);
        Assert.True(taskList.CompleteTask(title, deadline));
    }

    [Theory]
    [InlineData("TestTask")]
    [InlineData("TestTaskTwo")]
    [InlineData("TestTaskThree")]
    public void CompleteTask_SingleTask_ReturnsFalse(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        taskList.CompleteTask(title, deadline);
        Assert.False(taskList.CompleteTask(title, deadline));
    }

    [Theory]
    [InlineData("TestTaskBroken")]
    public void CompleteTask_SingleTask_ThrowsArgumentException(string taskKey)
    {
        TaskList taskList = new();
        (string title, DateTime deadline) = _tasks[taskKey];
        Assert.Throws<ArgumentException>(() => taskList.CompleteTask(title, deadline));
    }
}
