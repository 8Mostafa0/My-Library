namespace My_Library.ViewModel.SettingsViewModel
{
    public interface ILoanSettingsViewModel : IViewModelBase
    {
        string MaxBooksCount { get; set; }
        string MaxLoanDay { get; set; }

        void SettingsChanged();
    }
}