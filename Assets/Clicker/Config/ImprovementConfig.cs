using UnityEngine;

namespace Clicker.Config
{
    [CreateAssetMenu(fileName = "BusinessImprovementConfig", menuName = "Clicker/New Business Improvement", order = 2)]
    public class ImprovementConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField][Min(0)] private int _price;
        [SerializeField][Min(0)] private float _incomeMultiplier;
        
        public string ImprovementName => _name;
        public int Price => _price;
        public float IncomeMultiplier => _incomeMultiplier;
    }
}