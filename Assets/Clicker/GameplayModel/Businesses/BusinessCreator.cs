using System.Collections.Generic;
using Clicker.Id;
using Clicker.Creators;
using Clicker.Game.Businesses;
using Clicker.Game.Businesses.Improvements;
using Clicker.GameplayModel.Improvements;

namespace Clicker.GameplayModel.Businesses
{
    public class BusinessCreator : ICreator<IBusiness, BusinessInitData>
    {
        private readonly IIdGenerator _businessIdGenerator;
        private readonly ICreator<IImprovement, ImprovementInitData> _improvementCreator;

        public BusinessCreator(IIdGenerator businessIdGenerator, ICreator<IImprovement, ImprovementInitData> improvementCreator)
        {
            _businessIdGenerator = businessIdGenerator;
            _improvementCreator = improvementCreator;
        }

        public IBusiness Create(BusinessInitData config)
        {
            var improvements = new List<IImprovement>();
            for (int i = 0; i < config.Improvements.Length; i++)
            {
                var improvement = _improvementCreator.Create(config.Improvements[i]);
                improvements.Add(improvement);
            }

            return new Business(
                _businessIdGenerator.GetId(),
                config.Name,
                config.IncomeDelay,
                config.BasePrice,
                improvements.ToArray());
        }

        public void Reset()
        {
            _businessIdGenerator.Reset();
        }
    }
}