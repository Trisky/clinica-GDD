------------------------------------------------------------------------------------------------
------------------------TRABAJO PRACTICO GESTION DE DATOS---------------------------------------
----------------------------SCHEMA GRUPOSA------------------------------------------------------
------------------------------------------------------------------------------------------------
-----------------------------------SCHEMA-------------------------------------------------------
USE [GD2C2016]
GO
CREATE SCHEMA [GRUPOSA]
GO
-----------------------------------PROCEDURES---------------------------------------------------
------------------------------------------------------------------------------------------------
--sp_bajaLogica: Realiza una baja logica sobre el usuario 
GO
CREATE PROCEDURE [GRUPOSA].[sp_bajaLogica] (@usuario VARCHAR(250), @fechaHoy DATETIME)
AS   
    DECLARE @estadoActual BIT
	
	SELECT @estadoActual = Usuario_Habilitado FROM GRUPOSA.[Usuario] WHERE Usuario_Username = @usuario
	
	IF (@estadoActual = 1 ) 
		BEGIN
			UPDATE GRUPOSA.[Usuario] 
			SET Usuario_Habilitado = 0
			WHERE Usuario_Username = @usuario
			
			UPDATE GRUPOSA.[Paciente]
			SET Paci_estado = 0
			WHERE paci_usuario = @usuario
			AND Paci_Fecha_Baja = @fechaHoy; --GETDATE();
			
		
		END

	ELSE
		BEGIN
			UPDATE GRUPOSA.[Usuario] 
			SET Usuario_Habilitado = 1
			WHERE Usuario_Username = @usuario
			
			UPDATE GRUPOSA.[Paciente]
			SET Paci_estado = 1
			WHERE paci_usuario = @usuario
			AND Paci_Fecha_Baja = @fechaHoy; --GETDATE();
			
		END
GO
------------------------------------------------------------------------------------------------
--sp_turnosUsuarioBaja: Borra los turnos de un usuario, utilizr si cambia de plan se desafilia.
GO
CREATE PROCEDURE [GRUPOSA].[sp_turnosUsuarioBaja]
    @usuario VARCHAR(250)
AS   
    
	DECLARE @matricula VARCHAR(250);
	
	SELECT @matricula = Paci_Matricula FROM GRUPOSA.Paciente Paci
	WHERE Paci.Paci_Usuario = @usuario
	
	DELETE FROM GRUPOSA.Consultas
	WHERE Cons_Id_Turno IN (SELECT Turn_Numero FROM GRUPOSA.Turnos
							WHERE SUBSTRING(Turn_Paciente_Id,1,6) IN (SELECT SUBSTRING(Paci_Matricula,1,6) 
																	   FROM GRUPOSA.Paciente Paci
																	   WHERE Paci.Paci_Usuario = @usuario))
							   
	DELETE FROM GRUPOSA.Turnos
	WHERE SUBSTRING(Turn_Paciente_Id,1,6) IN (SELECT SUBSTRING(Paci_Matricula,1,6) FROM GRUPOSA.Paciente Paci
											  WHERE Paci.Paci_Usuario = @usuario)
							   
GO
------------------------------------------------------------------------------------------------
--sp_confirmacionTurno: Confirma un turno y se añade a la base.
GO
CREATE PROCEDURE [GRUPOSA].[sp_confirmacionTurno]
    @fecha 			VARCHAR (250),
	@hora			VARCHAR (250),
	@paciente		VARCHAR (250),
	@medico			VARCHAR (250),
	@especialidad	VARCHAR (250)
AS   
	DECLARE @turno NUMERIC (18,0);
	DECLARE @fecha_confirmada DATETIME;
	DECLARE @paciente_id VARCHAR(250);
	
	BEGIN
	
	SELECT @fecha_confirmada = CAST(@fecha AS DATETIME) + CAST(@hora AS DATETIME )
	SELECT @turno = MAX(Turn_Numero) + 1 FROM GRUPOSA.Turnos;
	SELECT @paciente_id = Paci_Matricula FROM GRUPOSA.Paciente WHERE Paci_Usuario = @paciente;
	
	
	INSERT INTO [GRUPOSA].[Turnos]
           ([Turn_Numero],[Turn_Fecha],[Turn_Paciente_Id],[Turn_Medico_Id],[Turn_Especialidad])
    VALUES(@turno, @fecha_confirmada, @paciente_id, @medico, @especialidad)
	
	INSERT INTO [GRUPOSA].[Consultas]
           ([Cons_Id_Turno],[Cons_Id_Bono],[Cons_Bono_Fecha],[Cons_Fecha_Turno],[Cons_Realizada],[Cons_Sintomas],[Cons_Enfermedades],[Cons_Diagnostico])
     VALUES
		   (@turno, NULL, NULL, @fecha_confirmada, 0, NULL, NULL, NULL)
		   
	UPDATE GRUPOSA.Bonos
	SET Bono_Fecha_Compra_Usado = @fecha_confirmada
	WHERE Bono_Id = (SELECT MAX(Bono_Id) FROM GRUPOSA.bonos 
					 WHERE Bono_Paci_Id = @paciente_id 
					 AND Bono_Fecha_Compra_Usado IS NULL)

	END 
GO

------------------------------------------------------------------------------------------------
--sp_cambioDePlan: Cambia de plan y registra el movimiento.
GO
CREATE PROCEDURE [GRUPOSA].[sp_cambioDePlan]
    @usuario VARCHAR(250),
	@nuevoPlan [NUMERIC] (18,0),
	@motivo VARCHAR (250),
	@fechaHoy DATETIME
AS   
	DECLARE @viejoPlan [NUMERIC] (18,0);
	
	SELECT @viejoPlan = Paci_Plan_Med_Cod_FK FROM GRUPOSA.Paciente Paci
	WHERE Paci.Paci_Usuario = @usuario
	
	INSERT INTO [GRUPOSA].[Auditoria_Plan] ([Auditoria_Usuario],[Auditoria_Plan_Antiguo],[Auditoria_Plan_Nuevo],[Auditoria_Motivo],[Auditoria_Fecha] )
	VALUES (@usuario, @viejoPlan, @nuevoPlan, @motivo, @fechaHoy);
	
	UPDATE GRUPOSA.Paciente 
	SET Paci_Plan_Med_Cod_FK = @nuevoPlan
	WHERE Paci_Usuario = @usuario 
	AND SUBSTRING(Paci_Matricula,1,6) IN (SUBSTRING(Paci_Matricula,1,6)) ;
	
GO
------------------------------------------------------------------------------------------------
--fnc_cantidadDeRolesUsuario: Devuelve la cantidad de roles del usuario para decidir el inicio.
GO
CREATE FUNCTION [GRUPOSA].fnc_cantidadDeRolesUsuario ( @usuario varchar(255) ) 
RETURNS INT
AS  
BEGIN 
    DECLARE @ret int;
		
    SELECT @ret = COUNT(*)   
    FROM GRUPOSA.RolesUsuario AS rolu   
    WHERE rolu.RolUsu_Usuario_Username = @usuario

	RETURN @ret;  
    END
GO
------------------------------------------------------------------------------------------------
--fnc_AfiliadoActivo: Verifica que un afiliado esta habilitado.
GO
CREATE FUNCTION [GRUPOSA].fnc_AfiliadoActivo ( @usuario varchar(255) ) 
RETURNS BIT
AS  
BEGIN 
    DECLARE @ret BIT;
			
    SELECT  @ret = Usuario_Habilitado    
    FROM GRUPOSA.Usuario AS US   
    WHERE US.Usuario_Username = @usuario

	RETURN @ret;  
    END
GO	
------------------------------------------------------------------------------------------------
--sp_cambiarEstadoRol: Cambia el estado de habilitado a inhabilitado y viceversa.
GO
CREATE PROCEDURE [GRUPOSA].[sp_cambiarEstadoRol]
    @rolCodigo NUMERIC(18,0)
AS   
    DECLARE @estadoActual NUMERIC (18,0)
		
	SELECT  @estadoActual = Rol_Estado FROM GRUPOSA.[Rol] WHERE Rol_Codigo = @rolCodigo
	
	IF (@estadoActual = 1 ) 
		BEGIN
			UPDATE GRUPOSA.[Rol] 
			SET Rol_Estado = 0
			WHERE Rol_Codigo = @rolCodigo
		END
	ELSE
		BEGIN
			UPDATE GRUPOSA.[Rol] 
			SET Rol_Estado = 1
			WHERE Rol_Codigo = @rolCodigo
		END
