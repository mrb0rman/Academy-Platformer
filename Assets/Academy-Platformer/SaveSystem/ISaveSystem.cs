namespace Academy_Platformer.SaveSystem
{
    public interface ISaveSystem<T>
    {
        public abstract void Save(T date);
        public abstract T Load();
        public abstract void Clear();
    }
}