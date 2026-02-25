
namespace My_Library.Store
{
    public interface ITimeStore
    {
        DateTime CurrentTime { get; set; }

        event Action CurrentViewModelChanged;
    }
}