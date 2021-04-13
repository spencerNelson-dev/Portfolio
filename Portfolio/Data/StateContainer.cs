using Portfolio.Shared.Projects.ReadingLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Data
{
    public class StateContainer
    {
        private List<ReadingLog> _readingLogs = new();

        public List<ReadingLog> ReadingLogs
        {
            get => _readingLogs;
            set
            {
                _readingLogs = value;
                NotifyStateChanged();
            }
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

    }
}
