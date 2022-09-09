namespace Clicker.Game.Businesses.Improvements
{
    public interface IImprovementInfo
    {
        string Name { get; }
        int Id { get; }
        int Price { get; }
        float IncomeMultiplier { get; }
        bool IsActive { get; }
    }
}