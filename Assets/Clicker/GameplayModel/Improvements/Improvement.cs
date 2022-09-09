using Clicker.GameplayModel.Save;
using GeneDenis.Serialisation;

namespace Clicker.GameplayModel.Improvements
{
    public class Improvement : IImprovement
    {
        private readonly int _id;
        private readonly string _name;
        private readonly float _incomeMultiplier;
        private readonly int _cost;

        public string Name => _name;
        public int Id => _id;
        public float IncomeMultiplier => _incomeMultiplier;
        public bool IsActive => IsPurchased;
        public int Price => _cost;
        public bool IsPurchased { get; private set; }

        public Improvement(int id, string name, float incomeMultiplier, int cost)
        {
            _id = id;
            _name = name;
            _incomeMultiplier = incomeMultiplier;
            _cost = cost;
            IsPurchased = false;
        }

        public void Buy()
        {
            IsPurchased = true;
        }

        public void Load()
        {
            if(DataSaver.TryLoad(SaveKey.IMPROVEMENT_IS_ACTIVE_KEY(_id), out bool isBuyed))
            {
                IsPurchased = isBuyed;
            }
        }

        public void Save()
        {
            DataSaver.Save(SaveKey.IMPROVEMENT_IS_ACTIVE_KEY(_id), IsPurchased);
        }
    }
}