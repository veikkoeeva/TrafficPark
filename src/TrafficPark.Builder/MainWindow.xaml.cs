using System.Windows;
using TrafficPark.Builder.ViewModel;


namespace TrafficPark.Builder
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        private MainViewModel ViewModel { get; }


        public MainWindow()
        {
            InitializeComponent();
            ViewModel = (MainViewModel)DataContext;
        }
    }
}
