using FactoryPlayer;

public class GameObjectsStorage
{
    private static GameObjectsStorage _instance;
    
    public TickableManager TickableManager;
    public PlayerView PlayerView;

    public static GameObjectsStorage GetInstance()
    {
        if (_instance == null)
            _instance = new GameObjectsStorage();
        return _instance;
    }
}
