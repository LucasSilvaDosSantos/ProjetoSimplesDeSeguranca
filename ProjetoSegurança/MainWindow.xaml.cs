using System.Windows;

namespace ProjetoSegurança
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtCesar_Click(object sender, RoutedEventArgs e)
        {
            var cesarView = new Cesar();
            cesarView.ShowDialog();
        }

        private void BtVigenere_Click(object sender, RoutedEventArgs e)
        {
            var vigenereView = new Vigenere();
            vigenereView.ShowDialog();
        }

        private void BtAnaliseDeFrequencia_Click(object sender, RoutedEventArgs e)
        {
            var analiseDeFrequenciaView = new AnaliseDeFrequencia();
            analiseDeFrequenciaView.ShowDialog();
        }
    }
}
