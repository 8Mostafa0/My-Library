
namespace My_Library.Model
{
    public interface IBook
    {
        DateTime CreatedAt { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        string PublicationDate { get; set; }
        string Publisher { get; set; }
        string Subject { get; set; }
        int Tier { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}