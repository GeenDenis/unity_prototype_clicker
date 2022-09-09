using System;
using System.Collections.Generic;
using Clicker.Creators;
using Clicker.Game;
using Clicker.Game.Businesses;
using Clicker.GameplayModel.Balance;
using Clicker.GameplayModel.Businesses;
using Clicker.GameplayModel.Buyes;
using Clicker.GameplayModel.Improvements;
using Clicker.GameplayModel.Incomies;
using Clicker.GameplayModel.Upgrades;

namespace Clicker.GameplayModel
{
    public class GameplayModel : IGameplayModel
    {
        private readonly List<IBusiness> _businesses;
        private readonly List<IImprovement> _improvements;
        private readonly ICreator<IBusiness, BusinessInitData> _businessCreator;
        private readonly IBalance _moneyBalance;
        private readonly IUpgrader _businessUpgrader;
        private readonly IIncome _businessIncomeCollecor;
        private readonly IBuyer _improvementBuyer;

        public int Balance => _moneyBalance.Balance;

        public GameplayModel(ICreator<IBusiness, BusinessInitData> businessCreator, IBalance moneyBalance, IUpgrader businessUpgrader, IIncome businessIncomeCollecor, IBuyer improvementBuyer)
        {
            _businesses = new List<IBusiness>();
            _improvements = new List<IImprovement>();
            _businessCreator = businessCreator;
            _moneyBalance = moneyBalance;
            _businessUpgrader = businessUpgrader;
            _businessIncomeCollecor = businessIncomeCollecor;
            _improvementBuyer = improvementBuyer;
        }

        public void Update(float delta)
        {
            _businesses.ForEach(business =>
            {
                business.Work(delta);
                _businessIncomeCollecor.GetIncome(business);
            });
        }

        public void AddBusiness(BusinessInitData businessdata)
        {
            var business = _businessCreator.Create(businessdata);
            _businesses.Add(business);
            _improvements.AddRange(business.GetImprovements());
        }

        public void UpgradeBusiness(int businessId)
        {
            var foundBusiness = _businesses.Find(business => business.Id == businessId);
            if (foundBusiness is null)
            {
                return;
            }
            _businessUpgrader.Upgrade(foundBusiness);
        }

        public void BuyImprovement(int improvementId)
        {
            var foundImprovement = _improvements.Find(improvement => improvement.Id == improvementId);
            if (foundImprovement is null)
            {
                return;
            }
            _improvementBuyer.Buy(foundImprovement);
        }

        public IBusinessInfo[] GetBusinessesInfo()
        {
            return Array.ConvertAll(_businesses.ToArray(), business => (IBusinessInfo) business);
        }

        public void LoadState()
        {
            _moneyBalance.Load();
            _businesses.ForEach(business => business.Load());
            _improvements.ForEach(improvement => improvement.Load());
        }

        public void Reset()
        {
            _businesses.Clear();
            _improvements.Clear();
        }

        public void SaveState()
        {
            _moneyBalance.Save();
            _businesses.ForEach(business => business.Save());
            _improvements.ForEach(improvement => improvement.Save());
        }
    }
}