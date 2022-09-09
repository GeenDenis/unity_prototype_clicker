namespace Clicker.UI.Screens
{
    public interface IScreensContainer
    {
        ScreenType GetScreen<ScreenType>() where ScreenType : IScreen;
        void AddScreen(IScreen screen);
    }
}