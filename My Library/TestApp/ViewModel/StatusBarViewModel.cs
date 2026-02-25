using My_Library.Store;
using System.Timers;

namespace My_Library.ViewModel
{
    public class StatusBarViewModel : ViewModelBase, IStatusBarViewModel
    {
        #region Dependencies
        private static System.Timers.Timer aTimer;
        private TimeStore _timeStore = new();
        public DateTime CloclString => _timeStore.CurrentTime;
        #endregion

        #region Constructor
        public StatusBarViewModel()
        {
            _timeStore.CurrentTime = DateTime.Now;
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
        }
        #endregion

        #region Methods
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            _timeStore.CurrentTime = DateTime.Now;
            OnProperychanged(nameof(CloclString));
        }
        #endregion
    }
}
