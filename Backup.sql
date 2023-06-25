CREATE DATABASE ExamenTecnicoDB
GO
USE ExamenTecnicoDB
CREATE TABLE VENTAS(
	ID_VENTA INT NOT NULL PRIMARY KEY,
	Fecha_venta datetime,
	Dni_cliente varchar(10),
	Nombre_empleado varchar(100),
	Nombre_cliente varchar(100),
	Importe_total decimal(10,2),
	Direccion_envio_cliente varchar(100),
	Direccion_sucursal_venta varchar(100),
	Nombre_sucursal_venta varchar(100),
	Producto varchar(10),
	Cantidad int
)
GO

INSERT INTO VENTAS (ID_VENTA, Fecha_venta) VALUES (10, '2023-06-22')
INSERT INTO VENTAS (ID_VENTA, Fecha_venta) VALUES (11, '2023-06-22')
INSERT INTO VENTAS (ID_VENTA, Fecha_venta) VALUES (25, '2023-06-23')
INSERT INTO VENTAS (ID_VENTA, Fecha_venta) VALUES (29, '2023-06-23')
INSERT INTO VENTAS (ID_VENTA, Fecha_venta) VALUES (30, '2023-06-23')
INSERT INTO VENTAS (ID_VENTA, Fecha_venta) VALUES (31, '2023-06-24')
INSERT INTO VENTAS (ID_VENTA, Fecha_venta) VALUES (32, '2023-06-24')
GO

CREATE PROC GetFechaMayoresVentas
AS
BEGIN 
SELECT TOP 1 Fecha_venta
FROM VENTAS
GROUP BY Fecha_venta 
ORDER BY COUNT(*) DESC
END
GO

EXEC GetFechaMayoresVentas

CREATE TABLE EmpleadosPendientes(
	Id_empleado INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Legajo varchar(20),
	Apellido varchar(30),
	Nombre varchar(30),
	Dni Bigint,
	Cuil BigInt,
	Fecha_nacimiento datetime
)

GO

CREATE PROC IngresarEmpleadoPendiente
(
	@Legajo varchar(20),
	@Apellido varchar(30),
	@Nombre varchar(30),
	@Dni BigInt,
	@Cuil BigInt,
	@Fecha_nacimiento datetime
)
AS
	INSERT INTO EmpleadosPendientes(Legajo, Apellido, Nombre, Dni, Cuil, Fecha_nacimiento) 
	VALUES (@Legajo, @Apellido, @Nombre, @Dni, @Cuil, @Fecha_nacimiento)
GO

CREATE PROC ObtenerEmpleadosPendientes
AS
BEGIN
SELECT * FROM EmpleadosPendientes
END
GO

