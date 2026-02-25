using My_Library.Model;

namespace My_Library.ViewModel.ModelsViewModel
{
    public interface ILoanViewModel
    {
        int BookID { get; }
        string BookName { get; }
        string BookSubject { get; }
        int ClientID { get; }
        string ClientName { get; }
        DateTime CreatedAt { get; }
        int ID { get; }
        DateTime ReturnDate { get; }
        string ReturnedDate { get; set; }
        DateTime UpdatedAt { get; }

        static abstract LoanViewModel Empty();
        ILoan ToLoan();
    }
}