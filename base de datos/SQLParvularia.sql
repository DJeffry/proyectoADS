/**
	1- los nombres de las tablas deben estar escritos en singular con camelCase
	2- una pleca con dos asteriscos indica una descripcion de como se usara la tabla
	3- las variables deberan estar escritas dependiendo sean singular o plural, pero deben estar escritas en camelCase
	4- las llaves primarias y foraneas se les ponen id_ o fk_ antes de ponerle el nombre
**/

use master
Go

 --para borrar la base de datos, hay que estar en el login de tu pc normal
 drop database GestorAlimentosBD
 GO

 create database GestorAlimentosBD
 GO

use GestorAlimentosBD
GO

--Se comienza por grado por que es el que es independiente a las demas tablas
/**
	La tabla grado tiene como objetivo llevar los dias de clases que se han impartido,
	la cantidad de veces que se han dado refrigerios y en que turnos se han relizado
**/
Create table grado(id_Grado int identity not null primary key,grado int not null,turno varchar(6),lectivos int, refrigerios int)
GO

--La segunda tabla tambien es independiente a las demas
/**
	La tabla Inventario es donde se registraran los alimentos que estan almacenados
**/
create table inventarioAlimentos(id_Alimentos int identity not null primary key,nombre varchar(255),unidades varchar(255),cantidad decimal,saldo decimal,fechaCaducidad date)
GO

/**
	Se registra el Ingreso y salida de los productos
**/
create table movimientoAlimentos(id_Movimiento int identity not null primary key,codigo char(4) not null,fechaMovimiento date,Lote varchar(255),cantidadAutorizada decimal,envaseEmpaque varchar(255),unidadesCompletas int,unidadesFracciones int,fk_Alimentos int not null foreign key (fk_Alimentos) references Inventarioalimentos(id_Alimentos))

GO

/**
	Estudiante, se registran los estudiantes que estan matriculados
**/
create table estudiante(id_Estudiante int identity not null primary key,Nombre varchar(255),Apellido varchar(255),sexo varchar(50),fk_Grado int not null foreign key (fk_grado) references grado(id_Grado) On Delete Cascade On update cascade)

/**
	Asistencia, se lleva el control de los alumnos que asistieron el dia del refrigerio
**/
create table asistencia(id_Asistencia int identity not null primary key,Fecha date,Consumo bit,presente bit,fk_Estudiante int not null foreign key (fk_Estudiante) references estudiante(id_Estudiante) On Delete Cascade On update cascade)
GO

/**
	Encargado, es el encargado de ingresar los datos 
**/
create table encargado(id_Encargado int identity not null primary key,nombre varchar(255),Apellidos varchar(255),rol varchar(255),usuario varchar(255) not null,pass varchar(255),fk_Grado int not null foreign key (fk_grado) references grado(id_Grado)On Delete Cascade On update cascade)
GO

create table informe(
id_Informe int identity not null primary key,
fk_Alimentos int foreign key (fk_Alimentos) references inventarioAlimentos(id_Alimentos)On Delete Cascade On update cascade,
fk_Grado int foreign key (fk_Grado) references grado(id_Grado)On Delete Cascade On update cascade,
fk_Encargado int foreign key (fk_Encargado) references encargado(id_Encargado)On Delete Cascade On update cascade,
fecha date
)
GO

--creando Login administrador

--el administrador nos servirá para logearnos en la base de datos y no nos de error al conectarnos en el programa
Create Login adminParvularia
with PASSWORD = 'admin123'
GO

--creamos un esquema para que el usuario que crearemos pueda acceder
create schema parvularia
GO

--agregamos las tablas dentro del esquema
Alter schema parvularia transfer informe;
Alter schema parvularia transfer inventarioAlimentos;
Alter schema parvularia transfer movimientoAlimentos;
Alter schema parvularia transfer grado;
Alter schema parvularia transfer encargado;
Alter schema parvularia transfer estudiante;
Alter schema parvularia transfer asistencia;
GO

--Creando usuario administrador
--creamos un usuario para tener derecho a interactuar con la base de datos
CREATE USER adminParvularia FOR LOGIN adminParvularia
WITH DEFAULT_SCHEMA = parvularia
GO

