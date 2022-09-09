using Clicker.Core.Update;
using Clicker.Game;

namespace Clicker
{
    public class AutoSaver : IUpdatable
    {
        private readonly IGameplayModel _gameplayModel;

        public AutoSaver(IGameplayModel gameplayModel)
        {
            _gameplayModel = gameplayModel;
        }

        public void Update(float delta)
        {
            _gameplayModel.SaveState();
        }
    }
}