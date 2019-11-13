using System.Globalization;
using System.Text;

namespace ProjetoSegurança
{
    static class FuncionalidadesBasicas
    {
        public static string NormalizarString(string text)
        {
            string[] caracterEspecial = new string[] { ":", ";", ".", ",", "!", "?", " ", "<", ">" };
            foreach (var i in caracterEspecial)
            {
                text = text.Replace(i, "");
            }
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString().ToLower();
        }       
    }
}
