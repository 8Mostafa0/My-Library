
namespace My_Library.Model
{
    public interface IClient
    {
        DateTime CreatedAt { get; set; }
        string FirstName { get; set; }
        int ID { get; set; }
        string LastName { get; set; }
        int Tier { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}