using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFire.Als
{
    /// <summary>
    /// African Language
    /// </summary>
    public abstract class AL
    {

        public abstract string Fonetica(string text, string dialeto = "");
        public abstract string Extended(string text);
        public abstract string Translate(string text, string dialeto = "");
        public abstract string Letter(string text);
        public abstract string FullWord(string text);

        /// <summary>
        /// Verifica se é o começo de uma sentença/palavra
        /// </summary>
        /// <param name="position">Posição Inicial</param>
        /// <param name="text">sentença</param>
        /// <returns>bool</returns>
        public bool isBeginWord(int position, string text)
        {
            string z = "";
            if (position == 0)
                return true;
            else
            {
                z = text.Substring(position - 1, 1);
                if ((z.CompareTo(" ") == 0) || (z.CompareTo("-") == 0))
                {
                    return true;
                }
            }
            return false;
        }
    }
}