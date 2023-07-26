namespace Bootstrap.Interface
{
    public interface IBootstrap
    {
        public bool Add(ICommand command);
        public bool Start();
    }
}