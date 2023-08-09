using FactoryPlayer;

namespace Interface
{
    public interface IFactoryCharacter
    {
        PlayerView Create(PlayerModel playerModel, PlayerView playerView);
    }
}