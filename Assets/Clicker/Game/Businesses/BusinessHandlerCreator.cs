using Clicker.Game.Businesses.Improvements;

namespace Clicker.Game.Businesses
{
    public class BusinessHandlerCreator : IHandlerCreator<IBusinessInfo>
    {
        private readonly IGameplayModel _gameplayModel;
        private readonly IGameplayView _view;

        public BusinessHandlerCreator(IGameplayModel gameplayModel, IGameplayView view)
        {
            _gameplayModel = gameplayModel;
            _view = view;
        }

        public IViewHandler Create(IBusinessInfo businessData)
        {
            var businessView = _view.CreateBusinessView(businessData);
            var improvementHandlers = CreateImprovementHandlers(businessData.GetImprovementsInfo(), businessView.Improvements);
            return new BusinessHandler(_gameplayModel, businessData, businessView, improvementHandlers);
        }
        
        public IViewHandler[] CreateImprovementHandlers(IImprovementInfo[] improvementsData, IImprovementView[] improvementViews)
        {
            var improvementHandlers = new IViewHandler[improvementsData.Length];
            for (int i = 0; i < improvementsData.Length; i++)
            {
                improvementHandlers[i] = new ImprovementHandler(_gameplayModel, improvementsData[i], improvementViews[i]);
            }
            return improvementHandlers;
        }
    }
}