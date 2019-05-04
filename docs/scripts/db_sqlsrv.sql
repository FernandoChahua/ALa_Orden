drop database ALaOrden

create database ALaOrden
go

use ALaOrden
go

create table Usuario(
	idUsuario int primary key identity,
	email varchar(50) not null unique,
	apodo varchar(50) not null unique,
	contrasena varchar(50) not null)
go

create table Tarjeta(
	idTarjeta int primary key identity,
	idUsuario int foreign key references Usuario(idUsuario) not null,
	nroCuenta char(16) not null,
	titular varchar(50) not null,
	fechaExp date not null,
	constraint CK_16DIGIT check(len(nroCuenta)=16))
go

create table Direccion( 
	idDireccion int primary key identity,
	idUsuario int foreign key references Usuario(idUsuario) not null,
	descripcion varchar(200) not null,
	latitud float not null,
	longitud float not null )


create table Franquicia(
	idFranquicia int primary key identity,
	nombre varchar(50) not null,
	url varchar(50) not null,
	logo varchar(100))
go

create table Sede(
	idSede int primary key identity,
	idFranquicia int foreign key references Franquicia(idFranquicia) not null,
	direccion varchar(200) not null)
go

create table Categoria(
	idCategoria int primary key identity,
	nombre varchar(50) not null unique)
go

create table Marca(
	idMarca int primary key identity,
	nombre varchar(50) not null unique)
go

create table Producto(
	idProducto int primary key identity,
	idCategoria int foreign key references Categoria(idCategoria) not null,
	idMarca int foreign key references Marca(idMarca) not null,
	nombre varchar(100) not null,
	presentacion varchar(50) not null,
	cantidad int not null,
	magnitud float not null,
	unidad varchar(20) not null,
	descripcion varchar(300),
	imagen varchar(100) )
go

create table Producto_Franquicia(
	idProducto int foreign key references Producto(idProducto) not null,
	idFranquicia int foreign key references Franquicia(idFranquicia) not null,
	codReferencia varchar(100) not null,
	primary key (idProducto, idFranquicia) )
go

create table Pedido(
	idPedido int primary key identity,
	idUsuario int foreign key references Usuario(idUsuario) not null,
	idSede int foreign key references Sede(idSede) not null,
	estado varchar(50) not null,
	fecha datetime not null,
	direccion varchar(200) not null,
	nroTransaccion int not null,
	subtotal decimal(7,2) not null,
	precioEnvio decimal(7,2) not null,
	descuento decimal(7,2) not null)
go

create table DetallePedido(
	idPedido int foreign key references Pedido(idPedido) not null,
	idProducto int foreign key references Producto(idProducto) not null,
	precio decimal(5,2) not null,
	cantidad int not null,
	primary key (idPedido, idProducto) )
go

/*QUERYS SELECT CON DATOS COMPLETOS*/
select p.idProducto,p.nombre as NombreProducto,p.presentacion as PresentacionProducto,p.cantidad as CantidadProducto,p.Magnitud as MagnitudProducto,p.unidad as UnidadProducto,p.descripcion as DescripcionProducto,p.imagen as ImagenProducto,c.idCategoria, c.nombre as NombreCategoria,m.idMarca,m.nombre as NombreMarca from Producto p, Marca m, Categoria c where p.idMarca = m.idMarca and p.idCategoria = c.idCategoria 
go

select c.idCategoria, c.nombre as NombreCategoria from Categoria c
go

select m.idMarca, m.nombre as NombreMarca from Marca m
go

select f.idFranquicia, f.nombre as NombreFranquicia,f.url as UrlFranquicia,f.logo as LogoFranquicia from Franquicia f
go

select s.idSede,s.direccion as DireccionSede,f.idFranquicia,f.nombre as NombreFranquicia,f.url as UrlFranquicia,f.logo as LogoFranquicia from Franquicia f,Sede s where s.idFranquicia = f.idFranquicia
go

