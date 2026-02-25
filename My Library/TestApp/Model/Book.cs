namespace My_Library.Model
{
    public class Book : IBook
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Subject { get; set; }
        public string PublicationDate { get; set; }
        public int Tier { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
