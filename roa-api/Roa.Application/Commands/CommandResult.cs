namespace Roa.Application.Commands;

public class CommandResult<T> : ICommandResult<T> where T : class
{
    public CommandResult(bool success, string message, T data, ICollection<string> notifications)
    {
        Success = success;
        Message = message;
        Data = data;
        Notifications = notifications;
    }

    public CommandResult(bool success, string message, T data)
    {
        Notifications = new List<string>();

        Success = success;
        Message = message;
        Data = data;
    }

    public bool Success { get; private set; }
    public string Message { get; private set; }
    public T Data { get; private set; }
    public ICollection<string> Notifications { get; private set; }

    public void AddNotification(string message) => Notifications.Add(message);

    public static CommandResult<T> CreateSuccess(T data) => new CommandResult<T>(true, "Success", data);

    public static CommandResult<T> CreateError(string message) => new CommandResult<T>(false, message, default(T));

    public static CommandResult<T> CreateError(string message, ICollection<string> notifications) =>
      new CommandResult<T>(false, message, default(T), notifications);

}