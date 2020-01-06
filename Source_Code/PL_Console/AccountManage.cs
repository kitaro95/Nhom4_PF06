using System;
using System.Collections.Generic;
using BL;
using Persistion;
using ConsoleTables;
using DAL;
using System.Text;

namespace PL_Console
{
    class AccountManage
    {
        string select, username, password, email, address, name;
        int cmt, phonenumber, age;
        Menu meNu = new Menu();
        MobileManage mobileManagE = new MobileManage();
        public void Register()
        {
            while (true)
            {
                System.Console.WriteLine("Mời nhập tài khoản và email");
                System.Console.WriteLine("Tai khoan : ");
                username = Console.ReadLine();
                System.Console.WriteLine("Email: ");
                email = Console.ReadLine();
                CustomerBL custBL = new CustomerBL();
                int flag = custBL.VerifyRegister(username, email);
                if (flag == 2)
                {
                    System.Console.WriteLine("Mời điền thêm thông tin để hoàn thành đăng ký");
                    System.Console.Write("Mật khẩu : ");
                    password = Password();
                    System.Console.Write("Tên : ");
                    name = Console.ReadLine();
                    System.Console.Write("Địa chỉ : ");
                    address = Console.ReadLine();
                    System.Console.Write("Tuổi : ");
                    age = Convert.ToInt32(Console.ReadLine());
                    System.Console.Write("Chứng minh nhân dân (Căn cước công dân) : ");
                    cmt = Convert.ToInt32(Console.ReadLine());
                    System.Console.Write("Số điện thoại : ");
                    phonenumber = Convert.ToInt32(Console.ReadLine());
                    int c = custBL.Register(username, password, email, address, name, age, phonenumber, cmt);
                    System.Console.WriteLine("Đăng ký thành công, hãy chọn đăng nhập để đăng nhập \n");
                    break;
                }
                else
                {
                    System.Console.WriteLine("Nhập Y để nhập lại hoặc phím bất kỳ khác để quay lại ");
                    select = Console.ReadLine();
                    if ((select == "Y") || (select == "y"))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }
        public void Login()
        {
            while (true)
            {
                System.Console.WriteLine("Nhập vào tài khoản và mật khẩu");
                System.Console.Write("Tài khoản : ");
                username = Console.ReadLine();
                System.Console.Write("Mật khẩu : ");
                password = Password();
                CustomerBL custBL1 = new CustomerBL();
                int verify = custBL1.VerifyLogin(username, password);
                if (verify == 1)
                {
                    Customer cust = custBL1.GetCustomer(username);
                    while (true)
                    {
                        System.Console.WriteLine("\nMENU");
                        System.Console.WriteLine("-----------------------------");
                        System.Console.WriteLine("1.Xem thông tin cá nhân");
                        System.Console.WriteLine("2.Xem thông tin điện thoại");
                        System.Console.WriteLine("3.Quản lý giỏ hàng");
                        System.Console.WriteLine("0.Thoát");
                        System.Console.WriteLine("-----------------------------\n");
                        System.Console.WriteLine("Nhập lựa chọn : ");
                        select = Console.ReadLine();
                        if (select == "1")
                        {
                            System.Console.WriteLine("Thông tin khách hàng");
                            System.Console.WriteLine("----------------------------");
                            System.Console.WriteLine("Tài khoản: " + cust.CustomerUsername);
                            System.Console.WriteLine("Email : " + cust.CustomerEmail);
                            System.Console.WriteLine("Tên : " + cust.CustomerName);
                            System.Console.WriteLine("Tuổi " + cust.CustomerAge);
                            System.Console.WriteLine("Địa chỉ : " + cust.CustomerAddress);
                            System.Console.WriteLine("Số điện thoại : " + cust.CustomerPhonenumber);
                            System.Console.WriteLine("Chứng minh nhân dân (Căn cước công dân) : " + cust.CustomerCMT);
                            System.Console.WriteLine("\nBấm phím bất kỳ để trở lại");
                            Console.ReadKey();

                        }
                        else if (select == "2")
                        {
                            meNu.mobilemenu();

                        }
                        else if (select == "3")
                        {
                            while (true)
                            {
                                meNu.ordermenu();
                                System.Console.WriteLine("Nhập lựa chọn : ");
                                select = Console.ReadLine();
                                if (select == "1")
                                {

                                    Order order = new Order();
                                    order.OrderCustomer = new Customer();
                                    order.OrderMobile = new Mobile();
                                    order.OrderCustomer.CustomerID = cust.CustomerID;
                                    while (true)
                                    {
                                        System.Console.WriteLine("Nhập vào mã của chiếc điện thoại muốn đặt hàng ");
                                        order.OrderMobile.MobileID = Convert.ToInt32(Console.ReadLine());
                                        MobileBL mbBL = new MobileBL();
                                        Mobile mb = mbBL.GetMobilebyId(order.OrderMobile.MobileID);
                                        if (mb.MobileName != null)
                                        {
                                            while (true)
                                            {
                                                System.Console.WriteLine("Số lượng muốn mua : ");
                                                order.Amount = Convert.ToInt32(Console.ReadLine());
                                                if (order.Amount <= mb.MobileQuantity)
                                                {
                                                    System.Console.WriteLine("Bạn chắc chắn muốn đặt chiếc điện thoại này??");
                                                    System.Console.WriteLine("Mã điện thoại: ",mb.MobileID);
                                                    System.Console.WriteLine("Tên điện thoại: ",mb.MobileName);
                                                    System.Console.WriteLine("Đơn giá: ",mb.MobilePrice);
                                                    System.Console.WriteLine("Số lượng: ",mb.MobileQuantity);
                                                    System.Console.WriteLine("Tống giá: ",mb.MobilePrice * mb.MobileQuantity);
                                                    System.Console.WriteLine("Nhập Y nếu đồng ý hoặc phím bất kỳ khác nếu muốn huỷ bỏ");
                                                    select = Console.ReadLine();
                                                    if ((select == "y") || (select == "Y"))
                                                    {
                                                        orderBL orderBL = new orderBL();
                                                        if (orderBL.CreatOrder(order))
                                                        {
                                                            System.Console.WriteLine("Đặt hàng thành công, chúng tôi sẽ cố gắng giao hàng trong thời gian sớm nhất");
                                                            System.Console.WriteLine("Xin cảm ơn quý khách");
                                                            System.Console.WriteLine("\nBấm phím bất kì để trở lại");
                                                            Console.ReadKey();
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        System.Console.WriteLine("Đã huỷ bỏ đặt hàng");
                                                        System.Console.WriteLine("\nBấm phím bất kỳ để trở lại");
                                                        Console.ReadKey();
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    System.Console.WriteLine("số lượng không hợp lệ, chúng tôi còn " + mb.MobileQuantity + " sản phẩm này");
                                                    System.Console.WriteLine("Nhập Y nếu muốn nhập lại");
                                                    select = Console.ReadLine();
                                                    if ((select == "y") || (select == "Y"))
                                                    {
                                                        continue;
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            System.Console.WriteLine("Bấm Y nếu muốn nhập lại mã");
                                            select = Console.ReadLine();
                                            if ((select == "y") || (select == "Y"))
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }

                                }
                                if (select == "2")
                                {
                                    orderBL OrderBL = new orderBL();
                                    List<Order> listOrders = new List<Order>();
                                    listOrders = OrderBL.OrderHistory(cust.CustomerID);
                                    if (listOrders == null)
                                    {
                                        System.Console.WriteLine("chẳng có gì hết");
                                    }
                                    else
                                    {
                                        if (listOrders.Count <=0)
                                        {
                                            System.Console.WriteLine("Bạn chưa đặt hàng bao giờ");
                                            System.Console.WriteLine("Hãy quay trở lại để đặt hàng");
                                        }
                                        else
                                        {
                                        var table = new ConsoleTable("Tài khoản", "Email", "Mã hoá đơn", "Mã Sản phẩm"
                                        , "Tên sản phẩm", "Số lượng", "tổng tiền", "Ngày đặt");
                                        foreach (var item in listOrders)
                                        {
                                            table.AddRow(item.OrderCustomer.CustomerUsername, item.OrderCustomer.CustomerEmail, item.OrderID, item.OrderMobile.MobileID, item.OrderMobile.MobileName, item.Amount, item.Amount * item.OrderMobile.MobilePrice, item.OrderDate);
                                        }
                                        table.Write(Format.Alternative);
                                        }
                                    }
                                    System.Console.WriteLine("\nBấm phím bất kỳ để trở lại");
                                    Console.ReadKey();
                                }

                            }


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
                else
                {
                    System.Console.WriteLine("Nhập Y nếu muốn nhập lại, nếu chưa có tài khoản nhập phím bất kỳ khác để quay lại đăng ký");
                    select = Console.ReadLine();
                    if ((select == "Y") || (select == "y"))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }
        public string Password()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo pass = Console.ReadKey(true);
                if (pass.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (pass.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        sb.Length--;
                    }
                    continue;
                }
                Console.Write('*');

                sb.Append(pass.KeyChar);
            }
            return sb.ToString();
        }

    }
}