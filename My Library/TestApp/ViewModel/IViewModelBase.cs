using System.ComponentModel;

namespace My_Library.ViewModel
{
    public interface IViewModelBase
    {
        event PropertyChangedEventHandler PropertyChanged;

        void Dispose();
    }
}