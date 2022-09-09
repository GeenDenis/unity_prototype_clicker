namespace Clicker.GameplayModel.Balance
{
    public interface ISpendableBalance : IBalance
    {
        bool TrySpend(int value);
    }
}