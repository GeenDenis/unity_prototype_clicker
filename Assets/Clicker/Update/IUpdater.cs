namespace Clicker.Core.Update
{
    public interface IUpdater
    {
        void AddObject(IUpdatable obj);
        void RemoveObject(IUpdatable obj);
        void RemoveAllObjects();
        void StartUpdate();
        void StopUpdate();
    }
}