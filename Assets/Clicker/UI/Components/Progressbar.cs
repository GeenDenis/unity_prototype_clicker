using Sirenix.OdinInspector;
using UnityEngine;

namespace Clicker.UI.Components
{
    public class Progressbar : MonoBehaviour
    {
        [SerializeField] private RectTransform _progressRectTransform;

        [Button]
        public void SetProgress(float value)
        {
            value = Mathf.Clamp(value, 0.02f, 1f);
            var anchorMaxY = _progressRectTransform.anchorMax.y;
            _progressRectTransform.anchorMax = new Vector2(value, anchorMaxY);
        }
    }
}