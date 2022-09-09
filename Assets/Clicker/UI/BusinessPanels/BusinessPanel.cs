using System;
using System.Collections.Generic;
using Clicker.Game;
using Clicker.Game.Businesses;
using Clicker.Game.Businesses.Improvements;
using Clicker.UI.Components;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI.BusinessPanels
{
    public class BusinessPanel : MonoBehaviour, IBusinessView
    {
        [SerializeField] private ImprovementCreator _improvementCreator;
        [SerializeField] private Progressbar _incomeProgress;
        [SerializeField] private Button _levelUpButton;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _incomeText;
        [SerializeField] private TextMeshProUGUI _levelUpPriceText;
        private List<Improvement> _improvements;

        public IImprovementView[] Improvements => _improvements.ToArray();
        
        public event Action OnClickLevelUp = delegate { };
        
        [Button]
        public void Init()
        {
            _improvements = new List<Improvement>();
            
            _levelUpButton.onClick.RemoveAllListeners();
            _levelUpButton.onClick.AddListener(() =>
            {
                OnClickLevelUp.Invoke();
            });
            
            _improvementCreator.Init();
        }

        [Button]
        public void AddImprovement(IImprovementInfo data)
        {
            var improvement = _improvementCreator.CreateImprovement();
            _improvements.Add(improvement);
            improvement.SetName(data.Name);
            improvement.SetPrice(data.Price);
            improvement.SetIncomeMultiplier(data.IncomeMultiplier);
            improvement.SetBuyAccess(false);
        }

        [Button]
        public void SetName(string value)
        {
            _nameText.text = value;
        }
        
        [Button]
        public void SetLevel(int value)
        {
            _levelText.text = $"level {value}";
        }
        
        [Button]
        public void SetIncome(int value)
        {
            var sign = value < 0 ? "" : "+";
            _incomeText.text = $"Income: {sign}{value}{UIConfig.MoneySymbol}";
        }
        
        [Button]
        public void SetUpgradeCost(int value)
        {
            _levelUpPriceText.text = $"{value}{UIConfig.MoneySymbol}";
        }
        
        [Button]
        public void SetUpgradeAccess(bool value)
        {
            _levelUpButton.interactable = value;
        }
        
        [Button]
        public void SetIncomeProgress(float value)
        {
            _incomeProgress.SetProgress(value);
        }

        private void OnDestroy()
        {
            _levelUpButton.onClick.RemoveAllListeners();
        }
    }
}