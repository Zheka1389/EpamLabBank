using System;
using System.Threading;
using System.Threading.Tasks;
using BankEmulator.UI;

namespace BankEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connecting to bank...");
            Thread.Sleep(2000);

            BankUI bankUI = new BankUI();
            bankUI.RunTerminal();

            Console.ReadKey();
        }
    }
}