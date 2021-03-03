using System;

namespace CustomerApp.Utils
{
    public static class CPF
    {
        public static bool IsValid(string cpf)
        {
            cpf = OnlyNumber(cpf);

            if (cpf.Length != 11)
                return false;

            
            bool match = true;
            for (int i = 1; i < 11 && match; i++)
                if (cpf[i] != cpf[0])
                    match = false;
            if (match)
                return false;

            int sum = 0;
            int rest;


            for (int i = 0; i < 9; i++)
                sum += (10 - i) * int.Parse(cpf[i].ToString());

            rest = 11 - (sum % 11);

            if (rest == 10 || rest == 11)
                rest = 0;

            if (rest != int.Parse(cpf[9].ToString()))
                return false;

            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += (11 - i) * int.Parse(cpf[i].ToString());

            rest = 11 - (sum % 11);

            if (rest == 10 || rest == 11)
                rest = 0;

            if (rest != int.Parse(cpf[10].ToString()))
                return false;

            return true;
        } 

        public static string OnlyNumber(string cpf)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string result = regex.Replace(cpf, string.Empty);
            return result;
        }

        public static string Formated(string cpf)
        {
            return Convert.ToInt64(cpf).ToString(@"000\.000\.000\-00");
        }    
    }
}