GO
------------------------------------------------------------------------------------------------
--fnc_nombreRol: Devuelve SI EXISTE EL ROL del rol enviado.
CREATE FUNCTION [GRUPOSA].[fnc_nombreRolExiste] (@nombreRol NUMERIC(18,0))
RETURNS NUMERIC(18,0)
AS
BEGIN
	DECLARE @existeRol NUMERIC(18,0)

	SELECT @existeRol = 1 FROM GRUPOSA.Rol R WHERE R.Rol_Nombre = @nombreRol
	RETURN ISNULL(@existeRol,0) --1 Existe, 0 No existe
END
GO
------------------------------------------------------------------------------------------------
--sp_intentoLogin: Modifica el estado de un usuario.
GO
CREATE PROCEDURE [GRUPOSA].[sp_intentoLogin](@usuario  VARCHAR(250), @password  VARCHAR(250))
AS
BEGIN
DECLARE @RET NUMERIC(18,0);
DECLARE @intentos NUMERIC(18,0);
DECLARE @existe_usuario NUMERIC(2);
	
	SELECT @existe_usuario = 1 FROM GRUPOSA.Usuario
    WHERE Usuario_Username = @usuario
	
	IF @existe_usuario = 1
		
		SET @RET = 0

		SELECT @intentos = Usuario_Intentos_Fallidos FROM GRUPOSA.Usuario
		WHERE Usuario_Username = @usuario
			
		IF (@password <> (SELECT Usuario_Password FROM GRUPOSA.Usuario WHERE Usuario_Username = @usuario))
			BEGIN
			SET @RET = 1
						
			IF (@intentos < 3) 
				BEGIN
				UPDATE GRUPOSA.Usuario
				SET Usuario_Intentos_Fallidos = Usuario_Intentos_Fallidos + 1
				WHERE Usuario_Username = @usuario
				END
			ELSE 
				BEGIN
				UPDATE GRUPOSA.Usuario
				SET Usuario_Habilitado = 1 --Inhabilitado
				WHERE Usuario_Username = @usuario
				END
			END
		ELSE
			BEGIN
			UPDATE GRUPOSA.Usuario
			SET Usuario_Habilitado = 0, --Habilitado
				Usuario_Intentos_Fallidos = 0
			WHERE Usuario_Username = @usuario	

			SET @RET = 0
			END
RETURN @RET
END
GO
------------------------------------------------------------------------------------------------
--sp_modificarAfiliado: Modifica un afiliado apartir de su id.
GO
CREATE PROCEDURE [GRUPOSA].[sp_modificarAfiliado]
	@afiliadoId	VARCHAR(250),
	@paci_tipodni VARCHAR(255),
	@paci_direccion VARCHAR(250), 
	@paci_tel VARCHAR(250),
	@paci_mail VARCHAR(250), 
	@paci_sexo VARCHAR(250),
	@paci_estado_civil VARCHAR(250),
	@paci_plan_medi VARCHAR(250),
	@motivo VARCHAR (250),
	@fechaHoy DATETIME
AS 
	
	DECLARE @viejoPlan [NUMERIC] (18,0);
	DECLARE @tel NUMERIC(18,0);
	DECLARE @plan NUMERIC(18,0);

	SET @tel = CAST(@paci_tel AS NUMERIC(18,0))
	SET @plan = CAST(@paci_plan_medi AS NUMERIC(18,0))

BEGIN
	
	UPDATE GRUPOSA.Paciente
	SET	Paci_TipoDocumento = ISNULL(@paci_tipodni,Paci_TipoDocumento),
		Paci_Telefono = ISNULL(@tel,Paci_Telefono),
		Paci_Sexo = ISNULL(@paci_sexo,Paci_Sexo),
		Paci_Direccion = ISNULL(@paci_direccion,Paci_Direccion),
		Paci_Mail = ISNULL(@paci_mail, Paci_Mail),
		Paci_Estado_Civil = ISNULL(@paci_estado_civil, Paci_Estado_Civil)
	WHERE @afiliadoId = Paci_Matricula;	

	
	SELECT @viejoPlan = Paci_Plan_Med_Cod_FK FROM GRUPOSA.Paciente Paci
	WHERE Paci.Paci_Matricula = @afiliadoId
	
	IF @plan <> @viejoPlan
		BEGIN
		
		INSERT INTO [GRUPOSA].[Auditoria_Plan] ([Auditoria_Usuario],[Auditoria_Plan_Antiguo],[Auditoria_Plan_Nuevo],[Auditoria_Motivo],[Auditoria_Fecha] )
		VALUES (@afiliadoId, @viejoPlan, @plan, @motivo, @fechaHoy);
		
		UPDATE GRUPOSA.Paciente 
		SET Paci_Plan_Med_Cod_FK = ISNULL(@plan,Paci_Plan_Med_Cod_FK)
		WHERE SUBSTRING(Paci_Matricula,1,6) IN (SUBSTRING(Paci_Matricula,1,6)) ;
			
		END
		
END;
GO
------------------------------------------------------------------------------------------------
--sp_crearAfiliado: Modifica un afiliado apartir de su id. 
--					Necesita tambien recibir el tipo familiar asi se agrega al grupo o no
GO
CREATE PROCEDURE [GRUPOSA].[sp_crearAfiliado]
	@paci_nom 				VARCHAR(250),
	@paci_apell 			VARCHAR(250),
	@paci_tipodni 			VARCHAR(255),
	@paci_dni				VARCHAR(250),
	@paci_direccion 		VARCHAR(250), 
	@paci_tel 				VARCHAR(250),
	@paci_mail 				VARCHAR(250), 
	@paci_fecha_nac 		VARCHAR(250),
	@paci_sexo 				VARCHAR(250),
	@paci_estado_civil 		VARCHAR(250),
	@paci_plan_medi 		VARCHAR(250),
	@paci_tipoFamiliar 		VARCHAR(250),
	@fechaHoy 				VARCHAR(250)
AS   
	DECLARE @var1 			NUMERIC (18,0);
	DECLARE @paci_usuario 	VARCHAR(255);
	DECLARE @paci_matricula VARCHAR(250);
	DECLARE @hoy DATE;
	DECLARE @dni NUMERIC(18,0);
	DECLARE @tel NUMERIC(18,0);
	DECLARE @fnac DATE;
	DECLARE @plan NUMERIC(18,0);

	SET @hoy = CAST(@fechaHoy AS DATE)
	SET @dni = CAST(@paci_dni AS NUMERIC(18,0))
	SET @tel = CAST(@paci_tel AS NUMERIC(18,0))
	SET @fnac = CAST(@paci_fecha_nac AS DATE)
	SET @plan = CAST(@paci_plan_medi AS NUMERIC(18,0))
	
	SET @var1 = NEXT VALUE FOR GRUPOSA.SQ_ID_PACIENTE
	SET @paci_matricula = RIGHT(replicate('0',5) + CAST(@var1 AS VARCHAR(5)) + @paci_tipoFamiliar, 8)
	SET @paci_usuario = LOWER(@paci_nom) + '_' + LOWER(@paci_apell) + '_' + @paci_matricula
	
	BEGIN TRANSACTION
	--Usuarios Medicos y Pacientes
	INSERT INTO [GRUPOSA].[Usuario] ([Usuario_Username],[Usuario_Password],[Usuario_Fecha_Creacion],[Usuario_Fecha_Ultima_Modificacion], [Usuario_Intentos_Fallidos], [Usuario_Habilitado])
	VALUES (@paci_usuario, '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4' , @hoy, NULL,0,0);
	COMMIT TRANSACTION;
	
	IF (@paci_tipoFamiliar <> '01')
	BEGIN
		SELECT @paci_matricula = SUBSTRING(MAX(Paci_Matricula),1,6) + @paci_tipoFamiliar FROM GRUPOSA.Paciente
	END
	
	BEGIN TRANSACTION
	INSERT INTO [GRUPOSA].[Paciente]
	   ([Paci_Matricula],[Paci_Nombre],[Paci_Apellido],[Paci_TipoDocumento],[Paci_Dni],
		[Paci_Direccion],[Paci_Telefono],[Paci_Mail],[Paci_Fecha_Nac],[Paci_Sexo],[Paci_Estado_Civil],
		[Paci_Plan_Med_Cod_FK], [Paci_Usuario], [Paci_Grupo_Fliar])
	VALUES
	    (@paci_matricula, @paci_nom, @paci_apell, @paci_tipodni, @dni, @paci_direccion, @tel, @paci_mail, 
		@fnac, @paci_sexo, @paci_estado_civil, @plan , @paci_usuario, @paci_tipoFamiliar);
	COMMIT TRANSACTION;
GO

--sp_AltaRol: Agrega Rol
GO
CREATE PROCEDURE [GRUPOSA].[sp_AltaRol]
    @nombre VARCHAR(250),
	@estado BIT,
	@esAdministrador BIT
