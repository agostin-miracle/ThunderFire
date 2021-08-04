using System.Xml.Serialization;

namespace ThunderFire.Books.Models
{
    public class ClasseGramatical
    {
        /// <summary>
        /// Código da Ação de Impressão
        /// </summary>
        [XmlAttribute("action")]
        public string Action { get; set; }
        [XmlAttribute("time")]
        public string Time { get; set; }
        [XmlAttribute("index")]
        public int Index { get; set; }
        [XmlText]
        public string Text { get; set; }

        public ClasseGramatical()
        {
            this.Action = "";
            this.Text = "";
            this.Time = "";
            this.Index = 0;
        }
    }

}
