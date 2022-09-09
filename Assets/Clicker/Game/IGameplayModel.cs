using Clicker.Core.Update;
using Clicker.Game.Businesses;

namespace Clicker.Game
{
    public interface IGameplayModel : IUpdatable
    {
        int Balance { get; }

        IBusinessInfo[] GetBusinessesInfo();
        void UpgradeBusiness(int businessId);
        void BuyImprovement(int improvementId);
        void AddBusiness(BusinessInitData businessData);
        void SaveState();
        void LoadState();
        void Reset();
    }
}