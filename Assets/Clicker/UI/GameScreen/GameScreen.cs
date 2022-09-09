using System.Collections.Generic;
using Clicker.Game.Businesses;
using Clicker.UI.BusinessPanels;
using Clicker.UI.Components;
using Clicker.UI.Screens;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Clicker.UI.GameScreen
{
    public class GameScreen : ScreenBase, IGameScreen
    {
        [SerializeField] private BusinessCreator _businessCreator;
        [SerializeField] private Counter _moneyCounter;
        private List<BusinessPanel> _businesses;

        [Button]
        public override void Init()
        {
            _businesses = new List<BusinessPanel>();

            _moneyCounter.Init();
            _moneyCounter.SetPostfix(UIConfig.MoneySymbol);
        }

        [Button]
        public IBusinessView CreateBusinessView(IBusinessInfo data)
        {
            var businessPanel = _businessCreator.CreateBusiness();
            _businesses.Add(businessPanel);
            CreateImprovements(businessPanel, data);
            businessPanel.SetName(data.Name);
            businessPanel.SetIncomeProgress(data.IncomeProgress);
            businessPanel.SetIncome(data.Income);
            businessPanel.SetLevel(data.Level);
            businessPanel.SetUpgradeCost(data.CurrentUpgradeCost);
            businessPanel.SetUpgradeAccess(false);
            return businessPanel;
        }

        public void ClearView()
        {
            _businesses.ForEach(business =>
            {
                Destroy(business.gameObject);
            });
        }

        public void SetBalance(int value)
        {
            _moneyCounter.SetValue(value);
        }

        private void CreateImprovements(BusinessPanel businessView, IBusinessInfo data)
        {
            data.GetImprovementsInfo().ForEach(businessView.AddImprovement);
        }
    }
}