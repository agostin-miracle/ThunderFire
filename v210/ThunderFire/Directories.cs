using System;
using System.Collections.Generic;
using System.Text;

namespace ThunderFire
{
    /// <summary>
    /// Diretórios
    /// </summary>
    public class Directories
    {
        /// <summary>
        /// Captura de Erro
        /// </summary>
        public static TrapError TrappedError = new TrapError();

        /// <summary>
        /// Retorna true se ocorreu algum erro
        /// </summary>
        /// <returns>bool</returns>
        public static bool HasError()
        {
            if (String.IsNullOrEmpty(TrappedError.ErrorMessage))
                return false;
            return true;
        }

        /// <summary>
        /// Combina uma pasta de arquivos a um nome de arquivo
        /// </summary>
        /// <param name="dir">Nome do Diretorio ou pasta</param>
        /// <param name="file">Nome do Arquivo/Diretório</param>
        /// <returns>Fullpath</returns>
        public static string CombinePath(string dir, string file)
        {
            string r = "";
            if (dir.EndsWith("\\"))
                r = dir + file;
            else
                r = dir + "\\" + file;
            return r;
        }

        /// <summary>
        /// Verifica se o caminho passado se refere a um padrao UNC
        /// </summary>
        /// <param name="address">string do endereço ou caminho</param>
        /// <returns>true, se o endereço corresponde ao padrao UNC</returns>
        /// <remarks>
        /// UNC é uma convenção de nomenclatura usada principalmente para especificar e mapear unidades de rede em Microsoft Windows. Nomes UNC são mais comumente utilizados para atingir os servidores de arquivos ou impressoras em uma rede local.
        /// </remarks>
        public static bool isUNC(string address)
        {
            return address.Substring(0, 2).CompareTo("\\\\") == 0;
        }


        /// <summary>
        /// Desmembra uma string no formato de um full path e organiza de acordo com os 'niveis' de diretorio
        /// </summary>
        /// <param name="path">Full Path</param>
        /// <param name="level">Número de Diretórios a considerar na rota</param>
        /// <returns>string</returns>
        public static string GetRootPath(string path, int level)
        {
            string r = path;
            if (path != "")
            {
                var t = path.Split('\\');
                string s = "";
                for (int i = 0; i <= level; i++)
                {
                    if (i <= level)
                    {
                        s += t[i] + "\\";
                    }
                }
                r = s;
            }
            return r;
        }

        /// <summary>
        /// Remove o caracter de single backslash (\) para double backslash (\\)
        /// </summary>
        /// <param name="_s">string a ser analisada</param>
        /// <returns>string alterada</returns>
        public static string ChangeBackSlash(string _s)
        {
            string _fc = "";
            for (int i = 0; i < _s.Length; i++)
            {
                if (_s.Substring(i, 1).CompareTo(@"\") == 0)
                    _fc += @"\\";
                else
                    _fc += _s.Substring(i, 1);
            }
            return _fc;
        }



        /// <summary>
        /// Cria um diretório
        /// </summary>
        /// <param name="dirpath">Nome do Diretório</param>
        /// <returns>true, se o diretório existe</returns>
        public static bool CreateDirectory(string dirpath)
        {
            try
            {
                if (!System.IO.Directory.Exists(dirpath))
                {
                    System.IO.Directory.CreateDirectory(dirpath);
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
            return System.IO.Directory.Exists(dirpath);
        }

    }
}
