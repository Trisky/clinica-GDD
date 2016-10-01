--===========================================================================================================
--===========================================================================================================		   
CREATE SEQUENCE GRUPOSA.SQ_ID_USUARIO  
    START WITH 1   
    INCREMENT BY 1;  

--===========================================================================================================
--===========================================================================================================
--INSERT TIPOS DE DOCUMENTO
INSERT INTO [GRUPOSA].[TipoDocumento]
           (Tipo_Doc_Desc)
     VALUES
           ( 'DNI')

INSERT INTO [GRUPOSA].[TipoDocumento]
           (Tipo_Doc_Desc)
	VALUES
           ('PASAPORTE')

INSERT INTO [GRUPOSA].[TipoDocumento]
           (Tipo_Doc_Desc)
     VALUES
           ('LC')


--===========================================================================================================
--===========================================================================================================
--/* Planes Medicos */

USE GD2C2016
BEGIN TRANSACTION
	
	DECLARE @plan_cod 					NUMERIC(18,0)
	DECLARE @plan_desc					VARCHAR(255)
	DECLARE @plan_precio_consulta 		NUMERIC(18,0)
	DECLARE @plan_precio_bono_farm		NUMERIC(18,0)

	DECLARE Cur_PlanesMedicos CURSOR FOR
	
		SELECT DISTINCT(plan_med_codigo), plan_med_descripcion,plan_med_precio_bono_consulta,plan_med_precio_bono_farmacia
		FROM gd_esquema.Maestra
		WHERE plan_med_codigo IS NOT NULL
		ORDER BY 1 ASC

	OPEN Cur_PlanesMedicos 
		
		FETCH Cur_PlanesMedicos INTO @plan_cod, @plan_desc, @plan_precio_consulta, @plan_precio_bono_farm	
	
		WHILE (@@FETCH_STATUS = 0)

			BEGIN	

				INSERT INTO [GRUPOSA].[PlanesMedicos]
				([Plan_Codigo],[Plan_Descripcion],[Plan_Precio_Bono_Consulta],[Plan_Precio_Bono_Farmacia])
		   		VALUES
				(@plan_cod, @plan_desc, @plan_precio_consulta, @plan_precio_bono_farm);
					
				FETCH NEXT FROM Cur_PlanesMedicos INTO @plan_cod, @plan_desc, @plan_precio_consulta, @plan_precio_bono_farm
			END
		

	CLOSE Cur_PlanesMedicos

	DEALLOCATE Cur_PlanesMedicos
	
COMMIT TRANSACTION
--===========================================================================================================
--===========================================================================================================
--/* Especialidades Medicas */

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
				([Espe_Cod],[Espe_Desc],[Espe_Tipo_Cod],[Espe_Tipo_Desc])
		   		VALUES
				(@espe_cod, @espe_desc, @espe_tipo_cod, @espe_tipo_desc);
					
				FETCH NEXT FROM Cur_Especialidades INTO @espe_cod, @espe_desc, @espe_tipo_cod, @espe_tipo_desc
			END
		

	CLOSE Cur_Especialidades

	DEALLOCATE Cur_Especialidades
	
COMMIT TRANSACTION

--===========================================================================================================
--===========================================================================================================
		   
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

--===========================================================================================================
--===========================================================================================================
--/* Medicos */
USE GD2C2016
BEGIN TRANSACTION
	
	DECLARE @medi_nom					VARCHAR(255)
	DECLARE @medi_apell					VARCHAR(255)
	DECLARE @medi_dni			 		NUMERIC(18,0)
	DECLARE @medi_direccion				VARCHAR(255)
	DECLARE @medi_mail 					VARCHAR(255)
	DECLARE @medi_telefono				NUMERIC(18,0)
	DECLARE @medi_fecha_nac				DATE
	DECLARE @medi_especialidad			NUMERIC (18,0)
	DECLARE @medi_tipodni				VARCHAR(255)
	DECLARE @medi_usuario 				NUMERIC(18,0)
	DECLARE @var1						NUMERIC(18,0)

	DECLARE Cur_Medicos CURSOR FOR
	
		SELECT medico_nombre, medico_apellido, medico_dni, medico_direccion, medico_fecha_nac, medico_mail, medico_telefono, especialidad_codigo  
		FROM gd_esquema.Maestra 
		WHERE medico_nombre IS NOT NULL
		GROUP BY medico_nombre, medico_apellido, medico_dni, medico_direccion, medico_fecha_nac, medico_mail, medico_telefono, especialidad_codigo
	
	OPEN Cur_Medicos 
		
		FETCH Cur_Medicos INTO @medi_nom, @medi_apell, @medi_dni, @medi_direccion, @medi_fecha_nac, @medi_mail, @medi_telefono, @medi_especialidad
				
		WHILE (@@FETCH_STATUS = 0)
		
			BEGIN	

				SET @medi_usuario = NEXT VALUE FOR GRUPOSA.SQ_ID_USUARIO
				
				INSERT INTO [GRUPOSA].[Medicos]
						   ([Medi_Nombre],[Medi_Apellido],[Medi_Dni],[Medi_Direccion],[Medi_Mail],[Medi_Telefono],[Medi_Fecha_Nac]
						   ,[FK_Medico_Especialidad],[Medi_Usuario])
					 VALUES
						   (@medi_nom, @medi_apell, @medi_dni, @medi_direccion, @medi_mail, @medi_telefono, @medi_fecha_nac, @medi_especialidad, 
						  cast(@medi_usuario as varchar(10)));

				FETCH NEXT FROM Cur_Medicos INTO @medi_nom, @medi_apell, @medi_dni, @medi_direccion, @medi_fecha_nac, @medi_mail, 
				@medi_telefono, @medi_especialidad
			END

	CLOSE Cur_Medicos

	DEALLOCATE Cur_Medicos
	
COMMIT TRANSACTION



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

