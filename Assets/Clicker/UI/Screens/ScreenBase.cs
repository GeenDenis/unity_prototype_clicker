using UnityEngine;

namespace Clicker.UI.Screens
{
    public abstract class ScreenBase : MonoBehaviour, IScreen
    {
        public abstract void Init();

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}