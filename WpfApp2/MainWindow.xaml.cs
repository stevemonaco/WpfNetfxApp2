using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestViewModel _viewModel;

        public MainWindow()
        {
            _viewModel = new TestViewModel()
            {
                Current = 5,
                Max = 50
            };

            DataContext = _viewModel;

            InitializeComponent();

            Task.Run(() => _viewModel.Update());
        }
    }
}

