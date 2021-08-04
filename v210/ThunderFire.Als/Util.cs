using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ThunderFire.Als
{

    public class Util
    {
        private string _palavra = "";
        private int _itemword = 1;


        /// <summary>
        /// Lingua Base de Entrada para avaliação
        /// </summary>
        public string SourceLanguage { get; set; }

        public Util() { }
        

        public string itemword(string t)
        {
            t = t.Trim();
            if (t.CompareTo(_palavra) == 0)
            {
                _itemword++;
            }
            else
            {
                _palavra = t;
                _itemword = 1;
            }
            return _itemword.ToString();
        }


        public static string replace(string _value, string _oldchar, string _newchar)
        {
            return _value.Replace(_oldchar, _newchar);
        }

        public static string firstchar(string _value)
        {
            try
            {
                _value = _value.Replace("?", "");
                _value = _value.Replace("-", "");
                _value = _value.Replace("'", "");
                _value = _value.Replace("*", "");
                _value = _value.Trim();

                return _value.Substring(0, 1).ToLower();
            }
            catch (Exception)
            {
                return "";
            }

        }
        public string Name(string texto)
        {
            int position = texto.IndexOf(' ');
            if (position > 0)
                return texto.Substring(0, position);
            return texto;
        }

        public string SurName(string texto)
        {
            int position = texto.IndexOf(' ');
            if (position > 0)
                return texto.Substring(position);
            return "";
        }

        public bool ContainText(string search, string dados)
        {
            return dados.ToLower().Contains(search.ToLower());
        }

        public string AlfaNumerico(string texto)
        {
            try
            {
                DateTime _date = DateTime.Now;
                if (DateTime.TryParse(texto, out _date))
                    return _date.ToString("yyyyMMddhhmmss");
            }
            catch
            {


            }
            return texto;
        }


        public bool CommentSize(string texto)
        {
            try
            {
                return (texto.Trim().Length > 100);
            }
            catch
            {
            }
            return false;
        }

        public bool contains(string fonte, string dados)
        {
            string[] words = dados.Split(',');
            string[] seek = fonte.Split(',');
            for (int j = 0; j < seek.Length; j++)
            {
                for (int p = 0; p < words.Length; p++)
                {
                    if (seek[j].Contains(words[p].ToString()))
                        return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Verifica se o parametro fonte contem qualquer item da string dados
        /// </summary>
        /// <param name="field">Campo a ser pesquisado</param>
        /// <param name="dados">string de dados a ser avaliada</param>
        /// <returns>True, se a string de dados nao tiver nenhum elemento</returns>
        public int containlist(string field, string dados)
        {
            int existe = 0;
            try
            {
                if (field.CompareTo("") != 0)
                {
                    string[] words = dados.Split(',');
                    for (int p = 0; p < words.Length; p++)
                    {
                        if (field.ToLower().Trim() == words[p].ToLower().Trim())
                        {
                            existe = 1;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                existe = 1;
            }
            return existe;
        }

        public bool Blocked(string tag, string forma)
        {
            bool retorno = true;
            tag = trim(tag);
            if ((tag == "corpo") || (tag == "folhas") || (tag == "divindades"))
                retorno = false;
            if (forma == "s.")
                retorno = false;
            return retorno;
        }
        
        private AL GetLanguage(string sourcelanguage)
        {
            return Factory.GetLanguage(sourcelanguage);
        }

        /// <summary>
        /// Retorna a string fonética do verbete
        /// </summary>
        /// <param name="text">Verbete</param>
        /// <param name="sourcelanguage">Base de Linguagem</param>
        /// <returns>string</returns>
        public string fonetica(string text, string sourcelanguage)
        {
            var objeto = GetLanguage(sourcelanguage);
            if(objeto!=null)
                return objeto.Fonetica(text);
            return "";
        }
        public string fonetica(string text, string sourcelanguage, string dialeto)
        {
            var objeto = GetLanguage(sourcelanguage);
            if (objeto != null)
                return objeto.Fonetica(text,dialeto);
            return "";
        }

        /// <summary>
        /// Retorna a string extendida do verbete
        /// </summary>
        /// <param name="text">Verbete</param>
        /// <param name="sourcelanguage">Base de Linguagem</param>
        /// <returns>string</returns>
        public string extended(string text, string sourcelanguage)
        {
            var objeto = GetLanguage(sourcelanguage);
            if (objeto != null)
                return objeto.Extended(text);
            return "";
        }
        
        public string substring(string t, int i, int f)
        {
            if (t != "")
                return t.Substring(i, f).ToUpper();
            return "";
        }
        /// <summary>
        /// Converte o texto para caixa alta
        /// </summary>
        /// <param name="_value">texto</param>
        /// <returns>string</returns>
        public string upper(string _value)
        {
            return _value.ToUpper().ToString();
        }
        /// <summary>
        /// Converte o texto para caixa baixa
        /// </summary>
        /// <param name="_value">texto</param>
        /// <returns>string</returns>
        public string lower(string text)
        {

            if (text != null)
            {
                if (this.SourceLanguage == ThunderFire.Als.Constants.YORUBA)
                {
                    //text = text.Replace("&#7744;", "ṁ");
                    //text = text.Replace("&#7742;", "ḿ");
                    //text = text.Replace("&#7864;", "ẹ");
                    ////text = text.Replace("&#7865;", "ẹ");
                    //text = text.Replace("&#7884;", "ọ");
                    //text = text.Replace("&#7864;", "&#7865;");
                    //text = text.Replace("&#7884;", "&#7885;");
                    //text = text.Replace("&#7778;", "&#7779;");
                    //text = text.Replace("&#323;", "ń");
                    ////text = text.Replace("&#324;", "ń");
                    //text = text.Replace("&#505;", "&#504;");
                    ////text = text.Replace("&#x300;", "̀");
                    ////text = text.Replace("&#x301;", "́");
                }

                else if (this.SourceLanguage == ThunderFire.Als.Constants.EWEGBE)
                {
                    text = text.Replace("&#x330;", "&#x331;");
                }
            }
            return text.ToLower();
        }


        /// <summary>
        /// Verifica se um determinado valor de Lista esta contido em Valor
        /// </summary>
        /// <param name="pvalue">Valor</param>
        /// <param name="plist">Lista</param>
        /// <returns>bool, true se contido</returns>
        public bool inlist(string pvalue, string plist)
        {
            string[] _list = plist.Split(',');
            string[] _value = pvalue.Split(',');
            for (int i = 0; i < _list.Length; i++)
            {
                for (int j = 0; j < _value.Length; j++)
                {
                    if (lower(_value[j]) == lower(_list[i]))
                        return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Retorna a string fonética do verbete
        /// </summary>
        /// <param name="text">Verbete</param>
        /// <param name="sourcelanguage">Base de Linguagem</param>
        /// <returns>string</returns>
        public string translate(string text, string sourcelanguage)
        {
            var objeto = GetLanguage(sourcelanguage);
            if (objeto != null)
                return objeto.Translate(text);
            return "";
        }
        public string translate(string text, string sourcelanguage, string dialeto="")
        {
            var objeto = GetLanguage(sourcelanguage);
            if (objeto != null)
                return objeto.Translate(text,dialeto);
            return "";
        }

        private string xTranslateChar(string s)
        {
            char[] r = s.ToCharArray();
            int len = r.Length;
            string rs = "";
            string t = "";
            for (int i = 0; i < len; i++)
            {
                if (r[i] == 596)
                {
                    if ((i + 1) < len)
                    {
                        if (r[i + 1] == 768) //`
                        {
                            t = "ŏ";
                        }
                        else if (r[i + 1] == 769) //´
                        {
                            if ((i + 2) < len)
                            {
                                if (r[i + 2] == 774)
                                    t = "òn";
                                else if (r[i + 2] == 771)
                                    t = "òn";
                                else
                                    t = "ò";
                            }
                            else
                            {
                                t = "ò";
                            }
                        }
                        else
                        {
                            t = "o";
                        }


                    }
                }
                else if (r[i] == 603)
                {
                    if ((i + 1) < len)
                    {
                        if (r[i + 1] == 768)
                        {
                            t = "e";
                        }
                        else if (r[i + 1] == 769)
                        {
                            t = "è";
                        }
                        else
                        {
                            t = "e";
                        }

                    }
                }
                else if (r[i] == 7869)
                {
                    if ((i + 1) < len)
                    {
                        if (r[i + 1] == 768)
                        {
                            t = "en";
                        }
                        else if (r[i + 1] == 769)
                        {
                            t = "én";
                        }
                        else
                        {
                            t = "en";
                        }

                    }
                }
                else if (r[i] == 331)
                {
                    if ((i + 1) < len)
                    {
                        if (r[i + 1] == 768)
                        {
                            t = "in";
                        }
                        else if (r[i + 1] == 769)
                        {
                            t = "ín";
                        }
                        else
                        {
                            t = "in";
                        }

                    }
                }

                else
                {
                    if ((r[i] == 768) || (r[i] == 769) || (r[i] == 774) || (r[i] == 771))
                    {
                        t = "";
                    }
                    else
                    {
                        t = r[i].ToString();
                    }
                }
                rs += t;
            }
            return rs;
        }

        public string Letter(string text, string sourcelanguage)
        {
            var objeto = GetLanguage(sourcelanguage);
            if (objeto != null)
                return objeto.Letter(text);
            return "";
        }

        /// <summary>
        /// Retorna a data atual
        /// </summary>
        /// <returns></returns>
        public string now()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }

        public string fieldvalue(string t)
        {
            t = t.Trim();
            if (t == "")
                return ".";
            return t;
        }


        /// <summary>
        /// Remove os espaços em branco
        /// </summary>
        /// <param name="t">texto</param>
        /// <returns>string</returns>
        public string trim(string t)
        {
            if ((!String.IsNullOrWhiteSpace(t)) || (!String.IsNullOrEmpty(t)))
                return t.Trim();
            return "";
        }

        public string substringbefore(string text, string find)
        {
            int pos = text.IndexOf(find);
            if (pos >= 0)
                return text.Substring(0, pos - 1);
            return text;
        }

        public string propername(string t)
        {
            return t.ProperName();
        }

        public string value(string t)
        {
            if ((!String.IsNullOrWhiteSpace(t)) || (!String.IsNullOrEmpty(t)))
                return int.Parse(t).ToString(); ;
            return "0";
        }

        /// <summary>
        /// Retorna true se a string é nula ou vazia
        /// </summary>
        /// <param name="_value"></param>
        /// <returns></returns>
        public bool empty(string _value)
        {
            if (String.IsNullOrEmpty(_value) || String.IsNullOrWhiteSpace(_value))
                return true;
            return false;
        }

        /// <summary>
        /// Remove os acentos da string fornecida
        /// </summary>
        /// <param name="text">texto</param>
        /// <returns>string</returns>
        public string removeacentos(string text)
        {
            return text.NoAccents().Trim();
        }

        public string roundhtmltag(string tag, string t)
        {
            return String.Format("<{0}>{1}</{0}>", tag, t);
        }

        public string fullword(string text, string sourcelanguage)
        {
            var objeto = GetLanguage(sourcelanguage);
            if (objeto != null)
                return objeto.FullWord(text);
            return "";
        }


        /// <summary>
        /// Substitui e Adiciona um texto
        /// </summary>
        /// <param name="text">Texto  a ser avaliado</param>
        /// <param name="replacetext">Texto a ser substituido e justaposot</param>
        /// <returns>string</returns>
        public static string replaceadd(string text, string replacetext)
        {
            text = text.Trim();
            text = text.Replace(replacetext, "");
            text += replacetext;
            return text;
        }

        ///// <summary>
        ///// Verifica se a imagem existe
        ///// </summary>
        ///// <param name="root">Diretório Base</param>
        ///// <param name="image">Nome da Imagem</param>
        ///// <returns>string</returns>
        //public string GetImage(string root, string image)
        //{
        //    string relativename = root + image;
        //    try
        //    {
        //        string fullname = HttpContext.Current.Server.MapPath(relativename);
        //        if (File.Exists(fullname))
        //            return relativename;
        //    }
        //    //catch (System.StackOverflowException Error)
        //    //{
        //    //    return "images/noimage.jpg";
        //    //}
        //    catch
        //    {
        //        return "images/noimage.jpg";
        //    }
        //    return "images/noimage.jpg";
        //}
    }
}