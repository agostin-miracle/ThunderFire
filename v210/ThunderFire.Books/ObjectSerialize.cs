using ThunderFire.Books.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ThunderFire.Books
{
    public class ObjectSerialize
    {
        public TrapError TrappedError = new TrapError();
        /// <summary>
        /// Define se realmente executa o log
        /// </summary>
        public bool SubmitLog { get; set; } = false;
        /// <summary>
        /// Status do Processamento
        /// </summary>
        public bool Status { get; internal set; }

        /// <summary>
        /// Retorna a string do arquivo xml serializado
        /// </summary>
        public string SerializedText { get; internal set; }

        public ObjectSerialize()
        {
            this.SubmitLog = true;
            this.TrappedError = new TrapError();
            this.Status = false;
        }


        /// <summary>
        /// Serializa um objeto do Tipo DictionaryData para um arquivo XML
        /// </summary>
        /// <param name="obj">Objeto do Tipo DictionaryData</param>
        public void SerializeDictionary(DictionaryData obj)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
                serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);
                StringBuilder sb = new StringBuilder();
                StringWriter writer = new StringWriter(sb);
                //TextWriter writer = new StreamWriter(fileName);
                serializer.Serialize(writer, obj);
                SerializedText = sb.ToString();
                writer.Close();
                this.Status = true;
            }
            catch (Exception Error)
            {
                this.TrappedError.SetError(Error);
                if (this.SubmitLog)
                    TrappedError.AddMessage(Error.Message);
            }
        }
        /// <summary>
        /// Serializa um objeto do Tipo DictionaryData para um arquivo XML
        /// </summary>
        /// <param name="obj">Objeto do Tipo DictionaryData</param>
        /// <param name="fileName">Nome do Arquivo a ser gravado</param>
        public void SerializeDictionary(DictionaryData obj, string fileName)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
                serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);
                TextWriter writer = new StreamWriter(fileName);
                serializer.Serialize(writer, obj);
                writer.Close();
                this.Status = true;
            }
            catch (Exception Error)
            {
                this.TrappedError.SetError(Error.Message, Error);
                if (this.SubmitLog)
                    TrappedError.AddMessage(Error.Message);
            }
        }


        /// <summary>
        /// DeSerializa um arquivo xml de estrutura DictionaryData para um objeto do Tipo DicionaryData
        /// </summary>
        /// <param name="filename">Nome do Arquivo a ser deserializado</param>
        /// <returns>Objeto</returns>
        public DictionaryData DeSerializeDictionary(string filename)
        {
            DictionaryData result = null;
            try
            {
                if (File.Exists(filename))
                {
                    if (this.SubmitLog)
                        TrappedError.AddMessage(String.Format("Begin in {0} ", DateTime.Now.ToString()));
                    XmlSerializer serializer = new XmlSerializer(typeof(DictionaryData));
                    serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
                    serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);
                    FileStream fs = new FileStream(filename, FileMode.Open);
                    result = (DictionaryData)serializer.Deserialize(fs);
                    if (this.SubmitLog)
                        TrappedError.AddMessage(String.Format("End in {0} ", DateTime.Now.ToString()));
                    this.Status = true;
                }
                else {
                    this.TrappedError.SetError("FILENOTFOUND");
                    this.TrappedError.UserError = String.Format("Arquivo {0} não existe", filename);
                }
            }
            catch (Exception Error)
            {
                this.TrappedError.SetError(Error);
                if (this.SubmitLog)
                    TrappedError.AddMessage(Error.Message);
            }
            return result;
        }

        private void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
        {
            if (this.SubmitLog)
                TrappedError.AddMessage(String.Format("Unknown Codee {0} = {1}", e.Name, e.Text));
        }

        private void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
        {
            System.Xml.XmlAttribute attr = e.Attr;
            if (this.SubmitLog)
                TrappedError.AddMessage(String.Format("Unknown attribute {0} = {1}", attr.Name, attr.Value));
        }
    }
}
