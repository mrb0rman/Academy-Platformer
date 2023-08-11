using FactoryPlayer;

public class GameObjectStorage
{
    private static GameObjectStorage _instance;
    
    public TickableManager TickableManager;
    public PlayerView PlayerView;

    public static GameObjectStorage GetInstance()
    {
        if (_instance == null)
            _instance = new GameObjectStorage();
        return _instance;
    }
}
