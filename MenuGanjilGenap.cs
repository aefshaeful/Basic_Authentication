using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Authentication
{
    internal class MenuGanjilGenap
    {
        // Mencetak Angka Ganjil Atau Genap:
        public static void PrintEvenOdd(int limit, string choice)
        {
            if (limit < 1)
            {
                Console.WriteLine("Batas akhir harus minimal 1");
                return;
            }

            Console.Write($"Print bilangan {choice} :");

            int start = choice == "ganjil" ? 1 : 2;
            for (int i = start; i <= limit; i += 2)
            {
                Console.Write(i + ",");
            }
        }

        // Memeriksa Angka Ganjil Atau Genap:
        public static string EvenOddCheck(int input)
        {
            if (input % 2 == 0)
            {
                return $"Genap";
            }
            else
            {
                return $"Ganjil";
            }
        }

        public static void MenuGanjilGenapMain()
        {
            ViewMenu.CheckGanjilGenap();
        }
    }
}
