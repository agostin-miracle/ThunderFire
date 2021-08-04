using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ThunderFire.Books.Models
{
    /// <summary>
    /// Estrutura Base do Dicionário
    /// </summary>
    [Serializable]
    [XmlRoot("documentos", Namespace = "", IsNullable = false)]
    public class DictionaryData
    {
        private List<Item> m_itemlist;
        /// <summary>
        /// Chave auxiliar de processamento
        /// </summary>
        [XmlIgnore]
        public string Key = "";

        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("title")]
        public string Title { get; set; }
        [XmlAttribute("ref")]
        public string NameSpace { get; set; }
        [XmlAttribute("UpdateData")]
        public string Data { get; set; }
        [XmlAttribute("total")]
        public string NumeroRegistros { get; set; }


        [XmlElement]
        public List<Item> item
        {
            get
            {
                if (m_itemlist == null)
                {
                    m_itemlist = new List<Item>();
                }
                return m_itemlist;
            }
        }
    }

}
