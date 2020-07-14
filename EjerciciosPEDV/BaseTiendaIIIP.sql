create database TiendaIIIPHOC
go
use TiendaIIIPHOC
go

create table Usuario(
idUsuario int primary key not null,
nombre varchar(25) not null,
apellido varchar(25) not null,
nombreUsuario varchar(25) not null,
psw varchar(40) not null,
rol char(15) not null,
estado char(25) not null,
correo char(45) not null,
)

select * from Usuario

create procedure insertarUsuario(
@idUsuario int primary key,
@nombre varchar(25),
@apellido varchar(25),
@nombreUsuario varchar(25),
@psw varchar(40),
@rol char(15),
@estado char(25)
)
AS 
BEGIN
if exists (select nombreUsuario from Usuario where nombreUsuario=@nombreUsuario and estado = 'Activo')
raiserror ('Ya existe un registro con el nombre de ese usuario, porfavor ingresa uno nuevo')
else
insert into Usuario values(@idUsuario,@nombre,@apellido,@nombreUsuario,@psw,@rol,@estado)
END

execute insertarUsuario 1,'Pedro','Perez','´Pedrez','1234','Admin','Activo'

create procedure modificarUsuario(
@idUsuario int primary key,
@nombre varchar(25),
@apellido varchar(25),
@nombreUsuario varchar(25),
@psw varchar(40),
@rol char(15),
@estado char(25)
)
AS 
BEGIN
if exists (select nombreUsuario,idUsuario from Usuario where (nombreUsuario=@nombreUsuario and idUsuario=@idUsuario and estado = 'Activo'))
raiserror ('Usuario en uso, Utiliza otro por favor')
update 
END