using System;
using Paypal.Entities;
using Paypal.Services;
namespace Paypal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data: ");

            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Contract value: ");
            double value = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of installments: ");
            int month = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, value);
            ContractService contractService = new ContractService(new PaypalServices ());
            contractService.ProcessContract(contract, month);
            Console.WriteLine("Installments: ");

            foreach (var item in contract.Installments)
            {
                Console.WriteLine($"{item.DueDate.ToString("dd/MM/yyyy")} - {item.Amount}");
            }
        }
    }
}
