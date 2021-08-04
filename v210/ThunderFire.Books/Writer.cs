using System;
using System.Reflection;
using System.Xml.Xsl;

namespace ThunderFire.Books
{
    public class Writer 
    {
        public TrapError TrappedError = new TrapError();
        /// <summary>
        /// Folha de Estilo Base
        /// </summary>
        public string XsltSource { get; set; }
        /// <summary>
        /// Dicionário de Origem
        /// </summary>
        public string DictionaryBaseCopy { get; set; }
        /// <summary>
        /// Dicionário de Destino
        /// </summary>
        public string TargetFile { get; set; }

        /// <summary>
        /// Cria um novo documento
        /// </summary>
        /// <param name="opcao">Tipo de Book</param>
        public bool Create(BOOKS opcao)
        {
            WriterItem EBook = new WriterItem(opcao);
            XsltArgumentList Args = EBook.Arguments();
            bool RETURN_VALUE = false;
            try
            {
                IODocument document = ThunderFire.Books.Documents.GetDocument(DictionaryBaseCopy, XsltSource, Args);

                if (!ThunderFire.Books.Documents.TrappedError.HasError())
                {
                    document.Save(TargetFile, DocumentAction.RemoveUTF16);
                    if (ThunderFire.Books.Documents.TrappedError.HasError())
                        this.TrappedError = ThunderFire.Books.Documents.TrappedError;
                    else
                    {
                        this.TrappedError.SetError("OK");
                        RETURN_VALUE = true;
                    }
                }
                else
                    this.TrappedError = ThunderFire.Books.Documents.TrappedError;

                document = null;
                Args = null;
                EBook = null;
            }
            catch (Exception Error)
            {
                this.TrappedError.SetError(Error);
                this.TrappedError.CurrentMethod = MethodBase.GetCurrentMethod().Name;
            }
            return RETURN_VALUE;
        }
    }
}