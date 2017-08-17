using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorKata
{

   
    public class Calculator
    {

        static void Main(string[] args)
        {
        }
        public string[] GetDelimiters(string text)
        {
            var delimiters = new List<string> { ",", "\n" };

            if (text.StartsWith("//"))
            {
                string[] customSeperators = { "[", "]" };
                var customSeperator = text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).First();

                text = text.Substring(customSeperator.Length, text.Length - customSeperator.Length);
                var allCustomSeperators = customSeperator.Split(customSeperators, StringSplitOptions.RemoveEmptyEntries);
              
                foreach (var sep in allCustomSeperators)
                {
                    delimiters.Add(sep);
                }

                delimiters.Add(text.Substring(2, 1));
            }
            return delimiters.ToArray();
        }

        public int Add(string numbers)
        {
            var numberArray = numbers.Split(GetDelimiters(numbers), StringSplitOptions.None);
            string negativeNumbers = "";
            
            int totalsum = 0;
            foreach (string number in numberArray)
            {
                int.TryParse(number, out int result);
                if (result < 0) negativeNumbers += number + " ";
                
                if (result <1000) totalsum += result;
            }
            if (negativeNumbers.Length <= 0) return totalsum;

            Console.WriteLine(negativeNumbers);
            throw new Exception($"negatives not allowed! you entered: {negativeNumbers}");
        }
    }
}
