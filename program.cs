using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            StreamWriter writer = File.CreateText("results.txt");
            
            for(int i=1000; i<9999; i++)
            {
                writer.WriteLine(program.RecursiveMain(i));
            }
            Console.WriteLine("Done");
            Console.Read();
        }

        public int RecursiveMain(int number)
        {
            int increasing = CreateNumber(Order(number, true));
            int decreasing = CreateNumber(Order(number, false));

            int result = Math.Abs(increasing - decreasing);

            if (result == number)
            {
                return number;
            }
            else
            {
                return RecursiveMain(result);
            }
        }

        public List<int> Order(int fourDigit, bool increasing)
        { // if increasing, last number is largest
            List<int> orderedNumber = new List<int>();

            for (int i = 1000; i > .9; i /= 10)
            {
                int place = fourDigit / i;
                orderedNumber.Add(place);
                fourDigit = fourDigit - place * i;
            }

            orderedNumber.Sort();

            if (!increasing)
            {
                orderedNumber = Reverse(orderedNumber);
            }

            return orderedNumber;
        }

        public List<int> Reverse(List<int> list)
        {
            List<int> newList = new List<int>();

            for (int i = list.Count; i > 0; i--)
            {
                newList.Add(list[i-1]);
            }
            return newList;
        }

        public int CreateNumber(List<int> list)
        {
            int num = 0;
            int multiplier = 1000;
            foreach (int i in list)
            {
                num += i * multiplier;
                multiplier /= 10;
            }

            return num;
        }
    }
}
