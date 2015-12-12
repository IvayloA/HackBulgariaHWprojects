using CashDeskLibraby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashDeskApplication
{
    class CashDeskApplication
    {
        static bool ValidBill(int amount)
        {
            if (amount == 2 || amount == 5 || amount == 10 || amount == 20 || amount == 50 || amount == 100)
                return true;
            else
                return false;
        }

        static void PrintHelp()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ");
            Console.WriteLine("takebill <amount> - adds a bill with value <amount> to the CashDesk");
            Console.WriteLine("takebatch <amount> <amount> ... - adds a batch of bills to the CashDesk");
            Console.WriteLine("total - prints the total money in the CashDesk");
            Console.WriteLine("inspect - prints detailed information of the money in the CashDesk");
            Console.WriteLine("exit - exits the application");
            Console.WriteLine(" ");
        }

        static void Main()
        {
            CashDesk desk = new CashDesk();
            bool Exit = false;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("CashDesk application\n");
            Console.WriteLine("help - display the list of all commands");

            StringBuilder userInput = new StringBuilder();

            while (!Exit)
            {
                Console.ForegroundColor = ConsoleColor.White;
                userInput.Append(Console.ReadLine());

                if (userInput.ToString().Contains("takebill"))
                {
                    userInput.Replace("takebill", "");
                    int amount = -1;
                    if (int.TryParse(userInput.ToString(), out amount))
                    {
                        if (ValidBill(amount))
                        {
                            desk.TakeMoney(new Bill(amount));
                            Console.WriteLine("Bill amount successfully added");
                        }
                        else
                            Console.WriteLine("The ${0} bill is not a valid one!", amount);
                    }
                    else
                        Console.WriteLine("Invalid amount!");
                }
                else if (userInput.ToString().Contains("takebatch"))
                {
                    userInput.Replace("takebatch", "");
                    List<Bill> BillList = new List<Bill>();

                    string[] BillArray = userInput.ToString().Split(' ');
                    int amount = -1;
                    foreach (var bill in BillArray)
                    {
                        if (int.TryParse(bill, out amount))
                        {
                            if (ValidBill(amount))
                            {
                                BillList.Add(new Bill(amount));
                                Console.WriteLine("Bill {0}  successfully added", amount);
                            }
                            
                            else
                                Console.WriteLine("Rejected, not a valid bill!", amount);
                        }
                    }
                    if (BillList.Count == 0)
                    {
                        Console.WriteLine("Invalid amount!");
                    }
                    else {

                        desk.TakeMoney(new BatchBill(BillList));
                    }
                }
                else if (userInput.ToString().Contains("total"))
                {
                    Console.WriteLine("${0}", desk.Total());
                }
                else if (userInput.ToString().Contains("inspect"))
                {
                    if (desk.Total() != 0)
                    {
                        desk.Inspect();
                    }
                    else
                    {
                        Console.WriteLine("The Cash Desk is empty.");
                    }
                }
                              
                else if (userInput.ToString().Contains("exit")) 
                {
                    Exit = true;
                }
                else if (userInput.ToString().Contains("help"))  
                {
                    PrintHelp();
                }
                else
                    Console.WriteLine("Invalid command!");

                userInput.Clear();
            }
        }
    }
}
