namespace Clicker.Game.Businesses.Improvements
{
    public class ImprovementHandler : IViewHandler
    {
        private readonly IGameplayModel _data;
        private readonly IImprovementInfo _improvementData;
        private readonly IImprovementView _view;
        private bool _inputIsActive;

        public ImprovementHandler(IGameplayModel data, IImprovementInfo improvementData, IImprovementView view)
        {
            _data = data;
            _improvementData = improvementData;
            _view = view;
        }

        public void Update(float delta)
        {
            _view.SetBuyAccess(_improvementData.Price <= _data.Balance);
            _view.SetPurchasedState(_improvementData.IsActive);
            _view.SetPrice(_improvementData.Price);
        }

        public void SetActiveInput(bool active)
        {
            if (_inputIsActive == active)
            {
                return;
            }
            
            if (active)
            {
                _view.OnClickBuy += OnClickBuy;
            }
            else
            {
                _view.OnClickBuy -= OnClickBuy;
            }
        }

        private void OnClickBuy()
        {
            _data.BuyImprovement(_improvementData.Id);
        }
    }
}