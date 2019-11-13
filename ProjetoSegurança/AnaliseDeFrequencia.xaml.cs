using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProjetoSegurança
{
    public partial class AnaliseDeFrequencia : Window
    {
        //                                                                 { a, e, o,  s,  r}
        private readonly List<int> letrasQueMaisAparecem = new List<int>() { 1, 5, 14, 18, 17 };
        public AnaliseDeFrequencia()
        {
            InitializeComponent();
        }

        private void BtVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtDecifrar_Click(object sender, RoutedEventArgs e)
        {
            if (tbCifrada.Text != null && tbCifrada.Text != "")
            {
                var listaString = Decifrar(tbCifrada.Text);
                tbDecifradaA.Text = listaString[0];
                tbDecifradaE.Text = listaString[1];
                tbDecifradaO.Text = listaString[2];
                tbDecifradaS.Text = listaString[3];
                tbDecifradaR.Text = listaString[4];
            }
            else
                MessageBox.Show("O campo cifra esta em branco", "Campo Inválido!");
        }

        private List<string> Decifrar(string msg)
        {
            msg = FuncionalidadesBasicas.NormalizarString(msg);
            var msgArray = msg.ToCharArray();
            var saida = new List<string>();
            foreach(int i in letrasQueMaisAparecem)
            {
                StringBuilder sb = new StringBuilder();
                foreach (char leeter in msgArray)
                {
                    var caracterAscii = ((int)leeter - i + 25 - 96) % 26 + 97;
                    sb.Append((char)caracterAscii);
                }
                saida.Add(sb.ToString());
            }
            return saida;
        }
    }
}
