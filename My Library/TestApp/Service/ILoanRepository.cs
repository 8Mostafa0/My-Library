using My_Library.Model;

namespace My_Library.Service
{
    public interface ILoanRepository
    {
        Task AddNewLoanToDb(ILoan loan);
        Task DeleteLoanInDB(ILoan loan);
        Task<List<Loan>> GetAllClientLoans(int clientId);
        Task<List<Loan>> GetAllLoans(string customSql = "");
        Task<Loan?> GetLoan(string customSql, string executionPart);
        Task<List<Loan>> GetNotReturnedLoanOfBook(int bookId);
        Task RemoveBookLoans(int bookId);
        Task RemoveClientLoans(int id);
        Task UpdateLoanAtDb(ILoan loan);
        Task<List<Loan>> UserHaveDilayedLoan(int clientId);
    }
}