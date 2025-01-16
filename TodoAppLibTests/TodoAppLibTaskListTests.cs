namespace TodoAppLibTests;

using TodoAppLib;

/// <summary>
/// Tests for the TodoAppLib.
/// Only testing the methods from TodoAppLib as the useful methods from
/// TodoAppLib.Task are inaccessible
/// </summary>
public class TodoAppLibTaskListTests
{
    private static readonly Dictionary<string, (string title, DateTime deadline)> _tasks = new()
    {
        { "TestTask", ("TestTask", DateTime.Now.AddYears(10)) },
        { "TestTaskTwo", ("TestTaskTwo", DateTime.Now.AddYears(10)) },
        { "TestTaskThree", ("TestTaskThree", DateTime.Now.AddYears(20)) },
        { "TestTaskBroken", ("TestTaskBroken,", new DateTime(1999, 1, 1)) },
    };

    public static IEnumerable<object[]> ValidTasks =>
        _tasks.Where(kv => kv.Key != "TestTaskBroken").Select(kv => new object[] { kv.Key });

    private static void AddTask(TaskList taskList, string taskKey)
    {
        var (title, deadline) = _tasks[taskKey];
        taskList.Add(title, deadline);
    }

    [Theory]
    [MemberData(nameof(ValidTasks))]
    public void Add_SingleTask_ReturnsTrue(string taskKey)
    {
        var taskList = new TaskList();
        var (title, deadline) = _tasks[taskKey];

        Assert.True(taskList.Add(title, deadline));
    }

    [Fact]
    public void Add_SingleTask_ThrowsArgumentException()
    {
        var taskList = new TaskList();
        var (title, deadline) = _tasks["TestTaskBroken"];

        Assert.Throws<ArgumentException>(() => taskList.Add(title, deadline));
    }

    [Theory]
    [MemberData(nameof(ValidTasks))]
    public void Remove_SingleTask_ReturnsTrue(string taskKey)
    {
        var taskList = new TaskList();
        AddTask(taskList, taskKey);

        var (title, deadline) = _tasks[taskKey];
        Assert.True(taskList.Remove(title, deadline));
    }

    [Theory]
    [MemberData(nameof(ValidTasks))]
    public void Remove_SingleTask_ReturnsFalse(string taskKey)
    {
        var taskList = new TaskList();
        var (title, deadline) = _tasks[taskKey];

        Assert.False(taskList.Remove(title, deadline));
    }

    [Fact]
    public void Remove_SingleTask_ThrowsArgumentException()
    {
        var taskList = new TaskList();
        var (title, deadline) = _tasks["TestTaskBroken"];

        Assert.Throws<ArgumentException>(() => taskList.Remove(title, deadline));
    }

    [Theory]
    [MemberData(nameof(ValidTasks))]
    public void ContainsTask_SingleTask_ReturnsTrue(string taskKey)
    {
        var taskList = new TaskList();
        AddTask(taskList, taskKey);

        var (title, deadline) = _tasks[taskKey];
        Assert.True(taskList.ContainsTask(title, deadline));
    }

    [Theory]
    [MemberData(nameof(ValidTasks))]
    public void ContainsTask_SingleTask_ReturnsFalse(string taskKey)
    {
        var taskList = new TaskList();
        var (title, deadline) = _tasks[taskKey];

        Assert.False(taskList.ContainsTask(title, deadline));
    }

    [Fact]
    public void ContainsTask_SingleTask_ThrowsArgumentException()
    {
        var taskList = new TaskList();
        var (title, deadline) = _tasks["TestTaskBroken"];

        Assert.Throws<ArgumentException>(() => taskList.ContainsTask(title, deadline));
    }

    [Theory]
    [MemberData(nameof(ValidTasks))]
    public void ModifyTask_SingleTask_ReturnsTrue(string taskKey)
    {
        var taskList = new TaskList();
        AddTask(taskList, taskKey);

        var (title, deadline) = _tasks[taskKey];

        Assert.True(taskList.ModifyTask(title, deadline, $"Modified{title}", deadline.AddYears(1)));
    }

    [Theory]
    [MemberData(nameof(ValidTasks))]
    public void ModifyTask_SingleTask_ReturnsFalse(string taskKey)
    {
        var taskList = new TaskList();
        var (title, deadline) = _tasks[taskKey];

        Assert.False(
            taskList.ModifyTask(title, deadline, $"Modified{title}", deadline.AddYears(1))
        );
    }

    [Fact]
    public void ModifyTask_SingleTask_ThrowsArgumentException()
    {
        var taskList = new TaskList();
        var (title, deadline) = _tasks["TestTaskBroken"];

        Assert.Throws<ArgumentException>(
            () => taskList.ModifyTask(title, deadline, $"Modified{title}", deadline.AddYears(1))
        );
    }

    [Theory]
    [MemberData(nameof(ValidTasks))]
    public void CompleteTask_SingleTask_ReturnsTrue(string taskKey)
    {
        var taskList = new TaskList();
        AddTask(taskList, taskKey);

        var (title, deadline) = _tasks[taskKey];
        Assert.True(taskList.CompleteTask(title, deadline));
    }

    [Theory]
    [MemberData(nameof(ValidTasks))]
    public void CompleteTask_SingleTask_ReturnsFalse(string taskKey)
    {
        var taskList = new TaskList();
        var (title, deadline) = _tasks[taskKey];

        Assert.False(taskList.CompleteTask(title, deadline));
    }

    [Fact]
    public void CompleteTask_SingleTask_ThrowsArgumentException()
    {
        var taskList = new TaskList();
        var (title, deadline) = _tasks["TestTaskBroken"];

        Assert.Throws<ArgumentException>(() => taskList.CompleteTask(title, deadline));
    }
}
