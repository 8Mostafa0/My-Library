
namespace My_Library.Model
{
    public interface IReservedBook
    {
        int BookId { get; set; }
        int ClientId { get; set; }
        DateTime CreatedAt { get; set; }
        int ID { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}