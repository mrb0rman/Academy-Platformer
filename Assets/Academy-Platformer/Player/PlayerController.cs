using Interface;

namespace FactoryPlayer
{
    public class PlayerController
    {
        private readonly IFactoryCharacter _factoryPlayer = new FactoryPlayer();
        
        public void Spawn()
        {
            _factoryPlayer.Create();
        }
    }
}