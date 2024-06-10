public interface IExecutable
{
    protected Func<bool> CanExecute { get; init; }
}