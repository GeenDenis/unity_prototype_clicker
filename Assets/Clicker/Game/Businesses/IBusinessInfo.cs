using Clicker.Game.Businesses.Improvements;

namespace Clicker.Game.Businesses
{
    public interface IBusinessInfo
    {
        string Name { get; }
        float IncomeProgress { get; }
        int Income { get; }
        int Id { get; }
        int Level { get; }
        int CurrentUpgradeCost { get; }

        IImprovementInfo[] GetImprovementsInfo();
    }
}