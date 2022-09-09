namespace Clicker.GameplayModel.Upgrades
{
    public interface IUpgradable
    {
        int UpgradeCost { get; }

        void Upgrade();
    }
}