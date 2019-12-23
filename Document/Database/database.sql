drop database  if exists UocCuongMobile;
create database if not exists UocCuongMobile;

use UocCuongMobile;

create table if not exists Customer(
Customer_id int primary key auto_increment,
Customer_Name nvarchar(255) not null,
Customer_email nvarchar(255) not null,
Customer_BirthDay date not null,
Phone_number nvarchar(255) not null,
address nvarchar(255),
Customer_password nvarchar(255),
Customer_Gerder nvarchar(255)
);
create table if not exists Orders(
Order_id int primary key auto_increment,
Customer_id int  ,
Monile_id int 
);
create table if not exists Order_Detail(
Order_id int primary key auto_increment,
Customer_id int 
);
create table if not exists Mobile(
Monile_id int primary key auto_increment,
Mobile_name nvarchar(255)  not null,
Mobile_Price decimal(10.2)   not null,
Mobile_Trademack nvarchar(255) not null,
Mobile_Screen nvarchar(255) ,
Mobile_Camera nvarchar(255) ,
Mobile_CPU nvarchar(255),
Mobile_RAM  nvarchar(255),
 Mobile_quantity int not null
);

insert into Mobile(Mobile_name,Mobile_Price,Mobile_Trademack,Mobile_Screen,Mobile_Camera,Mobile_CPU, Mobile_RAM,Mobile_quantity)
value("i iPhone 7 Plus - Hàng Chính Hãng VN/A",10990000,"Apple"," 5.5 inch, Full HD (1080 x 1920 pixels)","7MP/ 2 x 12MP","Apple A10 Fusion 4 nhân 64-bit","3GB",8),
("iPhone 7 Plus 128GB - Hàng Nhập Khẩu Chính Hãng",12490000,"Apple","5.5 inch, Full HD (1080 x 1920 pixels)","7MP/ 12MP","Apple A10 Fusion 4 nhân 64-bit","3GB",8),
("iPhone 7 Plus 32GB - Hàng Nhập Khẩu Chính Hãng",11190000,"Apple","5.5 inch, Full HD (1080 x 1920 pixels)","7MP/ 12MP","Apple A10 Fusion 4 nhân 64-bit","3GB",8),
("iPhone 7 Plus 32GB - Hàng Nhập Khẩu",11299000,"Apple","5.5 inch, Full HD (1080 x 1920 pixels)"," 7MP/ 2 x 12MP","Apple A10 Fusion 4 nhân 64-bit","3GB",8),
("iPhone 6s 32GB - Hàng Nhập Khẩu",5999000,"Apple","IPS đèn nền LED 4.7inch, 750 x 1334pixels (mật độ điểm ảnh 326ppi)","5MP/ 12MP","Apple A9","2GB",8),
(" iPhone XS 64GB - Hàng Nhập Khẩu",19090000,"Apple","5.8 inch Super Retina (2436 x 1125), 463ppi, 3D Touch, TrueTone Dolby Vision HDR 10"," 7MP/ 2 camera 12MP","A12 Bionic 64-bit 7nm","4GB",8),
("iPhone 11 256GB - Hàng Chính Hãng",24990000 ,"Apple","6.1 inches","12 MP + 12 MP/12 MP, f/2.2","Apple A13 Bionic 6 nhân","4GB",8),
("iPhone 11 256GB - Hàng Nhập Khẩu",21499000 ,"Apple","6.1 inches","12 MP + 12 MP/12 MP, f/2.2","Apple A13 Bionic 6 nhân","4GB",8),
("iPhone XS 256GB - Hàng Nhập Khẩu",22498000  ,"Apple","5.8 inch Super Retina (2436 x 1125), 463ppi, 3D Touch, TrueTone Dolby Vision HDR 10","7MP/ 2 camera 12MP","A12 Bionic 64-bit 7nm","4GB",8),
("iPhone 11 128GB - Hàng Chính Hãng",22990000 ,"Apple","6.1 inches","12 MP + 12 MP/12 MP, f/2.2","Apple A13 Bionic 6 nhân","4GB",8),
("Phone XS 64GB - Hàng Chính Hãng",21490000  ,"Apple","5.8 inch Super Retina (2436 x 1125), 463ppi, 3D Touch, TrueTone Dolby Vision HDR 10","7MP/ 2 camera 12MP","A12 Bionic 64-bit 7nm","4GB",8),
("iPhone 11 128GB - Hàng Nhập Khẩu",20294000  ,"Apple","6.1 inches","12 MP + 12 MP/12 MP, f/2.2","Apple A13 Bionic 6 nhân","4GB",8),
("iPhone XS 64GB - Hàng Nhập Khẩu",19090000,"Apple","5.8 inch Super Retina (2436 x 1125), 463ppi, 3D Touch, TrueTone Dolby Vision HDR 10","7MP/ 2 camera 12MP","A12 Bionic 64-bit 7nm","4GB",8),
("iPhone 11 Pro Max 256GB - Hàng Nhập Khẩu",30499000,"Apple","5.8 inchs, 1125 x 2436 Pixels","12 MP/Bộ 3 camera 12MP","Apple A13 Bionic (7 nm+)","6GB",8),
("iPhone 8 256GB - Hàng Nhập Khẩu Chính Hãng",15990000 ,"Apple","LED-backlit IPS LCD, 4.7 inch HD","7MP/12MP","Apple A11 Bionic 6 nhân","2GB",8),
("iPhone 11 Pro 64GB - Hàng Chính Hãng",28990000  ,"Apple","5.8 inchs, 1125 x 2436 Pixels","12 MP/Bộ 3 camera 12MP","Apple A13 Bionic (7 nm+)","4GB",8),
(" iPhone XR 128GB Xanh Dương - Hàng nhập khẩu",15499000,"Apple","6.1 inch LCD (828 x 1792), 324 ppi, 3D touch, True-tone"," 7MP / 12MP","A12 Binonic 64-bit 7nm","3GB",8),
("iPhone XR 256GB - Nhập Khẩu Chính Hãng",16990000  ,"Apple","6.1 inch LCD (828 x 1792), 324 ppi, 3D touch, True-tone"," 7MP / 12MP","A12 Binonic 64-bit 7nm","3GB",8),
("iPhone XS Max 256GB - Hàng Nhập Khẩu",22038000,"Apple","OLED 6.5 inch","12MP, camera trước 7MP xóa phông","","4GB",8),
("iPhone 11 Pro Max 64GB - Hàng Nhập Khẩu",27099000 ,"Apple","OLED (Super Retina XDR), 6.5 inch, 2688 x 1242 pixels","12MP / 12MP + 12MP + 12MP","","6GB",8),
("iPhone 8 256GB - Hàng Nhập Khẩu Chính Hãng",15990000,"Apple","LED-backlit IPS LCD, 4.7 inch HD","7MP/12MP","Apple A11 Bionic 6 nhân","2GB",8),
("iPhone 11 Pro Max 256GB - Hàng Chính Hãng",34990000,"Apple","OLED (Super Retina XDR), 6.5 inch, 2688 x 1242 pixels","12MP / 12MP + 12MP + 12MP","Apple A13 Bionic (7 nm+)","4GB",8),
("iPhone XR 128GB Đỏ - Hàng nhập khẩu",15499000 ,"Apple","6.1 inch LCD (828 x 1792), 324 ppi, 3D touch, True-tone","7MP / 12MP","A12 Binonic 64-bit 7nm","3GB",8),
("iPhone XR 128GB - Hàng Nhập Khẩu Chính Hãng",16990000  ,"Apple","6.1 inch LCD (828 x 1792), 324 ppi, 3D touch, True-tone","7MP / 12MP","A12 Binonic 64-bit 7nm","3GB",8),
(" iPhone 8 64GB - Nhập Khẩu Chính Hãng",11990000 ,"Apple","LED-backlit IPS LCD, 4.7 inch HD","7MP / 12MP","Apple A11 Bionic 6 nhân","2GB",8),
("iPhone XS Max 256GB - Hàng Chính Hãng",26990000,"Apple","6.5 inch Super Retina (2688 x 1242), 458ppi, 3D Touch, TrueTone Dolby Vision HDR 10","7MP/ 2 camera 12MP","A12 Binonic 64-bit 7nm","3GB",8),
("iPhone 8 256GB - Hàng Nhập Khẩu Chính Hãng",15990000 ,"Apple"," LED-backlit IPS LCD, 4.7 inch HD","7MP/12MP","Apple A11 Bionic 6 nhân","2GB",8),
("iPhone XR 128GB Đen - Hàng nhập khẩu",15499000  ,"Apple","6.1 inch LCD (828 x 1792), 324 ppi, 3D touch, True-tone","7MP / 12MP","A12 Binonic 64-bit 7nm","3GB",8),
("iPhone 8 Plus 256GB - Hàng Nhập Khẩu",16388000,"Apple","LED-backlit IPS LCD, 5.5 inch Full HD","7MP/12MP","Apple A11 Bionic 6 nhân","3GB",8);




select * from mobile;


