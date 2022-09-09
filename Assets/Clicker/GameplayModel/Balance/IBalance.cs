using Unity.VisualScripting.Dependencies.NCalc;

namespace Clicker.GameplayModel.Balance
{
    public interface IBalance
    {
        int Balance { get; }

        void Load();
        void Save();
    }
}