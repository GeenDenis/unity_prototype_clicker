namespace Clicker.GameplayModel.Save
{
    public static class SaveKey
    {
        public static string IMPROVEMENT_IS_ACTIVE_KEY(int id) => $"IMPROVEMENT_{id}_IS_ACTIVE";
        public static string BUSINESS_LEVEL_KEY(int id) => $"BUSINESS_{id}_LEVEL";
        public static string BUSINESS_INCOME_PROGRESS_KEY(int id) => $"BUSINESS_{id}_INCOME_PROGRESS";
        public static string BALANCE_KEY => $"BALANCE";
    }
}