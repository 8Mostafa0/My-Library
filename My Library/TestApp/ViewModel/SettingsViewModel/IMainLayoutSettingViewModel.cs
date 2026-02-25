namespace My_Library.ViewModel.SettingsViewModel
{
    public interface IMainLayoutSettingViewModel : IViewModelBase
    {
        bool BooksCount { get; set; }
        bool ClientsCount { get; set; }
        bool DilayedLoansCount { get; set; }
        bool LoansCount { get; set; }
    }
}