using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderFire.Books
{
    /// <summary>
    /// BOOKS
    /// </summary>
    public enum BOOKS
    {
        /// <summary>
        /// Yoruba
        /// </summary>
        YORUBA = 1,
        /// <summary>
        /// Kimbundu
        /// </summary>
        KIMBUNDU,
        /// <summary>
        /// Kicongo
        /// </summary>
        KICONGO,
        /// <summary>
        /// Ewegbe
        /// </summary>
        EWEGBE,
        /// <summary>
        /// Logba
        /// </summary>
        LOGBA,
        /// <summary>
        /// Inglês
        /// </summary>
        INGLES,
        FRANCES
    }

    public enum DICTIONARY
    {
        YORUBA_PORTUGUES = 1,
        PORTUGUES_YORUBA,
        YORUBA_INGLES,
        INGLES_YORUBA,
        INGLES_KIMBUNDU,
        KIMBUNDU_PORTUGUES,
        KICONGO_PORTUGUES,
        EWEGBE_PORTUGUES,
        PORTUGUES_EWEGBE,
        LOGBA_PORTUGUES,
        PORTUGUES_LOGBA,
        PORTUGUES_KIMBUNDU,
        PORTUGUES_KICONGO,
        KIMBUNDU_INGLES,
        KICONGO_INGLES,
        INGLES_KICONGO
    }

    public enum ACTIVELANGUAGE
    {
        /// <summary>
        /// Descritor Nativa
        /// </summary>
        NATIVA = 0,
        /// <summary>
        /// Descritor de Portugues
        /// </summary>
        PORTUGUES = 1,
        /// <summary>
        /// Desctitor de Ingles
        /// </summary>
        INGLES = 2
    }
    /// <summary>
    /// Controlador de Arquivo de Saida
    /// </summary>
    public enum FILENAMEITEM
    {
        /// <summary>
        /// Descritor nao fornecido
        /// </summary>
        NONE = 0,
        /// <summary>
        /// Descritor do Arquivo de Folhas
        /// </summary>
        FOLHAS,
        /// <summary>
        /// Descritor do Arquivo de Verbetes de Corpo
        /// </summary>
        CORPO,
        /// <summary>
        /// Descritor do Arquivo de Verbetes de Familia
        /// </summary>
        FAMILIA,
        /// <summary>
        /// Descritor do Arquivo de Verbetes de Idolos
        /// </summary>
        IDOLOS,
        /// <summary>
        /// Descritor do Arquivo de Verbetes de Cores
        /// </summary>
        CORES,
        /// <summary>
        /// Descritor do Arquivo de Verbetes de Saudações
        /// </summary>
        SAUDACOES,
        /// <summary>
        /// Descritor do Arquivo de Verbetes de Profissoes
        /// </summary>
        PROFISSOES,
        /// <summary>
        /// Descritor do Arquivo de Verbetes de Animais
        /// </summary>
        ANIMAIS,
        /// <summary>
        /// Descritor do Arquivo de Verbetes de Bebidas
        /// </summary>
        BEBIDAS,
        /// <summary>
        /// Descritor do Arquivo de Verbetes de Interjeiçoes
        /// </summary>
        INTERJEICOES
    }
}