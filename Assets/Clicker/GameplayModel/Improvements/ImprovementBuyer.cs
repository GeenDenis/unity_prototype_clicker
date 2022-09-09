using Clicker.GameplayModel.Balance;
using Clicker.GameplayModel.Buyes;

namespace Clicker.GameplayModel.Improvements
{
    public class ImprovementBuyer : IBuyer
    {
        private readonly ISpendableBalance _moneyBalance;

        public ImprovementBuyer(ISpendableBalance moneyBalance)
        {
            _moneyBalance = moneyBalance;
        }

        public void Buy(IBuyable obj)
        {
            if (!obj.IsPurchased && _moneyBalance.TrySpend(obj.Price))
            {
                obj.Buy();
            }
        }
    }
}