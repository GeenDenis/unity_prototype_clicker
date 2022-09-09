using Clicker.Config;

namespace Clicker.Game.Businesses.Improvements
{
    public struct ImprovementInitData
    {
        public readonly string Name;
        public readonly int Price;
        public readonly float IncomeMultiplier;

        public ImprovementInitData(ImprovementConfig config)
        {
            Name = config.ImprovementName;
            Price = config.Price;
            IncomeMultiplier = config.IncomeMultiplier;
        }
    }
}