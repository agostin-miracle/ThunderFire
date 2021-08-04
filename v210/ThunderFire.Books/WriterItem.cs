using System;
using System.Xml.Xsl;

namespace ThunderFire.Books
{
    public class WriterItem
    {
        /// <summary>
        /// Indica se na composicao do livro deverá ser montada a fonética do verbete
        /// </summary>
        public string ComporFonetica = "N";
        /// <summary>
        /// ID do Dicionário
        /// </summary>
        public string DictionaryId = "";
        /// <summary>
        /// Título do Dicionário
        /// </summary>
        public string DictionaryTitle = "";
        /// <summary>
        /// Referência do Dicionário
        /// </summary>
        public string DictionaryReference = "http://www.maze.kinghost.net";

        private BOOKS Opcao;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="opcao">Opção de Dicionário</param>
        public WriterItem(BOOKS opcao)
        {
            Opcao = opcao;
            switch (Opcao)
            {
                case BOOKS.YORUBA:
                    ComporFonetica = "S";
                    DictionaryId = "yoruba";
                    DictionaryTitle = "Yorúbá";
                    break;
                case BOOKS.KIMBUNDU:
                    ComporFonetica = "S";
                    DictionaryId = "kimbundu";
                    DictionaryTitle = "Kimbundu";
                    break;
                case BOOKS.KICONGO:
                    ComporFonetica = "S";
                    DictionaryId = "kicongo";
                    DictionaryTitle = "Kicongo";
                    break;
                case BOOKS.EWEGBE:
                    ComporFonetica = "S";
                    DictionaryId = "ewegbe";
                    DictionaryTitle = "Ewegbe";
                    break;
                case BOOKS.LOGBA:
                    ComporFonetica = "N";
                    DictionaryId = "Logba";
                    DictionaryTitle = "Logba";
                    break;
                case BOOKS.INGLES:
                    ComporFonetica = "N";
                    DictionaryId = "Ingles";
                    DictionaryTitle = "Ingles";
                    break;
                case BOOKS.FRANCES:
                    ComporFonetica = "N";
                    DictionaryId = "Frances";
                    DictionaryTitle = "Frances";
                    break;
            }
        }

        /// <summary>
        /// Argumentos de Composição do Dicionário
        /// </summary>
        /// <returns>XsltArgumentList</returns>
        public XsltArgumentList Arguments()
        {
            XsltArgumentList Args = new XsltArgumentList();
            Args.AddParam("compor_fonetica", "", ComporFonetica);
            Args.AddParam("dic_id", "", DictionaryId);
            Args.AddParam("dic_tit", "", DictionaryTitle);
            Args.AddParam("dic_ref", "", DictionaryReference);
            Args.AddParam("dic_data", "", DateTime.Now.ToString("dd/MM/yyyy"));
            return Args;
        }
    }
}
