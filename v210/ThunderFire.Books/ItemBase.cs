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
    /// Estrutura Base do Dicionário
    /// </summary>
    public class ItemBase
    {
        /// <summary>
        /// Chave auxiliar de processamento
        /// </summary>
        public string Key = "";

        /// <summary>
        /// Indicador de Seleção especial Book
        /// </summary>
        public string Book { get; set; } = "";
        /// <summary>
        /// Letra Inicial
        /// </summary>
        public string Letra { get; set; } = "";
        /// <summary>
        /// Versão
        /// </summary>
        public string Version { get; set; }
        public string Tag { get; set; }
        public string Literal { get; set; }
        public string Extended { get; set; }
        public string Word { get; set; }
        public string Image { get; set; }
        public WordReferenceData Palavra { get; set; }
        public string Pronuncia { get; set; }
        public string Fonetica { get; set; }
        public string Dialeto { get; set; }
        public RefReferenceData Referencia { get; set; }
        public string Flexao { get; set; }
        public string Marcador { get; set; }

        /// <summary>
        /// Número que indica o grupo de um determinado verbete
        /// </summary>
        public string Grupo { get; set; } = "0";
        public string Order { get; set; }
        public FormReferenceData Forma { get; set; }
        public LocalReferenceData Local { get; set; }
        /// <summary>
        /// Código da Classe
        /// </summary>
        public string Classe { get; set; }
        /// <summary>
        /// Descrição
        /// </summary>
        public RefReferenceData Descricao { get; set; }
        /// <summary>
        /// Verbo ou Referência
        /// </summary>
        public string Verbo { get; set; }
        /// <summary>
        /// Verbo ou Referência de ligação
        /// </summary>
        public string Ligacao { get; set; }
        /// <summary>
        /// Observação
        /// </summary>
        public string Observacao { get; set; }
        public string Observation { get; set; }
        public LatinReferenceData Latino { get; set; }
        public ItemBase()
        {
            Palavra = new WordReferenceData();
            Referencia = new RefReferenceData();
            Forma = new FormReferenceData();
            Local = new LocalReferenceData();
            Descricao = new RefReferenceData();
            Latino = new LatinReferenceData();

            this.Grupo = "0";
            this.Order = "0";
            this.Book = "0";
            this.Letra = "";
            this.Version = "1";
            this.Tag = "";
            this.Literal = "";
            this.Extended = "";
            this.Word = "";
            this.Fonetica = "";
            this.Pronuncia = "";
            this.Dialeto = "";
            this.Image = "";
            this.Flexao = "";
            this.Marcador = "";
            this.Verbo = "";
            this.Ligacao = "";
            this.Observacao = "";
            this.Observation = "";
        }



        //public ItemBase(string _palavra, string _forma, string _descricao, string _classe)
        //{
        //    IItemBase(_palavra, "", _forma, "", 0, "", _descricao, "", "", "", _classe, "");
        //}

        //public ItemBase(string _palavra, string _tag, string _forma, int _index, string _descricao, string _dialeto, string _local)
        //{
        //    IItemBase(_palavra, _tag, _forma, "", _index, "", _descricao, _dialeto, _local, "", "", "");
        //}

        //public ItemBase(string _palavra, string _tag, string _forma, int _index, string _descricao, string _dialeto, string _local, string _observacao)
        //{
        //    IItemBase(_palavra, _tag, _forma, "", _index, "", _descricao, _dialeto, _local, _observacao, "", "");
        //}

        //public ItemBase(string _palavra, string _tag, string _forma, int _index, string _ingles, string _descricao, string _dialeto, string _local, string _observacao)
        //{
        //    IItemBase(_palavra, _tag, _forma, "", _index, _ingles, _descricao, _dialeto, _local, _observacao, "", "");
        //}

        ///// <summary>
        ///// Cria uma instancia do objeto
        ///// </summary>
        ///// <param name="_palavra">Verbete</param>
        ///// <param name="_tag">Tag de controle</param>
        ///// <param name="_forma">Classe Gramatical</param>
        ///// <param name="_literal">Literal</param>
        ///// <param name="_index">Índice de Localização</param>
        ///// <param name="_ingles">Expresão em inglês</param>
        ///// <param name="_descricao">Descrição</param>
        ///// <param name="_dialeto">Dialeto</param>
        ///// <param name="_local">Local de Origem</param>
        ///// <param name="_observacao">Observação</param>
        //public ItemBase(string _palavra, string _tag, string _forma, string _literal, int _index, string _ingles, string _descricao, string _dialeto, string _local, string _observacao)
        //{
        //    IItemBase(_palavra, _tag, _forma, _literal, _index, _ingles, _descricao, _dialeto, _local, _observacao, "", "");
        //}
        //public ItemBase(string _palavra, string _tag, string _forma, string _literal, int _index, string _ingles, string _descricao, string _dialeto, string _local, string _observacao, string _classe)
        //{
        //    IItemBase(_palavra, _tag, _forma, _literal, _index, _ingles, _descricao, _dialeto, _local, _observacao, _classe, "");
        //}
        /// <summary>
        /// Cria uma instancia do objeto
        /// </summary>
        /// <param name="_palavra">Verbete</param>
        /// <param name="_tag">Tag de controle</param>
        /// <param name="_forma">Classe Gramatical</param>
        /// <param name="_literal">Literal</param>
        /// <param name="_index">Índice de Localização</param>
        /// <param name="_ingles">Expresão em inglês</param>
        /// <param name="_descricao">Descrição</param>
        /// <param name="_dialeto">Dialeto</param>
        /// <param name="_local">Local de Origem</param>
        /// <param name="_observacao">Observação</param>
        /// <param name="_classe">Classe de marcação</param>
        /// <param name="_referer">Referências</param>
        /// <param name="_figured">classe gramatical figurativa</param>
        public ItemBase(string _palavra, string _tag, string _forma, string _literal, int _index, string _ingles, string _descricao, string _dialeto, string _local, string _observacao, string _classe, string _referer, string _figured="0", string _grupo="0")
        {
            IItemBase(_palavra, _tag, _forma, _literal, _index, _ingles, _descricao, _dialeto, _local, _observacao, _classe, _referer, _figured, _grupo);
        }


        private void IItemBase(string _palavra, string _tag, string _forma, string _literal, int _index, string _ingles, string _descricao, string _dialeto, string _local, string _observacao, string _classe, string _referer,  string _figured , string _grupo)
        {
            Palavra = new WordReferenceData();
            Referencia = new RefReferenceData();
            Forma = new FormReferenceData();
            Local = new LocalReferenceData();
            Descricao = new RefReferenceData();
            Latino = new LatinReferenceData();

            this.Order = "0";
            this.Book = "";
            this.Letra = "";
            if (_palavra != "")
                this.Letra = _palavra.Substring(0, 1).ToUpper();
            this.Version = "1";
            this.Tag = "";
            this.Literal = _literal;
            this.Extended = "";
            this.Word = "";
            this.Image = "";
            this.Flexao = "";
            this.Marcador = "";
            this.Verbo = "";
            this.Ligacao = "";
            this.Observacao = _observacao;
            this.Observation = "";
            this.Grupo = _grupo;
            Palavra.Literal = "";
            Palavra.Text = _palavra.Trim().ToLower();

            Forma.Text = _forma.Trim().ToLower();
            Forma.Index = _index;
            Forma.Time = "";
            Forma.Figured = _figured;
            Descricao.Text = _descricao.Trim().ToLower();
            Descricao.English = _ingles;
            Dialeto = _dialeto;
            Local.Text = _local;
            Tag = _tag.ToLower();
            Classe = _classe;
            Referencia.Text = _referer;
        }

    }

    public class WordReferenceData
    {
        public string OrtoGraphy { get; set; } = "";
        public string Literal { get; set; } = "";
        public string LiteralEnglish { get; set; } = "";
        public string Text { get; set; } = "";
    }

    /// <summary>
    /// Descrição
    /// </summary>
    public class RefReferenceData
    {
        /// <summary>
        /// Tradução do Inglês
        /// </summary>
        public string English { get; set; } = "";
        /// <summary>
        /// Origem
        /// </summary>
        public string Src { get; set; } = "";
        public string Text { get; set; } = "";


        public string Entry { get; set; } = "";
    }
    public class FormReferenceData
    {
        /// <summary>
        /// Código da Ação de Impressão
        /// </summary>
        public string Action { get; set; } = "";
        /// <summary>
        /// Texto 
        /// </summary>
        public string Text { get; set; } = "";
        /// <summary>
        /// Tempo Gramatical
        /// </summary>
        public string Time { get; set; } = "";
        /// <summary>
        /// Indice de Pesquisa e Referência
        /// </summary>
        public int Index { get; set; } = 0;

        /// <summary>
        /// Classe Gramatical Figurativa
        /// </summary>
        public string Figured { get; set; } = "0";
    }
    public class LocalReferenceData
    {
        /// <summary>
        /// Descrição da Referência
        /// </summary>
        public string Reference { get; set; } = "";
        /// <summary>
        /// Texto
        /// </summary>
        public string Text { get; set; } = "";
        /// <summary>
        /// Inicializa o Membro Reference Data
        /// </summary>
        public LocalReferenceData()
        {
            this.Reference = "";
            this.Text = "";
        }
    }
    public class LatinReferenceData
    {
        public string Key { get; set; } = "0";
        /// <summary>
        /// ID de Referência do Item Pai
        /// </summary>
        public string ID { get; set; } = "";
        /// <summary>
        /// Nome Latim
        /// </summary>
        public string Cientifico { get; set; } = "";
        /// <summary>
        /// Familia em Latim
        /// </summary>
        public string Familia { get; set; }="";
    }


    public class ProcessDictionary
    {
        /// <summary>
        /// Instrução de Processamento Inicial do arquivo
        /// </summary>
        public string ProcessInstructionFile { get; set; }
        /// <summary>
        /// Indica se o processo ja foi iniciado
        /// </summary>
        public bool Started { get; set; }
        /// <summary>
        /// Arquivo Alvo de Processamwnto
        /// </summary>
        public string TargetFile { get; set; }

        /// <summary>
        /// Xml Document do Arquivo
        /// </summary>
        public XmlDocument Document { get; set; }

        /// <summary>
        /// Nó Raiz do documento
        /// </summary>
        public XmlNode Root { get; set; }

        /// <summary>
        /// Define se remove o arquivo
        /// </summary>
        public bool RemoveFile { get; internal set; } = false;

        /// <summary>
        /// Salva o documento
        /// </summary>
        public void Save()
        {
            if (this.TargetFile != "")
                Document.Save(this.TargetFile);
        }
        /// <summary>
        /// Inicia o processo de gravação
        /// </summary>
        /// <param name="pathfile">Nome do Arquivo destino de Atualização</param>
        public ProcessDictionary(string pathfile, bool removefile = true)
        {
            this.RemoveFile = removefile;
            this.TargetFile = pathfile;
            this.ProcessInstructionFile = "<?xml-stylesheet type=\"text/xsl\" href=\"exportd.xsl\"?>";
            this.Document = new XmlDocument();
            this.Started = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathfile">Nome do Arquivo de Saida</param>
        /// <param name="pifile">Instrução de Processamento</param>
        public ProcessDictionary(string pathfile, string pifile, bool removefile=true)
        {
            this.RemoveFile = removefile;
            this.TargetFile = pathfile;
            this.ProcessInstructionFile = "<?xml-stylesheet type=\"text/xsl\" href=\"" + pifile + "\"?>";
            this.Document = new XmlDocument();
            this.Started = false;
        }

        private void Start()
        {
            if (!this.Started)
            {
                if(this.RemoveFile)
                {
                    try
                    {
                        File.Decrypt(this.TargetFile);
                            }
                    catch { }
                }
                if (File.Exists(this.TargetFile))
                {
                    Document.Load(this.TargetFile);
                    Root = Document.SelectSingleNode("/documentos");
                    this.Started = true;
                }
                else
                {
                    string _cmdopen = this.ProcessInstructionFile + "<documentos/>";
                    Document.LoadXml(_cmdopen);
                    Root = Document.SelectSingleNode("/documentos");
                    this.Started = true;
                }
            }
        }

        public bool Insert(ItemBase word)
        {
            Start();
            if (this.Started)
            {
                XmlNode existe = Root.SelectSingleNode("/documentos/item[palavra='" + word.Palavra.Text + "']");
                if (existe == null)
                    return Add(word);
            }
            return false;
        }

        public bool AddSeeking(ItemBase word)
        {
            Start();
            if (this.Started)
            {
                try
                {
                    XmlNode existe = Root.SelectSingleNode("/documentos/item[palavra='" + word.Palavra.Text + "' and forma='" + word.Forma.Text + "' and descricao='" + word.Descricao.Text + "']");
                    if (existe == null)
                    {
                        return Add(word);
                    }
                }
                catch 
                {
                    
                }
            }
            return false;
        }

        public bool Add(ItemBase word)
        {
            //try
            //{
            Start();

            //if (!this.Started)
            //  return false;

            XmlElement item = Document.CreateElement("item");

            XmlAttribute attr = Document.CreateAttribute("book");
            attr.Value = word.Book;
            item.Attributes.Append(attr);

            attr = Document.CreateAttribute("letra");
            attr.Value = word.Letra;
            item.Attributes.Append(attr);

            attr = Document.CreateAttribute("version");
            attr.Value = word.Version;
            item.Attributes.Append(attr);

            attr = Document.CreateAttribute("tag");
            attr.Value = word.Tag;
            item.Attributes.Append(attr);

            attr = Document.CreateAttribute("literal");
            attr.Value = word.Literal;
            item.Attributes.Append(attr);

            attr = Document.CreateAttribute("extended");
            attr.Value = word.Extended;
            item.Attributes.Append(attr);

            attr = Document.CreateAttribute("word");
            attr.Value = word.Word;
            item.Attributes.Append(attr);

            attr = Document.CreateAttribute("image");
            attr.Value = word.Image;
            item.Attributes.Append(attr);

            XmlElement sentence = Document.CreateElement("palavra");
            sentence.InnerText = word.Palavra.Text;
            item.AppendChild(sentence);

            attr = Document.CreateAttribute("ortography");
            attr.Value = word.Palavra.OrtoGraphy;
            sentence.Attributes.Append(attr);

            //attr = Document.CreateAttribute("fonetica");
            //attr.Value = word.Fonetica;
            //sentence.Attributes.Append(attr);

            //attr = Document.CreateAttribute("pronuncia");
            //attr.Value = word.Pronuncia;
            //sentence.Attributes.Append(attr);

            attr = Document.CreateAttribute("literal");
            attr.Value = word.Palavra.Literal;
            sentence.Attributes.Append(attr);

            attr = Document.CreateAttribute("liteng");
            attr.Value = word.Palavra.LiteralEnglish;
            sentence.Attributes.Append(attr);

            sentence = Document.CreateElement("pronuncia");
            if (word.Marcador != "")
                sentence.InnerText = word.Pronuncia;
            item.AppendChild(sentence);

            sentence = Document.CreateElement("fonetica");
            if (word.Fonetica != "")
                sentence.InnerText = word.Fonetica;
            item.AppendChild(sentence);

            sentence = Document.CreateElement("referencia");
            attr = Document.CreateAttribute("english");
            attr.Value = word.Referencia.English;
            sentence.Attributes.Append(attr);
            if (word.Referencia.Text.Trim() != "")
                sentence.InnerText = word.Referencia.Text.Trim();
            item.AppendChild(sentence);

            sentence = Document.CreateElement("flexao");
            if (word.Flexao != "")
                sentence.InnerText = word.Flexao;
            item.AppendChild(sentence);

            sentence = Document.CreateElement("marcador");
            if (word.Marcador != "")
                sentence.InnerText = word.Marcador;
            item.AppendChild(sentence);

            sentence = Document.CreateElement("forma");
            attr = Document.CreateAttribute("grupo");
            attr.Value = word.Grupo.ToString();
            sentence.Attributes.Append(attr);

            attr = Document.CreateAttribute("dialeto");
            attr.Value = word.Dialeto.ToString();
            sentence.Attributes.Append(attr);

            attr = Document.CreateAttribute("order");
            attr.Value = word.Order.ToString();
            sentence.Attributes.Append(attr);

            attr = Document.CreateAttribute("classe");
            attr.Value = word.Classe.Trim();
            sentence.Attributes.Append(attr);

            attr = Document.CreateAttribute("index");
            attr.Value = word.Forma.Index.ToString();
            sentence.Attributes.Append(attr);
            attr = Document.CreateAttribute("action");
            attr.Value = word.Forma.Action;
            sentence.Attributes.Append(attr);
            attr = Document.CreateAttribute("time");
            attr.Value = word.Forma.Time;
            sentence.Attributes.Append(attr);
            attr = Document.CreateAttribute("figured");
            attr.Value = word.Forma.Figured;
            sentence.Attributes.Append(attr);

            if (word.Forma.Text != "")
                sentence.InnerText = word.Forma.Text;
            item.AppendChild(sentence);

            sentence = Document.CreateElement("local");
            attr = Document.CreateAttribute("ref");
            attr.Value = word.Local.Reference;
            sentence.Attributes.Append(attr);
            if (word.Local.Text != "")
                sentence.InnerText = word.Local.Text;
            item.AppendChild(sentence);


            sentence = Document.CreateElement("descricao");
            attr = Document.CreateAttribute("english");
            attr.Value = word.Descricao.English;
            sentence.Attributes.Append(attr);
            attr = Document.CreateAttribute("src");
            attr.Value = word.Descricao.Src;
            sentence.Attributes.Append(attr);
            sentence.InnerText = word.Descricao.Text;
            item.AppendChild(sentence);

            sentence = Document.CreateElement("verbo");
            if (word.Verbo != "")
                sentence.InnerText = word.Verbo;
            item.AppendChild(sentence);

            sentence = Document.CreateElement("ligacao");
            if (word.Ligacao != "")
                sentence.InnerText = word.Ligacao;
            item.AppendChild(sentence);

            sentence = Document.CreateElement("observacao");
            if (word.Observacao != "")
                sentence.InnerText = word.Observacao;
            item.AppendChild(sentence);

            sentence = Document.CreateElement("observation");
            if (word.Observation != "")
                sentence.InnerText = word.Observation;
            item.AppendChild(sentence);

            sentence = Document.CreateElement("cientifico");
            attr = Document.CreateAttribute("key");
            attr.Value = word.Latino.Key;
            sentence.Attributes.Append(attr);
            attr = Document.CreateAttribute("id");
            attr.Value = word.Latino.ID;
            sentence.Attributes.Append(attr);
            if (word.Latino.Cientifico != "")
                sentence.InnerText = word.Latino.Cientifico;
            item.AppendChild(sentence);

            sentence = Document.CreateElement("familia");
            if (word.Latino.Familia != "")
                sentence.InnerText = word.Latino.Familia;
            item.AppendChild(sentence);
            Root.AppendChild(item);
            return true;
        }
    }
}