--creamos los permisos del usuario para el esquema
GRANT SELECT ON SCHEMA :: parvularia to adminParvularia with GRANT OPTION;--con esto le decimos a la base de datos que adminClinicas tiene permiso de hacer select a las tablas dentro del esquema
GRANT INSERT ON SCHEMA :: parvularia to adminParvularia with GRANT OPTION;
GRANT UPDATE ON SCHEMA :: parvularia to adminParvularia with GRANT OPTION;
GRANT DELETE ON SCHEMA :: parvularia  to adminParvularia with GRANT OPTION;
GRANT exec ON SCHEMA :: parvularia to adminParvularia with GRANT OPTION;

--Creo un usuario administrador en la base de datos, siempre debe haber alguien para ingresar datos en el programa
	--primero creamos un grado, este grado sera en general para todos los grados
	INSERT INTO parvularia.grado values(0,null,null,null);
	select * from parvularia.grado;
	GO
	
	INSERT INTO parvularia.encargado values('admin0','admin', 'administrador','adminPR', 'admin123',1)
	select * from parvularia.encargado;
	GO

---------------------------------------Procedimientos almacenados
--procedimiento para iniciar sesion
create procedure parvularia.SPIniciarSesion(
	@usuario varchar(50),
	@pass varchar(50)
)
as
		select * from encargado
		where usuario=@usuario and pass = @pass;
GO


--Creando mantenimiento para grados

create procedure parvularia.verGrado(
	@id_Grado int
)as

	select * from parvularia.grado
	where id_Grado = @id_Grado;
GO

create procedure parvularia.insertarGrado(
	@grado int,
	@turno varchar,
	@lectivos int,
	@refrigerio int
)as
	insert into parvularia.grado values(
		@grado, @turno, @lectivos, @refrigerio	
	)
GO

create procedure parvularia.borrarGrado(
	@id_grado int
)as
	delete from parvularia.grado
	where id_Grado = @id_grado
GO

create procedure parvularia.modificarGrado(
	@id_grado int, @grado int, @turno varchar(6), @lectivos int, @refrigerio int
)as
	UPDATE parvularia.grado
	set grado = @grado,
		turno = @turno,
		lectivos = @lectivos,
		refrigerios = @refrigerio
		where id_grado = @id_grado
GO

--creando mantenimiento para estudiantes


create procedure parvularia.verEstudiante(
	@id_Estudiante int
)as

	select * from parvularia.estudiante
	where id_estudiante= @id_Estudiante;
GO

create procedure parvularia.insertarEstudiante(
	@nombre varchar(255),
	@apellido varchar(255),
	@sexo varchar(50),
	@fk_Grado int
)as
	insert into parvularia.estudiante values(
		@nombre, @apellido, @sexo, @fk_Grado
	)
GO

create procedure parvularia.borrarEstudiante(
	@id_estudiante int
)as
	delete from parvularia.estudiante
	where id_Estudiante = @id_estudiante
GO

create procedure parvularia.modificarEstudiante(
	@id_Estudiante int,
	@nombre varchar(255),
	@apellido varchar(255),
	@sexo varchar(50),
	@fk_Grado int
)as
	UPDATE parvularia.estudiante
	set nombre = @nombre,
		apellido = @apellido,
		sexo = @sexo,
		fk_Grado = @fk_Grado
		where id_Estudiante = @id_Estudiante
GO
	
--creando mantenimiento para asistencia


create procedure parvularia.verAsistenciaTotal(
	@id_Estudiante int
)as

	select * from parvularia.asistencia;
GO

create procedure parvularia.verAsistenciaEstudiante(
	@id_Estudiante int
)as

	select * from parvularia.asistencia
	where fk_estudiante= @id_Estudiante;
GO

create procedure parvularia.insertarAsistencia(
	@fecha date,
	@consumo bit,
	@presente bit,
	@fk_estudiante int
)as
	insert into parvularia.asistencia values(
		@fecha,
		@consumo,
		@presente,
		@fk_estudiante
	)
GO

create procedure parvularia.modificarAsistencia(
		@id_asistencia int,
		@consumo bit,
		@presente bit,
		@fk_estudiante int
)as
	UPDATE parvularia.asistencia
	set consumo = @consumo,
		presente = @presente
		where id_Asistencia = @id_asistencia
GO

--creando mantenimiento para inventario

