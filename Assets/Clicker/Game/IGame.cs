using Clicker.Core.Update;

namespace Clicker.Game
{
    public interface IGame : IUpdatable
    {
        void PlayGame();
        void StopGame();
        void PauseGame();
        void LoadGame();
        void SaveGame();
    }
}