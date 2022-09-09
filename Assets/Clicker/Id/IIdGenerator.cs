namespace Clicker.Id
{
    public interface IIdGenerator
    {
        int GetId();
        void Reset();
    }
}