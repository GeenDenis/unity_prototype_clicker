using System.Collections.Generic;
using System.Linq;

namespace Clicker.Game.Businesses
{
    public class BusinessHandler : IViewHandler
    {
        private readonly IGameplayModel _data;
        private readonly IBusinessInfo _businessData;
        private readonly IBusinessView _view;
        private IViewHandler[] _improvementHandlers;
        private bool _inputIsActive;

        public BusinessHandler(IGameplayModel data, IBusinessInfo businessData, IBusinessView view, IEnumerable<IViewHandler> improvementHandlers)
        {
            _data = data;
            _businessData = businessData;
            _view = view;
            _improvementHandlers = improvementHandlers.ToArray();
        }

        public void Update(float delta)
        {
            _view.SetLevel(_businessData.Level);
            _view.SetUpgradeCost(_businessData.CurrentUpgradeCost);
            _view.SetUpgradeAccess(_businessData.CurrentUpgradeCost <= _data.Balance);
            _view.SetIncome(_businessData.Income);
            _view.SetIncomeProgress(_businessData.IncomeProgress);
            
            for (int i = 0; i < _improvementHandlers.Length; i++)
            {
                _improvementHandlers[i].Update(delta);
            }
        }

        public void SetActiveInput(bool active)
        {
            if (_inputIsActive == active)
            {
                return;
            }

            if (active)
            {
                _view.OnClickLevelUp += OnClickLevelUp;
            }
            else
            {
                _view.OnClickLevelUp -= OnClickLevelUp;
            }
            
            for (int i = 0; i < _improvementHandlers.Length; i++)
            {
                _improvementHandlers[i].SetActiveInput(active);
            }
        }
        
        private void OnClickLevelUp()
        {
            _data.UpgradeBusiness(_businessData.Id);
        }
    }
}