using Clicker.Config;
using Clicker.Game.Businesses.Improvements;

namespace Clicker.Game.Businesses
{
    public struct BusinessInitData
    {
        public readonly string Name;
        public readonly float IncomeDelay;
        public readonly int BasePrice;
        public readonly int BaseIncome;
        public ImprovementInitData[] Improvements;

        public BusinessInitData(BusinessConfig config)
        {
            Name = config.BusinessName;
            IncomeDelay = config.IncomeDelay;
            BasePrice = config.BasePrice;
            BaseIncome = config.BaseIncome;
            Improvements = new ImprovementInitData[config.Improvements.Count];
            for (int i = 0; i < Improvements.Length; i++)
            {
                Improvements[i] = new ImprovementInitData(config.Improvements[i]);
            }
        }
    }
}