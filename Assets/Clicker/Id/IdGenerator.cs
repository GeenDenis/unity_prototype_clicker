namespace Clicker.Id
{
    public class IdGenerator : IIdGenerator
    {
        private int _currentFreeId;

        public int GetId()
        {
            var id = _currentFreeId;
            _currentFreeId++;
            return id;
        }

        public void Reset()
        {
            _currentFreeId = 0;
        }
    }
}