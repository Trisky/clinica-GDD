/* ***** Object:  Schema [GRUPOSA] ******************************************************* */
USE GD2C2016  
GO  
CREATE SCHEMA GRUPOSA  
GO  

/* ***** Object:  STORES_PROCEDURES [GRUPOSA].[Rol] ***************************************************/
GO
CREATE PROCEDURE [GRUPOSA].sp_eliminarRol
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
GO
CREATE PROCEDURE [GRUPOSA].sp_crearAfiliado
	@paci_matricula VARCHAR(250),
	@paci_nom VARCHAR(250),
	@paci_apell VARCHAR(250),
	@paci_tipodni NUMERIC (18,0),
	@paci_dni NUMERIC (18,0),
	@paci_direccion VARCHAR(250), 
	@paci_tel NUMERIC (18,0), 
	@paci_mail VARCHAR(250), 
	@paci_fecha_nac DATE, 
	@paci_sexo VARCHAR(250), 
	@paci_estado_civil NUMERIC (18,0),
	@paci_plan_medi NUMERIC (18,0),
	@paci_cant_fam NUMERIC (18,0),
	@paci_tipoFamiliar VARCHAR(250)
AS   
	DECLARE @var1 NUMERIC (18,0);
	DECLARE @paci_usuario VARCHAR(255);
	
	SET @var1 = NEXT VALUE FOR GRUPOSA.SQ_ID_PACIENTE
	SET @paci_matricula = RIGHT(replicate('0',5) + CAST(@var1 AS VARCHAR(5)) + @paci_tipoFamiliar, 5)
	SET @paci_usuario = LOWER(@paci_nom) + '_' + LOWER(@paci_apell)
					 
	INSERT INTO [GRUPOSA].[Paciente]
	   ([Paci_Matricula],[Paci_Nombre],[Paci_Apellido],[Paci_TipoDocumento],[Paci_Dni],
		[Paci_Direccion],[Paci_Telefono],[Paci_Mail],[Paci_Fecha_Nac],[Paci_Sexo],[Paci_Estado_Civil],
		[Paci_Plan_Med_Cod_FK],[Paci_Cant_Familiares], [Paci_Usuario])
	VALUES
	   (@paci_matricula, @paci_nom, @paci_apell, @paci_tipodni, @paci_dni, 
		@paci_direccion, @paci_tel, @paci_mail, @paci_fecha_nac, @paci_sexo, @paci_estado_civil, 
		@paci_plan_medi, @paci_cant_fam, @paci_usuario);
						
GO
GO
CREATE PROCEDURE [GRUPOSA].sp_bajaLogica
    @usuario VARCHAR(250)
AS   
    DECLARE @estadoActual BIT
	
	SELECT @estadoActual = Usuario_Habilitado FROM GRUPOSA.[Usuario] WHERE Usuario_Username = @usuario
	
	IF (@estadoActual = 1 ) 
		BEGIN
			UPDATE GRUPOSA.[Usuario] 
			SET Usuario_Habilitado = 0
			WHERE Usuario_Username = @usuario
		END
	ELSE
		BEGIN
			UPDATE GRUPOSA.[Usuario] 
			SET Usuario_Habilitado = 1
			WHERE Usuario_Username = @usuario
		END
GO
GO
CREATE PROCEDURE [GRUPOSA].sp_turnosUsuarioBaja
    @usuario VARCHAR(250)
AS   
    
	DECLARE @matricula VARCHAR(250);
	
	SELECT @matricula = Paci_Matricula FROM GRUPOSA.Paciente Paci
	WHERE Paci.Paci_Usuario = @usuario
	
	DELETE FROM GRUPOSA.Turnos
	WHERE Turn_Paciente_Id IN (SELECT SUBSTRING(Paci_Matricula,1,6) FROM GRUPOSA.Paciente Paci
							   WHERE Paci.Paci_Usuario = @usuario)	
GO
GO
CREATE PROCEDURE [GRUPOSA].sp_cambioDePlan
    @usuario VARCHAR(250),
	@nuevoPlan [NUMERIC] (18,0),
	@motivo VARCHAR (250)
