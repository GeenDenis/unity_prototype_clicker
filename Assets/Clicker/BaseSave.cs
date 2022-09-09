using Clicker.GameplayModel.Save;
using GeneDenis.Serialisation;

namespace Clicker
{
    public class BaseSave
    {
        public static bool SaveIsExists => DataSaver.Has(SaveKey.BUSINESS_LEVEL_KEY(0));

        public static void ApplyBaseSave()
        {
            DataSaver.Save(SaveKey.BUSINESS_LEVEL_KEY(0), 1);
        }
    }
}