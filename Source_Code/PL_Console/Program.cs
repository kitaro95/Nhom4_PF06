using System;
using System.Collections.Generic;
using BL;
using Persistion;
using ConsoleTables;
namespace PL_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //string select;
            int mobiID;
            string username,email,password;
            Console.WriteLine("Welcome to Mobile World !!! \n");
           
            // System.Console.WriteLine("Enter Select : ");
            // select = Console.ReadLine();
            System.Console.WriteLine("Enter MobiID");
            mobiID = Convert.ToInt32(Console.ReadLine());
            MobileBL mobiBL = new MobileBL();
            Mobile mob = mobiBL.GetMobilebyId(mobiID);
            if (mob != null)
            {
                System.Console.WriteLine("Name :" + mob.MobileName);
                System.Console.WriteLine("RAM : "+ mob.MobileRAM);
                System.Console.WriteLine("Camera : "+ mob.MobileCamera);
                System.Console.WriteLine("Storage : "+ mob.MobileStorage);
            }
            else
            {
                System.Console.WriteLine("Mobile ID not exist");
            }
            List<Mobile> ListMs = mobiBL.GetListMobile();
            var table = new ConsoleTable("MobileID","Name","RAM","Camera","Storage");
            foreach (var item in ListMs)
            {
             table.AddRow(item.MobileID,item.MobileName,item.MobileRAM,item.MobileCamera,item.MobileStorage);
            }
            table.Write(Format.Alternative);

            Console.WriteLine("Welcome to Mobile World !!! \n");
            System.Console.WriteLine("Nhap tai khoan va mat khau");
            System.Console.WriteLine("Tai khoan : ");
            username = Console.ReadLine();
            System.Console.WriteLine("Mat khau : ");
            password = Console.ReadLine();
            System.Console.WriteLine("Email: ");
            email = Console.ReadLine();
            CustomerBL custBL = new CustomerBL();
            int flag = custBL.VerifyRegister(username,email);
             if (flag == 2)
             {
               custBL.Register(username,password,email);
             }
            
            System.Console.WriteLine("Nhap tai khoan va mat khau");
            System.Console.WriteLine("Tai khoan : ");
            username = Console.ReadLine();
            System.Console.WriteLine("Mat khau : ");
            password = Console.ReadLine();
            CustomerBL custBL1 = new CustomerBL();
            Customer cust = custBL1.VerifyCustomer(username,password);
            


        }
    }
}