create procedure parvularia.verInventario(
	@id_Alimento int
)as

	select * from parvularia.inventarioAlimentos
	where id_Alimentos = @id_Alimento;
GO

create procedure parvularia.insertarInventario(
	@nombre varchar(255),
	@unidades varchar(255),
	@cantidad int,
	@saldo decimal,
	@caducidad date
)as
	insert into parvularia.inventarioAlimentos values(
	@nombre,
	@unidades,
	@cantidad,
	@saldo,
	@caducidad
	)
GO

create procedure parvularia.borrarInventario(
	@id_inventario int
)as
	delete from parvularia.inventarioAlimentos
	where id_Alimentos = @id_inventario
GO

create procedure parvularia.modificarInventario(
	@id_Inventario int,
	@nombre varchar(255),
	@unidades varchar(255),
	@cantidad int,
	@saldo decimal,
	@caducidad date
)as
	UPDATE parvularia.inventarioAlimentos
	set nombre = @nombre,
		unidades = @unidades,
		cantidad = @cantidad,
		saldo = @saldo,
		FechaCaducidad = @caducidad
		where id_Alimentos = @id_Inventario
GO

--creando mantenimiento para movimiento de alimentos

create procedure parvularia.verMovimiento(
	@codigo char(4)
)as

	select * from parvularia.movimientoAlimentos
	where codigo = @codigo;
GO

create procedure parvularia.insertarMovimiento(
	@codigo char(4),
	@fechaMovimiento date,
	@Lote varchar(255),
	@cantidadAutorizada decimal,
	@envaseEmpaque varchar(255),
	@unidadesCompletas int,
	@unidadesFracciones int,
	@fk_Alimentos int
)as
	insert into parvularia.movimientoAlimentos values(
	@codigo,
	@fechaMovimiento,
	@Lote,
	@cantidadAutorizada,
	@envaseEmpaque,
	@unidadesCompletas,
	@unidadesFracciones,
	@fk_Alimentos
	)
GO

create procedure parvularia.borrarMovimiento(
	@id_inventario int
)as
	delete from parvularia.inventarioAlimentos
	where id_Alimentos = @id_inventario
GO

create procedure parvularia.modificarMovimiento(
@id_Movimiento int,
	@codigo char(4),
	@fechaMovimiento date,
	@Lote varchar(255),
	@cantidadAutorizada decimal,
	@envaseEmpaque varchar(255),
	@unidadesCompletas int,
	@unidadesFracciones int,
	@fk_Alimentos int
)as
	UPDATE parvularia.movimientoAlimentos
	set codigo = @codigo,
		fechaMovimiento = @fechaMovimiento,
		lote = @Lote,
		cantidadAutorizada = @cantidadAutorizada,
		envaseEmpaque = @envaseEmpaque,
		unidadesCompletas = @unidadesCompletas,
		unidadesFracciones = @unidadesFracciones,
		fk_Alimentos = @fk_Alimentos
		where id_Movimiento = @id_Movimiento
GO

--creando mantenimiento para Encargados

create procedure parvularia.verEncargados(
	@id_Encargado int
)as

	select * from parvularia.encargado
	where id_Encargado = @id_Encargado;
GO

create procedure parvularia.insertarEncargado(
	@nombre varchar(255),
	@Apellidos varchar(255),
	@rol varchar(255),
	@usuario varchar(255),
	@pass varchar(255),
	@fk_Grado int

)as
	insert into parvularia.encargado values(
	@nombre,
	@Apellidos,
	@rol,
	@usuario,
	@pass,
	@fk_Grado
	)
GO

create procedure parvularia.borrarEncargado(
	@id_Encargado int
)as
	delete from parvularia.encargado
	where id_Encargado = @id_Encargado
GO

create procedure parvularia.modificarEncargado(
@id_Encargado int,
	@nombre varchar(255),
	@Apellidos varchar(255),
	@rol int,
	@usuario varchar(255),
	@pass varchar(255),
	@fk_Grado int
)as
	UPDATE parvularia.encargado
	set 
	nombre = @nombre,
	apellidos = @Apellidos,
	rol = @rol,
	usuario = @usuario,
	pass = @pass,
	fk_Grado = @fk_Grado
		where id_Encargado = @id_Encargado
GO
