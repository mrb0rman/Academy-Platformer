using Command;
namespace Bootstrap
{
    public interface IBootstrap
    {
        void Add(ICommand command);
        void Execute();
    }
}