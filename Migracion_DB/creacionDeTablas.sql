USE [GD2C2016]
GO

/* ***** Object:  Table [GRUPOSA].[Auditoria_Login]    Script Date: 9/22/2016 9:54:02 AM ***** */
CREATE TABLE [GRUPOSA].[Auditoria_Login]
	(
		[Auditoria_Login_Id] [NUMERIC](18, 0) IDENTITY(1,1) NOT NULL,
		[Auditoria_Login_Usuario_Username] [VARCHAR](255) NULL,
		[Auditoria_Login_Fecha] [DATETIME] NULL,
		[Auditoria_Login_Acceso_Correcto] [BIT] NULL,
		[Auditoria_Login_Numero_Intento] [NUMERIC](18, 0) NULL,
		
		CONSTRAINT [PK_Auditoria_Login_Id] PRIMARY KEY CLUSTERED ( [Auditoria_Login_Id] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]



/* ***** Object:  Table [GRUPOSA].[Bonos]    Script Date: 9/22/2016 9:54:02 AM ***** */
CREATE TABLE [GRUPOSA].[Bonos]
	(
		[FK_Bono_Plan] [NUMERIC](18, 0) NULL,
		[Bono_Consulta_Fecha_Impresion] [DATETIME] NULL,
		[Bono_Consulta_Numero] [NUMERIC](18, 0) NOT NULL,
		[Bono_expirado] [BIT] NOT NULL,
	 
		CONSTRAINT [PK_Bonos] PRIMARY KEY CLUSTERED ( [Bono_Consulta_Numero] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object:  Table [GRUPOSA].[Consultas]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[Consultas]
	(
		[Cons_Sintomas] [VARCHAR](255) NOT NULL,
		[Cons_Enfermedades] [VARCHAR](255) NOT NULL,
		[Cons_Fecha] [DATETIME] NOT NULL,
		[Cons_ID] [NUMERIC](18, 0) NOT NULL,
		
		CONSTRAINT [PK_Consultas] PRIMARY KEY CLUSTERED ( [Cons_ID] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object:  Table [GRUPOSA].[Especialidades]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[Especialidades]
	(
		[Espe_Codigo] [NUMERIC](18, 0) NOT NULL,
		[Espe_Descripcion] [VARCHAR](255) NULL,
		
		CONSTRAINT [PK_Especialidades] PRIMARY KEY CLUSTERED ([Espe_Codigo] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object:  Table [GRUPOSA].[Funcionalidad]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[Funcionalidad]
	(
		[Func_Codigo] 	[NUMERIC](18, 0) NOT NULL,
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

/* ***** Object:  Table [GRUPOSA].[HorariosAtencion]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[HorariosAtencion]
	(
		[Hora_Inicio] [DATETIME] NULL,
		[Hora_Fin] [DATETIME] NULL,
		[Hora_Dia] [NUMERIC](18, 0) NULL,
		[FK_Horario_Medico_dni] [NUMERIC](18, 0) NULL,
		[Hora_ID] [NUMERIC](18, 0) NOT NULL,
		
		CONSTRAINT [PK_HorariosAtencion] PRIMARY KEY CLUSTERED ( [Hora_ID] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object:  Table [GRUPOSA].[Medicos]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[Medicos]
	(
		[Medi_Nombre] [VARCHAR](255) NULL,
		[Medi_Apellido] [VARCHAR](255) NULL,
		[Medi_Dni] [NUMERIC](18, 0) NOT NULL,
		[Medi_Direccion] [VARCHAR](255) NULL,
		[Medi_Mail] [VARCHAR](255) NULL,
		[Medi_Telefono] [NUMERIC](18, 0) NULL,
		[FK_Medico_Turnos] [nchar](10) NULL,
		[Medi_Fecha_Nac] [DATETIME] NULL,
		[FK_Medico_Especialidad] [NUMERIC](18, 0) NULL,
		[FK_Medico_TipoDocumento] [NUMERIC](18, 0) NOT NULL,
		
		CONSTRAINT [PK_Medicos] PRIMARY KEY CLUSTERED ( [Medi_Dni] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object:  Table [GRUPOSA].[Pacientes]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[Pacientes]
	(
		[Paci_Nombre] [VARCHAR](255) NOT NULL,
		[Paci_Apellido] [VARCHAR](255) NOT NULL,
		[Paci_Dni] [NUMERIC](18, 0) NOT NULL,
		[Paci_Direccion] [VARCHAR](250) NULL,
		[Paci_Mail] [VARCHAR](250) NULL,
		[Paci_Fecha_Nac] [DATETIME] NOT NULL,
		[FK_Plan_Medico_Codigo] [NUMERIC](18, 0) NULL,
		[FK_Paciente_Turno] [NUMERIC](18, 0) NULL,
		[FK_Paciente_Bono] [NUMERIC](18, 0) NULL,
		[Paci_Id_Familia] [NUMERIC](18, 0) NOT NULL,
		[FK_Cod_Documento] [NUMERIC](18, 0) NULL,
		
		CONSTRAINT [PK_Pacientes] PRIMARY KEY CLUSTERED ([Paci_Dni] ASC	)
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

/* ***** Object:  Table [GRUPOSA].[Rol]    Script Date: 9/22/2016 9:54:02 AM ***** */
CREATE TABLE [GRUPOSA].[Rol]
	(
		[Rol_Codigo] [NUMERIC](18, 0) NOT NULL,
		[Rol_Nombre] [VARCHAR](250) NULL,
		[Rol_Estado] [BIT] NULL,
		[Rol_Es_Administrador] [BIT] NULL,
		
		CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED ( [Rol_Codigo] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
		CONSTRAINT [U_Rol_Nombre] UNIQUE NONCLUSTERED (	[Rol_Nombre] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	
	) ON [PRIMARY]
	
/* ***** Object:  Table [GRUPOSA].[RolesUsuario]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[RolesUsuario]
	(
		[RolUsu_Rol_Codigo] [NUMERIC](18, 0) NOT NULL,
		[RolUsu_Usuario_Username] [VARCHAR](255) NOT NULL,
	
		CONSTRAINT [PK_RolUsu] PRIMARY KEY CLUSTERED ( [RolUsu_Rol_Codigo] ASC, [RolUsu_Usuario_Username] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
/* ***** Object:  Table [GRUPOSA].[TipoDocumento]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[TipoDocumento]
	(
		[Tipo_Doc_Cod] [NUMERIC](18, 0) IDENTITY(1,1) NOT NULL,
		[Tipo_Doc_Desc] [VARCHAR](255) NULL,
	 
		CONSTRAINT [pk_Tipo_Doc_Cod] PRIMARY KEY CLUSTERED ( [Tipo_Doc_Cod] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object:  Table [GRUPOSA].[TiposCancelacion]    Script Date: 9/22/2016 9:54:02 AM ******/

CREATE TABLE [GRUPOSA].[TiposCancelacion]
	(
		[TipoCancelacion_Codigo] [NUMERIC](18, 0) NOT NULL,
		[TipoCancelacion_Descripcion] [VARCHAR](255) NULL,
		
		CONSTRAINT [PK_TiposCancelacion] PRIMARY KEY CLUSTERED ([TipoCancelacion_Codigo] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object:  Table [GRUPOSA].[Turnos]    Script Date: 9/22/2016 9:54:02 AM ******/

CREATE TABLE [GRUPOSA].[Turnos]
	(
		[Turn_Numero] [NUMERIC](18, 0) NOT NULL,
		[Turn_Fecha] [DATETIME] NULL,
		[Turn_Paciente_Id] [NUMERIC](18, 0) NULL,
		[Turn_Medico_Id] [NUMERIC](18, 0) NULL,
		[Turn_cancelado] [BIT] NOT NULL,
		[Turn_Justificacion] [VARCHAR](255) NULL,
		[Turn_CanceladoPorAfiliado] [BIT] NOT NULL,
		[Turn_TipoCancelacion] [NUMERIC](18, 0) NULL,
		[FK_Consulta_Turno] [NUMERIC](18, 0) NULL,

		CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED ( [Turn_Numero] ASC )
		 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object:  Table [GRUPOSA].[Usuario]    Script Date: 9/22/2016 9:54:02 AM ******/
CREATE TABLE [GRUPOSA].[Usuario]
	(
		[Usuario_Afiliado_Id] [NUMERIC] (18,0) NOT NULL,
		[Usuario_Username] [VARCHAR](255) NOT NULL,
		[Usuario_Password] [VARCHAR](255) NULL,
		[Usuario_Fecha_Creacion] [DATETIME] NULL,
		[Usuario_Fecha_Ultima_Modificacion] [DATETIME] NULL,
		[Usuario_Pregunta_Secreta] [VARCHAR](255) NULL,
		[Usuario_Respuesta_Secreta] [VARCHAR](255) NULL,
		[Usuario_Intentos_Fallidos] [NUMERIC](18, 0) NULL,
		[Usuario_Inhabilitado] [BIT] NULL,
		[FK_Medico_Dni] [NUMERIC](18, 0) NULL,
		[FK_Paciente_Dni] [NUMERIC](18, 0) NULL,
		[FK_RolUsu_Rol_Codigo] [NUMERIC](18, 0) NULL,
	 
		CONSTRAINT [PK_Usuario_Afiliado_Id] PRIMARY KEY CLUSTERED ([Usuario_Afiliado_Id] ASC )
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

/* ***** Object: Constraints ***/

ALTER TABLE [GRUPOSA].[Auditoria_Login]  WITH CHECK ADD  CONSTRAINT [FK_Auditoria_Login_Usuario_Username] FOREIGN KEY([Auditoria_Login_Usuario_Username])
REFERENCES [GRUPOSA].[Usuario] ([Usuario_Username])
GO
ALTER TABLE [GRUPOSA].[Auditoria_Login] CHECK CONSTRAINT [FK_Auditoria_Login_Usuario_Username]
GO
ALTER TABLE [GRUPOSA].[Bonos]  WITH CHECK ADD  CONSTRAINT [FK_Bonos_Planes] FOREIGN KEY([Bono_Consulta_Numero])
REFERENCES [GRUPOSA].[PlanesMedicos] ([Plan_Codigo])
GO
ALTER TABLE [GRUPOSA].[Bonos] CHECK CONSTRAINT [FK_Bonos_Planes]
GO
ALTER TABLE [GRUPOSA].[FuncionalidadesRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncRol_Func_Codigo] FOREIGN KEY([FuncRol_Func_Codigo])
REFERENCES [GRUPOSA].[Funcionalidad] ([Func_Codigo])
GO
ALTER TABLE [GRUPOSA].[FuncionalidadesRol] CHECK CONSTRAINT [FK_FuncRol_Func_Codigo]
GO
ALTER TABLE [GRUPOSA].[FuncionalidadesRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncRol_Rol_Codigo] FOREIGN KEY([FuncRol_Rol_Codigo])
REFERENCES [GRUPOSA].[Rol] ([Rol_Codigo])
GO
ALTER TABLE [GRUPOSA].[FuncionalidadesRol] CHECK CONSTRAINT [FK_FuncRol_Rol_Codigo]
GO
ALTER TABLE [GRUPOSA].[Medicos]  WITH CHECK ADD  CONSTRAINT [FK_Medico_Especialidad] FOREIGN KEY([FK_Medico_Especialidad])
REFERENCES [GRUPOSA].[Especialidades] ([Espe_Codigo])
GO
ALTER TABLE [GRUPOSA].[Medicos] CHECK CONSTRAINT [FK_Medico_Especialidad]
GO
ALTER TABLE [GRUPOSA].[Medicos]  WITH CHECK ADD  CONSTRAINT [FK_Medicos_HorariosAtencion] FOREIGN KEY([Medi_Dni])
REFERENCES [GRUPOSA].[HorariosAtencion] ([Hora_ID])
GO
ALTER TABLE [GRUPOSA].[Medicos] CHECK CONSTRAINT [FK_Medicos_HorariosAtencion]
GO
ALTER TABLE [GRUPOSA].[Medicos]  WITH CHECK ADD  CONSTRAINT [FK_Medicos_TipoDocumento] FOREIGN KEY([Medi_Dni])
REFERENCES [GRUPOSA].[TipoDocumento] ([Tipo_Doc_Cod])
GO
ALTER TABLE [GRUPOSA].[Medicos] CHECK CONSTRAINT [FK_Medicos_TipoDocumento]
GO
ALTER TABLE [GRUPOSA].[Medicos]  WITH CHECK ADD  CONSTRAINT [FK_Medicos_Turnos] FOREIGN KEY([Medi_Dni])
REFERENCES [GRUPOSA].[Turnos] ([Turn_Numero])
GO
ALTER TABLE [GRUPOSA].[Medicos] CHECK CONSTRAINT [FK_Medicos_Turnos]
GO
ALTER TABLE [GRUPOSA].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Bono] FOREIGN KEY([FK_Paciente_Bono])
REFERENCES [GRUPOSA].[Bonos] ([Bono_Consulta_Numero])
GO
ALTER TABLE [GRUPOSA].[Pacientes] CHECK CONSTRAINT [FK_Paciente_Bono]
GO
ALTER TABLE [GRUPOSA].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Turno] FOREIGN KEY([FK_Paciente_Turno])
REFERENCES [GRUPOSA].[Turnos] ([Turn_Numero])
GO
ALTER TABLE [GRUPOSA].[Pacientes] CHECK CONSTRAINT [FK_Paciente_Turno]
GO
ALTER TABLE [GRUPOSA].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Pacientes_TipoDocumento] FOREIGN KEY([FK_Cod_Documento])
REFERENCES [GRUPOSA].[TipoDocumento] ([Tipo_Doc_Cod])
GO
ALTER TABLE [GRUPOSA].[Pacientes] CHECK CONSTRAINT [FK_Pacientes_TipoDocumento]
GO
ALTER TABLE [GRUPOSA].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Plan_Medico_Paciente] FOREIGN KEY([FK_Plan_Medico_Codigo])
REFERENCES [GRUPOSA].[PlanesMedicos] ([Plan_Codigo])
GO
ALTER TABLE [GRUPOSA].[Pacientes] CHECK CONSTRAINT [FK_Plan_Medico_Paciente]
GO
ALTER TABLE [GRUPOSA].[RolesUsuario]  WITH CHECK ADD  CONSTRAINT [FK_Rol_RolesUsuario] FOREIGN KEY([RolUsu_Rol_Codigo])
REFERENCES [GRUPOSA].[Rol] ([Rol_Codigo])
GO
ALTER TABLE [GRUPOSA].[RolesUsuario] CHECK CONSTRAINT [FK_Rol_RolesUsuario]
GO
ALTER TABLE [GRUPOSA].[RolesUsuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_RolesUsuario] FOREIGN KEY([RolUsu_Usuario_Username])
REFERENCES [GRUPOSA].[Usuario] ([Usuario_Username])
GO
ALTER TABLE [GRUPOSA].[RolesUsuario] CHECK CONSTRAINT [FK_Usuario_RolesUsuario]
GO
ALTER TABLE [GRUPOSA].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Consultas] FOREIGN KEY([FK_Consulta_Turno])
REFERENCES [GRUPOSA].[Consultas] ([Cons_ID])
GO
ALTER TABLE [GRUPOSA].[Turnos] CHECK CONSTRAINT [FK_Turnos_Consultas]
GO
ALTER TABLE [GRUPOSA].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Pacientes] FOREIGN KEY([Turn_Paciente_Id])
REFERENCES [GRUPOSA].[Pacientes] ([Paci_Dni])
GO
ALTER TABLE [GRUPOSA].[Turnos] CHECK CONSTRAINT [FK_Turnos_Pacientes]
GO
ALTER TABLE [GRUPOSA].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_TiposCancelacion] FOREIGN KEY([Turn_TipoCancelacion])
REFERENCES [GRUPOSA].[TiposCancelacion] ([TipoCancelacion_Codigo])
GO
ALTER TABLE [GRUPOSA].[Turnos] CHECK CONSTRAINT [FK_Turnos_TiposCancelacion]
GO
ALTER TABLE [GRUPOSA].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Medico] FOREIGN KEY([FK_Medico_Dni])
REFERENCES [GRUPOSA].[Medicos] ([Medi_Dni])
GO
ALTER TABLE [GRUPOSA].[Usuario] CHECK CONSTRAINT [FK_Usuario_Medico]
GO
ALTER TABLE [GRUPOSA].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Paciente] FOREIGN KEY([FK_Paciente_Dni])
REFERENCES [GRUPOSA].[Pacientes] ([Paci_Dni])
GO
ALTER TABLE [GRUPOSA].[Usuario] CHECK CONSTRAINT [FK_Usuario_Paciente]