select p.idProducto,p.nombre as NombreProducto,p.presentacion as PresentacionProducto,p.cantidad as CantidadProducto,p.Magnitud as MagnitudProducto,p.unidad as UnidadProducto,p.descripcion as DescripcionProducto,p.imagen as ImagenProducto,c.idCategoria, c.nombre as NombreCategoria,m.idMarca,m.nombre as NombreMarca, f.idFranquicia, f.nombre as NombreFranquicia,f.url as UrlFranquicia,f.logo as LogoFranquicia,pf.codReferencia from Producto p, Marca m, Categoria c, Franquicia f,Producto_Franquicia pf where p.idMarca = m.idMarca and p.idCategoria = c.idCategoria and pf.idProducto = p.idProducto and pf.idFranquicia = f.idFranquicia

select dp.idPedido ,dp.precio as CantidadPrecio,dp.cantidad as CantidadDetalle,p.idProducto,p.nombre as NombreProducto,p.presentacion as PresentacionProducto,p.cantidad as CantidadProducto,p.Magnitud as MagnitudProducto,p.unidad as UnidadProducto,p.descripcion as DescripcionProducto,p.imagen as ImagenProducto,c.idCategoria, c.nombre as NombreCategoria,m.idMarca,m.nombre as NombreMarca from Marca m ,Categoria c, Producto p,DetallePedido dp where p.idMarca = m.idMarca and p.idCategoria = c.idCategoria and dp.idProducto = p.idProducto

select * from Direccion 


/*QUERYS GENERALES*/
select * from Franquicia
select * from Sede
select * from Categoria
select * from Producto
select * from Marca
select * from Producto_Franquicia
select * from DetallePedido
select * from Pedido
select * from Direccion
select * from Usuario
select * from Pedido
select * from Tarjeta

/*QUERY PARA BORRAR MEDIANTE ID*/
delete from Categoria where idCategoria = 1
delete from Marca where idMarca = 1
delete from Sede where idSede = 1
delete from Franquicia where idFranquicia = 1
delete from Producto where idProducto = 1
delete from Producto_Franquicia where idProducto = 1
delete from Producto_Franquicia where idProducto = 1 and idFranquicia = 1
delete from Producto_Franquicia where idFranquicia = 1
delete from DetallePedido where idPedido = 1 and idProducto = 1
delete from Direccion where idDireccion = 1
delete from Direccion where idUsuario = 1

/*QUERYS PARA INSERTAR DATOS*/
insert into Categoria values(@nombre)
insert into Categoria values('Snacks')

insert into Marca values(@nombre)
insert into Marca values('Costeno')


insert into Franquicia values(@nombre,@url,@logo)
insert into Franquicia values('asdfasdf','adfas','adsfasd')

insert into Sede values(@idFranquicia,@direccion)
insert into Sede values(1,'asdfasdf')

insert into Producto values(@idCategoria,@idMarca,@nombre,@presentacion,@cantidad,@magnitud,@unidad,@descripcion,@imagen)
insert into Producto values(2,2,'Agua San Luis','botella',1,625,'ml','Agua sin gas','#####'),
(1,1,'Leche evaporada','lata',1,500,'ml','123','#####'),
(3,3,'Piqueo Snax','bolsa',1,100,'g','Variedad de snacks','#####'),
(1,1,'Yogurt natural de fresa','botella',1,1,'L','yogurt natural sabor a fresa','#####')


insert into Producto_Franquicia values(@idProducto,@idFranquicia,@CodRef)
insert into Producto_Franquicia values(5,3,'adsfads')

insert into Direccion values(@idUsuario,@descripcion,@latitud,@longitud)

 /*QUERYS PARA ACTUALIZAR*/
update Producto set idCategoria=@idCategoria,idMarca=@idMarca,nombre=@nombre,presentacion=@presentacion,cantidad=@cantidad,magnitud=@magnitud,unidad=@unidad,descripcion=@descripcion,imagen=@imagen where idProducto = 1

update Marca set nombre = @nombre where idMarca = 1

update Categoria set nombre = @nombre where idCategoria = 1

update Franquicia set nombre = @nombre , url = @url, logo = @logo where idFranquicia = 1

update Sede set idFranquicia = @idFranquicia,direccion = @direccion where idSede = 1

update Producto_Franquicia set codReferencia = @codReferencia where idProducto = 1 , idFranquicia = 1

update Direccion set descripcion = @descripcion , latitud = @latitud , longitud = @longitud where idDireccion = 1


