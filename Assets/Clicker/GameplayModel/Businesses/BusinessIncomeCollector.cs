using Clicker.GameplayModel.Balance;
using Clicker.GameplayModel.Incomies;

namespace Clicker.GameplayModel.Businesses
{
    public class BusinessIncomeCollector : IIncome
    {
        private readonly IAppendableBalance _balance;

        public BusinessIncomeCollector(IAppendableBalance balance)
        {
            _balance = balance;
        }

        public void GetIncome(IIncomendable obj)
        {
            _balance.Append(obj.GetIncome());
        }
    }
}