using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ThunderFire.Books.Models
{
    public class InternalLocal
    {
        /// <summary>
        /// Descrição da Referência
        /// </summary>
        [XmlAttribute("ref")]
        public string Reference { get; set; } = "";
        /// <summary>
        /// Texto
        /// </summary>
        [XmlText]
        public string Text { get; set; } = "";
    }
}
