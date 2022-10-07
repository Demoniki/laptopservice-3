use data;

create proc spGetAllUsers
as 
begin
	select * from UserTable 
ends



create proc spInsertUser
@store_id int,
@location varchar(30)
as
begin 
	insert into Store(store_id,location)
	values(@store_id,@location)
end




create proc spUpdateUser
@store_id int,
@location varchar(30)
as
begin 
	update Store set 
	location=@location 
	where store_id=@store_id
end
	

create proc spDeleteUser
@store_id int
as
begin 
delete from Store where store_id=@store_id
end