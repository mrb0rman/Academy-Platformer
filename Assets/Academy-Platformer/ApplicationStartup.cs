using Academy_Platformer.ScoreCounter;
using Academy_Platformer.SoundMVC;
using Bootstrap;
using CreatingCommand;
using FactoryPlayer;
using UIService;
using UnityEngine;

namespace ApplicationStartup
{
    public class ApplicationStartup : MonoBehaviour
    {
        private IBootstrap _bootstrap = new Bootstrap.Bootstrap();
        private InputController _inputController;
        private PlayerStorage _playerStorage;
        private ScoreCounter _scoreCounter;
        private HUDWindowController _hudWindowController;

        private void Start()
        {
            StartBootstrap();
        }
        
        private void StartBootstrap()
        {
            _bootstrap.Add(new CreateMainCameraCommand(out var camera));
            _bootstrap.Add(new CreateUICommand(ref _hudWindowController, camera));
            _bootstrap.Add(new CreateTickableManagerCommand());
            
            _bootstrap.OnExecuteAllComandsNotify += NotifyOfCompletion;
            _bootstrap.Execute();
            
            _inputController = new InputController();
            new PlayerController(_inputController);
            new SoundController();
            
            _scoreCounter = new ScoreCounter();
            _scoreCounter.ScoreChangeNotify += _hudWindowController.ChangeScore;
        }

        private void NotifyOfCompletion()
        { }
    }
}