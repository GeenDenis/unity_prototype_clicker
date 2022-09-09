using System;
using Clicker.Game.Businesses.Improvements;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI.BusinessPanels
{
    public class Improvement : MonoBehaviour, IImprovementView
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Color _normalColor;
        [SerializeField] private Color _purchasedColor;

        private string _name;
        private string _incomeMultiplier;
        private bool _isPurchased;
        
        public event Action OnClickBuy = delegate { };

        [Button]
        public void Init()
        {
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() =>
            {
                OnClickBuy.Invoke();
            });
            UpdateDescription();
        }

        [Button]
        public void SetPurchasedState(bool value)
        {
            _isPurchased = value;
            var colors = _button.colors;
            colors.disabledColor = _isPurchased
                ? _purchasedColor
                : _normalColor;
            _button.colors = colors;
        }
        
        [Button]
        public void SetBuyAccess(bool active)
        {
            _button.interactable = _isPurchased
            ? false
            : active;
        }

        [Button]
        public void SetName(string text)
        {
            _name = text;
            UpdateDescription();
        }
        
        [Button]
        public void SetIncomeMultiplier(float value)
        {
            var sign = value < 0 ? "" : "+";
            _incomeMultiplier = $"{sign}{value * 100}%";
            UpdateDescription();
        }
        
        [Button]
        public void SetPrice(int value)
        {
            _priceText.text = _isPurchased 
            ? "Purchased"
            : $"{value}{UIConfig.MoneySymbol}";
        }

        private void UpdateDescription()
        {
            _descriptionText.text = $"{_name}, {_incomeMultiplier}";
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
    }
}