AS   
	
	BEGIN TRANSACTION 
	
	INSERT INTO [GRUPOSA].[Rol]
           ([Rol_Nombre],[Rol_Estado],[Rol_Es_Administrador])
    VALUES
           (@nombre,@estado,@esAdministrador)
	
	COMMIT TRANSACTION;
GO

--sp_medicosEspecialidad: Devuelve el nombre de los medicos de la especialidad recibida.
CREATE PROCEDURE [GRUPOSA].[sp_medicosEspecialidad] (@id_especialidad NUMERIC(18,0))
AS
BEGIN
	
	SELECT Esp.MedEspe_Medi_Id, UPPER(Med.Medi_Nombre+' ' + Med.Medi_Apellido) AS medico 
	FROM GRUPOSA.MedicoEspecialidad Esp, GRUPOSA.Medico Med 
	WHERE Esp.MedEspe_Espe_Cod = @id_especialidad
	AND Esp.MedEspe_Medi_Id = Med.Medi_Id;
	
END
GO 

---------------------------------------------------------------------------------------------
--sp_medicosEspecialidad: Devuelve el nombre de los medicos de la especialidad recibida.
CREATE PROCEDURE [GRUPOSA].[sp_turnosOcupadosDelDia] (@idMedico VARCHAR(250), @fecha VARCHAR(250))
AS
BEGIN
	
	SELECT T.Turn_Numero AS Turno,
		   SUBSTRING(CAST(CAST(T.Turn_Fecha AS TIME) AS varchar),1,5) AS Hora,
		   (SELECT UPPER(P.Paci_Apellido) + ' ' + UPPER(P.paci_nombre) FROM GRUPOSA.Paciente P WHERE P.Paci_Matricula = t.Turn_Paciente_Id ) AS Paciente
	FROM GRUPOSA.Turnos t
	WHERE Turn_Medico_Id = @IdMedico
	AND CAST(Turn_Fecha AS DATE) = CAST(@fecha AS DATE)
	AND Turn_Numero NOT IN (SELECT TC.Cancelacion_Turno_Id FROM GRUPOSA.TurnosCancelacion TC);
	
END
GO 

---------------------------------------------------------------------------------------------
--sp_turnosMedicosDisponibles: Devuelve los turnos disponibles del dia.
CREATE PROCEDURE [GRUPOSA].[sp_turnosMedicosDisponibles] (@diaConsultado VARCHAR(255), @especialidad VARCHAR(255),@id_medico VARCHAR(255))
AS
DECLARE @mediId VARCHAR(255);
DECLARE @mediEspecialidad VARCHAR(255);

BEGIN

SELECT HT.hora_turno FROM GRUPOSA.TurnosDisponible HT
WHERE HT.hora_turno NOT IN (SELECT CAST(TU.turn_fecha AS TIME) FROM GRUPOSA.Turnos TU, GRUPOSA.HorariosAtencion HA 
							WHERE TU.Turn_Medico_Id = @id_medico
							AND TU.turn_numero NOT IN (SELECT Cancelacion_Turno_Id FROM GRUPOSA.TurnosCancelacion C)
							AND TU.Turn_Especialidad = @especialidad
							AND CAST(TU.turn_fecha AS DATE) = CAST(@diaConsultado AS DATE)
							AND TU.Turn_Medico_Id = HA.Hora_Medico_Id_FK
							AND TU.Turn_Especialidad = HA.Hora_Especialidad)

AND HT.hora_turno < (SELECT CAST(HI.Hora_Fin AS TIME) FROM GRUPOSA.HorariosAtencion HI
					 WHERE HI.Hora_Medico_Id_FK = @id_medico
					 AND HI.Hora_Especialidad = @especialidad
					 AND HI.Hora_Dia = DATENAME(WEEKDAY, @diaConsultado))

END
GO
--------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [GRUPOSA].[sp_cerrarConsulta] (@turnoId NUMERIC(18,0), @diagnostico VARCHAR(255), @enfermedad VARCHAR(255), @sintomas VARCHAR(250), @idBono NUMERIC (18,0), @fechaHoy DATETIME)
AS
BEGIN
	
	UPDATE GRUPOSA.Consultas
	SET Cons_Diagnostico = @diagnostico,
		Cons_Sintomas = @sintomas,
		Cons_Enfermedades = @enfermedad,
		Cons_Id_Bono = @idBono,
		Cons_Bono_Fecha = @fechaHoy,
		Cons_Realizada = 1
	WHERE Cons_Id_Turno = @turnoId
	
END
GO
--------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [GRUPOSA].[sp_turnosActivosPaciente]
@paci_usuario VARCHAR(255)
AS
SELECT t.Turn_Numero,(m.Medi_Apellido)+', '+m.Medi_Nombre 'Doctor',e.Espe_Desc 'Especialidad',t.Turn_Fecha 'Fecha'
FROM GRUPOSA.Turnos t
JOIN GRUPOSA.Paciente p
ON t.Turn_Paciente_Id=p.Paci_Matricula
join GRUPOSA.Medico m
ON m.Medi_Id=t.Turn_Medico_Id
JOIN GRUPOSA.Especialidades e
ON e.Espe_Cod=t.Turn_Especialidad
WHERE p.Paci_Usuario=@paci_usuario
and Turn_Numero not in (select c.Cancelacion_Turno_Id from GRUPOSA.TurnosCancelacion c)
GO

CREATE PROCEDURE [GRUPOSA].[sp_obtenerDiasDeAtencion]
@id_medico VARCHAR(255)
AS
SELECT h.Hora_Dia
FROM GRUPOSA.HorariosAtencion h
WHERE h.Hora_Medico_Id_FK=@id_medico
GO

CREATE PROCEDURE [GRUPOSA].[sp_obtenerDiasDeAtencion2]
@id_medico VARCHAR(255),
@especialidad VARCHAR(255)
AS
SELECT h.Hora_Dia
FROM GRUPOSA.HorariosAtencion h
WHERE h.Hora_Medico_Id_FK=@id_medico
AND h.Hora_Especialidad=@especialidad
GO

CREATE PROCEDURE [GRUPOSA].[sp_bajaTurnosMedico]
	@fecha VARCHAR(255),
	@medico VARCHAR(255),
	@tipo NUMERIC(18,0),
	@descripcion VARCHAR(255),
	@fechaHoy DATETIME
AS
DECLARE @cant NUMERIC(18,0)
DECLARE @ind NUMERIC(18,0)
DECLARE @id_turno NUMERIC(18,0)

	CREATE TABLE #turnosDelDia(
								id_turno NUMERIC(18,0) IDENTITY(1,1),
								num_turno VARCHAR(255)
							   )
	
	SET @ind=1
	
	INSERT #turnosDelDia
	SELECT T.Turn_Numero FROM gruposa.Turnos T
	WHERE CONVERT(VARCHAR(10), Turn_Fecha, 103) = @fecha
	AND T.Turn_Medico_Id=@medico

	SELECT @cant=COUNT(*)+1 FROM #turnosDelDia
	WHILE @ind!=@cant
		BEGIN
			SELECT @id_turno=TD.num_turno FROM #turnosDelDia TD 
			WHERE TD.id_turno=@ind
			
			INSERT INTO GRUPOSA.TurnosCancelacion (Cancelacion_Tipo,Cancelacion_Turno_Id,Cancelacion_Motivo,Cancelacion_Fecha)
			VALUES (@tipo,@id_turno,@descripcion,CAST(@fechaHoy AS DATE))
			
			SET @ind+=1
		END
DROP TABLE #turnosDelDia
GO

CREATE PROCEDURE [GRUPOSA].[sp_bajaTurnoPaciente]
@tipo VARCHAR(250),
@id_turno NUMERIC(18,0),
@descripcion VARCHAR(255),
@fechaHoy DATETIME
AS
DECLARE @tip NUMERIC(18,0);
BEGIN
	
	SET @tip = CAST(@tipo AS NUMERIC(18,0));
	
	INSERT INTO GRUPOSA.TurnosCancelacion (Cancelacion_Tipo,Cancelacion_Turno_Id,Cancelacion_Motivo,Cancelacion_Fecha)
	VALUES (@tip,@id_turno,@descripcion,CAST(@fechaHoy AS DATE))
END
GO
-------------------------------------------------------------------------------------------------------------------
--sp_comprarBono: Crea Registros de bonos
GO
CREATE PROCEDURE [GRUPOSA].[sp_comprarBono]
	@PaciId			VARCHAR(250),
	@PaciPlan 		VARCHAR(255),
	@fechaHoy 		VARCHAR(250),
	@cantidadBonos	VARCHAR(250)
AS 
	DECLARE @cant 		NUMERIC(18,0);
	DECLARE @hoy  		DATETIME;
	DECLARE @bonoNumero NUMERIC(18,0);
	DECLARE @forTime	NUMERIC(18,0);

