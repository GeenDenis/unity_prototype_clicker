using System.Collections.Generic;

namespace Clicker.UI.Screens
{
    public class ScreensContainer : IScreensContainer
    {
        private List<IScreen> _screens;

        public void Init()
        {
            _screens = new List<IScreen>();
        }

        public void AddScreen(IScreen screen)
        {
            _screens.Add(screen);
        }

        public T GetScreen<T>() where T : IScreen
        {
            return (T)_screens.Find(ScreenIs<T>);
        }

        private bool ScreenIs<T>(IScreen screen) => screen is T;
    }
}