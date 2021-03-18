using GameServer.DTO;
using GameServer.Models;

namespace GameServer.Effects
{
    public interface IStatus
    {
        void SetGameState(GameStateSchema g);
        void SetGame(GameSchema g);
        void execute();
    }
}