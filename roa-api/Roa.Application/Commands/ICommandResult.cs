namespace Roa.Application.Commands;
public interface ICommandResult<out T> where T : class
{
    bool Success { get; }
    string Message { get; }
    T Data { get; }
    ICollection<string> Notifications { get; }

    void AddNotification(string message);
}