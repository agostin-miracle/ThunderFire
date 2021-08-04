using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ThunderFire.Books.Models
{
    public class InternalCientifico
    {
        /// <summary>
        /// ID de Referência do Item Pai
        /// </summary>
        [XmlAttribute("id")]
        public string ID { get; set; } = "";
        [XmlText]
        public string Text { get; set; } = "";
    }
}
