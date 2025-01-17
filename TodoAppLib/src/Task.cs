// Ignore Spelling: App Todo

namespace TodoAppLib.Internal;

/// <summary>
/// The representation of a Task item in a todo list.
/// </summary>
public record Task : IComparable<Task>
{
    public required string Title { get; init; }
    public required DateTime DeadLine { get; init; }

    /// <summary>
    /// Creates a Task object.
    /// Due to the non-existent constructor and the internal visibility of
    /// the method, external sources cannot create tasks.
    /// </summary>
    /// <param name="title"> Cannot contain commas</param>
    /// <param name="deadLine"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Thrown if the title contains commas</exception>
    internal static Task Create(string title, DateTime deadLine)
    {
        if (title.Contains(","))
        {
            throw new ArgumentException("Title cannot contain a comma");
        }
        return new Task { Title = title, DeadLine = deadLine };
    }

    public override string ToString()
    {
        return $"{Title},{DeadLine}";
    }

    public int CompareTo(Task? other)
    {
        if (other == null)
        {
            return 1;
        }
        int dateComparison = DeadLine.CompareTo(other.DeadLine);
        if (dateComparison != 0)
        {
            return dateComparison;
        }
        return string.Compare(Title, other.Title, StringComparison.OrdinalIgnoreCase);
    }
};
