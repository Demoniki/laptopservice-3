use data;

create table ServiceCenter(
ServiceCenter_id int primary key,
ServiceCenterName varchar(50),
location varchar(50)
)

create table UserTable(
id int primary key,
Name varchar(30),
ContactNumber varchar(10) ,
address varchar(50),
appointmentBookingDate Date,
LaptopModel varchar(30),
ServiceCenterId int
)

alter table UserTable 
add foreign key(ServiceCenterId) references ServiceCenter(ServiceCenter_id);