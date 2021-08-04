using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFire.Als
{
    public class Factory
    {
        /// <summary>
        /// Pega o objeto de Linguagem de acordo com a Origem 
        /// </summary>
        /// <param name="SourceLang">Identificador da Linguagem de Origem</param>
        /// <returns>AL</returns>
        public static AL GetLanguage(string SourceLang)
        {
            AL RETURN_VALUE= new Others();

            if (!String.IsNullOrEmpty(SourceLang))
            {
                SourceLang = SourceLang.ToUpper();
                if (SourceLang == "KIMBUNDU")
                    RETURN_VALUE = new Kimbundu();
                else if (SourceLang == "YORUBA")
                    RETURN_VALUE = new Yoruba();
                else if (SourceLang == "KICONGO")
                    RETURN_VALUE = new Kicongo();
                else if (SourceLang == "EWEGBE")
                    RETURN_VALUE = new Gbe();
                else if (SourceLang == "LOGBA")
                    RETURN_VALUE = new Logba();
            }
            return RETURN_VALUE;
        }
    }
}