AS   
	DECLARE @viejoPlan [NUMERIC] (18,0);
	
	SELECT @viejoPlan = Paci_Plan_Med_Cod_FK FROM GRUPOSA.Paciente Paci
	WHERE Paci.Paci_Usuario = @usuario
	
	INSERT INTO [GRUPOSA].[Auditoria_Plan] ([Auditoria_Usuario],[Auditoria_Plan_Antiguo],[Auditoria_Plan_Nuevo],[Auditoria_Motivo],[Auditoria_Fecha] )
	VALUES (@usuario, @viejoPlan, @nuevoPlan, @motivo, GETDATE());
	
	UPDATE GRUPOSA.Paciente 
	SET Paci_Plan_Med_Cod_FK = @nuevoPlan
	WHERE Paci_Usuario = @usuario;
	
GO
GO
CREATE PROCEDURE [GRUPOSA].sp_modificarAfiliado
    @afiliadoId VARCHAR(250),
	@nuevaDireccion VARCHAR(250),
	@nuevoEmail VARCHAR(250),
	@nuevoEstadoCivil VARCHAR (250),
	@nuevoPlanMedico VARCHAR(250)
AS   
	DECLARE @usuarioPaci VARCHAR(255);
	
	UPDATE GRUPOSA.Paciente
	SET Paci_Direccion = ISNULL(@nuevaDireccion,Paci_Direccion),
		Paci_Mail = ISNULL(@nuevoEmail, Paci_Mail),
		Paci_Estado_Civil = ISNULL(@nuevoEstadoCivil, Paci_Estado_Civil),
		Paci_Plan_Med_Cod_FK = ISNULL(@nuevoPlanMedico, Paci_Plan_Med_Cod_FK)
	WHERE @afiliadoId = Paci_Matricula;	
GO
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
/* ***** Object:  Table [GRUPOSA].[Rol] ************************************************** */

CREATE SEQUENCE GRUPOSA.SQ_ID_MEDICO
	START WITH 1   
	INCREMENT BY 1;  

CREATE SEQUENCE GRUPOSA.SQ_ID_PACIENTE
	START WITH 1   
	INCREMENT BY 1; 
	
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

