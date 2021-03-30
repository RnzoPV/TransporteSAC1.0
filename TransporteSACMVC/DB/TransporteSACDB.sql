if db_id('TransporteSACDB') is not null
	begin 
		use master
		drop database TransporteSACDB
	end
go

create database TransporteSACDB
go

use TransporteSACDB
go

create table Conductor(
id int not null identity(1,1),
nombre varchar(30) not null,
ape_pat varchar(30) not null,
ape_mat varchar(30) not null,
telefono varchar(11) not null
)
go

alter table conductor
	add  primary key (id)
go
select * from Conductor
go
