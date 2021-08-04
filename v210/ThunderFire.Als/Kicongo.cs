using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFire.Als
{
    public class Kicongo:AL
    {
        public override string Fonetica(string text, string dialeto = "")
        {
            return text.Trim();
        }
        public override string Extended(string text)
        {
            return text.Trim();
        }
        public override string Translate(string text, string dialeto = "")
        {
            string[] arg = text.Split(' ');
            string result = "";
            string word = "";
            string r = "";

            for (int j = 0; j < arg.Length; j++)
            {
                word = arg[j];
                word = word.Replace("s", "ss");
                if (word.Length > 2)
                {
                    if (word.Substring(0, 2) == "ss")
                    {
                        word = "s" + word.Substring(2);
                    }
                }
                if (word.IndexOf("n") == 0)
                    word = "un" + word.Substring(1);
                r = word.Trim();
                result += r + " ";
            }
            return result;

        }

        public override string Letter(string text)
        {
            string _letra = text.Trim().ToUpper() + "  ";
            if (_letra.Trim() == "")
                return "";

            if ((_letra.Substring(0, 1) == "-") || (_letra.Substring(0, 1) == "'"))
                _letra = _letra.Substring(1);

            _letra = _letra.Substring(0, 1).Trim();

            if ((_letra == "Ẽ") || (_letra.Substring(0, 1) == "Ẽ") || (_letra.Substring(0, 1) == "È") || (_letra.Substring(0, 1) == "Ê") || (_letra.Substring(0, 1) == "É"))
                _letra = "E";
            else if ((_letra == "Ń") || (_letra.Substring(0, 1) == "Ń"))
                _letra = "N";
            else if ((_letra.Substring(0, 1) == "Ã") || (_letra.Substring(0, 1) == "À") || (_letra.Substring(0, 1) == "Á") || (_letra.Substring(0, 1) == "Â"))
                _letra = "A";
            else if ((_letra.Substring(0, 1) == "Ì") || (_letra.Substring(0, 1) == "Í"))
                _letra = "I";
            else if (_letra.Substring(0, 1) == "Ḿ")
                _letra = "M";
            else if ((_letra.Substring(0, 1) == "Õ") || (_letra.Substring(0, 1) == "Ò") || (_letra.Substring(0, 1) == "Ô") || (_letra.Substring(0, 1) == "Ó"))
                _letra = "O";
            else if ((_letra.Substring(0, 1) == "Ú") || (_letra.Substring(0, 1) == "Ù"))
                _letra = "U";
            //else if ((_letra.Substring(0, 1) == "Ɖ")) 
            //    _letra = "D";

            else
                _letra = _letra.Substring(0, 1).ToUpper().Trim();
            return _letra;
        }

        public override string FullWord(string text)
        {
            text = text.ToLower().Trim();
            return text.Trim();
        }

    }
}
