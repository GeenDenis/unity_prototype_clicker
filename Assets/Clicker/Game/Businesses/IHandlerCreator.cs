namespace Clicker.Game.Businesses
{
    public interface IHandlerCreator<InDataType>
    {
        IViewHandler Create(InDataType data);
    }
}