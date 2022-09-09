using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI.BusinessPanels
{
    public class ImprovementCreator : MonoBehaviour
    {
        [SerializeField] private Improvement _improvementPrefab;
        [SerializeField] private VerticalLayoutGroup _improvementContainer;

        public void Init()
        {
            UpdateContainer();
        }
        
        public Improvement CreateImprovement()
        {
            var improvement = Instantiate(_improvementPrefab, _improvementContainer.transform);
            improvement.Init();
            UpdateContainer();
            return improvement;
        }

        private void UpdateContainer()
        {
            _improvementContainer.padding.bottom = _improvementContainer.transform.childCount > 0 ? 30 : 0;
        }
    }
}