using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI.BusinessPanels
{
    public class BusinessCreator : MonoBehaviour
    {
        [SerializeField] private BusinessPanel _businessPrefab;
        [SerializeField] private VerticalLayoutGroup _businessContainer;

        public BusinessPanel CreateBusiness()
        {
            var improvement = Instantiate(_businessPrefab, _businessContainer.transform);
            improvement.Init();
            return improvement;
        }
    }
}