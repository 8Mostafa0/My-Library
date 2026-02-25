
namespace My_Library.Model
{
    public interface ILoan
    {
        int BookId { get; set; }
        int ClientId { get; set; }
        DateTime CreatedAt { get; set; }
        int Id { get; set; }
        DateTime ReturnDate { get; set; }
        DateTime? ReturnedDate { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}