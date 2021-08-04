using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ThunderFire.Books.Models
{
    public class Palavra
    {
        [XmlAttribute("ortography")]
        public string OrtoGraphy { get; set; }
        [XmlAttribute("fonetica")]
        public string Fonetica { get; set; }
        [XmlAttribute("pronuncia")]
        public string Pronuncia { get; set; }
        [XmlAttribute("literal")]
        public string Literal { get; set; }
        [XmlAttribute("liteng")]
        public string LiteralEnglish { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

}
