using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFire.Als
{
    public class Kimbundu : AL
    {
        public override string Fonetica(string text, string dialeto="")
        {
            text = text.Replace("j", "ʤ"); //&#676;
            text = text.Replace("nh", "ɲ"); //&#626;
            text = text.Replace("ban", "bã");
            text = text.Replace("bân", "bã");
            text = text.Replace("gan", "gã");
            text = text.Replace("amb", "ãb");
            text = text.Replace("amp", "ãp");
            text = text.Replace("in", "ĩ");
            text = text.Replace("im", "ĩ");
            text = text.Replace("ong", "õg");
            text = text.Replace("omp", "õp");
            text = text.Replace("x", "ʃ");
            return text;
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
            string[] arg = text.Split(' ');
            string result = "";
            string word = "";
            string t = "";
            for (int j = 0; j < arg.Length; j++)
            {
                t += arg[j] + " ";
            }
            word = t.Replace("ri", "di");
            word = word.Replace("s", "ss");
            word = word.Replace("ge", "gue");
            word = word.Replace("gé", "gué");
            word = word.Replace("gê", "guê");
            word = word.Replace("gi", "gui");
            word = word.Replace("gî", "guî");
            word = word.Replace("nh", "nì");

            if (word.Length > 2)
            {
                if (word.Substring(0, 2) == "ng")
                    word = "i" + word;
                if (word.Substring(0, 2) == "nj")
                    word = "i" + word;
                if (word.Substring(0, 2) == "nk")
                    word = "i" + word;
                if (word.Substring(0, 2) == "nz")
                    word = "u" + word;
                if (word.Substring(0, 2) == "ss")
                    word = "s" + word.Substring(2);
                if (word.Substring(0, 3) == "-ss")
                    word = "s" + word.Substring(3);
            }
            word = word.Replace(" ss", "s");
            word = word.Replace("nss", "ns");
            word = word.Replace("-ss", "s");
            word = word.Replace(" ng", " ing");
            word = word.Replace(" nz", " unz");
            word = word.Replace(" nd", " ind");
            if (word.EndsWith("ss"))
                word = word.Substring(0, word.Length - 1);
            // ***
            word = word.Replace("j", "dj");
            result = word.Trim();
            return result;
        }
        public override string Letter(string text)
        {
            string _letra = text.Trim().ToUpper() + "  ";
            if (_letra.Trim() == "")
                return "";

            _letra = _letra.Replace("-", "");
            _letra = _letra.Replace("'", "");
            _letra = _letra.Substring(0, 1).Trim();
          

            if ((_letra == "Ẽ") || (_letra == "Ẽ") || (_letra == "È") || (_letra== "Ê") || (_letra == "É"))
                _letra = "E";
            else if ((_letra == "Ń") || (_letra == "Ń"))
                _letra = "N";
            else if ((_letra == "Ã") || (_letra == "À") || (_letra == "Á") || (_letra == "Â"))
                _letra = "A";
            else if ((_letra == "Ì") || (_letra == "Í"))
                _letra = "I";
            else if (_letra == "Ḿ")
                _letra = "M";
            else if ((_letra == "Õ") || (_letra == "Ò") || (_letra == "Ô") || (_letra == "Ó"))
                _letra = "O";
            else if ((_letra == "Ú") || (_letra == "Ù"))
                _letra = "U";
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
