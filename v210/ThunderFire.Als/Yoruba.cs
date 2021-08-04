using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ThunderFire.Als
{
    public class Yoruba:AL
    {
        public override string Fonetica(string text, string dialeto="")
        {
            text = text.Replace("ẹ", "ɛ");
            text = text.Replace("ẹn", "ɛ̃");
            text = text.Replace("ọ", "ɔ");
            text = text.Replace("ọ́n", "ɔ̃");
            text = text.Replace("ọ̀", "ɔ̃");
            text = text.Replace("ṣ", "ʃ");
            text = text.Replace("un", "ũ");
            text = text.Replace("nu", "nũ");
            text = text.Replace("j", "ʤ"); //&#676;
            text = text.Replace("an", "ã");
            text = text.Replace("in", "ĩ");
            text = text.Replace("ń", "ɳ");
            text = text.Replace("Ń", "ɳ");
            text = text.Replace("Ṁ", "ɱ");
            text = text.Replace("ṁ", "ɱ");
            text = text.Replace("p", "kp");
            text = text.Replace("gb", "ɡb");
            //text = text.Replace("&amp;", "&");
            return text;
        }

        public override string Extended(string text)
        {
            text = text.Replace("ş", "s");
            text = text.Replace("Ḿ", "m");
            text = text.Replace("ḿ", "m");
            text = text.Replace("Ṁ", "m");
            text = text.Replace("ṁ;", "m");
            text = text.Replace("Ẹ", "e");
            text = text.Replace("Ọ", "o");
            text = text.Replace("Ṣ;", "s");
            text = text.Replace("ẹ", "e");
            text = text.Replace("ọ", "o");
            text = text.Replace("ẹ", "e");
            text = text.Replace("ẹ̀", "e");
            text = text.Replace("ẹ́", "e");
            text = text.Replace("ọ", "o");
            text = text.Replace("ọ̀", "o");
            text = text.Replace("ọ́", "o");
            text = text.Replace("ş", "s");
            text = text.Replace("ṣ", "s");
            text = text.Replace("ń", "n");
            text = text.Replace("Ń", "n");
            text = text.Replace("ḿ", "m");
            text = text.Replace("Ḿ", "m");
            text = text.Replace("&#x300;", "");
            text = text.Replace("&#x301;", "");
            text = text.Replace("Ǹ", "n");
            text = text.Replace("ǹ", "n");
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
            string r = "";
            string n = "";
            string c = "";
            bool b = false;
            //int position = 0;

            for (int j = 0; j < arg.Length; j++)
            {
                // aberto   ´
                // fechado  ^
                word = arg[j];
                word = word.Replace("mọn", "mán");
                word = word.Replace("mọ̀n", "mân");
                word = word.Replace("mọ́n", "mán");
                word = word.Replace("gọ́n", "gán");
                word = word.Replace("yọ́n", "yán");
                word = word.Replace("fọ́n", "fán");
                word = word.Replace("pọ̀n", "pan");
                word = word.Replace("ṣọ̀n", "xân");
                word = word.Replace("fọn", "fán");
                word = word.Replace("à", "â");
                word = word.Replace("ã", "aa");
                word = word.Replace("ẽ", "ee");
                word = word.Replace("è", "ê");
                word = word.Replace("ĩ", "ii");
                word = word.Replace("õ", "oo");
                word = word.Replace("ò", "ô");
                word = word.Replace("ṣ", "x");
                word = word.Replace("w", "u");
                word = word.Replace("y", "i");
                word = word.Replace("Ǹ", "un");
                word = word.Replace("Ṁ", "um");
                word = word.Replace("ń", "un");
                word = word.Replace("j", "dj");
                word = word.Replace("gb", "b");
                word = word.Replace("ge", "gue");
                word = word.Replace("gé", "gué");
                r = "";
                for (int i = 0; i < word.Length; i++)
                {
                    b = isBeginWord(i, word);
                    c = word.Substring(i, 1);
                    if ((i + 1) < word.Length)
                        n = word.Substring(i + 1, 1);

                    if (c == "ẹ")
                    {
                        if (n == "̀")
                            r += "ê";
                        else
                            r += "é";
                    }
                    else if (c == "ọ")
                    {
                        if (n == "́")
                            r += "ó";
                        else if (n == "̀")
                            r += "ô";
                        else
                            r += "ó";
                    }

                    else if (c == "h")
                    {
                        if (b)
                            r += "r";
                        else
                            r += "rr";

                        //r += "r";

                    }
                    else if (c == "s")
                    {
                        if (!b)
                            r += "ss";
                        else
                            r += "s";
                    }
                    else
                        r += c.Replace("́", "").Replace("̀", "");

                }
                result += r + " ";
            }

            if (word.IndexOf("ss") == 0)
                word = word.Substring(1);
            if (word.IndexOf("ii") == 0)
                word = word.Substring(1);
            if (word.IndexOf("ìi") == 0)
                word = "ì" + word.Substring(2);
            word = word.Replace("ií", "ì");
            word = word.Replace("ìi", "ì");
            word = word.Replace("ii", "i");
            word = word.Replace("iì", "í");
            word = word.Replace("nss", "ns");

            return result;
        }

        public override string Letter(string text)
        {
            string _letra = text.Trim().ToUpper() + "  ";
            if (_letra.Trim() == "")
                return "";
            _letra = _letra.Substring(0, 2).Trim();
            if (_letra != "")
            {
                if (_letra.CompareTo("Ẹ̀") == 0)
                    _letra = "Ẹ";
                else if (_letra.CompareTo("Ọ̀") == 0)
                    _letra = "Ọ";
                else if (_letra.CompareTo("Ọ́") == 0)
                    _letra = "Ọ";
                else if (_letra.CompareTo("Ṣ") == 0)
                    _letra = "Ṣ";
                else if ((_letra == "Ẽ") || (_letra.Substring(0, 1) == "Ẽ") || (_letra.Substring(0, 1) == "È") || (_letra.Substring(0, 1) == "Ê"))
                    _letra = "E";
                else if ((_letra == "Ń") || (_letra.Substring(0, 1) == "Ń"))
                    _letra = "N";
                else if ((_letra.Substring(0, 1) == "Ã") || (_letra.Substring(0, 1) == "À") || (_letra.Substring(0, 1) == "Á") || (_letra.Substring(0, 1) == "Â"))
                    _letra = "A";
                else if (_letra.Substring(0, 1) == "Ì")
                    _letra = "I";
                else if (_letra.Substring(0, 1) == "Ḿ")
                    _letra = "M";
                else if ((_letra.Substring(0, 1) == "Õ") || (_letra.Substring(0, 1) == "Ò") || (_letra.Substring(0, 1) == "Ô") || (_letra.Substring(0, 1) == "Ó"))
                    _letra = "O";
                else
                    _letra = _letra.Substring(0, 1).ToUpper().Trim();
            }

            return _letra;
        }

        public override string FullWord(string text)
        {
            text = text.ToLower().Trim();

            text = text.Replace("&#7742;", "Ḿ");
            text = text.Replace("&#7743;", "ḿ");
            text = text.Replace("&#7744;", "Ḿ");
            text = text.Replace("&#7745;", "ḿ");
            text = text.Replace("&#7864;", "Ẹ");
            text = text.Replace("&#7884;", "Ọ");
            text = text.Replace("&#7778;", "Ṣ");
            text = text.Replace("ẹ̀", "ê");
            text = text.Replace("ẹ́", "é");
            text = text.Replace("ẹ", "é");
            text = text.Replace("ọ̀", "ô");
            text = text.Replace("ọ́", "ó");
            text = text.Replace("ọ", "ó");
            text = text.Replace("ẹ", "é");
            text = text.Replace("ẹ̀", "ê");
            text = text.Replace("ẹ́", "é");
            text = text.Replace("ọ", "ó");
            text = text.Replace("ọ̀", "ô");
            text = text.Replace("ọ́", "ó");
            text = text.Replace("ş", "s");
            text = text.Replace("ṣ", "s");
            text = text.Replace(".", "");
            text = text.Replace("  ", " ");
            text = text.Replace("-", "");
            return text.Trim();
        }

    }
}