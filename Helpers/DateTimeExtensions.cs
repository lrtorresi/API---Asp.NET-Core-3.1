using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchollAPI.Helpers
{
    public static class DateTimeExtensions
    {
        public static int GetIdadeAtual(this DateTime dateTime)
        {
            var DataAtual = DateTime.UtcNow;
            int Idade = DataAtual.Year - dateTime.Year;

            if(DataAtual < dateTime.AddYears(Idade))
            {
                Idade--;
            }

            return Idade;
        }
    }
}
