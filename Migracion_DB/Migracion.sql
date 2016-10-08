--
--Rev 1.0 - Agrego la migracion para las tablas consultas, turnos, horarios, medico-especialidad, roles-usuario
--

--===========================================================================================================
--===========================================================================================================		   
CREATE SEQUENCE GRUPOSA.SQ_ID_MEDICO
    START WITH 1   
    INCREMENT BY 1;  

CREATE SEQUENCE GRUPOSA.SQ_ID_PACIENTE
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
--INSERT TIPO ROL

INSERT GRUPOSA.[Rol] 
	([Rol_Codigo],[Rol_Nombre],[Rol_Estado],[Rol_Es_Administrador])
VALUES 
	(CAST(0 AS NUMERIC(18, 0)),N'Administrador',0,1)

INSERT GRUPOSA.[Rol] 
	([Rol_Codigo],[Rol_Nombre],[Rol_Estado],[Rol_Es_Administrador])
VALUES 
	(CAST(1 AS NUMERIC(18, 0)),N'Paciente',0,0)

INSERT GRUPOSA.[Rol] 
	([Rol_Codigo],[Rol_Nombre],[Rol_Estado],[Rol_Es_Administrador])
VALUES 
	(CAST(2 AS NUMERIC(18, 0)),N'Medico',0,0)

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
--/* Medicos */

USE GD2C2016
BEGIN TRANSACTION
	
	ALTER TABLE [GRUPOSA].[Medicos] NOCHECK  CONSTRAINT [FK_Medicos_HorariosAtencion]
	
	DECLARE @medi_id					VARCHAR(255)
	DECLARE @medi_nom					VARCHAR(255)
	DECLARE @medi_apell					VARCHAR(255)
	DECLARE @medi_tipodni				NUMERIC(18,0)
	DECLARE @medi_dni			 		NUMERIC(18,0)
	DECLARE @medi_direccion				VARCHAR(255)
	DECLARE @medi_mail 					VARCHAR(255)
	DECLARE @medi_telefono				NUMERIC(18,0)
	DECLARE @medi_fecha_nac				DATE
	DECLARE @medi_usuario 				VARCHAR(255)
	DECLARE @var						NUMERIC(18,0)
	
	DECLARE Cur_Medicos CURSOR FOR
		
		SELECT medico_nombre, medico_apellido, medico_dni, medico_direccion, medico_fecha_nac, medico_mail, medico_telefono 
		FROM gd_esquema.Maestra 
		WHERE medico_nombre IS NOT NULL
		GROUP BY medico_nombre, medico_apellido, medico_dni, medico_direccion, medico_fecha_nac, medico_mail, medico_telefono
		
		SELECT @medi_tipodni = Tipo_Doc_Cod FROM GRUPOSA.TIPODOCUMENTO
		WHERE TIPO_DOC_COD = 1;
		
	OPEN Cur_Medicos 
		
		FETCH Cur_Medicos INTO @medi_nom, @medi_apell, @medi_dni, @medi_direccion, @medi_fecha_nac, @medi_mail, @medi_telefono
				
		WHILE (@@FETCH_STATUS = 0)
		
			BEGIN	
				
				SET @var = NEXT VALUE FOR GRUPOSA.SQ_ID_MEDICO
				SET @medi_id = RIGHT(replicate('0',5) + CAST(@var AS VARCHAR(5)),5)
				SET @medi_usuario = LOWER(@medi_nom) + '_' + LOWER(@medi_apell) + '.' + 'clinica_frba'
				
					INSERT INTO [GRUPOSA].[Medicos]
					   ([Medi_Id],[Medi_Nombre],[Medi_Apellido],[Medi_TipoDocumento],[Medi_Dni],
						[Medi_Direccion],[Medi_Mail],[Medi_Telefono],[Medi_Fecha_Nac],[Medi_Usuario])
					VALUES
					   (@medi_id, @medi_nom, @medi_apell, @medi_tipodni, @medi_dni, 
						@medi_direccion, @medi_mail, @medi_telefono, @medi_fecha_nac, @medi_usuario);

					INSERT INTO [GRUPOSA].[Usuario]
						(Usuario_Username,Usuario_Password,Usuario_Inhabilitado,Usuario_Intentos_Fallidos,Usuario_Fecha_Creacion,Usuario_Fecha_Ultima_Modificacion)
					VALUES
						(@medi_usuario,'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4','FALSE',0,
						 '20160101 00:00:00 AM','20160101 00:00:00 AM');
					
				FETCH NEXT FROM Cur_Medicos INTO @medi_nom, @medi_apell, @medi_dni, @medi_direccion, @medi_fecha_nac, @medi_mail, 
				@medi_telefono
			END

	CLOSE Cur_Medicos

	DEALLOCATE Cur_Medicos
	ALTER TABLE [GRUPOSA].[Medicos] CHECK  CONSTRAINT [FK_Medicos_HorariosAtencion]
	
