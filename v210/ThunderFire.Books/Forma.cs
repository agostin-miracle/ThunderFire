using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ThunderFire.Books
{
    /// <summary>
    /// Estrutura de Contenção de Dados 'forma'
    /// </summary>
    public class FormaItem
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Texto
        /// </summary>
        public string Texto { get; set; }
        /// <summary>
        /// Inicia uma nova instância 
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="text">Texto</param>
        public FormaItem(string id, string text)
        {
            this.ID = id;
            this.Texto = Texto;
        }
    }

    public class Forma
    {
        public TrapError TrappedError = new TrapError();
        public string Language { get; set; }
        public string Texto { get; set; }
        public string FileName { get; set; }

        public Forma(string language)
        {
            this.Language = language;
        }

        public void Insert(FormaItem item)
        {
            try
            {
                if (this.FileName != "")
                {
                    if (File.Exists(this.FileName))
                    {
                        XmlDocument doc1 = new XmlDocument();
                        doc1.Load(this.FileName);
                        XmlNode node = doc1.SelectSingleNode("//root/base[@language = '" + this.Language + "']");
                        if (node != null)
                        {
                            var lid = item.ID.Split(',');
                            for (int i = 0; i < lid.Length; i++)
                            {
                                var dt = lid[i].ToString().Trim().ToLower().Replace("(", "").Replace(")", "");
                                XmlNode node1 = doc1.SelectSingleNode("//root/base[@language = '" + this.Language + "']/forma[@id='" + dt + "']");
                                if (node1 == null)
                                {
                                    XmlElement p0 = doc1.CreateElement("forma");
                                    p0.SetAttribute("id", dt);
                                    p0.SetAttribute("texto", item.Texto);
                                    node.AppendChild(p0);
                                    doc1.Save(this.FileName);
                                }

                            }

                        }
                    }
                }
            }
            catch (Exception Error)
            {
                this.TrappedError.SetError(Error.Message, Error);
            }
        }
        /// <summary>
        /// Adiciona um novo registro de Classe Gramatical
        /// </summary>
        /// <param name="item">ItemForma</param>
        public void Add(FormaItem item)
        {
            try
            {
                if (this.FileName != "")
                {
                    if (File.Exists(this.FileName))
                    {
                        XmlDocument doc1 = new XmlDocument();
                        doc1.Load(this.FileName);
                        XmlNode node = doc1.SelectSingleNode("//root/base[@language = '" + this.Language + "']");
                        if (node != null)
                        {
                            XmlNode node1 = doc1.SelectSingleNode("//root/base[@language = '" + this.Language + "']/forma[@id='" + item.ID + "']");
                            if (node1 == null)
                            {
                                XmlElement p0 = doc1.CreateElement("forma");
                                p0.SetAttribute("id", item.ID);
                                p0.SetAttribute("texto", item.Texto);
                                node.AppendChild(p0);
                                doc1.Save(this.FileName);
                            }
                        }
                    }
                }
            }
            catch (Exception Error)
            {
                this.TrappedError.SetError(Error);
            }
        }
    }
}
