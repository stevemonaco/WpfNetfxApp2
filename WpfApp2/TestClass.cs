using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

using Application = System.Windows.Application;

namespace WpfApp2
{
    public class TestViewModel : INotifyPropertyChanged
    {
        private int _max;
        public int Max
        {
            get => _max;
            set => SetField(ref _max, value);
        }

        private int _current;
        public int Current
        {
            get => _current;
            set => SetField(ref _current, value);
        }

        public void Update()
        {
            while (Current < Max)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Current++;
                });

                Thread.Sleep(500);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
