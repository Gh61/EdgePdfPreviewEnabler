using System.Windows;

namespace Gh61.EdgePdfPreviewEnabler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow LastInstance { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            LastInstance = this;
        }
    }
}
