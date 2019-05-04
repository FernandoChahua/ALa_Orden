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
	idCategoria int primary key,
	nombre varchar(50) not null unique)
go

create table Marca(
	idMarca int primary key,
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
	idFranquicia int not null,
	precio decimal(5,2) not null,
	cantidad int not null,
	primary key (idPedido, idProducto) )
go