BEGIN

	SET @hoy = DATEADD(DAY,92,CAST(@fechaHoy AS DATETIME));
	SET @cant = CAST (@cantidadBonos AS NUMERIC(18,0));
	SET @forTime = 0;
	
	WHILE @forTime < @cant
	BEGIN

		SELECT @bonoNumero = MAX(Bono_Consulta_Numero)+ 1 
		FROM GRUPOSA.Bonos

		BEGIN TRANSACTION
			INSERT INTO [GRUPOSA].[Bonos]
			([Bono_Paci_Id],[Bono_Plan],[Bono_Fecha_Impresion],[Bono_Fecha_Compra_Usado],
			 [Bono_Consulta_Numero],[Bono_expirado],[Bono_Numero_GrupoFamiliar])
			VALUES
			(@PaciId, @PaciPlan, @hoy, NULL, @bonoNumero, 0, SUBSTRING(@PaciId,1,6))
		
			UPDATE GRUPOSA.Bonos
			SET bono_expirado = 1
			WHERE Bono_Fecha_Impresion < @fechaHoy
			
		COMMIT TRANSACTION

		SET @forTime = @forTime + 1;
		
	END;
END
GO

---------------------------------------------------------------------------------------------------------------------
--SP_LISTADOS_ESTADISTICOS-------------------------------------------------------------------------------------------
CREATE PROCEDURE [GRUPOSA].[sp_top5EspecialidadesMasCanceladas](@fechaInicio VARCHAR(255), @fechaFinal VARCHAR(255))
AS
BEGIN
	SELECT TOP 5 (SELECT e.Espe_Desc FROM GRUPOSA.Especialidades e WHERE e.Espe_Cod = t.turn_especialidad) AS Especialidad, COUNT(*) Cantidad_de_Cancelaciones 
	FROM GRUPOSA.TurnosCancelacion c JOIN GRUPOSA.Turnos t ON c.Cancelacion_Turno_Id = t.Turn_Numero
	WHERE CAST(T.Turn_Fecha AS DATE) BETWEEN CAST(@fechaInicio AS DATE) AND CAST(@fechaFinal AS DATE)
	GROUP BY T.Turn_Especialidad
    ORDER BY COUNT(*) DESC
END
GO
CREATE PROCEDURE [GRUPOSA].[sp_top5ProfMasConsultadasPorPlan](@fechaInicio  VARCHAR(250), @fechaFinal  VARCHAR(250))
AS
BEGIN
	SELECT TOP 5 COUNT(*) AS Cantidad_Consultas, 
		(SELECT PM.Plan_Descripcion FROM GRUPOSA.PlanesMedicos PM WHERE PM.Plan_Codigo = p.Paci_Plan_Med_Cod_FK) AS Plan_Medico,
		(SELECT e.Espe_Desc FROM GRUPOSA.Especialidades e WHERE e.Espe_Cod = t.Turn_Especialidad) AS Especialidad,  
		(SELECT UPPER(M.Medi_Apellido+' '+M.Medi_Nombre) FROM GRUPOSA.Medico M WHERE M.Medi_Id = t.Turn_Medico_Id) AS Profesional
	FROM GRUPOSA.TURNOS T JOIN GRUPOSA.Paciente P ON T.Turn_Paciente_Id = P.Paci_Matricula
	WHERE CAST(T.Turn_Fecha AS DATE) BETWEEN CAST(@fechaInicio AS DATE) AND CAST(@fechaFinal AS DATE)
	GROUP BY Turn_Medico_Id, p.Paci_Plan_Med_Cod_FK,t.Turn_Especialidad
	ORDER BY 1 DESC
END
GO
CREATE PROCEDURE [GRUPOSA].[sp_top5ProfConMenosHsTrabPorEsp](@fechaInicio  VARCHAR(250), @fechaFinal  VARCHAR(250))
AS
BEGIN
	SELECT TOP 5 
	(SELECT e.Espe_Desc FROM GRUPOSA.Especialidades e WHERE e.Espe_Cod = Turn_Especialidad) AS Especialidad,  
	COUNT(*) AS Cantidad_de_Bonos_Utilizados 
	FROM GRUPOSA.Bonos JOIN GRUPOSA.Turnos T ON Bono_Consulta_Numero = T.Turn_Numero
	WHERE Bono_expirado <> 0
	AND CAST(T.Turn_Fecha AS DATE) BETWEEN CAST(@fechaInicio AS DATE) AND CAST(@fechaFinal AS DATE)
	GROUP BY Turn_Especialidad
	ORDER BY 2 DESC
END
GO
CREATE PROCEDURE [GRUPOSA].[sp_top5EspConMasBonosUtil](@fechaInicio VARCHAR(250), @fechaFinal  VARCHAR(250))
AS
BEGIN
	SELECT TOP 5 
		(SELECT e.Espe_Desc FROM GRUPOSA.Especialidades e WHERE e.Espe_Cod = Turn_Especialidad) AS Especialidad,  
		COUNT(*) AS Cantidad_de_Bonos_Utilizados 
		FROM GRUPOSA.Bonos JOIN GRUPOSA.Turnos T ON Bono_Consulta_Numero = T.Turn_Numero
	WHERE Bono_expirado <> 0
	AND CAST(T.Turn_Fecha AS DATE) BETWEEN CAST(@fechaInicio AS DATE) AND CAST(@fechaFinal AS DATE)
	GROUP BY Turn_Especialidad
	ORDER BY 2 DESC
END
GO
CREATE PROCEDURE [GRUPOSA].[sp_top5AfiliadosConMasBonos](@fechaInicio  VARCHAR(250), @fechaFinal  VARCHAR(250))
AS
BEGIN
SELECT TOP 5 (SELECT UPPER(Paci_Apellido + ' ' + Paci_Nombre) FROM GRUPOSA.Paciente WHERE Paci_Matricula =  Bono_Paci_Id) AS Afiliado, 
			 (CASE WHEN SUBSTRING(Bono_Paci_Id,7,8) = '01' THEN 'No Es Grupo Familiar' ELSE 'Grupo Familiar' END) AS Grupo_Fliar, 
			 COUNT(*) AS Cantidad_de_Bonos 
FROM GRUPOSA.Bonos JOIN GRUPOSA.Turnos T ON Bono_Consulta_Numero = T.Turn_Numero
WHERE CAST(T.Turn_Fecha AS DATE) BETWEEN CAST(@fechaInicio AS DATE) AND CAST(@fechaFinal AS DATE)
GROUP BY Bono_Paci_Id, Bono_Numero_GrupoFamiliar
ORDER BY 3 DESC, 2 ASC
END
GO

----------------------------------SECUENCIAS-------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------
BEGIN TRANSACTION

CREATE SEQUENCE GRUPOSA.SQ_ID_MEDICO
	START WITH 1   
	INCREMENT BY 1;  

CREATE SEQUENCE GRUPOSA.SQ_ID_PACIENTE
	START WITH 1   
	INCREMENT BY 1; 

