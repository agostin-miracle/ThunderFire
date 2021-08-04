using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace ThunderFire.Books
{
    public class ResourceBase
    {
        /// <summary>
        /// Nome do Parametro de Titulo
        /// </summary>
        public const string Title = "title";
        /// <summary>
        /// Nome do Parâmetro de Subtitulo
        /// </summary>
        public const string SubTitle = "subtitle";
        /// <summary>
        /// Nome do Parametro de Definição de Linguagem
        /// </summary>
        public const string Language = "language";
        /// <summary>
        /// Nome do Parâmetro de Exibição de Fonética
        /// </summary>
        public const string ExibeFonetica = "showf";
        /// <summary>
        /// Nome do Parâmetro de Exibição de Pronúncia
        /// </summary>
        public const string ExibePronuncia = "showp";
        /// <summary>
        /// Nome do Parâmetro de Exibição de Observações
        /// </summary>
        public const string ExibeObservacao = "showo";
        /// <summary>
        /// Nome do Parâmetro de Exibição de Flexões do Verbere
        /// </summary>
        public const string ExibeFlexao = "showl";
        /// <summary>
        /// Nome do Parâmetro de Exibição de Letra de Separação
        /// </summary>
        public const string ExibeLetra = "showc";
        /// <summary>
        /// Listagem Padrão Yoruba
        /// </summary>
        public const string ListagemYoruba1 = "DisplayYoruba1";
        /// <summary>
        /// Autor
        /// </summary>
        public const string AUTHOR = "Agostinho da Silva Milagres";
        /// <summary>
        /// Lingua Yoruba
        /// </summary>
        public const string YORUBA = "yoruba";
        /// <summary>
        /// Lingua Kimbundo
        /// </summary>
        public const string KIMBUNDO = "kimbundo";
        /// <summary>
        /// Lingua Kicongo
        /// </summary>
        public const string KICONGO = "kicongo";
        /// <summary>
        /// Lingua EWE
        /// </summary>
        public const string EWEGBE = "ewegbe";

        /// <summary>
        /// Lingua LOGBA
        /// </summary>
        public const string LOGBA = "logba";

        public const string TAG_UL = "ul";
        public const string TAG_LI = "li";
        public const string TAG_P = "p";

        /// <summary>
        /// Obtem o nome do arquivo de Processametnto
        /// </summary>
        /// <param name="source">Dicionário</param>
        /// <param name="LangSource">Linguagem Base</param>
        /// <param name="LangTarget">Linguagem de Destino</param>
        /// <param name="descritor">Descritor do Arquivo de Saida/gravação</param>
        /// <returns>Nome do Arquivo</returns>
        public static string GetNameSearch(BOOKS source, ACTIVELANGUAGE LangSource, ACTIVELANGUAGE LangTarget, FILENAMEITEM descritor)
        {
            string r = "";
            if (source == BOOKS.YORUBA)
                r += "YOR";
            else if (source == BOOKS.KIMBUNDU)
                r += "KBD";
            else if (source == BOOKS.KICONGO)
                r += "KCG";
            else if (source == BOOKS.EWEGBE)
                r += "EWE";
            else if (source == BOOKS.LOGBA)
                r += "LOG";

            if (r != "")
            {
                if (LangSource == ACTIVELANGUAGE.NATIVA)
                    r += "N";
                else if (LangSource == ACTIVELANGUAGE.PORTUGUES)
                    r += "P";
                else if (LangSource == ACTIVELANGUAGE.INGLES)
                    r += "I";
                else
                    r += "X";

                if (LangTarget == ACTIVELANGUAGE.NATIVA)
                    r += "N";
                else if (LangTarget == ACTIVELANGUAGE.PORTUGUES)
                    r += "P";
                else if (LangTarget == ACTIVELANGUAGE.INGLES)
                    r += "I";
                else
                    r += "X";


                if (descritor != FILENAMEITEM.NONE)
                {
                    if (descritor == FILENAMEITEM.FOLHAS)
                        r += "EWE";
                    else if (descritor == FILENAMEITEM.CORPO)
                        r += "ARA";
                    else if (descritor == FILENAMEITEM.FAMILIA)
                        r += "EBI";
                    else if (descritor == FILENAMEITEM.IDOLOS)
                        r += "ORI";
                    else if (descritor == FILENAMEITEM.CORES)
                        r += "AWO";
                    else if (descritor == FILENAMEITEM.SAUDACOES)
                        r += "IBA";
                    else if (descritor == FILENAMEITEM.PROFISSOES)
                        r += "IJO";
                    else if (descritor == FILENAMEITEM.ANIMAIS)
                        r += "ERA";
                    else if (descritor == FILENAMEITEM.BEBIDAS)
                        r += "OTI";
                    else if (descritor == FILENAMEITEM.INTERJEICOES)
                        r += "INT";
                    else
                        r += "UNKNOW";
                }
            }
            return r;
        }

        public static string GetNameSearchEx(string source, string langsource, string langtarget, string descritor)
        {
            string r = "";
            source = source.ToUpper();
            langsource = langsource.ToUpper();
            langtarget = langtarget.ToUpper();
            descritor = descritor.ToUpper();
            if (source == "YOR")
                r += "YOR";
            else if (source == "KBD")
                r += "KBD";
            else if (source == "KCG")
                r += "KCG";
            else if (source == "EWE")
                r += "EWE";
            else if (source == "LOG")
                r += "LOG";

            if (r != "")
            {
                if (langsource == "N")
                    r += "N";
                else if (langsource == "P")
                    r += "P";
                else if (langsource == "I")
                    r += "I";
                else
                    r += "X";

                if (langtarget == "N")
                    r += "N";
                else if (langtarget == "P")
                    r += "P";
                else if (langtarget == "I")
                    r += "I";
                else
                    r += "X";


                if (descritor != "")
                {
                    if (descritor == "EWE")
                        r += "EWE";
                    else if (descritor == "ARA")
                        r += "ARA";
                    else if (descritor == "EBI")
                        r += "EBI";
                    else if (descritor == "ORI")
                        r += "ORI";
                    else if (descritor == "AWO")
                        r += "AWO";
                    else if (descritor == "IBA")
                        r += "IBA";
                    else if (descritor == "IJO")
                        r += "IJO";
                    else if (descritor == "ERA")
                        r += "ERA";
                    else if (descritor == "OTI")
                        r += "OTI";
                    else if (descritor == "INT")
                        r += "INT";
                    else
                        r += "UNKNOW";
                }
            }
            return r;
        }


        /// <summary>
        /// Retorna o caminho configurado como 'bookpath' no arquivo de configuração
        /// </summary>
        /// <returns></returns>
        public static string BookPath { get; set; }

        
        public static string BasePath { get; set; }
        
        /// <summary>
        /// Retorna o caminho completo do arquivo combinado com o path de gravação de Logs
        /// </summary>
        /// <param name="file">Arquivo</param>
        /// <returns>string</returns>
        public static string LogPath { get; set; }

        /// <summary>
        /// Retorna o caminho configurado como 'datapath' no arquivo de configuração
        /// </summary>
        /// <returns></returns>
        public static string OutputPath { get; set; }


        public static List<ItemValue> Dictionaries()
        {
            List<ItemValue> RETURN_VALUE = new List<ItemValue>();
            RETURN_VALUE.Add(new ItemValue("Yorubá", 1));
            RETURN_VALUE.Add(new ItemValue("Kimbundu", 2));
            RETURN_VALUE.Add(new ItemValue("Kicongo", 3));
            RETURN_VALUE.Add(new ItemValue("Ewegbe", 4));
            RETURN_VALUE.Add(new ItemValue("Logba", 5));
            RETURN_VALUE.Add(new ItemValue("Inglês", 6));
            RETURN_VALUE.Add(new ItemValue("Raso_Kicongo", 7));
            RETURN_VALUE.Add(new ItemValue("Raso_Kibundu", 8));
            RETURN_VALUE.Add(new ItemValue("Francês", 9));
            RETURN_VALUE.Add(new ItemValue("Todos", 99));
            return RETURN_VALUE;
        }

        //public static List<ItemValue> AddPublish()
        //{
        //    List<ItemValue> RETURN_VALUE = new List<ItemValue>();
        //    RETURN_VALUE.Add(new ItemValue("Yorubá", 1));
        //    RETURN_VALUE.Add(new ItemValue("Kimbundu", 2));
        //    RETURN_VALUE.Add(new ItemValue("Kicongo", 3));
        //    RETURN_VALUE.Add(new ItemValue("Ewegbe", 4));
        //    RETURN_VALUE.Add(new ItemValue("Logba", 5));
        //    RETURN_VALUE.Add(new ItemValue("Seara", 6));
        //    RETURN_VALUE.Add(new ItemValue("Todos", 99));
        //    return RETURN_VALUE;
        //}


        public static List<ItemValue> Books()
        {
            List<ItemValue> RETURN_VALUE = new List<ItemValue>();
            RETURN_VALUE.Add(new ItemValue("Yorubá", 1));
            RETURN_VALUE.Add(new ItemValue("Kimbundu", 2));
            RETURN_VALUE.Add(new ItemValue("Kicongo", 3));
            RETURN_VALUE.Add(new ItemValue("Ewegbe", 4));
            RETURN_VALUE.Add(new ItemValue("Logba", 5));
            RETURN_VALUE.Add(new ItemValue("Inglês", 6));
            RETURN_VALUE.Add(new ItemValue("Orixás", 7));
            RETURN_VALUE.Add(new ItemValue("Todos", 99));
            return RETURN_VALUE;
        }


        ///// <summary>
        ///// Pega a primeira letra da expressao
        ///// </summary>
        ///// <param name="text">Texto a ser analisado</param>
        ///// <returns>string</returns>
        //public static string Letter(string text)
        //{
        //    return Letter(text, DICTIONARY.YORUBA_PORTUGUES);
        //}
        /// <summary>
        /// Pega a primeira letra da expressao
        /// </summary>
        /// <param name="text">Texto a ser analizado</param>
        /// <param name="basedic">ID do Dicionario Base</param>
        /// <returns>string</returns>
        //public static string Letter(string text, DICTIONARY basedic)
        //{
        //    string _letra = text + "  ";
        //    _letra = _letra.Substring(0, 2).ToUpper().Trim();

        //    if (_letra != "")
        //    {
        //        if (basedic == DICTIONARY.YORUBA_PORTUGUES)
        //        {
        //            if (_letra.CompareTo("Ẹ̀") == 0)
        //                _letra = "Ẹ";
        //            else if (_letra.CompareTo("Ẹ́") == 0)
        //                _letra = "Ẹ";
        //            else if (_letra.CompareTo("Ọ̀") == 0)
        //                _letra = "Ọ";
        //            else if (_letra.CompareTo("Ọ́") == 0)
        //                _letra = "Ọ";
        //            else if (_letra.CompareTo("Ṣ") == 0)
        //                _letra = "Ṣ";
        //            else if ((_letra == "Ẽ") || (_letra.Substring(0, 1) == "Ẽ") || (_letra.Substring(0, 1) == "È"))
        //                _letra = "E";
        //            else if ((_letra == "Ń") || (_letra.Substring(0, 1) == "Ń"))
        //                _letra = "N";
        //            else if (_letra.Substring(0, 1) == "Ã")
        //                _letra = "A";
        //            else if (_letra.Substring(0, 1) == "À")
        //                _letra = "A";
        //            else if (_letra.Substring(0, 1) == "Ì")
        //                _letra = "I";
        //            else if (_letra.Substring(0, 1) == "Ḿ")
        //                _letra = "M";
        //            else if (_letra.Substring(0, 1) == "Õ")
        //                _letra = "O";
        //            else if (_letra.Substring(0, 1) == "Ò")
        //                _letra = "O";
        //            else
        //                _letra = _letra.Substring(0, 1).ToUpper().Trim();

        //        }
        //        if (basedic == DICTIONARY.PORTUGUES_YORUBA)
        //        {
        //            _letra = _letra.Substring(0, 1).ToUpper().Trim();
        //            if (_letra.CompareTo("Á") == 0)
        //                _letra = "A";
        //            else if (_letra.CompareTo("À") == 0)
        //                _letra = "A";
        //            else if (_letra.CompareTo("Â") == 0)
        //                _letra = "A";
        //            else if (_letra.CompareTo("È") == 0)
        //                _letra = "E";
        //            else if (_letra.CompareTo("É") == 0)
        //                _letra = "E";
        //            else if (_letra.CompareTo("Ì") == 0)
        //                _letra = "I";
        //            else if (_letra.CompareTo("Í") == 0)
        //                _letra = "I";
        //            else if (_letra.CompareTo("Ò") == 0)
        //                _letra = "O";
        //            else if (_letra.CompareTo("Ó") == 0)
        //                _letra = "O";
        //            else if (_letra.CompareTo("Ù") == 0)
        //                _letra = "U";
        //            else if (_letra.CompareTo("Ú") == 0)
        //                _letra = "U";
        //            else
        //                _letra = _letra.Substring(0, 1).ToUpper().Trim();

        //        }
        //    }
        //    return _letra;
        //}



        public static List<string> getGramaticalClass(string sourcefile)
        {

            XDocument doc = XDocument.Load(sourcefile);
            var query = (from Itens in doc.Descendants("item").Where(b => (string)b.Element("forma") != "")
                         orderby
                            (string)Itens.Element("forma")
                         select (string)Itens.Element("forma")).Distinct();
            string[] ret = query.ToArray();
            List<string> result = new List<string>();
            foreach (string s in ret)
            {
                foreach (var u in s.Split(new char[] { ',', '+' }))
                {
                    result.Add(u.Trim().Replace("(", "").Replace(")", ""));
                }
            }
            var r = result.Distinct().OrderBy(c => (string)c);
            return r.ToList();
        }
    }
}
