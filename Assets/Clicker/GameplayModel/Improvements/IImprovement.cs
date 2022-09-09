using Clicker.Game.Businesses.Improvements;
using Clicker.GameplayModel.Buyes;

namespace Clicker.GameplayModel.Improvements
{
    public interface IImprovement : IImprovementInfo, IBuyable
    {
        void Save();
        void Load();
    }
}