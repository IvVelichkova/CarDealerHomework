using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        private const string format = "F2";
        public static string ToPrice (this decimal priceText)
        {
            return $"${priceText.ToString(format)}";
        }

        public static string ToPercentage (this double number)
        {
            return $"{number.ToString(format)}%";
        }
    }
}
