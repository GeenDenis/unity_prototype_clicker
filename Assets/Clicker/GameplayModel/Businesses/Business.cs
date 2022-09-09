using System;
using Clicker.Game;
using Clicker.Game.Businesses.Improvements;
using Clicker.GameplayModel.Improvements;
using Clicker.GameplayModel.Save;
using GeneDenis.Serialisation;
using UnityEngine;

namespace Clicker.GameplayModel.Businesses
{
    public class Business : IBusiness
    {
        private readonly IImprovement[] _improvements;
        private readonly string _name;
        private readonly float _incomeDelay;
        private readonly int _id;
        private readonly int _basePrice;
        private float _incomeProgress;
        private int _level;
        private int _upgradeCost;

        public string Name => _name;
        public int Id => _id;
        public int Level => _level;
        public int UpgradeCost => _upgradeCost;
        public int CurrentUpgradeCost => _upgradeCost;
        public int Income => GetIncomeValue();
        public float IncomeProgress => _incomeProgress;

        public Business(int id, string name, float incomeDelay, int basePrice, IImprovement[] improvements)
        {
            _id = id;
            _name = name;
            _incomeDelay = incomeDelay;
            _basePrice = basePrice;
            _improvements = improvements;
            _upgradeCost = GetUpgradeCostValue();
        }

        public void Work(float seconds)
        {
            if (_level == 0)
            {
                return;
            }
            
            _incomeProgress += seconds / _incomeDelay;
        }

        public void Upgrade()
        {
            _level++;
            _upgradeCost = GetUpgradeCostValue();
        }

        public IImprovementInfo[] GetImprovementsInfo()
        {
            return Array.ConvertAll(_improvements, improvement => (IImprovementInfo) improvement);
        }

        public IImprovement[] GetImprovements()
        {
            return _improvements;
        }

        private int GetUpgradeCostValue()
        {
            return (_level + 1) * _basePrice;
        }

        private int GetIncomeValue()
        {
            var income = _level * _basePrice * ImprovementsIncomeMultiplier();
            return Mathf.RoundToInt(income);
        }

        private float ImprovementsIncomeMultiplier()
        {
            var improvementsIncomeMultiplier = 1f;
            for (int i = 0; i < _improvements.Length; i++)
            {
                if (_improvements[i].IsPurchased)
                {
                    improvementsIncomeMultiplier += _improvements[i].IncomeMultiplier;
                }
            }

            return improvementsIncomeMultiplier;
        }

        public int GetIncome()
        {
            var incomeProgress = Mathf.FloorToInt(_incomeProgress);
            _incomeProgress -= incomeProgress;
            return incomeProgress * Income;
        }

        public void Load()
        {
            LoadField(SaveKey.BUSINESS_LEVEL_KEY(_id), ref _level);
            LoadField(SaveKey.BUSINESS_INCOME_PROGRESS_KEY(_id), ref _incomeProgress);
            _upgradeCost = GetUpgradeCostValue();
        }

        public void Save()
        {
            DataSaver.Save(SaveKey.BUSINESS_LEVEL_KEY(_id), _level);
            DataSaver.Save(SaveKey.BUSINESS_INCOME_PROGRESS_KEY(_id), _incomeProgress);
        }

        private static void LoadField<T>(string key, ref T value)
        {
            if(DataSaver.TryLoad(key, out T loadedValue))
            {
                value = loadedValue;
            }
        }
    }
}