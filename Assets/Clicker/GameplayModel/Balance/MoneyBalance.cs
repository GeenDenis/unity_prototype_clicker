using System;
using Clicker.GameplayModel.Save;
using GeneDenis.Serialisation;

namespace Clicker.GameplayModel.Balance
{
    public class MoneyBalance : IAppendableBalance, ISpendableBalance
    {
        private int _balance;

        public int Balance => _balance;

        public void Append(int value)
        {
            _balance += value;
        }

        public bool TrySpend(int value)
        {
            if (_balance >= value)
            {
                _balance -= value;
                return true;
            }

            return false;
        }

        public void Load()
        {
            DataSaver.TryLoad(SaveKey.BALANCE_KEY, out _balance);
        }

        public void Save()
        {
            DataSaver.Save(SaveKey.BALANCE_KEY, _balance);
        }
    }
}