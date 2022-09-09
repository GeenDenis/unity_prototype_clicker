namespace Clicker.GameplayModel.Balance
{
    public interface IAppendableBalance : IBalance
    {
        void Append(int value);
    }
}