/* ***** Object:  Table [GRUPOSA].[RolesUsuario]    Script Date: 9/22/2016 9:54:02 AM ***** */
CREATE TABLE [GRUPOSA].[RolesUsuario]
	(
		[RolUsu_Rol_Codigo] 				[VARCHAR](255) NOT NULL,
		[RolUsu_Usuario_Username] 			[VARCHAR](255) NOT NULL,
	
		CONSTRAINT [PK_RolUsu] PRIMARY KEY CLUSTERED ( [RolUsu_Rol_Codigo] ASC, [RolUsu_Usuario_Username] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
/* ***** Object:  Table [GRUPOSA].[Auditoria_Login]    Script Date: 9/22/2016 9:54:02 AM ***** */
CREATE TABLE [GRUPOSA].[Auditoria_Login]
	(
		[Auditoria_Login_Id] 				[NUMERIC](18, 0) IDENTITY(1,1) NOT NULL,
		[Auditoria_Login_Usuario_Username] 	[VARCHAR](255) NULL,
		[Auditoria_Login_Fecha] 			[DATETIME] NULL,
		[Auditoria_Login_Acceso_Correcto] 	[BIT] NULL,
		[Auditoria_Login_Numero_Intento] 	[NUMERIC](18, 0) NULL,
		
		CONSTRAINT [PK_Auditoria_Login_Id] PRIMARY KEY CLUSTERED ( [Auditoria_Login_Id] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object:  Table [GRUPOSA].[Usuario]    Script Date: 9/22/2016 9:54:02 AM ******/
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


/* ***** Object:  Table [GRUPOSA].[Pacientes]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[Paciente]
	(
		[Paci_Matricula] 		[VARCHAR](255) NOT NULL,
		[Paci_Nombre] 			[VARCHAR](255) NOT NULL,
		[Paci_Apellido] 		[VARCHAR](255) NOT NULL,
		[Paci_TipoDocumento] 	[NUMERIC](18, 0) NOT NULL,
		[Paci_Dni] 				[NUMERIC](18, 0) NOT NULL,
		[Paci_Direccion] 		[VARCHAR](250) NULL,
		[Paci_Telefono] 		[NUMERIC](18,0) NULL,
		[Paci_Mail] 			[VARCHAR](250) NULL,
		[Paci_Fecha_Nac] 		[DATE] NOT NULL,
		[Paci_Sexo]				[VARCHAR] (250) NULL,
		[Paci_Estado_Civil]		[NUMERIC] (18,0) NULL,		
		[Paci_Plan_Med_Cod_FK] 	[NUMERIC](18, 0) NULL,
		[Paci_Cant_Familiares] 	[NUMERIC](18, 0) NULL,
		[Paci_Usuario] 			[VARCHAR] (255) NOT NULL,
		
		CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED ([Paci_Matricula] ASC	)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
/* ***** Object:  Table [GRUPOSA].[TipoDocumento]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[TipoDocumento]
	(
		[Tipo_Doc_Cod]  [NUMERIC](18, 0) IDENTITY(1,1) NOT NULL,
		[Tipo_Doc_Desc] [VARCHAR](255) NULL,
	 
		CONSTRAINT [PK_Tipo_Doc_Cod] PRIMARY KEY CLUSTERED ( [Tipo_Doc_Cod] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object:  Table [GRUPOSA].[Auditoria_Plan]    Script Date: 9/22/2016 9:54:02 AM ***** */
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

/* ***** Object:  Table [GRUPOSA].[Especialidades]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[Especialidades]
	(
		[Espe_Cod] [NUMERIC](18, 0) NOT NULL,
		[Espe_Desc] [VARCHAR](255) NULL,
		[Espe_Tipo_Cod] [NUMERIC](18, 0) NOT NULL,
		[Espe_Tipo_Desc] [VARCHAR](255) NULL,
		
		CONSTRAINT [PK_Especialidades] PRIMARY KEY CLUSTERED ([Espe_Cod] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object:  Table [GRUPOSA].[Medicos]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[Medico]
	(
		[Medi_Id] [VARCHAR](255) NOT NULL,
		[Medi_Nombre] [VARCHAR](255) NULL,
		[Medi_Apellido] [VARCHAR](255) NULL,
		[Medi_TipoDocumento] [NUMERIC](18, 0) NOT NULL,
		[Medi_Dni] [NUMERIC](18, 0) NOT NULL,
		[Medi_Direccion] [VARCHAR](255) NULL,
		[Medi_Mail] [VARCHAR](255) NULL,
		[Medi_Telefono] [NUMERIC](18, 0) NULL,
		[Medi_Fecha_Nac] [DATE] NULL,
		[Medi_Usuario] [VARCHAR] (255) NOT NULL,
		
		CONSTRAINT [PK_Medicos] PRIMARY KEY CLUSTERED ( [Medi_Id] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object:  Table [GRUPOSA].[MedicoEspecialidad]    Script Date: 9/22/2016 9:54:02 AM ******/

CREATE TABLE [GRUPOSA].[MedicoEspecialidad]
	(
		[MedEspe_Medi_Id] [VARCHAR](255) NOT NULL,
		[MedEspe_Espe_Cod] [NUMERIC](18, 0) NOT NULL,
		
		CONSTRAINT [PK_MedicoEspecialidad] PRIMARY KEY CLUSTERED ([MedEspe_Medi_Id],[MedEspe_Espe_Cod] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	
/* ***** Object:  Table [GRUPOSA].[PlanesMedicos]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[PlanesMedicos]
	(
		[Plan_Codigo] [NUMERIC](18, 0) NOT NULL,
		[Plan_Descripcion] [VARCHAR](255) NULL,
		[Plan_Precio_Bono_Consulta] [NUMERIC](18, 0) NULL,
		[Plan_Precio_Bono_Farmacia] [NUMERIC](18, 0) NULL,
		
		CONSTRAINT [PK_PlanesMedicos] PRIMARY KEY CLUSTERED ( [Plan_Codigo] ASC) 
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]	
	
/* ***** Object:  Table [GRUPOSA].[HorariosAtencion]    Script Date: 9/22/2016 9:54:02 AM ******/
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
		
/* ***** Object:  Table [GRUPOSA].[Funcionalidad]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[Funcionalidad]
	(
		[Func_Codigo] 	[NUMERIC](18, 0) IDENTITY NOT NULL,
		[Func_Desc] 	[VARCHAR](250) NULL,
		
		CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED ( [Func_Codigo] ASC	)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object:  Table [GRUPOSA].[FuncionalidadesRol]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[FuncionalidadesRol]
	(
		[FuncRol_Rol_Codigo] [NUMERIC](18, 0) NOT NULL,
		[FuncRol_Func_Codigo] [NUMERIC](18, 0) NOT NULL,
		
		CONSTRAINT [PK_FuncRol] PRIMARY KEY CLUSTERED ([FuncRol_Rol_Codigo] ASC,[FuncRol_Func_Codigo] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


USE GD2C2016
BEGIN TRANSACTION
	
	/*Datos Previos*/
	BEGIN 
		--Tipos DNI
		INSERT INTO [GRUPOSA].[TipoDocumento] (Tipo_Doc_Desc)
		VALUES ( 'DNI')
		INSERT INTO [GRUPOSA].[TipoDocumento] (Tipo_Doc_Desc)
		VALUES ('PASAPORTE')
		INSERT INTO [GRUPOSA].[TipoDocumento] (Tipo_Doc_Desc)
		VALUES ('LC')
		
		--Funcionalidades
		INSERT INTO [GRUPOSA].[Funcionalidad]([Func_Desc])
		VALUES ('Crear')
		INSERT INTO [GRUPOSA].[Funcionalidad]([Func_Desc])
		VALUES ('Modificar')
		INSERT INTO [GRUPOSA].[Funcionalidad]([Func_Desc])
		VALUES ('Borrar') 
		
		--FuncionalidadesRol
		INSERT INTO [GRUPOSA].[FuncionalidadesRol] ([FuncRol_Rol_Codigo] ,[FuncRol_Func_Codigo])
		VALUES (1,1)
		INSERT INTO [GRUPOSA].[FuncionalidadesRol] ([FuncRol_Rol_Codigo] ,[FuncRol_Func_Codigo])
		VALUES (1,2)
		INSERT INTO [GRUPOSA].[FuncionalidadesRol] ([FuncRol_Rol_Codigo] ,[FuncRol_Func_Codigo])
		VALUES (1,3)

		--Roles 
		INSERT INTO GRUPOSA.[Rol] ([Rol_Nombre],[Rol_Estado],[Rol_Es_Administrador])
		VALUES ('Administrador',0,1)
		INSERT INTO GRUPOSA.[Rol] ([Rol_Nombre],[Rol_Estado],[Rol_Es_Administrador])
		VALUES ('Afiliado Paciente',0,0)
		INSERT INTO GRUPOSA.[Rol] ([Rol_Nombre],[Rol_Estado],[Rol_Es_Administrador])
		VALUES ('Profesional Medico',0,0)
		
		
		INSERT INTO GRUPOSA.[Usuario] ([Usuario_Username],[Usuario_Password],[Usuario_Fecha_Creacion],[Usuario_Habilitado])
		VALUES ('admin','w23e',GETDATE(),0)
		
		
		INSERT INTO GRUPOSA.[RolesUsuario] ([RolUsu_Rol_Codigo],[RolUsu_Usuario_Username])
		SELECT Rol_Codigo, 'admin' FROM GRUPOSA.[Rol] WHERE Rol_Nombre = 'Administrador';
		
		INSERT INTO [GRUPOSA].[PlanesMedicos] ([Plan_Codigo],[Plan_Descripcion],[Plan_Precio_Bono_Consulta],[Plan_Precio_Bono_Farmacia])
		SELECT DISTINCT(plan_med_codigo), plan_med_descripcion,plan_med_precio_bono_consulta,plan_med_precio_bono_farmacia
		FROM gd_esquema.Maestra
		WHERE plan_med_codigo IS NOT NULL
		ORDER BY 1 ASC;
		
		INSERT INTO [GRUPOSA].[Especialidades] ([Espe_Cod],[Espe_Desc],[Espe_Tipo_Cod],[Espe_Tipo_Desc])
		SELECT DISTINCT(especialidad_codigo), especialidad_descripcion, tipo_especialidad_codigo, tipo_especialidad_descripcion 
		FROM gd_esquema.Maestra
		WHERE especialidad_codigo IS NOT NULL
		ORDER BY 1 ASC;
	END	

COMMIT TRANSACTION;

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
	DECLARE @paci_estado_civil			NUMERIC(18,0)
	DECLARE @paci_plan_medi				NUMERIC(18,0)
	DECLARE @paci_cant					NUMERIC(18,0)
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
				SET @paci_usuario = LOWER(@paci_nom) + '_' + LOWER(@paci_apell) + '.' + 'clinica_frba'
					 
					INSERT INTO [GRUPOSA].[Paciente]
					   ([Paci_Matricula],[Paci_Nombre],[Paci_Apellido],[Paci_TipoDocumento],[Paci_Dni],
						[Paci_Direccion],[Paci_Telefono],[Paci_Mail],[Paci_Fecha_Nac],[Paci_Estado_Civil],
						[Paci_Plan_Med_Cod_FK],[Paci_Cant_Familiares], [Paci_Usuario])
					VALUES
					   (@paci_matricula, @paci_nom, @paci_apell, 1, @paci_dni, 
						@paci_direccion, @paci_tel, @paci_mail, @paci_fecha_nac, 0, @paci_plan_medi, 0, @paci_usuario);

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
	DECLARE @medi_tipodni				NUMERIC(18,0)
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
		
		SELECT @medi_tipodni = Tipo_Doc_Cod FROM GRUPOSA.TIPODOCUMENTO
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
		
		BEGIN
		--Usuarios Medicos y Pacientes
		INSERT INTO [GRUPOSA].[Usuario] ([Usuario_Username],[Usuario_Password],[Usuario_Intentos_Fallidos], [Usuario_Habilitado])
		SELECT DISTINCT(paci.Paci_Usuario), '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4' , 0,0 
		FROM GRUPOSA.paciente PACI;
				
		INSERT INTO [GRUPOSA].[Usuario] ([Usuario_Username],[Usuario_Password],[Usuario_Intentos_Fallidos], [Usuario_Habilitado])
		SELECT DISTINCT(medi.Medi_Usuario), '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4' , 0,0 
		FROM GRUPOSA.Medico medi;
		
		--RolesUsuario
		INSERT INTO [GRUPOSA].[RolesUsuario] ([RolUsu_Rol_Codigo],[RolUsu_Usuario_Username])
		SELECT DISTINCT(med.Medi_Usuario), ro.Rol_Codigo FROM GRUPOSA.medico AS med, gruposa.rol AS ro
		WHERE med.medi_usuario IS NOT NULL
		AND ro.Rol_Nombre = 'Profesional Medico';
		
		INSERT INTO [GRUPOSA].[RolesUsuario] ([RolUsu_Usuario_Username],[RolUsu_Rol_Codigo])
		SELECT DISTINCT(paci_usuario), ro.Rol_Codigo FROM GRUPOSA.paciente AS paci, gruposa.rol AS ro
		WHERE paci.paci_usuario IS NOT NULL
		AND ro.Rol_Nombre = 'Afiliado Paciente';
		
		--MedicosEspecialidad
		INSERT INTO [GRUPOSA].[MedicoEspecialidad] ([medespe_medi_id],[medespe_espe_cod])
		SELECT DISTINCT(esp.espe_cod), med.medi_id FROM gd_esquema.Maestra AS gdm, gruposa.medico AS med, gruposa.especialidades AS esp
		WHERE gdm.medico_nombre IS NOT NULL
		AND esp.espe_cod = gdm.especialidad_codigo
		AND med.medi_dni = gdm.medico_dni;
		END
		
		BEGIN
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
		GROUP BY MA.ESPECIALIDAD_CODIGO, ME.MEDI_ID
		END
		
		BEGIN
		
			UPDATE GRUPOSA.HorariosAtencion
			SET HORA_DIA = 'Miercoles'
			WHERE HORA_DIA = 'Domingo'
			
			UPDATE GRUPOSA.HorariosAtencion
			SET Hora_Inicio = '09:00',
				Hora_Fin = '15:00'
			WHERE HORA_DIA = 'Sábado'
		
		END
		
COMMIT TRANSACTION