COMMIT TRANSACTION

--===========================================================================================================
--===========================================================================================================
--/* Pacientes */
USE GD2C2016
BEGIN TRANSACTION

	DECLARE @paci_id					VARCHAR(255)
	DECLARE @paci_nom					VARCHAR(255)
	DECLARE @paci_apell					VARCHAR(255)
	DECLARE @paci_tipodni				NUMERIC(18,0)
	DECLARE @paci_dni			 		NUMERIC(18,0)
	DECLARE @paci_direccion				VARCHAR(255)
	DECLARE @paci_tel					NUMERIC(18,0)
	DECLARE @paci_mail 					VARCHAR(255)
	DECLARE @paci_fecha_nac				DATE
	DECLARE @paci_plan_medi				NUMERIC(18,0)
	DECLARE @paci_usuario 				VARCHAR(255)
	DECLARE @var1						NUMERIC(18,0)

	DECLARE Cur_Pacientes CURSOR FOR
		
		SELECT paciente_nombre, paciente_apellido, paciente_dni, paciente_direccion,
			   paciente_telefono, paciente_mail, paciente_fecha_nac, plan_med_codigo
		FROM gd_esquema.maestra
		GROUP by paciente_nombre,paciente_apellido,paciente_dni,paciente_direccion,paciente_telefono,
				 paciente_mail,paciente_fecha_nac,plan_med_codigo

		SELECT @paci_tipodni = Tipo_Doc_Cod FROM GRUPOSA.TIPODOCUMENTO
		WHERE TIPO_DOC_COD = 1;
		
	OPEN Cur_Pacientes 
		
		FETCH Cur_Pacientes INTO @paci_nom, @paci_apell, @paci_dni, @paci_direccion, @paci_tel, @paci_mail, @paci_fecha_nac, @paci_plan_medi
				
		WHILE (@@FETCH_STATUS = 0)
		
			BEGIN	
				
				SET @var1 = NEXT VALUE FOR GRUPOSA.SQ_ID_PACIENTE
				SET @paci_id = RIGHT(replicate('0',5) + CAST(@var1 AS VARCHAR(5)),5)
				SET @paci_usuario = LOWER(@paci_nom) + '_' + LOWER(@paci_apell) + '.' + 'clinica_frba'
					 
					INSERT INTO [GRUPOSA].[Pacientes]
					   ([Paci_Id],[Paci_Nombre],[Paci_Apellido],[Paci_TipoDocumento],[Paci_Dni],
						[Paci_Direccion],[Paci_Mail],[Paci_Telefono],[Paci_Fecha_Nac],[Paci_Usuario], [FK_Plan_Medico_Codigo])
					VALUES
					   (@paci_id, @paci_nom, @paci_apell, @paci_tipodni, @paci_dni, 
						@paci_direccion, @paci_mail, @paci_tel, @paci_fecha_nac, @paci_usuario, @paci_plan_medi);

				FETCH NEXT FROM Cur_Pacientes INTO @paci_nom, @paci_apell, @paci_dni, @paci_direccion, @paci_tel, @paci_mail, @paci_fecha_nac, @paci_plan_medi
			END

	CLOSE Cur_Pacientes

	DEALLOCATE Cur_Pacientes
	
COMMIT TRANSACTION

--===========================================================================================================
--===========================================================================================================
--/* Medicos-Especialidades */
USE GD2C2016
BEGIN TRANSACTION

	ALTER TABLE [GRUPOSA].[MedicoEspecialidad] NOCHECK  CONSTRAINT [FK_MedEspe_Medico]
	ALTER TABLE [GRUPOSA].[MedicoEspecialidad] NOCHECK  CONSTRAINT [FK_MedEspe_Espe]

	INSERT INTO [GRUPOSA].[MedicoEspecialidad] ([medespe_medi_id],[medespe_espe_cod])
	SELECT DISTINCT(esp.espe_cod), med.medi_id FROM gd_esquema.Maestra AS gdm, gruposa.medicos AS med, gruposa.especialidades AS esp
	WHERE gdm.medico_nombre IS NOT NULL
	AND esp.espe_cod = gdm.especialidad_codigo
	AND med.medi_dni = gdm.medico_dni

	
	ALTER TABLE [GRUPOSA].[MedicoEspecialidad] CHECK  CONSTRAINT [FK_MedEspe_Medico]
	ALTER TABLE [GRUPOSA].[MedicoEspecialidad] CHECK  CONSTRAINT [FK_MedEspe_Espe]
	
