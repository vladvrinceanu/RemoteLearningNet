using System;
using System.Collections.Generic;
using System.Text;
using iQuest.VendingMachine.Exceptions;
namespace iQuest.VendingMachine.PresentationLayer
{
    internal class BuyView
    {
        public int RequestProduct()
        {

            ConsoleColor oldcolor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Type the product ID: ");

            Console.ForegroundColor = oldcolor;

            bool success =  int.TryParse(Console.ReadLine(),out int number);

            if (success)
            {
                return number;
            }
            else
            {
               return 0;
            }
            // TryParse citeste Cancel Exception string.isnullorwhitespace
        }
        public void DispenseProduct(string productName)
        {
            Console.WriteLine();
            Console.Write($"{"You bought: "} {productName}");
        }
    }
}
