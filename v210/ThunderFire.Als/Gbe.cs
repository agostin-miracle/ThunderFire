using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFire.Als
{
    /// <summary>
    /// Linguas GBE
    /// </summary>
    public class Gbe : AL
    {

        public override string Fonetica(string text, string dialeto = "")
        {
            if (dialeto.ToLower() == "fon" || dialeto == "")
            {
                text = text.Replace("xɔ́s", "hɔ́s");
                text = text.Replace("xw", "ʁʷ");
            }
            //ʁʷ	

            text = text.Replace("ny", "ɲ");
            text = text.Replace("ts", "ʧ");
            text = text.Replace("dz", "ʤ");
            text = text.Replace("ŋ", "ng");
            text = text.Replace("ʋ", "β;");
            text = text.Replace("&amp;", "&");
            text = text.Replace("ɔ;", "ó");
            text = text.Replace("ɖ;", "d");
            text = text.Replace("ƒ", "ɸ");
            text = text.Replace("e", "ɛ");
            text = text.Replace("è", "ɛ̀");
            text = text.Replace("é", "ɛ́");

            if(text.EndsWith("án"))
                text = text.Replace("án", "ɐ́̃");
            if (text.EndsWith("ín"))
                text = text.Replace("á", "í̃");
            if (text.EndsWith("in"))
                text = text.Replace("in", "ĩ");
            if (text.EndsWith("ín"))
                text = text.Replace("ín", "í̃");
            if (text.EndsWith("ìn"))
                text = text.Replace("in", "ĩ");
            if (text.EndsWith("ĭn"))
                text = text.Replace("ĭn", "ĭ̃");
            if (text.EndsWith("ɛn"))
                text = text.Replace("ɛ́n", "ɛ̃");
            if (text.EndsWith("ɛ́n"))
                text = text.Replace("ɛ́n", "ɛ́̃");
            if (text.EndsWith("ɔ́n"))
                text = text.Replace("ɔ́n", "ɔ́̃");
            if (text.EndsWith("ɔ̀n"))
                text = text.Replace("ɔ̀n", "ɔ̃");

            if (text.EndsWith("ɔn"))
                text = text.Replace("ɔn", "ɔ̃");

            text = text.Replace("dàn", "dɐ́̄");
            text = text.Replace("dan", "dɐ̃");
            text = text.Replace("sán", "sɐ́̃");
            text = text.Replace("gán", "gɐ́̃");
            text = text.Replace("àn", "ɐ́̄");
            text = text.Replace("an", "ɐ̃");
            text = text.Replace("ăn", "ɐ̃");
            text = text.Replace("am", "ɐ̃̆");
            text = text.Replace("pɛ́n", "pɛ́̃");
            text = text.Replace("wɛ́n", "wɛ́̃");
            text = text.Replace("kpɛn", "kpɛ̃");
            text = text.Replace("en", "ɐ̃");
            text = text.Replace("em", "ẽ");
            text = text.Replace("din", "dĩ");
            text = text.Replace("dìn", "dĩ");
            text = text.Replace("dĭn", "dĭ̃");
            text = text.Replace("lín", "lí̃");
            text = text.Replace("lin", "lĩ");
            text = text.Replace("kwín", "kwí̃");
            text = text.Replace("wín", "wí̃");
            text = text.Replace("ɔn", "ɔ̃");
            text = text.Replace("lɔ̆n", "ló̃");
            text = text.Replace("un", "ũ");
            text = text.Replace("dùn", "dũ̀");
            text = text.Replace("zùn", "zũ");
            text = text.Replace("fùn", "fũ̀");
            text = text.Replace("fún", "fú̃");
            text = text.Replace("tún", "tú̃");
            text = text.Replace("zún", "zú̃");
            text = text.Replace("hún", "hú̃");
            text = text.Replace("sún", "sú̃");
            text = text.Replace("wún", "wú̃");
            text = text.Replace("wùn", "wũ");
            text = text.Replace("kún", "kú̃");
            text = text.Replace("ny", "ɲ");
            return text;
        }

        public override string Extended(string text)
        {
            text = text.Replace("ɔ̀̃", "o");
            text = text.Replace("ɔ͂", "o");
            text = text.Replace("ʋ", "v");
            text = text.Replace("ɖ", "d");
            text = text.Replace("ny", "nh");
            text = text.Replace("&#331;", "n");
            text = text.Replace("ŋ", "n");
            text = text.Replace("x", "ch");
            text = text.Replace("ɔ", "o");
            text = text.Replace("ɖ", "d");
            text = text.Replace("ɣ", "g");
            text = text.Replace("ƒ", "f");
            text = text.Replace("ă", "a");
            text = text.Replace("ɛ", "e");
            text = text.Replace("ò", "o");
            return text.NoAccents().Trim();
        }

        public override string Translate(string text, string dialeto = "")
        {
            string[] arg = text.Split(' ');
            string result = "";
            string word = "";
            dialeto = dialeto.ToLower().Trim();

            word = text;
            word = word.Replace("gb", "b");
            word = word.Replace("kp", "p");
            if (dialeto == "fon" || dialeto == "")
            {
                //word = TranslateChar(word);
                word = word.Replace("h", "r");          // 1 //
                word = word.Replace("ɲ", "inh");
                word = word.Replace("ny", "inh");
                word = word.Replace("ŋ", "gn");
                word = word.Replace("ɛ̀", "e");
                word = word.Replace("ɛ́", "è");
                word = word.Replace("ɛ", "é");
                
                word = word.Replace("ɔ̀", "o");
                word = word.Replace("ɔ́̃", "on");
                word = word.Replace("ɔ́̆", "on");
                word = word.Replace("ɔ́", "o");
                word = word.Replace("ɔ", "ò");



                word = word.Replace("x", "h");          // 2 //
                                                        //word = word.Replace("gb", "guib");
                word = word.Replace("à", "a");
                word = word.Replace("ã", "an");
                word = word.Replace("è", "e");
                word = word.Replace("é", "e");
                word = word.Replace("e͂", "en");
                word = word.Replace("ì", "i");
                word = word.Replace("ĩ̀", "in");
                word = word.Replace("ŭ", "u"); // u breve

                //word = word.Replace("ŋ", "n");
                word = word.Replace("ɖ", "d");
                word = word.Replace("ɣ", "g");
                //word = word.Replace("ɣ", "i");
                word = word.Replace("onb", "omb");
                word = word.Replace("w", "u");
                word = word.Replace("ú͂̀", "ún");
                word = word.Replace("uù", "û");
                word = word.Replace("uu", "u");
                word = word.Replace("uú", "ú");
                word = word.Replace("ʋ", "v");
                word = word.Replace("yĭ", "i");
                word = word.Replace("iĭ", "i");
                word = word.Replace("ii", "i");
                word = word.Replace("j", "dj");
                word = word.Replace("gɛ̀", "guê");
                // ****
                word = word.Replace("hl", "rir");
                word = word.Replace("sl", "sr");
            }
            else
            {

                //word = word.Replace("gb", "guib");

                word = word.Replace("ẽ̀", "èn");
                word = word.Replace("e͂", "en");
                word = word.Replace("à", "a");
                word = word.Replace("ã", "an");
                word = word.Replace("è", "e");
                word = word.Replace("é", "e");
                word = word.Replace("ɛ", "é");
                word = word.Replace("ɔ̀̃", "on");
                word = word.Replace("ɔ͂", "òn");
                word = word.Replace("ɔ", "ò");

                word = word.Replace("ĩ́", "in");
                word = word.Replace("ĩ̀", "in");
                word = word.Replace("ɲ", "nh");
                word = word.Replace("&#365;", "u"); // u breve
                word = word.Replace("ŋ", "in");
                word = word.Replace("ŋ̀", "ìn");
                word = word.Replace("x", "ch");
                word = word.Replace("ɖ", "d");
                word = word.Replace("ɣ", "g");
                word = word.Replace("onb", "omb");
                word = word.Replace("w", "u");
                word = word.Replace("ú͂̀", "ún");
                word = word.Replace("u͂", "un");
                word = word.Replace("uu", "u");
                word = word.Replace("ʋ", "v");
                word = word.Replace("sr", "sir");
                word = word.Replace("ts", "ch");
                word = word.Replace("dz", "j");
                word = word.Replace("yĭ", "i");
                word = word.Replace("ny", "ni");
                word = word.Replace("ƒ", "f");
            }
            word = word.Replace("zl", "zir");
            word = word.Replace("s", "ss");
            word = word.Replace("nss", "ns");
            if (word.IndexOf("ss") == 0)
                word = word.Substring(1);
            if (word.IndexOf("ii") == 0)
                word = word.Substring(1);

            result = word.Trim() + " ";
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

            else
                _letra = _letra.Substring(0, 1).ToUpper().Trim();
            return _letra;
        }

        public override string FullWord(string text)
        {
            text = text.ToLower().Trim();
            text = text.Replace("ʋ", "v");
            text = text.Replace("ɖ", "d");
            text = text.Replace("ny", "nh");
            text = text.Replace("ŋ̀", "n");
            text = text.Replace("ŋ", "n");
            text = text.Replace("x", "ch");
            text = text.Replace("ɔ", "o");
            text = text.Replace("ɔ", "o");
            text = text.Replace("ɖ", "d");
            text = text.Replace("ɖ", "d");
            text = text.Replace("ɣ", "g");
            text = text.Replace("ƒ", "f");
            return text.Trim();
        }

    }
}