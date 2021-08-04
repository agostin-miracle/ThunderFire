using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ThunderFire.Books.Models
{
    public class Item
    {
        [XmlAttribute("book")]
        public string Book { get; set; }
        [XmlAttribute("letra")]
        public string Letra { get; set; }
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlAttribute("tag")]
        public string Tag { get; set; }
        [XmlAttribute("literal")]
        public string Literal { get; set; }
        [XmlAttribute("extended")]
        public string Extended { get; set; }
        [XmlAttribute("word")]
        public string Word { get; set; }
        [XmlAttribute("image")]
        public string Image { get; set; }

        [XmlElement("pronuncia")]
        public Palavra Pronuncia { get; set; }

        [XmlElement("fonetica")]
        public Palavra Fonetica { get; set; }

        [XmlElement("palavra")]
        public Palavra Palavra { get; set; }
        [XmlElement("referencia")]
        public InternalReference Referencia { get; set; }

        [XmlIgnore]
        private string TextFlexao { get; set; }
        [XmlElement("flexao")]
        public XmlCDataSection Flexao
        {
            get
            {
                if (TextFlexao != null)
                    return new System.Xml.XmlDocument().CreateCDataSection(TextFlexao);
                else
                    return new System.Xml.XmlDocument().CreateCDataSection("");
            }
            set
            {
                if (value != null)
                    TextFlexao = value.Value;
                else
                    TextFlexao = "";
            }
        }

        [XmlElement("marcador")]
        public string Marcador { get; set; }

        [XmlElement("order")]
        public string Order { get; set; }

        [XmlElement("forma")]
        public ClasseGramatical Forma { get; set; }

        [XmlElement("local")]
        public InternalLocal Local { get; set; }
        /// <summary>
        /// Código da Classe
        /// </summary>
        [XmlElement("classe")]
        public string Classe { get; set; }
        /// <summary>
        /// Descrição
        /// </summary>
        [XmlElement("descricao")]
        public InternalDescription Descricao { get; set; }
        /// <summary>
        /// Verbo ou Referência
        /// </summary>
        [XmlElement("verbo")]
        public string Verbo { get; set; }
        /// <summary>
        /// Verbo ou Referência de ligação
        /// </summary>
        [XmlElement("ligacao")]
        public string Ligacao { get; set; }
        /// <summary>
        /// Observação
        /// </summary>
        //[XmlText]

        [XmlIgnore]
        private string Text1 { get; set; }

        [XmlElement("observacao")]
        public XmlCDataSection Observacao
        {
            get { return new System.Xml.XmlDocument().CreateCDataSection(Text1); }
            set { Text1 = value.Value; }
        }

        //[XmlIgnore]
        private string Text2 { get; set; }

        [XmlElement("observation")]
        public XmlCDataSection Observation
        {
            get { return new System.Xml.XmlDocument().CreateCDataSection(Text2); }
            set { Text2 = value.Value; }
        }

        [XmlElement("cientifico")]
        public InternalCientifico Cientifico { get; set; }
        [XmlElement("familia")]
        public string Familia { get; set; }


        public Item()
        {
            Palavra = new Palavra();
            Referencia = new InternalReference();
            Forma = new ClasseGramatical();
            Local = new InternalLocal();
            Descricao = new InternalDescription();
            Cientifico = new InternalCientifico();
        }
    }
}
