namespace Clicker.GameplayModel.Buyes
{
    public interface IBuyable
    {
        bool IsPurchased { get; }
        int Price { get; }

        void Buy();
    }
}