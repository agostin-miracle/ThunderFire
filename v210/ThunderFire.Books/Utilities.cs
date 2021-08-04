using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ThunderFire.Books
{
    /// <summary>
    /// Utilitários de Atualização
    /// </summary>
    public class Utilities 
    {
        /// <summary>
        /// Captura de Erro
        /// </summary>
        public static TrapError TrappedError = new TrapError();

        /// <summary>
        /// Limpa as definições de forma e descrição em inglês 
        /// </summary>
        /// <param name="file">Arquivo Alvo</param>
        /// <param name="tag">Tag de Maracação</param>
        public static void ClearTagValues(string file, string tag)
        {
            TrappedError.SetError();
            XmlDocument _doc = new XmlDocument();
            try
            {
                _doc.Load(file);
                XmlNodeList _item = _doc.SelectNodes("//documentos/item[@tag='" + tag + "']");
                for (int i = 0; i < _item.Count; i++)
                {
                    _item[i].SelectSingleNode("forma").InnerText = "";
                    _item[i].SelectSingleNode("descricao/@english").Value = "";
                }
                _doc.Save(file);
            }
            catch (Exception Error)
            {
                TrappedError.SetError(Error);
            }
        }

        /// <summary>
        /// Efetua a limpeza dos parametros de forma e english da  descrição de um verbete
        /// </summary>
        /// <param name="file">Nome do Arquivo</param>
        /// <param name="description">Descrição</param>
        public static void ClearDescriptionValues(string file, string description)
        {
            TrappedError.SetError();
            XmlDocument _doc = new XmlDocument();
            try
            {
                _doc.Load(file);
                XmlNodeList _item = _doc.SelectNodes("//documentos/item[descricao='" + description + "']");
                for (int i = 0; i < _item.Count; i++)
                {
                    _item[i].SelectSingleNode("forma").InnerText = "";
                    _item[i].SelectSingleNode("descricao/@english").Value = "";
                }
                _doc.Save(file);
            }
            catch (Exception Error)
            {
                TrappedError.SetError(Error);
            }
            finally
            {
                _doc = null;
            }
        }


        //public static void ChangeLetter(string file)
        //{
        //    TrappedError.SetError();
        //    XmlDocument _doc = new XmlDocument();
        //    Util obj = new Util();
        //    try
        //    {
        //        _doc.Load(file);
        //        XmlNodeList _item = _doc.SelectNodes("//documentos/item");
        //        for (int i = 0; i < _item.Count; i++)
        //        {
        //            string _palavra = _item[i].SelectSingleNode("palavra").InnerText.Trim();
        //            string _dialeto = _item[i].SelectSingleNode("forma/@dialeto").Value.Trim();
        //            _item[i].SelectSingleNode("@letra").Value = obj.Letter(_palavra, "");
        //            if (_dialeto == "")
        //                _item[i].SelectSingleNode("forma/@dialeto").Value = "Fon";
        //        }
        //        _doc.Save(file);
        //    }
        //    catch (Exception Error)
        //    {
        //        TrappedError.SetError(Error);
        //    }
        //    finally
        //    {
        //        _doc = null;
        //    }
        //}
    }
}