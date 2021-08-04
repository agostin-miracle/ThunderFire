using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace ThunderFire
{
    /// <summary>
    /// Operações com Arquivos
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(true)]
    public class Files
    {
        /// <summary>
        /// Histórico de Execução
        /// </summary>
        public static StringBuilder Logging;
        /// <summary>
        /// Captura de Erros
        /// </summary>
        public static TrapError TrappedError = new TrapError();
        /// <summary>
        /// Le/Define a Versão do XML
        /// </summary>
        public static string XmlVersion { get; set; } = "1.0";
        /// <summary>
        /// Le/Define o encoding do XML a ser gerado
        /// </summary>
        public static string Encoding { get; set; } = "utf-8";
        /// <summary>
        /// Le/define o Root do arquivo 
        /// </summary>
        public static string RootName { get; set; } = "root";
        /// <summary>
        /// Le/Define o nome do registro
        /// </summary>
        public static string RecordName { get; set; } = "item";


        /// <summary>
        /// Grava uma linha no arquivo
        /// </summary>
        /// <param name="ptext">Texto a ser gravado</param>
        /// <param name="pfilename">Nome do Arquivo</param>
        public static void AppendText(string ptext, string pfilename)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(pfilename))
                {
                    sw.WriteLine(ptext);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception Error)
            {
                TrappedError.SetError(Error.Message, Error);
            }
        }
        /// <summary>
        /// Grava um string builder para um arquivo
        /// </summary>
        /// <param name="pfilename">Nome do Arquivo</param>
        /// <param name="ptext">StringBuilder a ser gravado</param>
        public void AppendText(string pfilename, StringBuilder ptext)
        {
            string[] _lines = ptext.ToString().Split('\n');
            for (int i = 0; i < _lines.Length; i++)
            {
                AppendText(_lines[i].ToString(), pfilename);
            }
        }
        /// <summary>
        /// Cria um arquivo texto
        /// </summary>
        /// <param name="pfilename">Nome do Arquivo</param>
        /// <param name="ptext">Texto do Arquivo</param>
        /// <param name="CheckIfExists">Checar se o arquivo existe, se existir remove</param>
        public static void CreateText(string pfilename, string ptext, bool CheckIfExists = false)
        {
            TrappedError.SetError();
            try
            {
                if (CheckIfExists)
                {
                    RemoveFile(pfilename);
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(pfilename))
                {
                    file.Write(ptext);
                    file.Flush();
                    file.Close();
                }
            }
            catch (Exception Error)
            {
                TrappedError.SetError(Error.Message, Error);
                TrappedError.UserError = String.Format("Falha na gravação do arquivo {0}.", pfilename);
            }
        }


        /// <summary>
        /// Copia um arquivo para o formato Base64
        /// </summary>
        /// <param name="psource">Arquivo de Source</param>
        /// <param name="ptarget">Arquivo de Destinos</param>
        public static void CopyFileFromBase64(string psource, string ptarget)
        {
            try
            {
                string t = System.IO.File.ReadAllText(psource);
                System.IO.File.WriteAllBytes(ptarget, Convert.FromBase64String(t));
            }
            catch (Exception Error)
            {
                TrappedError.SetError("", Error.Message, String.Format("Falha na copia do arquivo {0}.", psource), Error);
            }
        }

        /// <summary>
        /// Copia um arquivo para um arquivo no formato Base64
        /// </summary>
        /// <param name="source">Arquivo de origem</param>
        /// <param name="target">Arquivo de Destino</param>
        public static void CopyToFileBase64(string source, string target)
        {
            byte[] t = System.IO.File.ReadAllBytes(source);
            System.IO.File.WriteAllText(target, Convert.ToBase64String(t));
        }

        /// <summary>
        /// Remove um arquivo
        /// </summary>
        /// <param name="pfilename">Nome Completo do arquivo</param>
        public static void RemoveFile(string pfilename)
        {
            TrappedError.SetError();
            try
            {
                if (System.IO.File.Exists(pfilename))
                    System.IO.File.Delete(pfilename);
            }
            catch (Exception Error)
            {
                TrappedError.SetError("", Error.Message, String.Format("Falha na remoção do arquivo {0}.", pfilename), Error);
            }
        }

        /// <summary>
        /// Retorna o conteudo texto de um arquivo, se existir
        /// </summary>
        /// <param name="pfilename">Nome completo do arquivo</param>
        /// <returns>string, conteudo do arquivo</returns>
        public static string ReadFile(string pfilename)
        {
            TrappedError.SetError();
            try
            {
                if (File.Exists(pfilename))
                    return File.ReadAllText(pfilename);
            }
            catch (Exception Error)
            {
                TrappedError.SetError("", Error.Message, String.Format("Falha na leitura do arquivo {0}.", pfilename), Error);
            }
            return "";
        }
        /// <summary>
        /// Grava um Texto
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="result">Texto a ser gravado</param>
        /// <param name="file">Nome do Arquivo</param>
        public static void WriteAllText(string path, string result, string file)
        {
            if (result != "")
            {
                File.WriteAllText(Path.Combine(path, file), result);
            }
        }
        /// <summary>
        /// Grava um Texto
        /// </summary>
        /// <param name="file">Nome do Arquivo</param> 
        /// <param name="result">Texto a ser gravado</param>
        public static void WriteAllText(string file, string result)
        {
            if (result != "")
                File.WriteAllText(file, result);

        }

        /// <summary>
        /// Cria um arquivo XML
        /// </summary>
        /// <param name="ptext">Texto a ser gravado</param>
        /// <param name="pfilename">Nome completo do arquivo</param>
        public static void CreateXmlFile(string ptext, string pfilename)
        {
            TrappedError.SetError();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(ptext);
                if (File.Exists(pfilename))
                    File.Delete(pfilename);
                doc.Save(pfilename);
                doc = null;
            }
            catch (Exception Error)
            {
                TrappedError.SetError("", Error.Message, String.Format("Falha na gravação do arquivo {0}.", pfilename), Error);
            }
        }





        /// <summary>
        /// Retorna o número de linhas de um arquivo
        /// </summary>
        /// <param name="sourcefile">Nome do Arquivo</param>
        /// <returns>int</returns>
        public static int GetLines(string sourcefile)
        {
            bool go = true;
            int RETURN_VALUE = 0;
            StreamReader rd = null;
            if (go)
            {
                try
                {
                    rd = new StreamReader(sourcefile);
                }
                catch (FileNotFoundException Error)
                {
                    TrappedError.SetError("FILENOTFOUND");
                    TrappedError.ErrorMessage = Error.Message;
                    TrappedError.ErrorObject = Error;
                    go = false;
                }
            }
            if (go)
            {
                try
                {
                    string _line = "";
                    int _NUMLIN = 0;
                    while ((_line = rd.ReadLine()) != null)
                    {
                        _NUMLIN++;
                    }

                    rd.Close();
                    RETURN_VALUE = _NUMLIN--;

                }
                catch (Exception Error)
                {
                    TrappedError.ErrorCode = ErrorManager.GetErrorCode(Error);
                    if (TrappedError.ErrorCode != "")
                        TrappedError.SetError(TrappedError.ErrorCode);
                    TrappedError.ErrorMessage = Error.Message;
                    TrappedError.ErrorObject = Error;
                    RETURN_VALUE = 0;
                }
            }
            return RETURN_VALUE;
        }

        /// <summary>
        /// Define um nome de arquivo de saida
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="basefile">Nome Base do Arquivo</param>
        /// <param name="extension">Extensão, assume a extensao '.log' por padrão</param>
        /// <param name="applyserialization">define se deve serializar o nome com uma data, se não informado assume 'true'</param>
        /// <returns>string, contendo o nome do arquivo</returns>
        public static string SetLogFile(string path, string basefile, string extension = ".log", bool applyserialization = true)
        {
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            string file = "";
            if (applyserialization)
                file = Directories.CombinePath(path, basefile + "_" + DateTime.Now.ToString("ddMMyyyy") + extension);
            else
                file = Directories.CombinePath(path, basefile + extension);
            return file;
        }


        /// <summary>
        /// Remove um arquivo
        /// </summary>
        /// <param name="file">Nome do Arquivo</param>
        /// <returns>true, se o arquivo não mais existe</returns>
        public static bool DeleteFile(string file)
        {
            try
            {
                if (System.IO.File.Exists(file))
                {
                    System.IO.File.Delete(file);
                }
            }
            catch (Exception Error)
            {
                TrappedError.ErrorCode = ErrorManager.GetErrorCode(Error);
                if (TrappedError.ErrorCode != "")
                    TrappedError.SetError(TrappedError.ErrorCode);
                TrappedError.ErrorMessage = Error.Message;
                TrappedError.ErrorObject = Error;

                return false;
            }
            return !System.IO.File.Exists(file);
        }
    }
}
