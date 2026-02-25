using My_Library.Model;

namespace My_Library.ViewModel.ModelsViewModel
{
    public interface IReservedBookViewModel : IViewModelBase
    {
        int BookId { get; }
        string BookName { get; set; }
        int ClientId { get; }
        string ClientName { get; set; }
        DateTime CreatedAt { get; }
        int ID { get; }
        DateTime UpdatedAt { get; }

        IReservedBook ToReservedBook();
    }
}