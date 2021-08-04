using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ThunderFire.Books
{
    public class Splitter 
    {
        XmlTextWriter writer;
        private bool InitWriter = false;
        private string MarkLetter = "";
        private string MarkKeyWord = "";
        private bool LetterOpened = false;
        private bool KeyOpened = false;

        public TrapError TrappedError = new TrapError();
        /// <summary>
        /// Filtro de aplicação sobre a tag 'forma'
        /// </summary>
        public string TypeFilter { get; set; } = "";
        /// <summary>
        /// Modo de Atuação da Tag
        /// </summary>
        /// <remarks>
        /// <para> Default 'Select', seleciona os registros</para>
        /// <para> 'Exclude', Exclui os registros do resultado</para>
        /// </remarks>
        public string TagFilterMode { get; set; } = "Select";

        /// <summary>
        /// Define se devera ocorrer a impressão do tipo latim de modo extendido 
        /// </summary>
        public int LatinExpandDescription { get; set; }
        /// <summary>
        /// Arquivo de Origem
        /// </summary>
        public string SourceBaseFile { get; set; }
        /// <summary>
        /// Pasta Base de Gravação
        /// </summary>
        public string TargetPath { get; set; }
        /// <summary>
        /// Nome do Arquivo de Gravação
        /// </summary>
        public string TargetFile { get; set; } = "";

        /// <summary>
        /// Filtro baseado na tag de registro
        /// </summary>
        public string TagFilter { get; set; } = "";


        /// <summary>
        /// Local de Gravação
        /// </summary>
        public string WriteDataPath { get; set; }

        /// <summary>
        /// Style Sheet de Referência
        /// </summary>
        public string StyleSheetDisplay { get; set; } = "";

        //public string SourcePathResources { get; set; }
        public Splitter()
        {
            InitWriter = false;
            MarkLetter = "";
            MarkKeyWord = "";
            this.LetterOpened = false;
            this.KeyOpened = false;
            this.LatinExpandDescription = 0;
            //this.SourcePathResources = "";
            this.TypeFilter = "tag";
            this.StyleSheetDisplay = "grp_book1.xslt";
        }

        /// <summary>
        /// Cria o novo arquivo de Dicionário
        /// </summary>
        /// <param name="Saida">Tipo de Dicionario</param>
        public void Execute(DICTIONARY Saida)
        {
            string XslSourceFile = Resource1.orderbook.ToString();
            string field = "";
            switch (Saida)
            {
                case DICTIONARY.YORUBA_PORTUGUES:
                    field = "palavra";
                    XslSourceFile = Resource1.orderword.ToString();
                    break;

                case DICTIONARY.YORUBA_INGLES:
                    field = "palavra";
                    XslSourceFile = Resource1.orderword.ToString();
                    break;
                case DICTIONARY.KICONGO_INGLES:
                    field = "palavra";
                    XslSourceFile = Resource1.orderword.ToString();
                    break;

                case DICTIONARY.PORTUGUES_YORUBA:
                    field = "descricao";
                    XslSourceFile = Resource1.orderdescription.ToString();
                    break;
                case DICTIONARY.PORTUGUES_KIMBUNDU:
                    field = "descricao";
                    XslSourceFile = Resource1.orderdescription.ToString();
                    break;
                case DICTIONARY.PORTUGUES_KICONGO:
                    field = "descricao";
                    XslSourceFile = Resource1.orderdescription.ToString();
                    break;

                case DICTIONARY.INGLES_YORUBA:
                    field = "descricao/@english";
                    XslSourceFile = Resource1.orderenglish.ToString();
                    break;
                case DICTIONARY.INGLES_KIMBUNDU:
                    field = "descricao/@english";
                    XslSourceFile = Resource1.orderenglish.ToString();
                    break;
                case DICTIONARY.INGLES_KICONGO:
                    field = "descricao/@english";
                    XslSourceFile = Resource1.orderenglish.ToString();
                    break;

                case DICTIONARY.KIMBUNDU_PORTUGUES:
                    field = "palavra";
                    XslSourceFile = Resource1.orderword.ToString();
                    break;
                case DICTIONARY.KIMBUNDU_INGLES:
                    field = "palavra";
                    XslSourceFile = Resource1.orderword.ToString();
                    break;
                case DICTIONARY.KICONGO_PORTUGUES:
                    field = "palavra";
                    XslSourceFile = Resource1.orderword.ToString();
                    break;
                case DICTIONARY.EWEGBE_PORTUGUES:
                    field = "palavra";
                    XslSourceFile = Resource1.orderword.ToString();
                    break;
                case DICTIONARY.PORTUGUES_EWEGBE:
                    field = "descricao";
                    XslSourceFile = Resource1.orderdescription.ToString();
                    break;

                case DICTIONARY.LOGBA_PORTUGUES:
                    field = "palavra";
                    break;
                case DICTIONARY.PORTUGUES_LOGBA:
                    field = "descricao";
                    XslSourceFile = Resource1.orderdescription.ToString();
                    break;
            }
            string dmy = DateTime.Now.ToString("ddMMyyyyhhmmssffff");
            string TargetTempFile = ResourceBase.LogPath(dmy + "_"+ Path.GetFileName(TargetFile) + ".xml");
            string XlstTempFile = ResourceBase.LogPath(dmy + "_" + Path.GetFileName(TargetFile) + ".xslt");
            TrappedError.AddMessage(String.Format("TargetTempFile = {0}", TargetTempFile));
            TrappedError.AddMessage(String.Format("SourceBaseFile = {0}", this.SourceBaseFile));
            TrappedError.AddMessage(String.Format("XslSourceFile = {0}", XlstTempFile));
            MazeFire.IODocument document = ThunderFire.Books.Documents.GetDocumentFromString(this.SourceBaseFile, XslSourceFile, field);
            if (!ThunderFire.Books.Documents.TrappedError.HasError())
            {
                Files.CreateXmlFile(XslSourceFile,XlstTempFile);
                document.Save(TargetTempFile, DocumentAction.RemoveUTF16);
                if (File.Exists(TargetTempFile))
                {
                    if (Read(Saida, TargetTempFile))
                    {
                        Files.RemoveFile(TargetTempFile);
                        TrappedError.AddMessage(String.Format("Removido o Arquivo {0}", TargetTempFile));
                        Files.RemoveFile(XlstTempFile);
                        TrappedError.AddMessage(String.Format("Removido o Arquivo {0}", XlstTempFile));
                    }
                }
            }
            else
                TrappedError.AddMessage(MazeFire.Documents.TrappedError.ErrorMessage);
        }


        private bool Read(DICTIONARY Dict, string SourceFile)
        {
            bool RETURN_VALUE = false;
            ItemBase objeto;
            WriterInit(Dict);
            using (XmlReader reader = XmlReader.Create(SourceFile))
            {
                objeto = new ItemBase();
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:

                            if (reader.Name == "item")
                            {
                                objeto.Book = reader["book"].ToString();
                                objeto.Version = reader["version"].ToString();
                                objeto.Tag = reader["tag"].ToString();
                                objeto.Literal = reader["literal"].ToString();
                                objeto.Extended = reader["extended"].ToString();
                                objeto.Image = reader["image"].ToString();
                                objeto.Word = reader["word"].ToString();
                            }
                            if (reader.Name == "palavra")
                            {
                                objeto.Palavra.Literal = reader["literal"].ToString().Trim();
                                if (reader["liteng"] != null)
                                    objeto.Palavra.LiteralEnglish = reader["liteng"].ToString().Trim();
                                if (reader["ortography"] != null)
                                    objeto.Palavra.OrtoGraphy = reader["ortography"].ToString();
                                objeto.Palavra.Text = reader.ReadString().Trim();
                            }

                            if (reader.Name == "pronuncia")
                                objeto.Pronuncia = reader.ReadString().Trim();

                            if (reader.Name == "fonetica")
                                objeto.Fonetica = reader.ReadString().Trim();

                            if (reader.Name == "referencia")
                            {
                                objeto.Referencia.English = reader["english"].ToString();
                                objeto.Referencia.Text = reader.ReadString();
                            }

                            if (reader.Name == "local")
                            {
                                objeto.Local.Reference = reader["ref"].ToString();
                                objeto.Local.Text = reader.ReadString();
                            }

                            if (reader.Name == "forma")
                            {
                                if (reader["grupo"] != null)
                                    objeto.Grupo = reader["grupo"].Trim();
                                if (reader["action"] != null)
                                    objeto.Forma.Action = reader["action"].ToString().ToUpper();
                                if (reader["time"] != null)
                                    objeto.Forma.Time = reader["time"].ToString().ToLower();
                                if (reader["dialeto"] != null)
                                    objeto.Dialeto = reader["dialeto"].Trim();
                                if (reader["classe"] != null)
                                    objeto.Classe = reader["classe"].ToString().ToUpper();
                                if (reader["order"] != null)
                                    objeto.Order = reader["order"].ToString().ToLower();
                                objeto.Forma.Text = reader.ReadString().Trim();
                            }
                            if (reader.Name == "ligacao")
                            {
                                objeto.Ligacao = reader.ReadString().Trim();
                                if (objeto.Ligacao == ".")
                                    objeto.Ligacao = "";
                            }

                            if (reader.Name == "flexao")
                                objeto.Flexao = reader.ReadString();

                            if (reader.Name == "marcador")
                                objeto.Marcador = reader.ReadString();

                            if (reader.Name == "verbo")
                                objeto.Verbo = reader.ReadString();


                            if (reader.Name == "descricao")
                            {
                                objeto.Descricao.English = reader["english"].ToString();
                                objeto.Descricao.Src = reader["src"].ToString();
                                if(reader["verbete"]!=null)
                                objeto.Descricao.Entry = reader["verbete"].ToString();
                                objeto.Descricao.Text = reader.ReadString();
                            }
                            if (reader.Name == "observacao")
                                objeto.Observacao = reader.ReadString();
                            if (reader.Name == "observation")
                                objeto.Observation = reader.ReadString();

                            if (reader.Name == "cientifico")
                            {
                                if (reader["id"] != null)
                                    objeto.Latino.ID = reader["id"].ToString();
                                objeto.Latino.Cientifico = reader.ReadString();
                            }
                            if (reader.Name == "familia")
                                objeto.Latino.Familia = reader.ReadString();
                            break;

                        case XmlNodeType.EndElement:

                            if (reader.Name == "item")
                            {
                                if (TagFilter == "")
                                {
                                    Translate(Dict, objeto);
                                    objeto = new ItemBase();
                                }
                                if (TagFilter != "")
                                {
                                    if (TypeFilter == "tag")
                                    {
                                        if (this.TagFilterMode == "Select")
                                        {
                                            if (objeto.Tag == TagFilter)
                                            {
                                                Translate(Dict, objeto);
                                                objeto = new ItemBase();
                                            }
                                        }
                                        else
                                        {
                                            if (this.TagFilterMode == "Exclude")
                                            {
                                                if (!IN(objeto.Tag, TagFilter))
                                                {
                                                    Translate(Dict, objeto);
                                                    objeto = new ItemBase();
                                                }

                                            }
                                        }
                                    }
                                    if (TypeFilter == "book")
                                    {
                                        if (objeto.Book == "1")
                                        {
                                            Translate(Dict, objeto);
                                            objeto = new ItemBase();
                                        }
                                    }

                                    if (TypeFilter == "adjetivo")
                                    {
                                        if ((objeto.Book == "1") && (objeto.Forma.Text == "adj"))
                                        {
                                            Translate(Dict, objeto);
                                            objeto = new ItemBase();
                                        }

                                    }
                                    else if (TypeFilter == "forma")
                                    {
                                        if (objeto.Forma.Text.Contains(TagFilter))
                                        {
                                            Translate(Dict, objeto);
                                            objeto = new ItemBase();
                                        }
                                    }
                                    else if (TypeFilter == "dialeto")
                                    {
                                        if (objeto.Dialeto.ToUpper().Contains(TagFilter.ToUpper()))
                                        {
                                            Translate(Dict, objeto);
                                            objeto = new ItemBase();
                                        }
                                    }
                                    else
                                    {
                                        objeto = new ItemBase();
                                    }
                                }

                            }
                            break;
                    }
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
                RETURN_VALUE = true;
            }
            return RETURN_VALUE;
        }

        private ItemBase Translate(DICTIONARY Saida, ItemBase no)
        {
            Als.Util Utl = new Als.Util();
            string result1 = "";
            bool _toeng = false;
            string _word = "";
            string _description = "";
            bool _write = true;

            switch (Saida)
            {

                case DICTIONARY.YORUBA_PORTUGUES:
                    no.Letra = Utl.Letter(no.Palavra.Text, ResourceBase.YORUBA);
                    no.Key = no.Palavra.Text;
                    break;

                case DICTIONARY.YORUBA_INGLES:
                    no.Letra = Utl.Letter(no.Palavra.Text, ResourceBase.YORUBA);
                    no.Key = no.Palavra.Text;
                    no.Descricao.Text = no.Descricao.English;
                    _toeng = true;

                    if (no.Descricao.Text == "")
                        _write = false;
                    break;

                case DICTIONARY.KIMBUNDU_INGLES:
                    no.Letra = Utl.Letter(no.Palavra.Text, "KIMBUNDU");
                    no.Key = no.Palavra.Text;
                    no.Descricao.Text = no.Descricao.English;
                    _toeng = true;
                    if (no.Descricao.Text == "")
                        _write = false;
                    break;

                case DICTIONARY.KICONGO_INGLES:
                    no.Letra = Utl.Letter(no.Palavra.Text, "");
                    //no.Key = no.Extended;
                    no.Key = no.Palavra.Text;
                    no.Descricao.Text = no.Descricao.English;
                    _toeng = true;
                    if (no.Descricao.Text == "")
                        _write = false;

                    break;

                case DICTIONARY.PORTUGUES_YORUBA:
                    no.Key = no.Descricao.Text.Replace("'", "´").Trim();
                    if (no.Descricao.Entry.ToString()!="")
                    {
                        no.Key = no.Descricao.Entry.ToString().Trim();
                    }
                    no.Letra = no.Key.ToString().NoAccents().Trim().Substring(0, 1).ToUpper();
                    result1 = no.Palavra.Text.Trim();
                    no.Palavra.Text = no.Descricao.Text.Replace("'", "´").ToLower();
                    no.Descricao.Text = result1.Trim();

                    break;

                case DICTIONARY.PORTUGUES_EWEGBE:
                    no.Key = no.Descricao.Text.Replace("'", "´").Trim();
                    no.Letra = no.Key.ToString().NoAccents().Trim().Substring(0, 1).ToUpper();
                    result1 = no.Palavra.Text.Trim();
                    no.Palavra.Text = no.Descricao.Text.Replace("'", "´").ToLower();
                    no.Descricao.Text = result1;
                    break;

                case DICTIONARY.PORTUGUES_KIMBUNDU:
                    no.Key = no.Descricao.Text.Replace("'", "´").Trim();
                    no.Letra = no.Key.ToString().NoAccents().Trim().Substring(0, 1).ToUpper();
                    result1 = no.Palavra.Text.Trim();
                    no.Palavra.Text = no.Descricao.Text.Replace("'", "´").ToLower();
                    no.Descricao.Text = result1.Trim();
                    no.Word = "";
                    break;

                case DICTIONARY.PORTUGUES_KICONGO:
                    no.Key = no.Descricao.Text.Replace("'", "´").Trim();
                    no.Letra = no.Key.ToString().NoAccents().Trim().Substring(0, 1).ToUpper();
                    result1 = no.Palavra.Text.Trim();
                    no.Palavra.Text = no.Descricao.Text.Replace("'", "´").ToLower();
                    no.Descricao.Text = result1.Trim();
                    no.Word = "";
                    break;


                case DICTIONARY.INGLES_YORUBA:
                    _word = no.Palavra.Text.Trim();
                    _description = no.Descricao.English.Trim();
                    //no.Letra = Utl.Letter(_description, "");
                    no.Letra = _description.ToString().NoAccents().Trim().Substring(0, 1).ToUpper();
                    no.Key = _description.ToLower();
                    no.Palavra.Text = _description;
                    no.Descricao.Text = _word;
                    _toeng = true;
                    break;

                case DICTIONARY.INGLES_KIMBUNDU:
                    _word = no.Palavra.Text.Trim();
                    _description = no.Descricao.English.Trim();
                    no.Letra = _description.ToString().NoAccents().Trim().Substring(0, 1).ToUpper();
                    //no.Letra = Utl.Letter(_description, "");
                    no.Key = _description.ToLower();
                    no.Palavra.Text = _description;
                    no.Descricao.Text = _word;
                    _toeng = true;
                    break;

                case DICTIONARY.INGLES_KICONGO:
                    _word = no.Palavra.Text.Trim();
                    _description = no.Descricao.English.Trim();
                    no.Letra = _description.ToString().NoAccents().Trim().Substring(0, 1).ToUpper();
                    //no.Letra = Utl.Letter(_description, "");
                    no.Key = _description.ToLower();
                    no.Palavra.Text = _description;
                    no.Descricao.Text = _word;
                    _toeng = true;
                    break;


                case DICTIONARY.KIMBUNDU_PORTUGUES:
                    no.Letra = Utl.Letter(no.Palavra.Text, "KIMBUNDU");
                    //no.Letra = no.Palavra.Text.ToString().NoAccents().Trim().Substring(0, 1).ToUpper();
                    no.Key = no.Palavra.Text;
                    break;


                case DICTIONARY.KICONGO_PORTUGUES:
                    //no.Letra = Utl.Letter(no.Palavra.Text, "");
                    no.Letra = no.Palavra.Text.ToString().NoAccents().Trim().Substring(0, 1).ToUpper();
                    no.Key = no.Palavra.Text.Trim();
                    break;

                case DICTIONARY.EWEGBE_PORTUGUES:
                    //no.Letra = Utl.Letter(no.Palavra.Text, "");
                    no.Letra = no.Palavra.Text.ToString().NoAccents().Trim().Substring(0, 1).ToUpper();
                    no.Key = no.Palavra.Text;
                    break;

                case DICTIONARY.LOGBA_PORTUGUES:
                    //no.Letra = Utl.Letter(no.Palavra.Text, "");
                    no.Letra = no.Palavra.Text.ToString().NoAccents().Trim().Substring(0, 1).ToUpper();
                    no.Key = no.Extended;
                    break;
                case DICTIONARY.PORTUGUES_LOGBA:
                    //no.Letra = Utl.Letter(no.Descricao.Text.Replace("'", "´"), "");
                    no.Letra = no.Descricao.Text.ToString().NoAccents().Trim().Substring(0, 1).ToUpper();
                    no.Key = no.Descricao.Text.Replace("'", "´");
                    result1 = no.Palavra.Text;
                    no.Palavra.Text = no.Descricao.Text.Replace("'", "´");
                    no.Descricao.Text = result1;
                    break;

            }

            if (_write)
            {
                no.Key = no.Key.ToLower();
                if (MarkLetter != no.Letra)
                {
                    MarkLetter = no.Letra;
                    if (KeyOpened)
                    {
                        writer.WriteEndElement();
                        KeyOpened = false;
                    }

                    if (LetterOpened)
                        writer.WriteEndElement();

                    writer.WriteStartElement("letter");
                    writer.WriteAttributeString("value", no.Letra);
                    LetterOpened = true;
                }


                if (MarkKeyWord != no.Key)
                {
                    MarkKeyWord = no.Key;
                    if (KeyOpened)
                        writer.WriteEndElement();

                    writer.WriteStartElement("key");
                    writer.WriteAttributeString("palavra", no.Palavra.Text);
                    writer.WriteAttributeString("pronuncia", no.Pronuncia);
                    writer.WriteAttributeString("fonetica", no.Fonetica);
                    writer.WriteAttributeString("ortography", no.Palavra.OrtoGraphy);
                    KeyOpened = true;
                }

                writer.WriteStartElement("item");
                writer.WriteAttributeString("entry", no.Palavra.Text);
                writer.WriteAttributeString("grupo", no.Grupo);
                writer.WriteAttributeString("order", no.Order);
                //writer.WriteAttributeString("fonetica", no.Fonetica);
                writer.WriteAttributeString("ligacao", no.Ligacao.ToLower());
                writer.WriteAttributeString("extended", no.Extended.ToLower());

                //writer.WriteAttributeString("ortography", no.Palavra.OrtoGraphy);
                writer.WriteAttributeString("time", no.Forma.Time);
                writer.WriteAttributeString("word", no.Word);
                writer.WriteAttributeString("src", no.Descricao.Src);
                writer.WriteAttributeString("book", no.Book);
                writer.WriteAttributeString("forma", no.Forma.Text);
                writer.WriteAttributeString("dialeto", no.Dialeto.ToUpper());
                writer.WriteAttributeString("action", no.Forma.Action);
                writer.WriteAttributeString("tag", no.Tag);
                writer.WriteAttributeString("classe", no.Classe);
                string _literal = no.Palavra.Literal;
                if (_toeng)
                    _literal = no.Palavra.LiteralEnglish;

                writer.WriteAttributeString("literal", _literal);
                writer.WriteAttributeString("referencia", no.Referencia.Text);
                
                ////int x1 = 0;
                ////if (no.Palavra.Text == "venenu")
                ////    x1 = 1;
                writer.WriteStartElement("verbo");
                writer.WriteString(DefineVerbo(_toeng, no));
                writer.WriteEndElement();

                writer.WriteStartElement("flexao");
                if (no.Flexao != "")
                    writer.WriteCData(no.Flexao);
                writer.WriteEndElement();

                writer.WriteStartElement("genero");
                writer.WriteCData(DefineLatinData(_toeng, no));
                writer.WriteEndElement();
                writer.WriteStartElement("observacao");
                if (_toeng)
                    writer.WriteCData(no.Observation.ToString());
                else
                    writer.WriteCData(no.Observacao.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("descricao");
                result1 = no.Local.Reference.ToString().Trim();
                writer.WriteAttributeString("ref", result1);
                result1 = no.Local.Text.Trim();
                writer.WriteAttributeString("site", result1);
                writer.WriteCData(no.Descricao.Text.Trim());
                writer.WriteEndElement();
                writer.WriteEndElement();
                return no;
            }
            return null;
        }

        private string DefineVerbo(bool _toeng, ItemBase no)
        {
            string RETURN_VALUE = "";
            string _action = no.Forma.Action.Trim().ToUpper();
            string _verb = no.Verbo.Trim();
            _verb = _verb.Replace(".", "");

            if (!String.IsNullOrWhiteSpace(_verb))
            {
                if (_action == "@")
                    RETURN_VALUE = "deriva do verbo " + _verb;
                else if (_action == "R")
                    RETURN_VALUE = "refere-se a " + _verb;
                else if (_action == "P")
                    RETURN_VALUE = "Plural " + _verb;
                else if (_action == "S")
                    RETURN_VALUE = "Singular " + _verb;
                else if (_action == "C")
                    RETURN_VALUE = "CONTRAÇÃO DE " + _verb;
                else if (_action == "D")
                    RETURN_VALUE = "Diminuntivo de " + _verb;
                else if (_action == "A")
                    RETURN_VALUE = "Aumentativo de " + _verb;
                else if (_action == "AB")
                    RETURN_VALUE = "Abrev. de " + _verb;
                else if (_action == "V")
                    RETURN_VALUE = "do verbo " + _verb;
                else if (_action == "N")
                    RETURN_VALUE = "neg. de " + _verb;
                else if (_action == "VIDE")
                    RETURN_VALUE = "VIDE " + _verb;
                else if (_action == "SIN")
                    RETURN_VALUE = "sin. " + _verb;
                else if (_action == "SUB")
                    RETURN_VALUE = "subj. de " + _verb;
                else if (_action == "IMP")
                    RETURN_VALUE = "imper. de " + _verb;
                else if (_action == "RD")
                    RETURN_VALUE = "radical do verbo " + _verb;
                else if (_action == "PRET")
                    RETURN_VALUE = "pret. de " + _verb;
                else if (_action == "PRETI")
                    RETURN_VALUE = "pret. I de " + _verb;
                else if (_action == "PRETII")
                    RETURN_VALUE = "pret. II de " + _verb;
                else if (_action == "FUT")
                    RETURN_VALUE = "fut. de " + _verb;
                else if (_action == "OMQ")
                    RETURN_VALUE = "o mesmo que " + _verb;
            }
            else
            {
                if (_action == "DP")
                {
                    if (!_toeng)
                    {
                        RETURN_VALUE = "Deriva do Português";
                    }
                    else
                    {
                        RETURN_VALUE = "derives from portuguese";
                    }
                }
            }
            return RETURN_VALUE;
        }

        private string DefineLatinData(bool _toeng, ItemBase no)
        {
            bool continua = true;
            string retorno = "";
            string _id = no.Latino.ID.Trim();
            string _ctf = no.Latino.Cientifico.Trim();
            string _fam = no.Latino.Familia.Trim();
            _fam = "";

            if ((_ctf == "") || (_ctf == "."))
                continua = false;

            if (continua)
            {
                if (_fam != "")
                {
                    if (_id != "")
                        retorno = "(" + _id + ", " + _fam + ")";
                    else
                        retorno = "(" + _ctf + ", " + _fam + ")";
                }
                else
                    retorno = "(" + _ctf + ")";
            }
            return retorno;
        }

        private void WriterInit(DICTIONARY Saida)
        {
            InitWriter = false;
            MarkLetter = "";
            MarkKeyWord = "";
            LetterOpened = false;
            KeyOpened = false;

            if (this.WriteDataPath != "")
            {
                if (!InitWriter)
                {
                    if (File.Exists(this.WriteDataPath))
                        File.Delete(this.WriteDataPath);
                    writer = new XmlTextWriter(this.WriteDataPath, null);
                    writer.Formatting = Formatting.Indented;
                    InitWriter = true;
                    writer.WriteStartDocument();
                    writer.WriteProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href='" + this.StyleSheetDisplay + "'");
                    writer.WriteStartElement("root");
                }
            }
        }

        /// <summary>
        /// Verifica se o parametro fonte contem qualquer item da string dados
        /// </summary>
        /// <param name="field">Campo a ser pesquisado</param>
        /// <param name="dados">string de dados a ser avaliada</param>
        /// <returns>True, se a string de dados nao tiver nenhum elemento</returns>
        private bool IN(string field, string dados)
        {
            bool existe = false;
            try
            {
                if (field.CompareTo("") != 0)
                {
                    string[] words = dados.Split(',');
                    for (int p = 0; p < words.Length; p++)
                    {
                        if (field.ToLower().Trim() == words[p].ToLower().Trim())
                        {
                            existe = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                existe = false;
            }
            return existe;
        }
    }
}