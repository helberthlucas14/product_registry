﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductRegistry.Infrastructure.CrossCutting.Commons.Extensions
{
    public static class StringExtension
    {
        public static string RemoveNotNumbers(string value)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string ret = reg.Replace(value, string.Empty);
            return ret;
        }

        public static bool ValidateFederalRegistration(this string value)
        {
            var documentNumber = RemoveNotNumbers(value);

            if (documentNumber.Length > 11)
                return false;

            while (documentNumber.Length != 11)
                documentNumber = '0' + documentNumber;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (documentNumber[i] != documentNumber[0])
                    igual = false;

            if (igual || documentNumber == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(documentNumber[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }

        public static bool ValidateNationalRegisterLegalEntity(this string value)
        {
            var documentNumber = RemoveNotNumbers(value);
            int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            documentNumber = documentNumber.Trim();
            documentNumber = documentNumber.Replace(".", "").Replace("-", "").Replace("/", "");
            if (documentNumber.Length != 14)
                return false;
            tempCnpj = documentNumber.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return documentNumber.EndsWith(digito);
        }

        public static string DbStringFormat(this string value, string host, string user, string secret)
            => value.Replace("{Host}", host).Replace("{User}", user).Replace("{Secret}", secret);

        public static string ExtractDocumentType(this string value)
        {
            var arr = value.Split("-");
            return arr[^2];
        }
        public static string AddFilePath(this string value)
            => $"/api/v1/file/{value}";
    }
}
