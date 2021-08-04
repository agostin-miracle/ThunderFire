using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFire.Als
{
    public class Others:AL
    {
        public override string Fonetica(string text, string disleto = "")
        {
            return text.Trim();
        }

        public override string Extended(string text)
        {
            text = text.Replace("-", "");
            text = text.Replace("!", "");
            text = text.Replace("?", "");
            text = text.Replace("̀", "");
            text = text.Replace("́", "");
            text = text.Replace(".", "");
            text = text.Replace("  ", " ");
            return text.NoAccents().Trim();
        }

        public override string Translate(string text, string dialeto = "")
        {
            return text.Trim();
        }
        public override string Letter(string text)
        {
            string _letra = "";
            if (text.Trim() != "")
                _letra = text.Substring(0, 1).Trim().ToUpper();
            return _letra;
        }

        public override string FullWord(string text)
        {
            text = text.ToLower().Trim();
            text = text.Replace(".", "");
            text = text.Replace("  ", " ");
            text = text.Replace("-", "");
            return text.Trim();
        }

    }
}
