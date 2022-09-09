using Clicker.Game.Businesses;
using Clicker.GameplayModel.Improvements;
using Clicker.GameplayModel.Incomies;
using Clicker.GameplayModel.Upgrades;

namespace Clicker.GameplayModel.Businesses
{
    public interface IBusiness : IBusinessInfo, IIncomendable, IUpgradable
    {
        void Work(float seconds);
        IImprovement[] GetImprovements();
        void Save();
        void Load();
    }
}