COMMIT TRANSACTION

--===========================================================================================================
--===========================================================================================================
--/* Turnos */

USE GD2C2016
BEGIN TRANSACTION

	ALTER TABLE [GRUPOSA].[TURNOS] NOCHECK  CONSTRAINT [FK_Turnos_Consultas]
	ALTER TABLE [GRUPOSA].[TURNOS] NOCHECK  CONSTRAINT [FK_Turnos_TiposCancelacion]

	INSERT INTO [GRUPOSA].[TURNOS] 
		([Turn_Numero],[Turn_Fecha], [Turn_Paciente_Id],[Turn_Medico_Id],[Turn_cancelado],[Turn_CanceladoPorAfiliado], [Turn_FK_Consulta])
	SELECT DISTINCT(GDM.TURNO_NUMERO), GDM.TURNO_FECHA, PAC.PACI_ID, MED.MEDI_ID , 0, 0, 1
	FROM GD_ESQUEMA.MAESTRA AS GDM, GRUPOSA.PACIENTES AS PAC, GRUPOSA.MEDICOS AS MED
	WHERE GDM.MEDICO_DNI = MED.MEDI_DNI
	AND PAC.PACI_DNI = GDM.PACIENTE_DNI

	ALTER TABLE [GRUPOSA].[TURNOS] CHECK  CONSTRAINT [FK_Turnos_Consultas]
	ALTER TABLE [GRUPOSA].[TURNOS] CHECK  CONSTRAINT [FK_Turnos_TiposCancelacion]
	
COMMIT TRANSACTION

--===========================================================================================================
--===========================================================================================================
--/* Consultas */

USE GD2C2016
BEGIN TRANSACTION

	INSERT INTO [GRUPOSA].[CONSULTAS] ([Cons_Sintomas], [Cons_Enfermedades])
	SELECT DISTINCT(consulta_enfermedades), consulta_sintomas 
	FROM gd_esquema.maestra
	WHERE consulta_enfermedades IS NOT NULL
	GROUP BY consulta_enfermedades, consulta_sintomas
	
COMMIT TRANSACTION

--===========================================================================================================
--===========================================================================================================
--/* Roles-Usuario */

USE GD2C2016
BEGIN TRANSACTION

	ALTER TABLE [GRUPOSA].[ROLESUSUARIO] NOCHECK  CONSTRAINT [FK_Usuario_RolesUsuario]

	INSERT INTO [GRUPOSA].[ROLESUSUARIO] ([RolUsu_Usuario_Username], [RolUsu_Rol_Codigo])
	SELECT DISTINCT(MED.Medi_Usuario), ROL.Rol_Codigo FROM GRUPOSA.Medicos AS MED, GRUPOSA.Rol AS ROL
	WHERE LOWER(ROL.Rol_Nombre) = LOWER('MEDICO')
	
	INSERT INTO [GRUPOSA].[ROLESUSUARIO] ([RolUsu_Usuario_Username], [RolUsu_Rol_Codigo])
	SELECT DISTINCT(PAC.Paci_Usuario), ROL.Rol_Codigo FROM GRUPOSA.Pacientes AS PAC, GRUPOSA.Rol AS ROL
	WHERE LOWER(ROL.Rol_Nombre) = LOWER('PACIENTE')
	
	ALTER TABLE [GRUPOSA].[ROLESUSUARIO] CHECK  CONSTRAINT [FK_Usuario_RolesUsuario]
			
COMMIT TRANSACTION

--===========================================================================================================
--===========================================================================================================
--/* HORARIOS-Usuario */

USE GD2C2016
BEGIN TRANSACTION
	
	INSERT INTO [GRUPOSA].[HorariosAtencion] ([Hora_Inicio],[Hora_Fin],[Horario_FK_Medico_Usuario])
	SELECT CAST(DATEPART(HOUR,MIN(TURN_FECHA)) AS CHAR(1))+':'+CAST(DATEPART(MINUTE,MIN(TURN_FECHA)) AS CHAR(1)) + '0' AS HORA_ENTRADA,
		   CAST(DATEPART(HOUR,MAX(TURN_FECHA)) AS CHAR(2))+':'+CAST(DATEPART(MINUTE,MAX(TURN_FECHA)) AS CHAR(2)) AS HORA_SALIDA,
		   MED.Medi_Usuario
		   FROM GRUPOSA.TURNOS AS TUR, GRUPOSA.Medicos AS MED
		   WHERE TUR.Turn_Medico_Id = MED.Medi_Id
	GROUP BY Medi_Usuario
	ORDER BY 3;
		
COMMIT TRANSACTION


/*
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


*/