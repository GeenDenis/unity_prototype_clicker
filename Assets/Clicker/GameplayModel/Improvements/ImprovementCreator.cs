using Clicker.Id;
using Clicker.Creators;
using Clicker.Game.Businesses.Improvements;

namespace Clicker.GameplayModel.Improvements
{
    public class ImprovementCreator : ICreator<IImprovement, ImprovementInitData>
    {
        private readonly IIdGenerator _improvementIdGenerator;

        public ImprovementCreator(IIdGenerator improvementIdGenerator)
        {
            _improvementIdGenerator = improvementIdGenerator;
        }

        public IImprovement Create(ImprovementInitData config)
        {
            return new Improvement(
                id: _improvementIdGenerator.GetId(),
                name: config.Name,
                incomeMultiplier: config.IncomeMultiplier,
                cost: config.Price);
        }

        public void Reset()
        {
            _improvementIdGenerator.Reset();
        }
    }
}