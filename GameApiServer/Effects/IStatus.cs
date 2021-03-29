using GameApiServer.DTO;

namespace GameApiServer.Effects
{
    public interface IStatus
    {
        void SetGameState(GameStateSchema g);
        void SetGame(GameSchema g);
        void execute();
    }
}