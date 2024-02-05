using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuyumcuAPI.Infrastructure.Cryptions
{
    public static class ApiKey
    {
        private const string chars = "$IJK%OP#FGH@!4S[TU5-tuC<DEv+no/*abc(de>fgh_ij}xy2VW{X36B]L7kl89m)pw0?;qrs:AMR=YZ^z1&NQ";
        public static string CreateApiKey()
        {
            Random random = new();
            string result = "";
            int num = 0;

            for (int i = 0; i < 100; i++)
            {
                num = random.Next(0, chars.Length);
                result += chars[num];
            }

            return result;
        }
    }
}
