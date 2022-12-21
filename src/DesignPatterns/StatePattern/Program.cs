﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                var order = new OrderProxy();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(order);
                Console.ResetColor();

                order.State.Dump();

                order.IsPaid = true;

                while (!(order.State is Cancelled || order.State is Completed))
                {
                    if (order.CanConfirm)
                        Console.Write("Confirm (Enter) ");

                    if (order.CanCancel)
                        Console.Write("(C)ancel ");

                    var key = Console.ReadKey().Key;

                    Console.WriteLine();

                    if (key == ConsoleKey.Enter)
                        order.Confirm();

                    if (key == ConsoleKey.C)
                        order.Cancel();

                    order.State.Dump();

                }

                Console.Clear();

            }
        }
    }
}