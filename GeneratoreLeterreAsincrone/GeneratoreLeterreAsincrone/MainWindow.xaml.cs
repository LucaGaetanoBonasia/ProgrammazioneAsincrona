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
        List<char> lettere = new List<char>() {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

        Random random = new Random();

        int count = 0;

        char letteraEstratta;

        int lunghezza = 4;

        public MainWindow()
        {
            InitializeComponent();
            GeneraLettere();
        }

        private async void GeneraLettere()
        {
            while (true)
            {
                count = random.Next(0, 26);
                this.Dispatcher.Invoke(() =>
                {
                    lblLettere.Content = lettere[count].ToString();
                });
                await Task.Delay(100);
            }
            
        }

        private async void btnEstrai_Click(object sender, RoutedEventArgs e)
        {
            letteraEstratta = lettere[count];
            InserisciLetteraEstratta();
             await Task.Delay(100);
        }

        private void InserisciLetteraEstratta()
        {
            if (lbxParole.Items.Count == 0)
            {
                lbxParole.Items.Add(letteraEstratta.ToString());
            }
            else
            {
                int ultimaRiga = lbxParole.Items.Count - 1; //prende l'indice dell’ultima riga della ListBox.
                string parola = lbxParole.Items[ultimaRiga].ToString(); //prende il contenuto dell’ultima riga e lo converte in stringa.

                if (parola.Length < lunghezza) //controlla se la lunghezza della parola è inferiore alla lunghezza desiderata.
                {
                    parola += letteraEstratta;  
                    lbxParole.Items[ultimaRiga] = parola;  //aggiorna l’ultima riga della ListBox con la nuova parola formata dall’aggiunta della lettera estratta.
                }
                else
                {
                    lbxParole.Items.Add(letteraEstratta.ToString()); //se la parola ha raggiunto la lunghezza desiderata, viene aggiunta una nuova riga alla ListBox con la lettera estratta.
                }
            }
        }

        private async void btnLunghezza_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(tbxParola.Text, out int lunghezzaInserita))
            {
                lunghezza = lunghezzaInserita;
            }
            else
            {
             MessageBox.Show("Inserisci un numero valido per la lunghezza della parola.");
            }

            tbxParola.Clear();
        }
    }
}