using TodoAppLib;
using Task = TodoAppLib.Internal.Task;

DateTime date = new(2027, 12, 3);
DateTime date2 = new(2026, 12, 3);

TaskList taskList = new();
taskList.Add("kLOL", date2);
taskList.Add("jLOL", date2);
taskList.Add("LOL", date);
taskList.Complete("LOL", date);
