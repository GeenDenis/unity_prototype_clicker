using System.Collections.Generic;
using UnityEngine;

namespace Clicker.Config
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Clicker/New Config", order = 0)]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private List<BusinessConfig> _businesses;
        [SerializeField] private string _moneySymbol;

        public BusinessConfig[] Businesses => _businesses.ToArray();
        public string MoneySymbol => _moneySymbol;
    }
}