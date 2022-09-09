using System.Collections.Generic;
using Clicker.UI.Screens;
using UnityEngine;

namespace Clicker.UI
{
    public class ScreensInitialisator : MonoBehaviour
    {
        [SerializeField] private List<ScreenBase> _screens;

        public IScreensContainer Init()
        {
            var screenContainer = new ScreensContainer();
            screenContainer.Init();
            InitScreens(screenContainer);
            return screenContainer;
        }

        private void InitScreens(IScreensContainer screenContainer)
        {
            for (int i = 0; i < _screens.Count; i++)
            {
                InitScreen(_screens[i], screenContainer);
            }
        }

        private void InitScreen(ScreenBase screen, IScreensContainer screenContainer)
        {
            screen.Init();
            screenContainer.AddScreen(screen);
        }
    }
}