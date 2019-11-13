using System.Text;
using System.Windows;

namespace ProjetoSegurança
{
    public partial class Vigenere : Window
    {
        public Vigenere()
        {
            InitializeComponent();
        }

        private void BtCifrar_Click(object sender, RoutedEventArgs e)
        {
            tbCifrada.Text = CifraVigenere(tbDecifrada.Text, tbChave.Text, true);
        }

        private void BtDecifrar_Click(object sender, RoutedEventArgs e)
        {
            tbDecifrada.Text = CifraVigenere(tbCifrada.Text, tbChave.Text, false);
        }

        private string AlterarTamanhoChave(string msg, string chave)
        {
            while (msg.Length > chave.Length)
            {
                chave = (chave+chave);
            }
            return chave;
        }

        private string CifraVigenere(string msg, string chaveEntrada, bool cifrar)
        {
            StringBuilder sb = new StringBuilder();
            var decifrada = FuncionalidadesBasicas.NormalizarString(msg);
            var chave = FuncionalidadesBasicas.NormalizarString(chaveEntrada);
            chave = AlterarTamanhoChave(decifrada, chave);

            var msgArray = decifrada.ToCharArray();
            var chaveArray = chave.ToCharArray();

            for (var i = 0; i < msgArray.Length; i++)
            {
                int caracterAscii;

                var aux = (int)chaveArray[i] - 96;

                if (cifrar)
                    caracterAscii = ((int)msgArray[i] + aux + 25 - 96) % 26 + 97;
                else
                    caracterAscii = ((int)msgArray[i] - aux + 25 - 96) % 26 + 97;
                sb.Append((char)caracterAscii);
            }
            return sb.ToString();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }     
    }
}