COMMIT TRANSACTION
----------------------------------CREATE TABLES----------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------
CREATE TABLE [GRUPOSA].[Rol]
	(
		[Rol_Codigo] 					[NUMERIC](18, 0) IDENTITY(1,1) NOT NULL,
		[Rol_Nombre] 					[VARCHAR](250) NULL,
		[Rol_Estado] 					[BIT] NOT NULL,
		[Rol_Es_Administrador] 			[BIT] NULL,
		
		CONSTRAINT [PK_Rol_Codigo] PRIMARY KEY CLUSTERED ( [Rol_Codigo] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
		CONSTRAINT [U_Rol_Nombre] UNIQUE NONCLUSTERED (	[Rol_Nombre] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[Funcionalidad]
	(
		[Func_Codigo] 					[NUMERIC](18, 0) IDENTITY NOT NULL,
		[Func_Desc] 					[VARCHAR](250) NULL,
		[Func_Habilitada] 				[BIT] DEFAULT 0,
		
		CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED ( [Func_Codigo] ASC	)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[FuncionalidadesRol]
	(
		[FuncRol_Rol_Codigo] 			[NUMERIC](18, 0) NOT NULL,
		[FuncRol_Func_Codigo] 			[NUMERIC](18, 0) NOT NULL,
		
		CONSTRAINT [PK_FuncRol] PRIMARY KEY CLUSTERED ([FuncRol_Rol_Codigo] ASC,[FuncRol_Func_Codigo] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[RolesUsuario]
	(
		[RolUsu_Rol_Codigo] 				[NUMERIC](18, 0) NOT NULL,
		[RolUsu_Usuario_Username] 			[VARCHAR](255) NOT NULL,
	
		CONSTRAINT [PK_RolUsu] PRIMARY KEY CLUSTERED ( [RolUsu_Rol_Codigo] ASC, [RolUsu_Usuario_Username] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[Usuario]
	(
		[Usuario_Username] 					[VARCHAR](255) NOT NULL,
		[Usuario_Password] 					[VARCHAR](255) NULL,
		[Usuario_Fecha_Creacion] 			[DATETIME] NULL,
		[Usuario_Fecha_Ultima_Modificacion] [DATETIME] NULL,
		[Usuario_Intentos_Fallidos] 		[NUMERIC](18, 0) NULL,
		[Usuario_Habilitado] 				[BIT] NULL,
		
		CONSTRAINT [PK_Usuario_Id] PRIMARY KEY CLUSTERED ([Usuario_Username] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[Medico]
	(
		[Medi_Id] 					[VARCHAR](255) NOT NULL,
		[Medi_Nombre] 				[VARCHAR](255) NULL,
		[Medi_Apellido] 			[VARCHAR](255) NULL,
		[Medi_TipoDocumento] 		[VARCHAR](255) NOT NULL,
		[Medi_Dni] 					[NUMERIC](18, 0) NOT NULL,
		[Medi_Sexo]					[VARCHAR](255) DEFAULT NULL,
		[Medi_Direccion] 			[VARCHAR](255) NULL,
		[Medi_Mail] 				[VARCHAR](255) NULL,
		[Medi_Telefono] 			[NUMERIC](18, 0) NULL,
		[Medi_Fecha_Nac] 			[DATE] NULL,
		[Medi_Usuario] 				[VARCHAR] (255) NOT NULL,
		
		CONSTRAINT [PK_Medicos] PRIMARY KEY CLUSTERED ( [Medi_Id] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[Paciente]
	(
		[Paci_Matricula] 		[VARCHAR](255) NOT NULL,
		[Paci_Nombre] 			[VARCHAR](255) NOT NULL,
		[Paci_Apellido] 		[VARCHAR](255) NOT NULL,
		[Paci_TipoDocumento] 	[VARCHAR](255) NOT NULL,
		[Paci_Dni] 				[NUMERIC](18, 0) NOT NULL,
		[Paci_Direccion] 		[VARCHAR](250) NULL,
		[Paci_Telefono] 		[NUMERIC](18,0) NULL,
		[Paci_Mail] 			[VARCHAR](250) NULL,
		[Paci_Fecha_Nac] 		[DATE] NOT NULL,
		[Paci_Sexo]				[VARCHAR] (255) DEFAULT 'Masculino',
		[Paci_Estado_Civil]		[VARCHAR] (255) DEFAULT 'Soltero',		
		[Paci_Plan_Med_Cod_FK] 	[NUMERIC](18, 0) NULL,
		[Paci_Usuario] 			[VARCHAR] (255) NOT NULL,
		[Paci_estado]			[BIT] DEFAULT 0,
		[Paci_Fecha_Baja]		[DATE] NULL,
		[Paci_Grupo_Fliar]		[VARCHAR] (255),
		
		CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED ([Paci_Matricula] ASC	)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[TipoDocumento]
	(
		[Tipo_Doc_Cod]  [NUMERIC](18, 0) IDENTITY(1,1) NOT NULL,
		[Tipo_Doc_Desc] [VARCHAR](255) NOT NULL,
	 
		CONSTRAINT [PK_Tipo_Doc_Cod] PRIMARY KEY CLUSTERED ( [Tipo_Doc_Desc] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[EstadoCivil]
	(
		[EstadoCivil_Id]  	[NUMERIC](18, 0) IDENTITY(1,1) NOT NULL,
		[EstadoCivil_Desc] 	[VARCHAR](255) NOT NULL,
	 
		CONSTRAINT [PK_EstadoCivil_Id] PRIMARY KEY CLUSTERED ( [EstadoCivil_Desc] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[MedicoEspecialidad]
	(
		[MedEspe_Medi_Id] 		[VARCHAR](255) NOT NULL,
		[MedEspe_Espe_Cod] 		[NUMERIC](18, 0) NOT NULL,
		
		CONSTRAINT [PK_MedicoEspecialidad] PRIMARY KEY CLUSTERED ([MedEspe_Medi_Id],[MedEspe_Espe_Cod] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[Especialidades]
	(
		[Espe_Cod] [NUMERIC](18, 0) NOT NULL,
		[Espe_Desc] [VARCHAR](255) NULL,
		[Espe_Tipo_Cod] [NUMERIC](18, 0) NOT NULL,
		[Espe_Tipo_Desc] [VARCHAR](255) NULL,
		
		CONSTRAINT [PK_Especialidades] PRIMARY KEY CLUSTERED ([Espe_Cod] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[PlanesMedicos]
	(
		[Plan_Codigo] [NUMERIC](18, 0) NOT NULL,
		[Plan_Descripcion] [VARCHAR](255) NULL,
		[Plan_Precio_Bono_Consulta] [NUMERIC](18, 0) NULL,
		[Plan_Precio_Bono_Farmacia] [NUMERIC](18, 0) NULL,
		
		CONSTRAINT [PK_PlanesMedicos] PRIMARY KEY CLUSTERED ( [Plan_Codigo] ASC) 
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]	

CREATE TABLE [GRUPOSA].[TiposCancelacion]
	(
		[TipoCancelacion_Codigo] [NUMERIC](18, 0) NOT NULL,
		[TipoCancelacion_Descripcion] [VARCHAR](255) NULL,
		
		CONSTRAINT [PK_TiposCancelacion] PRIMARY KEY CLUSTERED ([TipoCancelacion_Codigo] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[Auditoria_Plan]
	(
		[Auditoria_Movim]					[NUMERIC] (18,0) IDENTITY(1,1) NOT NULL,
		[Auditoria_Usuario] 				[VARCHAR](250) NULL,
		[Auditoria_Plan_Antiguo] 			[NUMERIC](18, 0) NULL,
		[Auditoria_Plan_Nuevo] 				[NUMERIC](18, 0) NULL,
		[Auditoria_Motivo] 					[VARCHAR](255) NULL,
		[Auditoria_Fecha] 					[DATETIME] NULL,
		
		CONSTRAINT [PK_Auditoria_Movim] PRIMARY KEY CLUSTERED ( [Auditoria_Movim] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]	

CREATE TABLE [GRUPOSA].[Consultas]
	(
		[Cons_Id] 			[NUMERIC](18, 0) IDENTITY(1,1) NOT NULL,
		[Cons_Id_Turno] 	[NUMERIC](18,0),
		[Cons_Id_Bono] 		[NUMERIC](18, 0),
		[Cons_Bono_Fecha] 	[DATETIME],
		[Cons_Fecha_Turno] 	[DATETIME],
		[Cons_Realizada]	[BIT] DEFAULT 0, -- 0 F, 1 V
		[Cons_Sintomas] 	[VARCHAR](255),
		[Cons_Enfermedades] [VARCHAR](255),
		[Cons_Diagnostico]	[VARCHAR](255),
		
		CONSTRAINT [PK_Consultas] PRIMARY KEY CLUSTERED ( [Cons_ID] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[Turnos]
	(
		[Turn_Numero] [NUMERIC](18, 0) NOT NULL,
		[Turn_Fecha] [DATETIME] NULL,
		[Turn_Paciente_Id] [VARCHAR](255) NULL,
		[Turn_Medico_Id] [VARCHAR](255) NULL,
		[Turn_Especialidad] [VARCHAR] (255) NULL,

		CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED ( [Turn_Numero] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[HorariosAtencion]
	(
		[Hora_Inicio] [VARCHAR] (255) NULL,
		[Hora_Fin] [VARCHAR] (255) NULL,
		[Hora_Dia] [VARCHAR](255) NULL,
		[Hora_Medico_Id_FK] [VARCHAR](255) NULL,
		[Hora_Especialidad] [VARCHAR](255) NULL,
		[Hora_ID] [NUMERIC](18,0) IDENTITY(1,1) NOT NULL,
		
		CONSTRAINT [PK_HorariosAtencion] PRIMARY KEY CLUSTERED ( [Hora_ID] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]	

CREATE TABLE [GRUPOSA].[TurnosCancelacion]
	(
		[Cancelacion_Id] 			[NUMERIC](18,0)IDENTITY(1,1) NOT NULL,
		[Cancelacion_Tipo]		 	[NUMERIC](18, 0),
		[Cancelacion_Turno_Id] 		[NUMERIC](18, 0),
		[Cancelacion_Motivo] 		[VARCHAR](255),
		[Cancelacion_Fecha]			[DATE],
				
				
		CONSTRAINT [PK_Cancelacion_Id] PRIMARY KEY CLUSTERED ([Cancelacion_Id],[Cancelacion_Turno_Id] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


CREATE TABLE [GRUPOSA].[Bonos]
	(
		[Bono_Id] NUMERIC(18,0) IDENTITY(1,1) NOT NULL,
		[Bono_Paci_Id] [VARCHAR](255) NOT NULL,
		[Bono_Plan] [NUMERIC](18, 0) NULL,
		[Bono_Fecha_Impresion] [DATETIME] NULL,		
		[Bono_Fecha_Compra_Usado] [DATETIME] NULL,
		[Bono_Consulta_Numero] [NUMERIC](18, 0) NOT NULL,
		[Bono_expirado] [BIT] DEFAULT 0,
		[Bono_Numero_GrupoFamiliar] [VARCHAR](255) NOT NULL,
		
		CONSTRAINT [PK_Bonos] PRIMARY KEY CLUSTERED ( [Bono_Id] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

CREATE TABLE [GRUPOSA].[TurnosDisponible](
	[HORA_TURNO] [time](7) NULL
) ON [PRIMARY]
GO
	
-----------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------
-----MIGRACION---------------------------------------------------------------------------------------------------------------------------------------
GO
USE GD2C2016
GO
/* Datos Previos */
BEGIN TRANSACTION
	
	--Especialidades	
	BEGIN
		INSERT INTO [GRUPOSA].[Especialidades] ([Espe_Cod],[Espe_Desc],[Espe_Tipo_Cod],[Espe_Tipo_Desc])
		SELECT DISTINCT(especialidad_codigo), especialidad_descripcion, tipo_especialidad_codigo, tipo_especialidad_descripcion 
		FROM gd_esquema.Maestra
		WHERE especialidad_codigo IS NOT NULL
		ORDER BY 1 ASC;
		
		INSERT INTO [GRUPOSA].[PlanesMedicos] ([Plan_Codigo],[Plan_Descripcion],[Plan_Precio_Bono_Consulta],[Plan_Precio_Bono_Farmacia])
		SELECT DISTINCT(plan_med_codigo), plan_med_descripcion,plan_med_precio_bono_consulta,plan_med_precio_bono_farmacia
		FROM gd_esquema.Maestra
		WHERE plan_med_codigo IS NOT NULL
		ORDER BY 1 ASC;

	END
	
	--Roles 
		INSERT INTO GRUPOSA.[Rol] ([Rol_Nombre],[Rol_Estado],[Rol_Es_Administrador])
		VALUES ('Administrador',0,1)
		INSERT INTO GRUPOSA.[Rol] ([Rol_Nombre],[Rol_Estado],[Rol_Es_Administrador])
		VALUES ('Afiliado Paciente',0,0)
		INSERT INTO GRUPOSA.[Rol] ([Rol_Nombre],[Rol_Estado],[Rol_Es_Administrador])
		VALUES ('Profesional Medico',0,0)

	--Tipos DNI
		INSERT INTO [GRUPOSA].[TipoDocumento] (Tipo_Doc_Desc)
		VALUES ( 'DNI')
		INSERT INTO [GRUPOSA].[TipoDocumento] (Tipo_Doc_Desc)
		VALUES ('PASAPORTE')
		INSERT INTO [GRUPOSA].[TipoDocumento] (Tipo_Doc_Desc)
		VALUES ('LC')

	--TiposCancelacion	
		INSERT INTO [GRUPOSA].TiposCancelacion([TipoCancelacion_Codigo],[TipoCancelacion_Descripcion])
		VALUES (1,'Cancelada por el paciente'),(2,'Cancelada por el medico')

	--Usuario Admin	
		INSERT INTO GRUPOSA.[Usuario] ([Usuario_Username],[Usuario_Password],[Usuario_Fecha_Creacion],[Usuario_Habilitado],[Usuario_Intentos_Fallidos])
		VALUES ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',GETDATE(),0,0)
	
	--Rol usuario Admin
		INSERT INTO GRUPOSA.[RolesUsuario] ([RolUsu_Rol_Codigo],[RolUsu_Usuario_Username])
		SELECT Rol_Codigo, 'admin' FROM GRUPOSA.[Rol] WHERE Rol_Nombre = 'Administrador';
		
		
COMMIT TRANSACTION

/*Pacientes*/
BEGIN TRANSACTION
	DECLARE @paci_matricula 			VARCHAR(255)
	DECLARE @paci_nom					VARCHAR(255)
	DECLARE @paci_apell					VARCHAR(255)
	DECLARE @paci_tipodni				NUMERIC(18,0)
	DECLARE @paci_dni			 		NUMERIC(18,0)
	DECLARE @paci_direccion				VARCHAR(255)
	DECLARE @paci_tel					NUMERIC(18,0)
	DECLARE @paci_mail 					VARCHAR(255)
	DECLARE @paci_fecha_nac				DATE
	DECLARE @paci_sexo	 				VARCHAR(255)
	DECLARE @paci_estado_civil			VARCHAR(250)
	DECLARE @paci_plan_medi				NUMERIC(18,0)
	DECLARE @paci_usuario 				VARCHAR(255)
	DECLARE @var1						NUMERIC(18,0)

	DECLARE Cur_Pacientes CURSOR FOR
		
		SELECT paciente_nombre, paciente_apellido, paciente_dni, paciente_direccion,
			   paciente_telefono, paciente_mail, paciente_fecha_nac, plan_med_codigo
		FROM gd_esquema.maestra 
		GROUP by paciente_nombre,paciente_apellido,paciente_dni,paciente_direccion,paciente_telefono,
				 paciente_mail,paciente_fecha_nac,plan_med_codigo


	OPEN Cur_Pacientes 
		
		FETCH Cur_Pacientes INTO @paci_nom, @paci_apell, @paci_dni, @paci_direccion, @paci_tel, @paci_mail, @paci_fecha_nac, @paci_plan_medi
				
		WHILE (@@FETCH_STATUS = 0)
		
			BEGIN	
				
				SET @var1 = NEXT VALUE FOR GRUPOSA.SQ_ID_PACIENTE
				SET @paci_matricula = RIGHT(replicate('0',5) + CAST(@var1 AS VARCHAR(5)) + '01', 8)
				SET @paci_usuario = LOWER(@paci_nom) + '_' + LOWER(@paci_apell) + '_' + @paci_matricula
									 
					INSERT INTO [GRUPOSA].[Paciente]
					   ([Paci_Matricula],[Paci_Nombre],[Paci_Apellido],[Paci_TipoDocumento],[Paci_Dni],
						[Paci_Direccion],[Paci_Telefono],[Paci_Mail],[Paci_Fecha_Nac],[Paci_Estado_Civil],
						[Paci_Plan_Med_Cod_FK], [Paci_Usuario], [Paci_Grupo_Fliar])
					VALUES
					   (@paci_matricula, @paci_nom, @paci_apell, 'DNI', @paci_dni, 
						@paci_direccion, @paci_tel, @paci_mail, @paci_fecha_nac, 'Soltero', @paci_plan_medi, @paci_usuario, '01');

				FETCH NEXT FROM Cur_Pacientes INTO @paci_nom, @paci_apell, @paci_dni, @paci_direccion, @paci_tel, @paci_mail, @paci_fecha_nac, @paci_plan_medi
			END

	CLOSE Cur_Pacientes

	DEALLOCATE Cur_Pacientes

COMMIT TRANSACTION;

/*Medicos */
BEGIN TRANSACTION
	
	DECLARE @medi_id					VARCHAR(255)
	DECLARE @medi_nom					VARCHAR(255)
	DECLARE @medi_apell					VARCHAR(255)
	DECLARE @medi_tipodni				VARCHAR(255)
	DECLARE @medi_dni			 		NUMERIC(18,0)
	DECLARE @medi_direccion				VARCHAR(255)
	DECLARE @medi_mail 					VARCHAR(255)
	DECLARE @medi_telefono				NUMERIC(18,0)
	DECLARE @medi_fecha_nac				DATETIME
	DECLARE @medi_usuario 				VARCHAR(255)
	DECLARE @var						NUMERIC(18,0)
	
	DECLARE Cur_Medicos CURSOR FOR
		
		SELECT medico_nombre, medico_apellido, medico_dni, medico_direccion, medico_fecha_nac, medico_mail, medico_telefono 
		FROM gd_esquema.Maestra 
		WHERE medico_nombre IS NOT NULL
		GROUP BY medico_nombre, medico_apellido, medico_dni, medico_direccion, medico_fecha_nac, medico_mail, medico_telefono
		
		SELECT @medi_tipodni = Tipo_Doc_Desc FROM GRUPOSA.TIPODOCUMENTO
		WHERE TIPO_DOC_COD = 1;
		
	OPEN Cur_Medicos 
		
		FETCH Cur_Medicos INTO @medi_nom, @medi_apell, @medi_dni, @medi_direccion, @medi_fecha_nac, @medi_mail, @medi_telefono
				
		WHILE (@@FETCH_STATUS = 0)
		
			BEGIN	
				
			SET @var = NEXT VALUE FOR GRUPOSA.SQ_ID_MEDICO
			SET @medi_id = RIGHT(replicate('0',5) + CAST(@var AS VARCHAR(5)) + '01', 8)
			SET @medi_usuario = LOWER(@medi_nom) + '_' + LOWER(@medi_apell) + '.' +  'clinica_frba'
					
					INSERT INTO [GRUPOSA].[Medico]
					   ([Medi_Id],[Medi_Nombre],[Medi_Apellido],[Medi_TipoDocumento],[Medi_Dni],
						[Medi_Direccion],[Medi_Mail],[Medi_Telefono],[Medi_Fecha_Nac],[Medi_Usuario])
					VALUES
					   (@medi_id, @medi_nom, @medi_apell, @medi_tipodni, @medi_dni, 
						@medi_direccion, @medi_mail, @medi_telefono, @medi_fecha_nac, @medi_usuario);

				FETCH NEXT FROM Cur_Medicos INTO @medi_nom, @medi_apell, @medi_dni, @medi_direccion, @medi_fecha_nac, @medi_mail, 
				@medi_telefono
			END

	CLOSE Cur_Medicos

	DEALLOCATE Cur_Medicos
	
COMMIT TRANSACTION

/*Datos*/
	BEGIN TRANSACTION
	--Usuarios Medicos y Pacientes
		INSERT INTO [GRUPOSA].[Usuario] ([Usuario_Username],[Usuario_Password],[Usuario_Intentos_Fallidos], [Usuario_Habilitado])
		SELECT DISTINCT(paci.Paci_Usuario), '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4' , 0,0 
		FROM GRUPOSA.paciente PACI;
				
		INSERT INTO [GRUPOSA].[Usuario] ([Usuario_Username],[Usuario_Password],[Usuario_Intentos_Fallidos], [Usuario_Habilitado])
		SELECT DISTINCT(medi.Medi_Usuario), '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4' , 0,0 
		FROM GRUPOSA.Medico medi;
	COMMIT TRANSACTION

	BEGIN TRANSACTION
	--EstadoCivil
		INSERT INTO [GRUPOSA].[EstadoCivil] ([EstadoCivil_Desc])
		VALUES ('Soltero'),('Casado'),('Viudo'),('Divorciado')
	--RolesUsuario
		INSERT INTO [GRUPOSA].[RolesUsuario] ([RolUsu_Usuario_Username],[RolUsu_Rol_Codigo])
		SELECT DISTINCT(med.Medi_Usuario), ro.Rol_Codigo FROM GRUPOSA.medico AS med, gruposa.rol AS ro
		WHERE med.medi_usuario IS NOT NULL
		AND ro.Rol_Nombre = 'Profesional Medico';
		
		INSERT INTO [GRUPOSA].[RolesUsuario] ([RolUsu_Usuario_Username],[RolUsu_Rol_Codigo])
		SELECT DISTINCT(paci_usuario), ro.Rol_Codigo FROM GRUPOSA.paciente AS paci, gruposa.rol AS ro
		WHERE paci.paci_usuario IS NOT NULL
		AND ro.Rol_Nombre = 'Afiliado Paciente';
	
	COMMIT TRANSACTION
	
	BEGIN TRANSACTION	
	--MedicosEspecialidad
		INSERT INTO [GRUPOSA].[MedicoEspecialidad] ([medespe_espe_cod],[medespe_medi_id])
		SELECT DISTINCT(esp.espe_cod), med.medi_id FROM gd_esquema.Maestra AS gdm, gruposa.medico AS med, gruposa.especialidades AS esp
		WHERE gdm.medico_nombre IS NOT NULL
		AND esp.espe_cod = gdm.especialidad_codigo
		AND med.medi_dni = gdm.medico_dni;
	COMMIT TRANSACTION
		
	BEGIN TRANSACTION
		INSERT INTO [GRUPOSA].[HorariosAtencion]
           ([Hora_Dia],[Hora_Inicio],[Hora_Fin],[Hora_Medico_Id_FK],[Hora_Especialidad])
			SELECT DATENAME(WEEKDAY,  ROW_NUMBER() OVER(ORDER BY (SELECT 1))) AS HORA_DIA,
			   RIGHT(REPLICATE('0',2) + RTRIM(CAST(DATEPART(HOUR,MIN(MA.TURNO_FECHA)) AS CHAR(2))),2)
			   + ':' + 
			   RIGHT(REPLICATE('0',2) + RTRIM(CAST(DATEPART(MINUTE,MIN(MA.TURNO_FECHA)) AS CHAR(2))),2) AS HORA_ENTRADA,
			   RIGHT(REPLICATE('0',2) + RTRIM(CAST(DATEPART(HOUR,MAX(MA.TURNO_FECHA)) AS CHAR(2))),2)
			   + ':' + 
			   RIGHT(REPLICATE('0',2) + RTRIM(CAST(DATEPART(MINUTE,MAX(MA.TURNO_FECHA)) AS CHAR(2))),2) AS HORA_SALIDA,
			   ME.MEDI_ID, MA.ESPECIALIDAD_CODIGO
		FROM GD_ESQUEMA.MAESTRA MA, GRUPOSA.MEDICO ME
		WHERE ESPECIALIDAD_DESCRIPCION IS NOT NULL
		AND ME.MEDI_APELLIDO = MA.MEDICO_APELLIDO
		and MA.ESPECIALIDAD_CODIGO IN (SELECT m.MedEspe_Espe_Cod FROM GRUPOSA.MedicoEspecialidad m WHERE m.MedEspe_Medi_Id = me.medi_id) 
		GROUP BY MA.ESPECIALIDAD_CODIGO, ME.MEDI_ID
	COMMIT TRANSACTION
	
	BEGIN TRANSACTION
		INSERT INTO [GRUPOSA].[Turnos] ([Turn_Numero],[Turn_Fecha],[Turn_Paciente_Id],[Turn_Medico_Id], [Turn_Especialidad])
		SELECT DISTINCT(gdm.turno_numero), gdm.turno_fecha, pac.paci_matricula, med.medi_id, gdm.Especialidad_Codigo
		FROM gd_esquema.maestra AS gdm, gruposa.paciente AS pac, gruposa.medico AS med
		WHERE gdm.medico_dni = med.medi_dni
		AND pac.paci_dni = gdm.paciente_dni
	COMMIT TRANSACTION

	BEGIN TRANSACTION
		
			UPDATE GRUPOSA.HorariosAtencion
			SET HORA_DIA = 'Miercoles',
			    HORA_INICIO = '18:00',
				HORA_FIN = '20:00'
			WHERE HORA_DIA = 'Domingo'
			
			UPDATE GRUPOSA.HorariosAtencion
			SET Hora_Inicio = '09:00',
				Hora_Fin = '15:00'
			WHERE HORA_DIA = 'Sábado'
		
	COMMIT TRANSACTION
	
	BEGIN TRANSACTION
	
		INSERT INTO [GRUPOSA].[Bonos] 
		([Bono_Paci_Id],[Bono_Plan],[Bono_Fecha_Compra_Usado],[Bono_Fecha_Impresion],[Bono_Consulta_Numero],[Bono_Numero_GrupoFamiliar])
		SELECT DISTINCT P.Paci_Matricula, M.Plan_Med_Codigo, M.Compra_Bono_Fecha, M.Bono_Consulta_Fecha_Impresion, Bono_Consulta_Numero, SUBSTRING(P.Paci_Matricula,1,6)
		FROM GRUPOSA.Paciente P JOIN gd_esquema.Maestra M ON (P.Paci_Dni = M.Paciente_Dni)
		WHERE Bono_Consulta_Numero IS NOT NULL

		UPDATE GRUPOSA.Bonos
		SET bono_expirado = 1
		WHERE bono_fecha_compra_usado IS NOT NULL
		OR Bono_Consulta_Numero IN (SELECT Bono_Consulta_Numero FROM gd_esquema.Maestra M 
									WHERE M.Bono_Consulta_Fecha_Impresion < Turno_Fecha);	
	
	COMMIT TRANSACTION
	
	BEGIN TRANSACTION
		INSERT INTO [GRUPOSA].[Consultas] ([Cons_Id_Turno],[Cons_Id_Bono],[Cons_Bono_Fecha],[Cons_Fecha_Turno],[Cons_Enfermedades],[Cons_Sintomas])
		SELECT M.Turno_Numero, M.Bono_Consulta_Numero, M.Compra_Bono_Fecha, M.Turno_Fecha, M.Consulta_Enfermedades, M.Consulta_Sintomas
		FROM gd_esquema.Maestra M
		WHERE M.Turno_Numero IS NOT NULL
	COMMIT TRANSACTION

	BEGIN TRANSACTION
		INSERT INTO [GRUPOSA].[TurnosCancelacion] 
		([Cancelacion_Tipo],[Cancelacion_Turno_Id],[Cancelacion_Motivo],[Cancelacion_Fecha])
		SELECT 1, M.Turno_Numero, 'Cancelada por vencimiento de Bono', M.Turno_Fecha - 2
		FROM gd_esquema.Maestra M 
		WHERE M.Bono_Consulta_Fecha_Impresion < Turno_Fecha

	COMMIT TRANSACTION
	
	BEGIN TRANSACTION
		UPDATE [GRUPOSA].[Consultas] 
		SET Cons_Realizada = 1
		WHERE Cons_Enfermedades IS NOT NULL
	COMMIT TRANSACTION
	
	
	BEGIN TRANSACTION

	DECLARE @hora_fin TIME;
	DECLARE @hora TIME;

	SET @hora = CAST('08:00' AS TIME)
	SET @hora_fin = CAST ('20:00' AS TIME)

	WHILE (@hora <= @hora_fin) 
	BEGIN 

		INSERT INTO GRUPOSA.turnosdisponible (HORA_TURNO)
		VALUES(@hora)	
		
		SET @hora = DATEADD(mi,30,@hora);
		
	END

	COMMIT TRANSACTION
	
	BEGIN TRANSACTION

	--Funcionalidades
		INSERT INTO [GRUPOSA].[Funcionalidad]([Func_Desc])
		VALUES ('Crear')
		INSERT INTO [GRUPOSA].[Funcionalidad]([Func_Desc])
		VALUES ('Modificar')
		INSERT INTO [GRUPOSA].[Funcionalidad]([Func_Desc])
		VALUES ('Borrar') 
		INSERT INTO [GRUPOSA].[Funcionalidad]([Func_Desc])
		VALUES ('Solicitar Turno') 
		INSERT INTO [GRUPOSA].[Funcionalidad]([Func_Desc])
		VALUES ('Registrar Atencion Medica') 
		
	--FuncionalidadesRol
		INSERT INTO [GRUPOSA].[FuncionalidadesRol] ([FuncRol_Rol_Codigo] ,[FuncRol_Func_Codigo])
		VALUES (1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(1,11),(1,12),
			   (1,13),(1,14),(2,9),(2,8),(2,4),(2,13),(3,11),(3,12),(3,10),(2,14),(3,14),(1,15)
		
		
		INSERT INTO [GD2C2016].[GRUPOSA].[Funcionalidad]
		VALUES ('ABM de Afiliado',0),('Registro Llegada',0),('Pedir Turno',0),('Compra Bono',0),('Cancelar Atencion',0),
			   ('Registro Agenda',0),('Registro Resultado',0),('Cancelar Turno',0),('Listados',0), ('ABM de Rol',0)
 
	COMMIT TRANSACTION
	
--------------------------------------------------------------------------------------------------------------------------------------
------------CONSTRAINT
BEGIN TRANSACTION

	ALTER TABLE GRUPOSA.Medico ADD CONSTRAINT FK_Medico_TipoDocumento FOREIGN KEY
	(Medi_TipoDocumento) REFERENCES GRUPOSA.TipoDocumento (Tipo_Doc_Desc) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
		
	ALTER TABLE GRUPOSA.HorariosAtencion ADD CONSTRAINT FK_HorariosAtencion_Medico FOREIGN KEY
	(Hora_Medico_Id_FK) REFERENCES GRUPOSA.Medico (Medi_Id) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	--PREVIO A AGREGAR UN REGISTRO A MEDICOS DEBE INGESARSE USUARIO
	ALTER TABLE GRUPOSA.Medico ADD CONSTRAINT FK_Medico_Usuario FOREIGN KEY
	(Medi_Usuario) REFERENCES GRUPOSA.Usuario (Usuario_Username) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	ALTER TABLE GRUPOSA.Auditoria_Plan ADD CONSTRAINT FK_Auditoria_Plan_PlanesMedicos FOREIGN KEY
	(Auditoria_Plan_Nuevo) REFERENCES GRUPOSA.PlanesMedicos (Plan_Codigo) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	ALTER TABLE GRUPOSA.Bonos ADD CONSTRAINT FK_Bonos_Paciente FOREIGN KEY
	(Bono_Paci_Id) REFERENCES GRUPOSA.Paciente (Paci_Matricula) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	ALTER TABLE GRUPOSA.MedicoEspecialidad ADD CONSTRAINT FK_MedicoEspecialidad_Especialidades FOREIGN KEY
	(MedEspe_Espe_Cod) REFERENCES GRUPOSA.Especialidades (Espe_Cod) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
		
	ALTER TABLE GRUPOSA.MedicoEspecialidad ADD CONSTRAINT FK_MedicoEspecialidad_Medico FOREIGN KEY
	(MedEspe_Medi_Id) REFERENCES GRUPOSA.Medico (Medi_Id) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	ALTER TABLE GRUPOSA.TurnosCancelacion ADD CONSTRAINT FK_TurnosCancelacion_Turnos FOREIGN KEY
	(Cancelacion_Turno_Id) REFERENCES GRUPOSA.Turnos (Turn_Numero) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
		
	ALTER TABLE GRUPOSA.TurnosCancelacion ADD CONSTRAINT FK_TurnosCancelacion_TiposCancelacion FOREIGN KEY
	(Cancelacion_Tipo) REFERENCES GRUPOSA.TiposCancelacion (TipoCancelacion_Codigo) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	ALTER TABLE GRUPOSA.Turnos ADD CONSTRAINT FK_Turnos_Paciente FOREIGN KEY
	(Turn_Paciente_Id) REFERENCES GRUPOSA.Paciente (Paci_Matricula) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	ALTER TABLE GRUPOSA.Turnos ADD CONSTRAINT FK_Turnos_Medico 
	FOREIGN KEY (Turn_Medico_Id) REFERENCES GRUPOSA.Medico (Medi_Id) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
		
	ALTER TABLE GRUPOSA.Paciente ADD CONSTRAINT FK_Paciente_PlanesMedicos FOREIGN KEY
	(Paci_Plan_Med_Cod_FK) REFERENCES GRUPOSA.PlanesMedicos (Plan_Codigo) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	ALTER TABLE GRUPOSA.Paciente ADD CONSTRAINT FK_Paciente_EstadoCivil FOREIGN KEY
	(Paci_Estado_Civil) REFERENCES GRUPOSA.EstadoCivil (EstadoCivil_Desc) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	ALTER TABLE GRUPOSA.Paciente ADD CONSTRAINT FK_Paciente_Usuario FOREIGN KEY 
	(Paci_Usuario) REFERENCES GRUPOSA.Usuario (Usuario_Username) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	ALTER TABLE GRUPOSA.Paciente ADD CONSTRAINT FK_Paciente_TipoDocumento 
	FOREIGN KEY (Paci_TipoDocumento) REFERENCES GRUPOSA.TipoDocumento (Tipo_Doc_Desc) ON UPDATE  NO ACTION ON DELETE  NO ACTION 
		
	ALTER TABLE GRUPOSA.FuncionalidadesRol ADD CONSTRAINT FK_FuncionalidadesRol_Funcionalidad1 FOREIGN KEY
	(FuncRol_Func_Codigo) REFERENCES GRUPOSA.Funcionalidad (Func_Codigo) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	ALTER TABLE GRUPOSA.FuncionalidadesRol ADD CONSTRAINT FK_FuncionalidadesRol_Rol FOREIGN KEY
	(FuncRol_Rol_Codigo) REFERENCES GRUPOSA.Rol (Rol_Codigo) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	ALTER TABLE GRUPOSA.RolesUsuario ADD CONSTRAINT FK_RolesUsuario_Rol FOREIGN KEY 
	(RolUsu_Rol_Codigo) REFERENCES GRUPOSA.Rol (Rol_Codigo) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	ALTER TABLE GRUPOSA.RolesUsuario ADD CONSTRAINT FK_RolesUsuario_Usuario FOREIGN KEY
	(RolUsu_Usuario_Username) REFERENCES GRUPOSA.Usuario (Usuario_Username) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

	ALTER TABLE GRUPOSA.Consultas ADD CONSTRAINT FK_Consultas_Turnos FOREIGN KEY
	(Cons_Id_Turno) REFERENCES GRUPOSA.Turnos (Turn_Numero) ON UPDATE  NO ACTION ON DELETE  NO ACTION 

COMMIT TRANSACTION