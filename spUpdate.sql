use data;


create proc spUpdateUser
@id int ,
@ContactNumber varchar(10)

as
begin 
	update UserTable set 
	ContactNumber=@ContactNumber
	where id=@id
end
	