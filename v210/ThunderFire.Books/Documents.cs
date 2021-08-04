using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace ThunderFire.Books
{
    public class Documents
    {
        /// <summary>
        /// Captura de Erro
        /// </summary>
        public static TrapError TrappedError = new TrapError();


        
        public static string GetDocument(string xmlFile, string xslFile)
        {
            StringBuilder sb = new StringBuilder();
            string _retorno = "";
            try
            {
                XslCompiledTransform xslDoc = new XslCompiledTransform();
                XsltSettings settings = new XsltSettings(false, true);
                XsltArgumentList Args = new XsltArgumentList();
                settings.EnableDocumentFunction = true;
                xslDoc.Load(xslFile, settings, new XmlUrlResolver());
                StringWriter stringWriter = new StringWriter(sb);
                Als.Util obj = new Als.Util();
                Args.AddExtensionObject("urn:util", obj);
                xslDoc.Transform(xmlFile, Args, stringWriter);
                stringWriter.Close();
                _retorno = sb.ToString();
            }
            catch (Exception Error)
            {
                TrappedError.SetError("", Error.Message, "<p>Não foi possível renderizar as informações sobre o documento solicitado</p>", Error);
            }
            return _retorno;
        }

        /// <summary>
        /// Retorna um objeto do documento xml transformado para o xslt fornecido lido
        /// </summary>
        /// <param name="xmlFile">Aruivo XML</param>
        /// <param name="xslFile">Arquivo de Transformação XSLT</param>
        /// <param name="id">id de identificação</param>
        /// <returns>IODocument</returns>
        public static IODocument GetDocument(string xmlFile, string xslFile, string id)
        {
            StringBuilder sb = new StringBuilder();
            IODocument retorno = new IODocument();
            TrappedError.SetError();
            GetDocumentParam(1, retorno, xmlFile, id);
            try
            {
                XslCompiledTransform xslDoc = new XslCompiledTransform();
                XsltArgumentList Args = new XsltArgumentList();
                XsltSettings settings = new XsltSettings(false, true);
                settings.EnableDocumentFunction = true;
                xslDoc.Load(xslFile, settings, new XmlUrlResolver());
                StringWriter stringWriter = new StringWriter(sb);
                Als.Util obj = new Als.Util();
                Args.AddExtensionObject("urn:util", obj);
                Args.AddParam("pid", "", id.ToString());
                xslDoc.Transform(xmlFile, Args, stringWriter);
                stringWriter.Close();
                retorno.Data = sb.ToString();
                TrappedError.SetError("", "", "PROCESSAMENTO EFETUADO COM SUCESSO", null);
            }

            catch (XmlException Error)
            {
                TrappedError.SetError(Error.Message, Error);
            }
            catch (FileNotFoundException Error)
            {
                if (Error.FileName.Contains(".xslt"))
                    TrappedError.SetError("", Error.Message, "Arquivo de Transformação de Dados não encontrado", Error);
                else
                    TrappedError.SetError("", Error.Message, "Arquivo de Dados não encontrado", Error);
            }
            catch (Exception Error)
            {
                TrappedError.SetError(Error.Message, Error);
            }
            return retorno;
        }

        public static IODocument GetStringFromFile(string xmlFile, string xslFile, string id)
        {
            StringBuilder sb = new StringBuilder();
            IODocument retorno = new IODocument();
            TrappedError.SetError();
            try
            {
                XslCompiledTransform xslDoc = new XslCompiledTransform();
                XsltArgumentList Args = new XsltArgumentList();
                XsltSettings settings = new XsltSettings(false, true);
                settings.EnableDocumentFunction = true;
                xslDoc.Load(xslFile, settings, new XmlUrlResolver());
                StringWriter stringWriter = new StringWriter(sb);
                Als.Util obj = new Als.Util();
                Args.AddExtensionObject("urn:util", obj);
                Args.AddParam("pid", "", id.ToString());
                //xslDoc.Transform(xmlFile, Args, stringWriter);
                xslDoc.Transform(new XPathDocument(new StringReader(xmlFile)), Args, stringWriter);
                stringWriter.Close();
                retorno.Data = sb.ToString();
                TrappedError.SetError("", "", "PROCESSAMENTO EFETUADO COM SUCESSO", null);
            }

            catch (XmlException Error)
            {
                TrappedError.SetError(Error.Message, Error);
            }
            catch (FileNotFoundException Error)
            {
                TrappedError.SetError(Error.Message, Error);
                if (Error.FileName.Contains(".xslt"))
                    retorno.Data = "Arquivo de Transformação de Dados não encontrado";
                else
                    retorno.Data = "Arquivo de Dados não encontrado";
            }
            catch (Exception Error)
            {
                TrappedError.SetError(Error.Message, Error);
                retorno.Data = Error.Message;
            }
            return retorno;
        }

        public static IODocument GetStringFromFile(string xmlFile, string xslFile, XsltArgumentList args)
        {
            StringBuilder sb = new StringBuilder();
            IODocument retorno = new IODocument();
            TrappedError.SetError();
            try
            {
                XslCompiledTransform xslDoc = new XslCompiledTransform();
                XsltArgumentList Args = new XsltArgumentList();
                XsltSettings settings = new XsltSettings(false, true);
                settings.EnableDocumentFunction = true;
                xslDoc.Load(xslFile, settings, new XmlUrlResolver());
                StringWriter stringWriter = new StringWriter(sb);
                Als.Util obj = new Als.Util();
                Args.AddExtensionObject("urn:util", obj);
                xslDoc.Transform(xmlFile, Args, stringWriter);
                xslDoc.Transform(new XPathDocument(new StringReader(xmlFile)), Args, stringWriter);
                stringWriter.Close();
                retorno.Data = sb.ToString();
                TrappedError.SetError("", "", "PROCESSAMENTO EFETUADO COM SUCESSO", null);
            }

            catch (XmlException Error)
            {
                TrappedError.SetError(Error.Message, Error);
            }
            catch (FileNotFoundException Error)
            {
                TrappedError.SetError(Error.Message, Error);
                if (Error.FileName.Contains(".xslt"))
                    retorno.Data = "Arquivo de Transformação de Dados não encontrado";
                else
                    retorno.Data = "Arquivo de Dados não encontrado";
            }
            catch (Exception Error)
            {
                TrappedError.SetError(Error.Message, Error);
                retorno.Data = Error.Message;
            }
            return retorno;
        }
        /// <summary>
        /// Executa a transformação de um documento xml 
        /// </summary>
        /// <param name="xmlFile">Arquivo XML</param>
        /// <param name="xslFile">Arquivo XSL/XSLT</param>
        /// <param name="Args">Argumentos de Pesquisa</param>
        /// <returns>string HTML</returns>
        public static IODocument GetDocument(string xmlFile, string xslFile, XsltArgumentList Args)
        {
            StringBuilder sb = new StringBuilder();
            IODocument retorno = new IODocument();
            TrappedError.SetError();
            try
            {
                XslCompiledTransform xslDoc = new XslCompiledTransform();
                XsltSettings settings = new XsltSettings(false, true);
                settings.EnableDocumentFunction = true;
                xslDoc.Load(xslFile, settings, new XmlUrlResolver());
                StringWriter stringWriter = new StringWriter(sb);
                Als.Util obj = new Als.Util();
                Args.AddExtensionObject("urn:util", obj);
                xslDoc.Transform(xmlFile, Args, stringWriter);
                stringWriter.Close();
                retorno.Data = sb.ToString();
                TrappedError.SetError("", "", "PROCESSAMENTO EFETUADO COM SUCESSO", null);
            }
            catch (XmlException Error)
            {
                TrappedError.SetError(Error);
                retorno.Data = Error.Message;
            }
            catch (FileNotFoundException Error)
            {
                TrappedError.SetError(Error);
                if (Error.FileName.Contains(".xslt"))
                    retorno.Data = "Arquivo de Transformação de Dados não encontrado";
                else
                    retorno.Data = "Arquivo de Dados não encontrado";
            }
            catch (System.Xml.Xsl.XsltException Error)
            {
                TrappedError.SetError(Error);
                retorno.Data = "Falha na carga do Arquivo de Transformação";
            }

            catch (Exception Error)
            {
                TrappedError.SetError(Error);
                retorno.Data = Error.Message;
            }
            return retorno;
        }

        public static IODocument GetDocumentWithPage(string xmlFile, string xslFile, string id)
        {
            StringBuilder sb = new StringBuilder();
            IODocument retorno = new IODocument();
            TrappedError.SetError();
            try
            {
                XslCompiledTransform xslDoc = new XslCompiledTransform();
                XsltArgumentList Args = new XsltArgumentList();
                XsltSettings settings = new XsltSettings(false, true);
                settings.EnableDocumentFunction = true;
                xslDoc.Load(xslFile, settings, new XmlUrlResolver());
                StringWriter stringWriter = new StringWriter(sb);
                Als.Util obj = new Als.Util();
                Args.AddExtensionObject("urn:util", obj);
                Args.AddParam("pid", "", id.ToString());
                xslDoc.Transform(xmlFile, Args, stringWriter);
                stringWriter.Close();
                retorno.Data = sb.ToString();
            }

            catch (XmlException Error)
            {
                TrappedError.SetError(Error.Message, Error);
            }
            catch (FileNotFoundException Error)
            {
                TrappedError.SetError(Error.Message, Error);
                retorno.Data = "Arquivo não encontrado";
            }
            catch (Exception Error)
            {
                TrappedError.SetError(Error.Message, Error);
                retorno.Data = "Não foi possível localizar informações sobre o documento solicitado";
            }
            finally
            {
                sb = null;
            }
            return retorno;
        }

        public static IODocument GetDocumentWithPage(string xmlFile, string xslFile, XsltArgumentList Args)
        {
            StringBuilder sb = new StringBuilder();
            IODocument retorno = new IODocument();
            TrappedError.SetError();
            try
            {
                XslCompiledTransform xslDoc = new XslCompiledTransform();
                XsltSettings settings = new XsltSettings(false, true);
                settings.EnableDocumentFunction = true;
                xslDoc.Load(xslFile, settings, new XmlUrlResolver());
                StringWriter stringWriter = new StringWriter(sb);
                xslDoc.Transform(xmlFile, Args, stringWriter);
                stringWriter.Close();
                retorno.Data = sb.ToString();
            }
            catch (XmlException Error)
            {
                TrappedError.SetError(Error.Message, Error);
            }
            catch (DirectoryNotFoundException Error)
            {
                TrappedError.SetError("", Error.Message, "Arquivo não encontrado", Error);
            }
            catch (FileNotFoundException Error)
            {
                TrappedError.SetError("", Error.Message, "Arquivo não encontrado", Error);
            }
            catch (Exception Error)
            {
                TrappedError.SetError("", Error.Message, "Não foi possível localizar informações sobre o documento solicitado", Error);
            }
            finally
            {
                sb = null;
            }
            return retorno;
        }

        public static IODocument GetDocumentFromString(string xmlFile, string xsltstring, XsltArgumentList Args)
        {
            StringBuilder sb = new StringBuilder();
            IODocument retorno = new IODocument();
            try
            {
                XslCompiledTransform xslDoc = new XslCompiledTransform();
                XsltSettings settings = new XsltSettings(false, true);
                settings.EnableDocumentFunction = true;
                //XmlTextReader xslfile = new XmlTextReader(xsltstring);
                xslDoc.Load(XmlReader.Create(new StringReader(xsltstring)), settings, new XmlUrlResolver());

                //xslDoc.Load(xslfile);
                //xslDoc.Load(XmlReader.Create(new StringReader(xsltstring)), settings, new XmlUrlResolver());
                StringWriter stringWriter = new StringWriter(sb);
                //Util obj = new Util();
                //Args.AddExtensionObject("urn:util", obj);
                xslDoc.Transform(xmlFile, Args, stringWriter);
                stringWriter.Close();
                retorno.Data = sb.ToString();
            }
            catch (XmlException Error)
            {
                TrappedError.SetError(Error.Message, Error);
            }
            catch (DirectoryNotFoundException Error)
            {
                TrappedError.SetError("", Error.Message, "Arquivo não encontrado", Error);
            }
            catch (FileNotFoundException Error)
            {
                TrappedError.SetError("", Error.Message, "Arquivo não encontrado", Error);
            }
            catch (Exception Error)
            {
                TrappedError.SetError("", Error.Message, "Não foi possível localizar informações sobre o documento solicitado", Error);
            }
            finally
            {
                sb = null;
            }
            return retorno;
        }

        /// <summary>
        /// Resolve um arquivo xml baseado em uma transformação xlst string
        /// </summary>
        /// <param name="xmlFile">Arquivo XML</param>
        /// <param name="xsltstring">XSLT string</param>
        /// <param name="id">Id de Filtro</param>
        /// <returns>IODocument</returns>
        public static IODocument GetDocumentFromString(string xmlFile, string xsltstring, string id)
        {
            StringBuilder sb = new StringBuilder();
            IODocument retorno = new IODocument();
            try
            {
                XslCompiledTransform xslDoc = new XslCompiledTransform();
                XsltArgumentList Args = new XsltArgumentList();
                XsltSettings settings = new XsltSettings(false, true);
                settings.EnableDocumentFunction = true;
                xslDoc.Load(XmlReader.Create(new StringReader(xsltstring)), settings, new XmlUrlResolver());
                StringWriter stringWriter = new StringWriter(sb);
                Als.Util obj = new Als.Util();
                //Args.AddExtensionObject("urn:util", obj);
                Args.AddParam("field", "", id.ToString());
                xslDoc.Transform(xmlFile, Args, stringWriter);
                stringWriter.Close();
                retorno.Data = sb.ToString();
            }

            catch (XmlException Error)
            {
                TrappedError.SetError(Error);
            }
            catch (DirectoryNotFoundException Error)
            {
                TrappedError.SetError("", Error.Message, "Arquivo não encontrado", Error);
            }
            catch (FileNotFoundException Error)
            {
                TrappedError.SetError("", Error.Message, "Arquivo não encontrado", Error);
            }
            catch (Exception Error)
            {
                TrappedError.SetError("", Error.Message, "Não foi possível localizar informações sobre o documento solicitado", Error);
            }
            finally
            {
                sb = null;
            }
            return retorno;
        }

        public static IODocument GetDocumentFromString(string xmlFile, string xsltstring)
        {
            StringBuilder sb = new StringBuilder();
            IODocument retorno = new IODocument();
            try
            {
                XslCompiledTransform xslDoc = new XslCompiledTransform();
                XsltArgumentList Args = new XsltArgumentList();
                XsltSettings settings = new XsltSettings(false, true);
                settings.EnableDocumentFunction = true;
                xslDoc.Load(XmlReader.Create(new StringReader(xsltstring)), settings, new XmlUrlResolver());
                StringWriter stringWriter = new StringWriter(sb);
                Als.Util obj = new Als.Util();
                //Args.AddExtensionObject("urn:util", obj);
                //Args.AddParam("field", "", id.ToString());
                xslDoc.Transform(xmlFile, Args, stringWriter);
                stringWriter.Close();
                retorno.Data = sb.ToString();
            }

            catch (XmlException Error)
            {
                TrappedError.SetError(Error.Message, Error);
            }
            catch (DirectoryNotFoundException Error)
            {
                TrappedError.SetError("", Error.Message, "Arquivo não encontrado", Error);
            }
            catch (FileNotFoundException Error)
            {
                TrappedError.SetError("", Error.Message, "Não foi possível localizar informações sobre o documento solicitado", Error);
            }
            catch (Exception Error)
            {
                TrappedError.SetError("", Error.Message, "Não foi possível localizar informações sobre o documento solicitado", Error);
            }
            finally
            {
                sb = null;
            }
            return retorno;
        }


        /// <summary>
        /// Le os parametros de um documento XML
        /// </summary>
        /// <param name="mode">1 - Arquivo Físico, 2 - String XML</param>
        /// <param name="document">Objeto IoDocument de contenção</param>
        /// <param name="xmlFile">Arquivo ou String XML</param>
        /// <param name="id">ID do Documento</param>
        public static void GetDocumentParam(int mode, IODocument document, string xmlFile, string id)
        {
            try
            {
                if ((mode == 1) || (mode == 2))
                {
                    XmlDocument _doc = new XmlDocument();
                    if (mode == 1)
                        _doc.Load(xmlFile);
                    if (mode == 2)
                        _doc.LoadXml(xmlFile);

                    XmlNode node = _doc.SelectSingleNode("//documentos/documento[@id='" + id.ToString() + "']");
                    if (node != null)
                    {
                        if (node.SelectSingleNode("@title") != null)
                            document.Title = node.SelectSingleNode("@title").Value.ToString();
                        if (node.SelectSingleNode("@UpdateData") != null)
                            document.UpdateData = node.SelectSingleNode("@UpdateData").Value.ToString();

                    }
                    node = null;
                    _doc = null;
                }
            }

            catch (Exception Error)
            {
                TrappedError.SetError("", Error.Message, "Não foi possível localizar informações sobre o documento solicitado", Error);
            }
        }
    }
}
