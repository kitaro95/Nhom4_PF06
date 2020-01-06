using System;
using System.Collections.Generic;
using BL;
using Persistion;
using ConsoleTables;
using DAL;
namespace PL_Console
{
    class MobileManage
    {
        int mobiID;

        public void ViewItemDetail()
        {
            System.Console.WriteLine("Mời nhập vào mã sản phẩm (MobileID) : ");
            mobiID = Convert.ToInt32(Console.ReadLine());
            MobileBL mobiBL = new MobileBL();
            Mobile mob = mobiBL.GetMobilebyId(mobiID);
            if (mob != null)
            {
                System.Console.WriteLine("Tên :" + mob.MobileName);
                System.Console.WriteLine("RAM : " + mob.MobileRAM);
                System.Console.WriteLine("Camera : " + mob.MobileCamera);
                System.Console.WriteLine("CPU : " + mob.MobileCPU);
                System.Console.WriteLine("Màn hình : " + mob.MobileScreen);
                System.Console.WriteLine("Sản xuất : " + mob.MobileTradeMack);
                System.Console.WriteLine("Giá : " + mob.MobilePrice);
                System.Console.WriteLine("Số lượng :" + mob.MobileQuantity);
            }
            else
            {
                System.Console.WriteLine("Không tìm thấy sản phẩm nào");
            }
        }
        public int SearchItem()
        {
            string mobilename;
            System.Console.WriteLine("Mời nhập vào tên điện thoại : ");
            mobilename = Console.ReadLine();
            MobileBL mobiBL = new MobileBL();
            List<Mobile> ListMs = mobiBL.GetMobilebyName(mobilename);
            if (ListMs.Count != 0)
            {
                var table = new ConsoleTable("Mã sản phẩm", "Tên", "RAM", "Camera", "Màn hình", "CPU", "Sản xuất", "Giá", "Số lượng");
                foreach (var item in ListMs)
                {
                    table.AddRow(item.MobileID, item.MobileName, item.MobileRAM, item.MobileCamera, item.MobileScreen, item.MobileCPU, item.MobileTradeMack, item.MobilePrice, item.MobileQuantity);
                }
                table.Write(Format.Alternative);
                return 1;
            }
            else
            {
                System.Console.WriteLine("Không tìm thấy sản phẩm nào");
                return 0;
            }
        }
        public void ShowListItem()
        {
            MobileBL mobiBL = new MobileBL();
            List<Mobile> ListMs = mobiBL.GetListMobile();
            var table = new ConsoleTable("Mã sản phẩm", "Tên", "RAM", "Camera", "Màn hình", "CPU", "Sản xuất", "Giá", "Số lượng");
            foreach (var item in ListMs)
            {
                table.AddRow(item.MobileID, item.MobileName, item.MobileRAM, item.MobileCamera, item.MobileScreen, item.MobileCPU, item.MobileTradeMack, item.MobilePrice, item.MobileQuantity);
            }
            table.Write(Format.Alternative);
        }


    }
}