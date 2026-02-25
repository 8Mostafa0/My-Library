using My_Library.Model;
using My_Library.ViewModel.ModelsViewModel;

namespace My_Library.Store
{
    public interface ILoansStore
    {
        IEnumerable<ILoanViewModel> Loans { get; }

        Task AddLoan(ILoan loan);
        Task GetAllLoans(string customSql = "");
        Task Load();
        Task LoanDeleted(ILoan loan);
        Task LoanUpdated(ILoan loan);
        Task UpdateLoan(ILoan loan);
    }
}