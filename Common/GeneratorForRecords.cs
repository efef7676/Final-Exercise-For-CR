using Fare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class GeneratorForRecords
    {
        private static Random _random = new Random();

        public GeneratorForRecords()
        { }

        // TODO: are you sure this generates a valid credit card?
        public string GenerateValidCreditCard()
        {
            var builder = new StringBuilder();
            while (builder.Length < 16)
            {
                builder.Append(_random.Next(9).ToString());
            }

            return builder.ToString();
        }

        // TODO: refer to RecivedRecord. 
        public double GenerateDoublePrice(bool isOneInstallment)
        {
            if (isOneInstallment)
            {
                return _random.NextDouble() + _random.Next(5000);
            }

            return _random.NextDouble() + _random.Next(int.MaxValue/40);
        }

        // TODO: refer to RecivedRecord. 
        public int GenerateIntegerPrice(bool isOneInstallment)
        {
            if (isOneInstallment)
            {
                return _random.Next(5000);
            }

            return _random.Next(int.MaxValue / 40);
        }

        public string GenerateValidStoreId()
        {
            //5 Points! Totachit!
            // TODO: (But maybe just move it to config)
            Xeger xeger = new Xeger(@"^[A-F][A-D]\d{5}", _random);

            return xeger.Generate();
        }

        // TODO: refer to RecivedRecord. 
        public DateTime GenerateValidDate(char activityDays = ' ')
        {
            var start = new DateTime(2000, 1, 1);
            var range = (DateTime.Today - start).Days;
            var date = start.AddDays(_random.Next(range));

            if (activityDays == 'B')
            {
                while ((int)date.DayOfWeek == 6)
                {
                    date = start.AddDays(_random.Next(range));
                }
            }
            else if (activityDays == 'C')
            {
                while ((int)date.DayOfWeek == 6 || (int)date.DayOfWeek == 5)
                {
                    date = start.AddDays(_random.Next(range));
                }
            }

            return date;
        }

        // TODO: why dynamic?
        // TODO: refer to RecivedRecord. 
        public dynamic GenerateInstallmentsByPrice(bool isOneInstallment, double price)
        {
            // TODO: why not string array?
            var oneInstallmentOptions = new dynamic[] { "FULL", 1, null};
            if (isOneInstallment)
            {
                return oneInstallmentOptions[_random.Next(oneInstallmentOptions.Length)];
            }
            else
            {
                return _random.Next(2, ((int)price) * 10);
            }
        }
    }
}
