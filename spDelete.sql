use data

create proc spDeleteUser
@id int
as
begin 
delete from UserTable where id=@id
end