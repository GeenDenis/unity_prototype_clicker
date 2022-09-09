using Clicker.Config;
using Clicker.Core.Update;
using Clicker.Game.Businesses;

namespace Clicker.Game
{
    public static class GameInitialisator
    {
        public static Game Init(IGameplayModel gameplayModel, IUpdater gameUpdater, IGameplayView view, BusinessConfig[] configs)
        {
            var handlerCreator = new BusinessHandlerCreator(gameplayModel, view); ;
            return new Game(gameplayModel, gameUpdater, view, handlerCreator, configs);
        }
    }
}