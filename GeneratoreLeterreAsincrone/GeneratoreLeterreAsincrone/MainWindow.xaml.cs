using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeneratoreLeterreAsincrone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<char> lettere = new List<char>() {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        Random random = new Random();

        int count = 0;
        
        public MainWindow()
        {
            InitializeComponent();
                count= random.Next(0, 26);
                this.Dispatcher.Invoke(() =>
                {
                    lblLettere.Content = lettere[count].ToString();
                });
            
        }

        private void btnEstrai_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}