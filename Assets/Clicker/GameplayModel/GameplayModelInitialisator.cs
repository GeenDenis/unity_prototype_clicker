using Clicker.GameplayModel.Balance;
using Clicker.GameplayModel.Businesses;
using Clicker.GameplayModel.Improvements;
using Clicker.Id;

namespace Clicker.GameplayModel
{
    public static class GameplayModelInitialisator
    {
        public static GameplayModel Init()
        {
            var businessIdGenerator = new IdGenerator();
            var improvementIdGenerator = new IdGenerator();
            var improvementCreator = new ImprovementCreator(improvementIdGenerator);
            var businessCreator = new BusinessCreator(businessIdGenerator, improvementCreator);
            var moneyBalance = new MoneyBalance();
            var incomeCollector = new BusinessIncomeCollector(moneyBalance);
            var businessUpgrader = new BusinessUpgrader(moneyBalance);
            var improvementBuyer = new ImprovementBuyer(moneyBalance);
            return new GameplayModel(businessCreator, moneyBalance, businessUpgrader, incomeCollector, improvementBuyer);
        }
    }
}