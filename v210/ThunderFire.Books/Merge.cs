using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace ThunderFire.Books
{
    public class Merge 
    {
        private int _mergecount = 0;

        public TrapError TrappedError = new TrapError();
        /// <summary>
        /// Número de Registros afetados
        /// </summary>
        public int MergeCount
        {
            get { return _mergecount; }
        }

        public void Do(string engpathfile, string targetfile)
        {
            XmlDocument source = new XmlDocument();
            XmlDocument target = new XmlDocument();
            string _tagtarget = "";
            string _destarget = "";
            string _frmtarget = "";
            string _indtarget = "";
            string _engword = "";
            string _frmeng = "";
            string _srcverb = "";
            byte _figured = 0;
            bool go = true;
            _mergecount = 0;

            try
            {
                if (File.Exists(engpathfile))
                {
                    if (File.Exists(targetfile))
                    {
                        source.Load(engpathfile);
                        target.Load(targetfile);

                        XmlNodeList nodes = target.SelectNodes("//documentos/item[descricao[@english=''] ]");

                        if (nodes != null)
                        {
                            for (int j = 0; j < nodes.Count; j++)
                            {
                                //string _sourceword= nodes[j].SelectSingleNode("palavra").InnerText.Trim().ToLower();
                                _tagtarget = nodes[j].SelectSingleNode("@tag").Value.ToString().Trim();
                                _figured = 0;
                                if (nodes[j].SelectSingleNode("forma/@figured") != null)
                                {
                                    string _tmp = "";
                                    if (!String.IsNullOrEmpty(nodes[j].SelectSingleNode("forma/@figured").InnerText))
                                        _tmp = nodes[j].SelectSingleNode("forma/@figured").InnerText.ToString().Trim();
                                    if (_tmp != "")
                                        _figured = byte.Parse(_tmp);
                                    else
                                        _figured = 0;
                                }


                                _frmtarget = "";
                                if (nodes[j].SelectSingleNode("forma") != null)
                                {
                                    if (!String.IsNullOrEmpty(nodes[j].SelectSingleNode("forma").InnerText))
                                        _frmtarget = nodes[j].SelectSingleNode("forma").InnerText.ToString().Trim();
                                }

                                _indtarget = "0";
                                if (nodes[j].SelectSingleNode("forma/@index") != null)
                                    _indtarget = nodes[j].SelectSingleNode("forma/@index").Value.ToString().Trim();

                                _destarget = nodes[j].SelectSingleNode("descricao").InnerText.Trim().Trim().ToLower();
                                //if (_destarget == "javali-afrioano" && _indtarget != "0")
                                //    j1 = 2;

                                if (_destarget != "")
                                {
                                    _destarget = _destarget.Replace("'", "´");
                                    XmlNodeList _eng = source.SelectNodes("//documentos/item[descricao='" + _destarget + "']");
                                    _engword = "";
                                    _frmeng = "";
                                    go = false;
                                    if (_eng != null)
                                    {
                                        for (int i = 0; i < _eng.Count; i++)
                                        {
                                            if (_eng[i].SelectSingleNode("forma/@index") != null)
                                            {
                                                if (_eng[i].SelectSingleNode("forma/@index").Value.ToString().Trim() == _indtarget)
                                                {
                                                    if (_eng[i].SelectSingleNode("@tag").Value.ToString().Trim().ToLower() == _tagtarget)
                                                    {
                                                        _engword = _eng[i].SelectSingleNode("palavra").InnerText.ToString().Trim();
                                                        _frmeng = "";
                                                        if (_eng[i].SelectSingleNode("forma") != null)
                                                            _frmeng = _eng[i].SelectSingleNode("forma").InnerText.ToString().Trim();
                                                        _srcverb = "";
                                                        if (_eng[i].SelectSingleNode("descricao/@src") != null)
                                                            _srcverb = _eng[i].SelectSingleNode("descricao/@src").Value.ToString().Trim().ToUpper();
                                                        go = true;
                                                        break;
                                                    }

                                                }

                                            }
                                        }

                                        if (go)
                                        {
                                            if (_engword != "")
                                            {
                                                if (_frmtarget == "")
                                                {
                                                    if (_figured == 1)
                                                        nodes[j].SelectSingleNode("forma").InnerText = "fig";
                                                    else if (_figured == 2)
                                                        nodes[j].SelectSingleNode("forma").InnerText = "pop";
                                                    else if (_figured == 3)
                                                        nodes[j].SelectSingleNode("forma").InnerText = "gir";
                                                    else if (_figured == 4)
                                                        nodes[j].SelectSingleNode("forma").InnerText = "pej";
                                                    else if (_figured == 5)
                                                        nodes[j].SelectSingleNode("forma").InnerText = "coloq";
                                                    else if (_figured == 6)
                                                        nodes[j].SelectSingleNode("forma").InnerText = "vi";
                                                    else if (_figured == 7)
                                                        nodes[j].SelectSingleNode("forma").InnerText = "adj";
                                                    else if (_figured == 8)
                                                        nodes[j].SelectSingleNode("forma").InnerText = "sm";

                                                    else
                                                        nodes[j].SelectSingleNode("forma").InnerText = _frmeng;
                                                    nodes[j].SelectSingleNode("descricao/@english").Value = _engword;
                                                    nodes[j].SelectSingleNode("descricao/@src").Value = _srcverb;
                                                    _mergecount++;
                                                }
                                                else if (_frmtarget != "")
                                                {
                                                    if (_frmtarget == _frmeng)
                                                    {
                                                        if (_figured == 1)
                                                            nodes[j].SelectSingleNode("forma").InnerText = "fig";

                                                        nodes[j].SelectSingleNode("descricao/@english").Value = _engword;
                                                        nodes[j].SelectSingleNode("descricao/@src").Value = _srcverb;
                                                        _mergecount++;
                                                    }
                                                }

                                            }
                                        }

                                    }

                                }
                            }
                        }
                        else
                        {
                            this.TrappedError.SetError("EMPTYDATA");
                            this.TrappedError.CurrentMethod = MethodBase.GetCurrentMethod().Name;
                            this.TrappedError.UserError = "Não existem dados para serem traduzidos !!!";
                        }
                    }
                    else
                    {
                        this.TrappedError = new TrapError();
                        this.TrappedError.CurrentMethod = MethodBase.GetCurrentMethod().Name;
                        this.TrappedError.UserError = String.Format("Arquivo Alvo {0} não existente !!!", targetfile);
                    }
                }
                else
                {
                    this.TrappedError.SetError("FILENOTFOUND");
                    this.TrappedError.CurrentMethod = MethodBase.GetCurrentMethod().Name;
                    this.TrappedError.UserError = String.Format("Arquivo Tradutor {0} não existente !!!", engpathfile);
                }
            }
            catch (Exception Error)
            {
                this.TrappedError.SetError(Error.Message, Error);
                this.TrappedError.CurrentMethod = MethodBase.GetCurrentMethod().Name;
            }
            finally
            {
                if (_mergecount > 0)
                    target.Save(targetfile);
                source = null;
                target = null;
            }
        }
    }
}