using System.Collections.Generic;
using Clicker.Config;
using Clicker.Core.Update;
using Clicker.Game.Businesses;

namespace Clicker.Game
{
    public class Game : IGame
    {
        private readonly IGameplayModel _gameplayModel;
        private readonly IGameplayView _view;
        private readonly IHandlerCreator<IBusinessInfo> _handlerCreator;
        private readonly IUpdater _gameUpdater;
        private readonly BusinessConfig[] _configs;
        private List<IViewHandler> _businessHandlers;
        private bool _isStarted;
        private bool _isPaused;

        public Game(IGameplayModel gameplayModel, IUpdater gameUpdater, IGameplayView view, IHandlerCreator<IBusinessInfo> handlerCreator, BusinessConfig[] configs)
        {
            _businessHandlers = new List<IViewHandler>();
            _gameplayModel = gameplayModel;
            _view = view;
            _handlerCreator = handlerCreator;
            _gameUpdater = gameUpdater;
            _configs = configs;
        }

        public void Update(float delta)
        {
            _gameplayModel.Update(delta);
            for (int i = 0; i < _businessHandlers.Count; i++)
            {
                _businessHandlers[i].Update(delta);
            }
            _view.SetBalance(_gameplayModel.Balance);
        }

        public void PlayGame()
        {
            if (_isStarted && _isPaused)
            {
                SetActiveInput(true);
                _gameUpdater.StartUpdate();
                _isPaused = false;
                return;
            }
            
            StopGame();
            InitModel();
            InitHandlers();
            _gameUpdater.StartUpdate();
            _isStarted = true;
        }

        public void StopGame()
        {
            SetActiveInput(false);
            _businessHandlers.Clear();
            _gameUpdater.StopUpdate();
            _gameplayModel.Reset();
            _view.ClearView();
            _isStarted = false;
            _isPaused = false;
        }

        public void PauseGame()
        {
            SetActiveInput(false);
            _gameUpdater.StopUpdate();
            _isPaused = true;
        }

        public void LoadGame()
        {
            if (!_isStarted)
            {
                PlayGame();
            }
            
            _gameplayModel.LoadState();
        }

        public void SaveGame()
        {
            if (!_isStarted)
            {
                return;
            }
            
            _gameplayModel.SaveState();
        }

        private void InitModel()
        {
            for (int i = 0; i < _configs.Length; i++)
            {
                _gameplayModel.AddBusiness(new BusinessInitData(_configs[i]));
            }
        }

        private void InitHandlers()
        {
            var business = _gameplayModel.GetBusinessesInfo();
            for (int i = 0; i < business.Length; i++)
            {
                var handler = _handlerCreator.Create(business[i]);
                handler.SetActiveInput(true);
                _businessHandlers.Add(handler);
            }
        }


        private void SetActiveInput(bool active)
        {
            for (int i = 0; i < _businessHandlers.Count; i++)
            {
                _businessHandlers[i].SetActiveInput(active);
            }
        }
    }
}