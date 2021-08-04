using System;
using System.Collections.Generic;
using System.Text;

namespace ThunderFire
{
    /// <summary>
    /// Mensagem de Erro
    /// </summary>
    public class ErrorMsg
    {
        /// <summary>
        /// Nome do Método
        /// </summary>
        public string Method { get; set; } = "";
        /// <summary>
        /// ID do Errro
        /// </summary>
        public int ErrorId { get; set; } = -1;
        /// <summary>
        /// Código do Erro
        /// </summary>
        public string ErrorCode { get; set; } = "";
        /// <summary>
        /// Severidade do Erro
        /// </summary>
        public string Severity { get; set; } = "";
        /// <summary>
        /// Mensagem
        /// </summary>
        public string Message { get; set; } = "";
        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; } = "";
        /// <summary>
        /// Origem do Erro
        /// </summary>
        public string Source { get; set; } = "";

        /// <summary>
        /// ID do Erro
        /// </summary>
        public int ID { get; set; } = -1;

        /// <summary>
        /// Construtor
        /// </summary>
        public ErrorMsg() { }


        /// <summary>
        /// Construtor de Mensagens
        /// </summary>
        /// <param name="errorid">ID do erro</param>
        /// <param name="errorcode">Código do Erro</param>
        /// <param name="severity">Severidade do Erro</param>
        /// <param name="message">Mensagem do erro</param>
        /// <param name="description">Descrição do Erro</param>
        /// 
        public ErrorMsg(int errorid, string errorcode, string severity, string message, string description) : this(errorid, errorcode, severity, message, description, "") { }

        /// <summary>
        /// Construtor de Mensagens
        /// </summary>
        /// <param name="errorid">ID do erro</param>
        /// <param name="errorcode">Código do Erro</param>
        /// <param name="severity">Severidade do Erro</param>
        /// <param name="message">Mensagem do erro</param>
        /// <param name="description">Descrição do Erro</param>
        /// <param name="source">Origem do Erro</param>
        public ErrorMsg(int errorid, string errorcode, string severity, string message, string description, string source)
        {
            this.ErrorId = errorid;
            this.ErrorCode = errorcode;
            this.Severity = severity;
            this.Message = message;
            this.Description = description;
            this.Source = source;
        }
    }
}
