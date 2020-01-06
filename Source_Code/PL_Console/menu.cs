using System;
using System.Collections.Generic;
using BL;
using Persistion;
using ConsoleTables;
using DAL;
namespace PL_Console
{
    class Menu
    {
        string select;
        public void mainmenu()
        {
            System.Console.WriteLine("\nMENU");
            System.Console.WriteLine("-----------------------------");
            System.Console.WriteLine("1.Quản lý tài khoản");
            System.Console.WriteLine("2.Xem thông tin điện thoại");
            System.Console.WriteLine("0.Thoát ");
            System.Console.WriteLine("-----------------------------\n");
        }

        public void accountmenu()
        {
            AccountManage accountManage = new AccountManage();
            while (true)
            {
                System.Console.WriteLine("\nQuản lý tài khoản");
                System.Console.WriteLine("-----------------------------");
                System.Console.WriteLine("1.Đăng nhập");
                System.Console.WriteLine("2.Đăng ký");
                System.Console.WriteLine("0.Quay lại");
                System.Console.WriteLine("-----------------------------\n");
                System.Console.WriteLine("Mời nhập lựa chọn : ");
                select = Console.ReadLine();
                if (select == "1")
                {
                    accountManage.Login();
                }
                else if (select == "2")
                {
                    accountManage.Register();
                }
                else if (select == "0")
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Lựa chọn không tồn tại, mời chọn lại \n");

                }
            }
        }
        public void mobilemenu()
        {
            MobileManage mobileManage = new MobileManage();
            while (true)
            {
                System.Console.WriteLine("\nXem thông tin điện thoại");
                System.Console.WriteLine("-----------------------------");
                System.Console.WriteLine("1.Xem danh sách điện thoại");
                System.Console.WriteLine("2.Xem thông tin điện thoại theo tên");
                System.Console.WriteLine("3.Xem thông tin điện thoại theo mã");
                System.Console.WriteLine("0.Quay lại");
                System.Console.WriteLine("-----------------------------\n");
                System.Console.WriteLine("Mời nhập lựa chọn : ");
                select = Console.ReadLine();
                if (select == "1")
                {
                    mobileManage.ShowListItem();
                    System.Console.WriteLine("\nBấm phấm bất kỳ để quay lại");
                    Console.ReadKey();
                }
                else if (select == "2")
                {
                    mobileManage.SearchItem();
                   System.Console.WriteLine("\nBấm phấm bất kỳ để quay lại");
                   Console.ReadKey();
                }
                else if (select == "3")
                {
                    mobileManage.ViewItemDetail();
                    System.Console.WriteLine("\nBấm phấm bất kỳ để quay lại");
                    Console.ReadKey();
                }
                else if (select == "0")
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Lựa chọn không tồn tại, mời chọn lại");
                }
            }
        }
        public void ordermenu()
        {
            System.Console.WriteLine("\nQuản lý đơn hàng");
            System.Console.WriteLine("-----------------------------");
            System.Console.WriteLine("1.Đặt hàng");
            System.Console.WriteLine("2.Xem lịch sử đặt hàng");
            System.Console.WriteLine("0.Quay lại");
            System.Console.WriteLine("-----------------------------\n");
        }
    }
}