using System;
using System.Collections.Generic;
using BL;
using Persistion;
using ConsoleTables;
using DAL;
namespace PL_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            string select;
            Console.WriteLine("Chào mừng đến với Ước Cường Mobile !!! \n");

            while (true)
            {
                menu.mainmenu();
                System.Console.WriteLine("Mời nhập lựa chọn : ");
                select = Console.ReadLine();
                if (select == "1")
                {
                    menu.accountmenu();

                }
                else if (select =="2")
                {
                    menu.mobilemenu();
                }
                else if (select == "0")
                {
                    System.Console.WriteLine("Chúc quý khách một ngày tốt lành, xin cảm ơn và hẹn gặp lại\n");
                    Environment.Exit(0);
                }
                else
                {
                    System.Console.WriteLine("Lựa chọn không tồn tại, xin mời chọn lại\n");
                }
            }
        }
    }
}
