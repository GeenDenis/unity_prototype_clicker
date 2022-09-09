namespace Clicker.Creators
{
    public interface ICreator<T, ConfigType>
    {
        T Create(ConfigType config);
        void Reset();
    }
}