using System;
using System.Globalization;
using System.Text;
using System.Windows;

namespace ProjetoSegurança
{
    public partial class Cesar : Window
    {
        public Cesar()
        {
            InitializeComponent();
        }

        private void BtCifrar_Click(object sender, RoutedEventArgs e)
        {
            if (tbDecifrada.Text != "" && tbPosicoes.Text != "")
                tbCifrada.Text = CifraCesar(true, tbDecifrada.Text);
            else
                MessageBox.Show("O campo mensagem decifrada ou o campos possições esta em branco", "Campo Inválido!");
        }

        private void BtDecifrar_Click(object sender, RoutedEventArgs e)
        {
            if (tbCifrada.Text != "" && tbPosicoes.Text != "")
                tbDecifrada.Text = CifraCesar(false, tbCifrada.Text);
            else
                MessageBox.Show("O campo mensagem cifrada ou o campos possições esta em branco", "Campo Inválido!");
        }

        private string CifraCesar(bool soma, string msg)
        {
            msg = FuncionalidadesBasicas.NormalizarString(msg);

            var msgArray = msg.ToCharArray();
            StringBuilder sb = new StringBuilder();

            for (var i = 0; i < msgArray.Length; i++)
            {
                int caracterAscii;
                if (soma)
                {
                    caracterAscii = ((int)msgArray[i] + int.Parse(tbPosicoes.Text) + 25 - 96) % 26 + 97;
                }
                else
                {
                    caracterAscii = (((int)msgArray[i] - int.Parse(tbPosicoes.Text) + 25 - 96) % 26 + 97);
                }
                sb.Append((char)(caracterAscii));

            }
            return sb.ToString();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}