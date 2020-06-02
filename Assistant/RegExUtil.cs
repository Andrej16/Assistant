using System;
using System.Text.RegularExpressions;

namespace Assistant
{
    /// <summary>
    /// Структура. Содержит функции проверки корректности вводимых пользователем данных.
    /// </summary>
    public struct RegExUtil
    {
        /// <summary>
        /// Выполняет проверку строки содержащей мобильные телефонные номера.
        /// </summary>
        /// <remarks>
        /// Выполняет проверку строки содержащей мобильные телефонные номера по критериям:
        /// телефонный номер должен содержать 10 цифр, телефонный номер должен начинаться с ноля 0kkXXXXXXX.
        /// </remarks>
        /// <param name="numStr">Строка представляющая телефонный номер.</param>
        /// <returns>true - если телефонный номер соответствует шаблону, иначе false.</returns>
        public static bool TelNumValidate(string numStr)
        {
            Regex tReg = new Regex(@"^0\d{9}$");
            char[] separators = { ' ', ',', '\n', '\r' };

            string[] telephones = numStr.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string t in telephones)
            {
                if (!tReg.IsMatch(t))
                    return false;   //Телефонный номер введен не верно
            }
            return true;
        }
        /// <summary>
        /// Выполняет проверку корректности вин кода транспортного средства.
        /// </summary>
        /// <remarks>Вин код должен содержать от 7-17 символов(лат. верхнего регистра)/цифр.</remarks>
        /// <param name="vin">Строка представляющая вин код.</param>
        /// <returns>true - если вин код соответствует шаблону, иначе false.</returns>
        public static bool VinValidate(string vin)
        {
            Regex tReg = new Regex("^[A-Z0-9]{7,17}$");

            return tReg.IsMatch(vin);
        }
        /// <summary>
        /// Выполняет проверку корректности ИНН, в зависимости от типа клиета.
        /// </summary>
        /// <remarks>ИНН должен содержать только цифры, длина 12 символов для типа клиента юр. лицо,
        /// и 10 символов для физ. лицо.</remarks>
        /// <param name="inn">Идентификационный номер.</param>
        /// <param name="typeClient">Тип клиента 1 - Юр. лицо, 2 - Физ. лицо.</param>
        /// <returns>true - если ИНН соответствует шаблону, иначе false.</returns>
        public static bool IdentnumValidate(string inn, int typeClient)
        {
            Regex innReg;

            switch(typeClient)
            {
                case 1:     //Юр. лицо
                    innReg = new Regex(@"^\d{12}$");
                    break;
                case 2:     //Физ. лицо
                    innReg = new Regex(@"^\d{10}$");
                    break;
                default:
                    innReg = null;
                    break;
            }

            return innReg.IsMatch(inn);
        }
        /// <summary>
        /// Выполняет проверку корректности кода ЕДРПОУ.
        /// </summary>
        /// <remarks>Длина ЕДРПОУ должна равняться 8 (10) символам.
        /// ЕДРПОУ должно содержать только цифры.</remarks>
        /// <param name="edrp">Код ЕДРПОУ.</param>
        /// <returns>true - в случае успешной проверки, иначе false.</returns>
        public static bool EdrpouValidate(string edrp)
        {
            Regex eReg = new Regex(@"^\d{8,10}$");

            return eReg.IsMatch(edrp);
        }
        /// <summary>
        /// Проверка номера мобильного, для шаблона "380*********", где * - цифры, вхождение каждой из которых 
        /// не допускается во всех местах *.
        /// </summary>
        /// <remarks>Выполняется двух этапная проверка:
        /// - ^380\d{9}$, все символы - цыфры, первые 380, затем остальные 9 представляющие сам номер;
        /// - (\d)\1{8}$, соответствует строке в которой последние 9 символов("(\d)" - также считается как одиночный символ,
        ///     \1{8} - следующие 8 символов) - цифры являющиеся одинаковыми, что неразрешено!</remarks>
        /// <param name="phone">Строка представляющая номер мобильного телефона.</param>
        /// <returns>true - в случае успешной проверки, иначе false.</returns>
        public static bool PrimaryPhoneValidate(string phone)
        {
            //Первый этап проверки
            Regex pReg;
            bool result;

            //Первый этап проверки
            pReg = new Regex(@"^380\d{9}$");
            result = pReg.IsMatch(phone);
            //Второй этап проверки
            pReg = new Regex(@"(\d)\1{8}$");
            result = result && !pReg.IsMatch(phone);

            return result;
        }
        /// <summary>
        /// Проверка корректности адреса электронной почты.
        /// </summary>
        /// <param name="email">Строка представляющая E-mail</param>
        /// <returns>true - в случае успешной проверки, иначе false.</returns>
        public static bool EmailValidate(string email)
        {
            Regex reg = new Regex(@"^[a-z.]+@[a-z]+\.[a-z]+$");

            return reg.IsMatch(email);
        }
        /// <summary>
        /// Checking strings for email format compliance
        /// </summary>
        /// <param name="strIn">The string representing E-mail</param>
        /// <returns></returns>
        public static bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        /// <summary>
        /// Remove special characters
        /// </summary>
        /// <param name="str">Source string,the string to search for a match.</param>
        /// <returns>A new string that is identical to the input string, 
        /// except that the replacement string takes the place of each matched string. 
        /// If pattern is not matched in the current instance, 
        /// the method returns the current instance unchanged.
        /// </returns>
        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, @"[^a-zA-ZА-Яа-я0-9\.]+", "", RegexOptions.Compiled);
        }
        /// <summary>
        /// Значение может содержать одно или два слова, начинающихся с заглавной буквы 
        /// </summary>
        public static bool CheckNameMembNatMinority(string source)
        {
            string pattern = @"^([А-ЯІЇЄ][а-яіїє']*)((\s[А-ЯІЇЄ][а-яіїє']*)$|$)";
            if (string.IsNullOrEmpty(source))
                return false;

            return Regex.IsMatch(source.Trim(), pattern);
        }
        /// <summary>
        /// Значение 3 слова, начинающихся с заглавной буквы 
        /// </summary>
        public static bool CheckFullName(string source)
        {
            string pattern = @"^([А-ЯІЇЄ][а-яіїє']*)\s([А-ЯІЇЄ][а-яіїє']*)\s([А-ЯІЇЄ][а-яіїє']*)$";
            if (string.IsNullOrEmpty(source))
                return false;

            return Regex.IsMatch(source.Trim(), pattern);
        }
    }
}
