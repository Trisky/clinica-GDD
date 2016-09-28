--1 creacion usuarios pacientes
DECLARE @fecha DATETIME

SET @fecha = GETDATE()

INSERT GRUPOSA.Usuario
SELECT DISTINCT GRUPOSA.ObtenerUserName(Paciente_Nombre, Paciente_Apellido, Paciente_Fecha_Nac)
	,'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4' 
	,@fecha --f. creacion
	,NULL --f. ultima modificacion
	,'' -- p secreta
	,'' -- r secreta
	,0 -- intentos fallidos
	,0 -- inhabilitado?
	,Paciente_Dni -- es paciente
	,Medico_Dni -- noes medico!
FROM GD2C2016.gd_esquema.Maestra 
Where Paciente_Nombre is not null

go
--===========================================================================================================
--===========================================================================================================
--2 creacion usuarios medicos
DECLARE @fecha DATETIME

SET @fecha = GETDATE()

INSERT GRUPOSA.Usuario
SELECT DISTINCT GRUPOSA.ObtenerUserName(Medico_Nombre,Medico_Apellido,Medico_Fecha_Nac)
	,'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'
	,@fecha --f. creacion
	,NULL --f. ultima modificacion
	,'' -- p secreta
	,'' -- r secreta
	,0 -- intentos fallidos
	,0 -- inhabilitado?
	,null --no es paciente
	,Medico_Dni --es medico!
FROM GD2C2016.gd_esquema.Maestra 
Where Medico_Dni is not null 

go
--===========================================================================================================
--===========================================================================================================
--3 copio planes medicos
insert GRUPOSA.PlanesMedicos
select distinct Plan_Med_Codigo,Plan_Med_Descripcion,Plan_Med_Precio_Bono_Consulta,Plan_Med_Precio_Bono_Farmacia
from GD2C2016.gd_esquema.Maestra
--===========================================================================================================
--===========================================================================================================
/* 4 - ABM Especialidades Medicas */

USE GD2C2016
BEGIN TRANSACTION
	
	DECLARE @espe_cod 			NUMERIC(18,0)
	DECLARE @espe_desc			VARCHAR(255)
	DECLARE @espe_tipo_cod 		NUMERIC(18,0)
	DECLARE @espe_tipo_desc		VARCHAR(255)

	DECLARE Cur_Especialidades CURSOR FOR
	
		SELECT DISTINCT(especialidad_codigo), especialidad_descripcion, tipo_especialidad_codigo, tipo_especialidad_descripcion 
		FROM gd_esquema.Maestra
		WHERE especialidad_codigo IS NOT NULL
		ORDER BY 1 ASC

	OPEN Cur_Especialidades 
		
		FETCH Cur_Especialidades INTO @espe_cod, @espe_desc, @espe_tipo_cod, @espe_tipo_desc
		WHILE (@@FETCH_STATUS = 0)

			BEGIN	

				INSERT INTO [GRUPOSA].[Especialidades]
				([Especialidad_Cod],[Especialidad_Desc],[Especialidad_Tipo_Cod],[Especialidad_Tipo_Desc])
		   		VALUES
				(@espe_cod, @espe_desc, @espe_tipo_cod, @espe_tipo_desc);
					
				FETCH NEXT FROM Cur_Especialidades INTO @espe_cod, @espe_desc, @espe_tipo_cod, @espe_tipo_desc
			END
		

	CLOSE Cur_Especialidades

	DEALLOCATE Cur_Especialidades
	
COMMIT TRANSACTION

--===========================================================================================================
--===========================================================================================================
--5 tipos de documento
insert GRUPOSA.TipoDocumento
VALUES (
	CAST(0 AS NUMERIC(18, 0))
	,N'DNI'
	)
GO
insert GRUPOSA.TipoDocumento
VALUES (
	CAST(1 AS NUMERIC(18, 0))
	,N'Pasaporte'
	)
GO
insert GRUPOSA.TipoDocumento
VALUES (
	CAST(2 AS NUMERIC(18, 0))
	,N'LC'
	)
GO
--===========================================================================================================
--===========================================================================================================
--6 tipos de rol

INSERT GRUPOSA.[Rol] (
	[Rol_Codigo]
	,[Rol_Nombre]
	,[Rol_Estado]
	,[Rol_Es_Administrador]
	)
VALUES (
	CAST(0 AS NUMERIC(18, 0))
	,N'Administrador'
	,0
	,1
	)
	go
INSERT GRUPOSA.[Rol] (
	[Rol_Codigo]
	,[Rol_Nombre]
	,[Rol_Estado]
	,[Rol_Es_Administrador]
	)
VALUES (
	CAST(1 AS NUMERIC(18, 0))
	,N'Paciente'
	,0
	,0
	)
	go
INSERT GRUPOSA.[Rol] (
	[Rol_Codigo]
	,[Rol_Nombre]
	,[Rol_Estado]
	,[Rol_Es_Administrador]
	)
VALUES (
	CAST(2 AS NUMERIC(18, 0))
	,N'Medico'
	,0
	,0
	)
GO

