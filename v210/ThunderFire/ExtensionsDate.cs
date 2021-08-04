using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ThunderFire
{
    /// <summary>
    /// Extensions (DateTime)
    /// </summary>
    public static class ExtensionsDate
    {
        /// <summary>
        /// Retorna a data por extenso variando da cultura pt-BR
        /// </summary>
        /// <param name="current">Date</param>
        /// <returns>Data no formato [Dia da Semana + Dia do mes + ' de ' +  mes + ' de' + ano]</returns>
        public static string DataExtenso(this DateTime current)
        {
            var r = ActionOnDate(current, "pt-BR");
            return String.Format("{0} de {1} de {2}", r.Day, r.Months, r.Year);

        }
        /// <summary>
        /// Retorna a data por extenso
        /// </summary>
        /// <param name="current">Date</param>
        /// <param name="cultureinfo">CultureInfo</param>
        /// <returns>Data no formato [Dia da Semana + Dia do mes + ' de ' +  mes + ' de' + ano]</returns>
        public static string DataExtenso(this DateTime current, string cultureinfo)
        {
            var r = ActionOnDate(current, cultureinfo);
            return String.Format("{0} de {1} de {2}", r.Day, r.Months, r.Year);
        }

        /// <summary>
        /// Dia da Semama (pt-BR)
        /// </summary>
        /// <param name="current">DateTime</param>
        /// <returns>string</returns>
        public static string DayOfWeekString(this DateTime current)
        {
            return ActionOnDate(current, "pt-BR").DayOfWeeks;
        }
        /// <summary>
        /// Dia da Semama
        /// </summary>
        /// <param name="current">Data</param>
        /// <param name="cultureinfo">Culture Info</param>
        /// <returns>String</returns>
        public static string DayOfWeekString(this DateTime current, string cultureinfo)
        {
            return ActionOnDate(current, cultureinfo).DayOfWeeks;
        }

        /// <summary>
        /// Mês por extenso (pt-BR)
        /// </summary>
        /// <param name="current">Data corrente</param>
        /// <returns>string</returns>
        public static string MonthString(this DateTime current)
        {
            return ActionOnDate(current, "pt-BR").Months;
        }
        /// <summary>
        /// Mês por extenso
        /// </summary>
        /// <param name="current">Data corrente</param>
        /// <param name="cultureinfo">Culture</param>
        /// <returns>string</returns>
        public static string MonthString(this DateTime current, string cultureinfo)
        {
            return ActionOnDate(current, cultureinfo).Months;
        }

        internal static DateInfo ActionOnDate(DateTime current, string cultureinfo)
        {
            CultureInfo culture = new CultureInfo(cultureinfo);
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            DateInfo refDate = new DateInfo();
            refDate.Culture = culture.Name;
            refDate.Day = current.Day;
            refDate.Month = current.Month;
            refDate.Year = current.Year;
            refDate.Months = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(current.Month));
            refDate.DayOfWeek = (byte)current.DayOfWeek;
            refDate.DayOfWeeks = culture.TextInfo.ToTitleCase(dtfi.GetDayName(current.DayOfWeek));
            return refDate;
        }
    }
}
