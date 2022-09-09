using System.Collections.Generic;
using UnityEngine;

namespace Clicker.Config
{
    [CreateAssetMenu(fileName = "BusinessConfig", menuName = "Clicker/New Business", order = 1)]
    public class BusinessConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField][Min(0.0001f)] private float _incomeDelay;
        [SerializeField][Min(0)] private int _basePrice;
        [SerializeField][Min(0)] private int _baseIncome;
        [SerializeField] private List<ImprovementConfig> _improvements;
        
        public string BusinessName => _name;
        public float IncomeDelay => _incomeDelay;
        public int BasePrice => _basePrice;
        public int BaseIncome => _baseIncome;
        public List<ImprovementConfig> Improvements => _improvements;
    }
}