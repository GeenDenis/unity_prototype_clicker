using Clicker.Config;
using Clicker.Core.Update;
using Clicker.Game;
using Clicker.GameplayModel;
using Clicker.UI;
using Clicker.UI.GameScreen;
using UnityEngine;

namespace Clicker
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private GameConfig _config;
        [SerializeField] private UpdateCaller _saveCaller;
        [SerializeField] private UpdateCaller _gameUpdater;
        [SerializeField] private ScreensInitialisator _screensInitialisator;

        private IGameplayModel _gameplayModel;
        private IGame _game;
        
        private void Awake() => Init();

        private void Init()
        {
            if (!BaseSave.SaveIsExists)
            {
                BaseSave.ApplyBaseSave();
            }
            
            
            //-------------------------------------
            _saveCaller.Init();
            _gameUpdater.Init();
            
            UIConfig.MoneySymbol = _config.MoneySymbol;
            var screenContainer = _screensInitialisator.Init();
            var gameScreen = screenContainer.GetScreen<IGameScreen>();
            
            _gameplayModel = GameplayModelInitialisator.Init();
            _game = GameInitialisator.Init(_gameplayModel, _gameUpdater, gameScreen, _config.Businesses);
            _gameUpdater.AddObject(_game);
            _game.PlayGame();
            //-------------------------------------
            
            
            _gameplayModel.LoadState();
            _saveCaller.AddObject(new AutoSaver(_gameplayModel));
            _saveCaller.StartUpdate();
        }
    }
}