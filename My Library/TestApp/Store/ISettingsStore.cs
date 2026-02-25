
namespace My_Library.Store
{
    public interface ISettingsStore
    {
        string GetHashedPassword();
        Dictionary<string, bool> GetLayoutSettings();
        Dictionary<string, int> GetLoansSetting();
        void SaveLayoutSettings(Dictionary<string, bool> settings);
        void SaveLoanSettings(Dictionary<string, int> settings);
        void SaveNoneHashedPassword(string password);
        bool VerifyPassword(string EnteredPassword);
    }
}