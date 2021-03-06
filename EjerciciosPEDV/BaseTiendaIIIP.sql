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
correo char(45) not null
)


create procedure insertarUsuario(
@idUsuario int,
@nombre varchar(25),
@apellido varchar(25),
@nombreUsuario varchar(25),
@psw varchar(40),
@rol char(15),
@estado char(25),
@correo varchar(45)
)
AS 
BEGIN
if exists (select nombreUsuario from Usuario where nombreUsuario=@nombreUsuario and estado = 'Activo')
raiserror('Ya existe un registro con el nombre de ese usuario, porfavor ingresa uno nuevo',16,1)
else
insert into Usuario(idUsuario,nombre,apellido,nombreUsuario,psw,rol,estado,correo) values(@idUsuario,@nombre,@apellido,@nombreUsuario,@psw,@rol,@estado,@correo)
END

execute insertarUsuario 1,'Pedro','Perez','´Pedrez','1234','Admin','Activo','pedrope@gmail.com'

create procedure modificarUsuario(
@idUsuario int,
@nombre varchar(25),
@apellido varchar(25),
@nombreUsuario varchar(25),
@psw varchar(40),
@rol char(15),
@estado char(25),
@correo varchar(25)
)
AS 
BEGIN
if exists (select nombreUsuario,idUsuario from Usuario where (nombreUsuario=@nombreUsuario and idUsuario=@idUsuario and estado = 'Activo'))
raiserror ('Usuario en uso, Utiliza otro por favor',16,1)
update Usuario set nombre = @nombre, apellido = @apellido, psw = @psw, rol = @rol, correo = @correo
where idUsuario = @idUsuario
END

Create procedure eliminarUsuario(
@idUsuario int, @rol char(15) 
)
AS
BEGIN
if exists (select nombreUsuario from Usuario where @rol = 'admin')
	raiserror('El usuario *admin*, No se puede eliminar, accion denegada',16,1)
	else
	update Usuario set estado = 'Eliminado'
	where idUsuario = @idUsuario and rol <> 'admin'
END



create procedure BuscarUsuario(@userName varchar(50))
as
begin
select CONCAT(nombre, ' ', apellido) as 'Nombre Completo', nombreUsuario as 'Usuario',
estado as 'Estado', rol as 'Puesto', correo as 'correo'
from Usuario
where nombreUsuario like '%' +@userName+ '%'
end


------Encriptar--------
create master key encryption by
password = 'clave12345678';
go


create certificate TiendaIIIPHOC01
with subject='TiendaIIIPHOC';
go

select * from sys.certificates
go

create symmetric key ClaveSimetrica
with algorithm = AES_128
encryption by certificate TiendaIIIPHOC01;
go

alter table Usuario
add Passwd varbinary(128);

open symmetric key ClaveSimetrica
decryption by certificate TiendaIIIPHOC01;
go


update Usuario
set Passwd = ENCRYPTBYKEY (KEY_GUID('ClaveSimetrica'),psw)
from Usuario

close symmetric key ClaveSimetrica;
go


-----Desencriptar------
open symmetric Key ClaveSimetrica
decryption by certificate TiendaIIIPHOC01;

select convert(varchar(40),DECRYPTBYKEY(Passwd)) as Contraseña, nombreUsuario from Usuario
close symmetric key ClaveSimetrica
select * from Usuario
