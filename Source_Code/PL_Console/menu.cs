using System;

namespace PL_Console
{
    class menu
    {
        public void mainmenuguest()
        {
            System.Console.WriteLine("MAIN MENU");
            System.Console.WriteLine("-----------------------------");
            System.Console.WriteLine("1.Account Management");
            System.Console.WriteLine("2.View Mobile Information");
            System.Console.WriteLine("0.Exit");
            System.Console.WriteLine("-----------------------------");
        }

        public void accountmenu()
        {
            System.Console.WriteLine("Account Managenent");
            System.Console.WriteLine("-----------------------------");
            System.Console.WriteLine("1.Login");
            System.Console.WriteLine("2.Register");
            System.Console.WriteLine("0.Exit");
            System.Console.WriteLine("-----------------------------");
        }
        public void mobilemenu()
        {
            System.Console.WriteLine("View Mobile Information");
            System.Console.WriteLine("-----------------------------");
            System.Console.WriteLine("1.View List Mobile");
            System.Console.WriteLine("2.View Mobile Detail");
            System.Console.WriteLine("0.Exit");
            System.Console.WriteLine("-----------------------------");
        }
        public void cartmenu()
        {
            System.Console.WriteLine("Cart Management");
            System.Console.WriteLine("-----------------------------");
            System.Console.WriteLine("1.Add Mobile to Cart");
            System.Console.WriteLine("2.Edit Cart");
            System.Console.WriteLine("0.Exit");
            System.Console.WriteLine("-----------------------------");
        }
        public void mainmenumember()
        {
            System.Console.WriteLine("MAIN MENU");
            System.Console.WriteLine("-----------------------------");
            System.Console.WriteLine("1.Update Customer Information");
            System.Console.WriteLine("2.View Mobile Information");
            System.Console.WriteLine("3.Cart Management");
            System.Console.WriteLine("0.Exit");
            System.Console.WriteLine("-----------------------------");
        }
    }
}