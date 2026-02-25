namespace My_Library.Model
{
    public class ReservedBook : IReservedBook
    {
        public int ID { get; set; }
        public int BookId { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
