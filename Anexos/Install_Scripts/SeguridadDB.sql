USE [SeguridadDB]
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[IdFamilia] [uniqueidentifier] NOT NULL,
	[NombreRol] [varchar](1000) NULL,
	[Fecha_Familia] [datetime] NULL,
 CONSTRAINT [PK_Familia] PRIMARY KEY CLUSTERED 
(
	[IdFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_Familia]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Familia](
	[IdFamilia] [uniqueidentifier] NULL,
	[IdFamiliaHijo] [uniqueidentifier] NULL,
	[FechaCreacionFF] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamiliaPatente]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamiliaPatente](
	[IdFamilia] [uniqueidentifier] NULL,
	[IdPatente] [uniqueidentifier] NULL,
	[FechaCreacionFP] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[idlog] [uniqueidentifier] NOT NULL,
	[message] [nvarchar](100) NULL,
	[severity] [nvarchar](100) NULL,
	[fecha_txr] [datetime] NULL,
 CONSTRAINT [PK_log] PRIMARY KEY CLUSTERED 
(
	[idlog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patente]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[IdPatente] [uniqueidentifier] NOT NULL,
	[NombrePermiso] [varchar](1000) NULL,
	[Vista] [varchar](1000) NULL,
	[Fecha_Patente] [datetime] NULL,
 CONSTRAINT [PK_Patente] PRIMARY KEY CLUSTERED 
(
	[IdPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [uniqueidentifier] NOT NULL,
	[Usu_nom] [varchar](30) NOT NULL,
	[Contrasenia] [varchar](max) NULL,
	[Nombre_Completo] [nvarchar](1000) NULL,
	[Email] [varchar](30) NULL,
	[TipoDocumento] [varchar](30) NULL,
	[NroDocumento] [varchar](30) NULL,
	[FechaCreacion_Usu] [datetime] NULL,
	[Activo] [char](1) NULL,
	[EsAdmin] [char](1) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioFamilia]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioFamilia](
	[IdUsuario] [uniqueidentifier] NULL,
	[IdFamilia] [uniqueidentifier] NULL,
	[FechaCreacionUF] [datetime] NULL,
	[Usu_nom] [varchar](30) NULL,
	[NombreRol] [varchar](1000) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioPatente]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPatente](
	[IdUsuario] [uniqueidentifier] NULL,
	[IdPatente] [uniqueidentifier] NULL,
	[FechaCreacion] [datetime] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Familia] ([IdFamilia], [NombreRol], [Fecha_Familia]) VALUES (N'98ea5d11-9355-4ecf-9707-24c76a53d57c', N'TESTER', CAST(N'2023-10-25T17:07:10.917' AS DateTime))
INSERT [dbo].[Familia] ([IdFamilia], [NombreRol], [Fecha_Familia]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'ADMIN', CAST(N'2023-12-01T16:10:22.593' AS DateTime))
GO
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'98ea5d11-9355-4ecf-9707-24c76a53d57c', N'0983674e-3766-496b-b057-58a309b0f9be', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'a8ed59fd-0ac5-48bb-9b59-04bc67c20466', CAST(N'2024-03-17T21:36:26.060' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'5d2331fa-5635-4d28-9ba5-0a7f71b6e756', CAST(N'2024-03-17T21:57:24.923' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'4688ac54-7fb4-46d2-89f5-0cf8fe1640cc', CAST(N'2024-03-17T21:57:24.923' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'0d0dd81d-44ab-419b-9736-1fe95ea9b61f', CAST(N'2024-03-17T21:58:45.383' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'e2bf9f53-20f8-4788-9b8d-21f7a74b0c5a', CAST(N'2024-03-18T15:47:12.150' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'47904bc3-9947-40bb-b0b4-26bc0e739e85', CAST(N'2024-03-18T15:47:12.150' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'93070717-253d-4a98-bd53-395d7d50871e', CAST(N'2024-03-18T15:47:12.150' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'0983674e-3766-496b-b057-58a309b0f9be', CAST(N'2024-03-18T15:47:12.150' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'0983674e-3766-496b-b057-58a309b0f9be', CAST(N'2024-03-18T15:48:31.330' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'575cbe4d-8350-4cac-9757-6256ae12555f', CAST(N'2024-03-18T15:48:31.330' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'49498ed9-e903-4ee8-876f-66257d575cc5', CAST(N'2024-03-18T15:48:31.330' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'1132684e-edff-42d6-ad4f-778151f36eeb', CAST(N'2024-03-18T15:48:31.330' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'63b90e52-8120-4fdb-a6cb-c5ca738adbf4', CAST(N'2024-03-18T15:49:57.600' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'6779464a-7705-429f-863f-d8b396e23d13', CAST(N'2024-03-18T15:49:57.603' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'b4a9fdf1-0193-4f36-babd-edf3ebf5456b', CAST(N'2024-03-18T15:49:57.603' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'7afe6714-3fe3-4489-bb7f-fae48f3ffbb6', CAST(N'2024-03-18T15:49:57.603' AS DateTime))
INSERT [dbo].[FamiliaPatente] ([IdFamilia], [IdPatente], [FechaCreacionFP]) VALUES (N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', N'0188ddee-16d1-4d81-9e00-fce457f12a40', CAST(N'2024-03-18T15:49:57.603' AS DateTime))
GO
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'a8ed59fd-0ac5-48bb-9b59-04bc67c20466', N'Operaciones', N'WinFormApp.Forms.FrmPrincipal', CAST(N'2023-10-25T11:19:51.740' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'5d2331fa-5635-4d28-9ba5-0a7f71b6e756', N'Copia de seguridad y restaurar DB', N'WinFormApp.Forms.System Management.FrmSeguridadRestaurar', CAST(N'2023-10-25T11:18:14.593' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'4688ac54-7fb4-46d2-89f5-0cf8fe1640cc', N'Cerrar Sesión', N'WinFormApp.Forms.FrmPrincipal', CAST(N'2023-10-25T09:31:24.880' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'0d0dd81d-44ab-419b-9736-1fe95ea9b61f', N'Reportes', N'WinFormApp.Forms.FrmPrincipal', CAST(N'2023-10-25T11:19:26.957' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'e2bf9f53-20f8-4788-9b8d-21f7a74b0c5a', N'Compra', N'WinFormApp.Forms.Business.FrmCompra', CAST(N'2023-10-25T11:20:44.590' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'47904bc3-9947-40bb-b0b4-26bc0e739e85', N'Registrar Propiedad', N'WinFormApp.Forms.Business.FrmPropiedades', CAST(N'2023-10-25T11:21:44.127' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'93070717-253d-4a98-bd53-395d7d50871e', N'Administración del Sistema', N'WinFormApp.Forms.FrmPrincipal', CAST(N'2023-10-25T11:16:03.917' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'0983674e-3766-496b-b057-58a309b0f9be', N'Sesión', N'WinFormApp.Forms.FrmPrincipal', CAST(N'2023-10-25T09:25:45.720' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'575cbe4d-8350-4cac-9757-6256ae12555f', N'Gestión de Permisos', N'WinFormApp.Forms.SysteManagement.FrmGestorPermisos', CAST(N'2023-10-25T11:17:47.700' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'49498ed9-e903-4ee8-876f-66257d575cc5', N'Registrar Escribania', N'WinFormApp.Forms.Business.FrmEscribania', CAST(N'2023-10-25T11:22:09.613' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'1132684e-edff-42d6-ad4f-778151f36eeb', N'Ayuda', N'WinFormApp.Forms.FrmPrincipal', CAST(N'2024-03-03T14:22:51.790' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'63b90e52-8120-4fdb-a6cb-c5ca738adbf4', N'Idioma', N'WinFormApp.Forms.FrmPrincipal', CAST(N'2023-10-25T11:19:02.647' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'6779464a-7705-429f-863f-d8b396e23d13', N'Alquiler', N'WinFormApp.Forms.Business.FrmAlquiler', CAST(N'2023-10-25T11:20:20.657' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'b4a9fdf1-0193-4f36-babd-edf3ebf5456b', N'Gestión De Usuarios', N'WinFormApp.Forms.System Management.FrmGestorUsuarios', CAST(N'2023-10-25T11:16:35.493' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'7afe6714-3fe3-4489-bb7f-fae48f3ffbb6', N'Venta', N'WinFormApp.Forms.Business.FrmVenta', CAST(N'2023-10-25T11:21:20.503' AS DateTime))
INSERT [dbo].[Patente] ([IdPatente], [NombrePermiso], [Vista], [Fecha_Patente]) VALUES (N'0188ddee-16d1-4d81-9e00-fce457f12a40', N'Cambiar Sesión', N'WinFormApp.Forms.FrmPrincipal', CAST(N'2023-10-25T09:30:54.197' AS DateTime))
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Usu_nom], [Contrasenia], [Nombre_Completo], [Email], [TipoDocumento], [NroDocumento], [FechaCreacion_Usu], [Activo], [EsAdmin]) VALUES (N'cfd8023b-0898-4f21-a385-08b5a079d793', N'admin', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', N'Administrador de Sistema', N'info@myimbo.com', N'DNI', N'20500900', CAST(N'2023-09-01T19:16:35.893' AS DateTime), N'S', N'S')
INSERT [dbo].[Usuario] ([IdUsuario], [Usu_nom], [Contrasenia], [Nombre_Completo], [Email], [TipoDocumento], [NroDocumento], [FechaCreacion_Usu], [Activo], [EsAdmin]) VALUES (N'19b37d6c-f7c6-4c8c-892e-6dd7bc8c8213', N'tester', N'bdea3eb189822ec26fb752c97e3c2b50fd87326af90d8ca01c5bf67d7b8d1a67', N'Usuario Tester QA', N'tester@myimbo.com', N'CUIT', N'30209005007', CAST(N'2024-03-17T15:06:39.060' AS DateTime), N'S', N'N')
GO
INSERT [dbo].[UsuarioFamilia] ([IdUsuario], [IdFamilia], [FechaCreacionUF], [Usu_nom], [NombreRol]) VALUES (N'3b02589c-453c-483c-b31c-111f4d59ab98', N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', CAST(N'2024-03-18T16:36:06.870' AS DateTime), N'gaston', N'ADMIN')
INSERT [dbo].[UsuarioFamilia] ([IdUsuario], [IdFamilia], [FechaCreacionUF], [Usu_nom], [NombreRol]) VALUES (N'cfd8023b-0898-4f21-a385-08b5a079d793', N'dc004d67-fd93-4da8-b7ef-9a83ef3c4251', CAST(N'2023-12-01T16:15:02.327' AS DateTime), N'admin', N'ADMIN')
GO
INSERT [dbo].[UsuarioPatente] ([IdUsuario], [IdPatente], [FechaCreacion]) VALUES (N'19b37d6c-f7c6-4c8c-892e-6dd7bc8c8213', N'0983674e-3766-496b-b057-58a309b0f9be', CAST(N'2023-10-30T13:52:03.483' AS DateTime))
INSERT [dbo].[UsuarioPatente] ([IdUsuario], [IdPatente], [FechaCreacion]) VALUES (N'cfd8023b-0898-4f21-a385-08b5a079d793', N'1132684e-edff-42d6-ad4f-778151f36eeb', CAST(N'2024-03-03T14:23:13.823' AS DateTime))
INSERT [dbo].[UsuarioPatente] ([IdUsuario], [IdPatente], [FechaCreacion]) VALUES (N'19b37d6c-f7c6-4c8c-892e-6dd7bc8c8213', N'4688ac54-7fb4-46d2-89f5-0cf8fe1640cc', CAST(N'2023-10-30T13:53:19.520' AS DateTime))
INSERT [dbo].[UsuarioPatente] ([IdUsuario], [IdPatente], [FechaCreacion]) VALUES (N'cfd8023b-0898-4f21-a385-08b5a079d793', N'93070717-253d-4a98-bd53-395d7d50871e', CAST(N'2024-02-20T19:07:22.483' AS DateTime))
INSERT [dbo].[UsuarioPatente] ([IdUsuario], [IdPatente], [FechaCreacion]) VALUES (N'cfd8023b-0898-4f21-a385-08b5a079d793', N'0983674e-3766-496b-b057-58a309b0f9be', CAST(N'2024-02-20T22:05:51.430' AS DateTime))
INSERT [dbo].[UsuarioPatente] ([IdUsuario], [IdPatente], [FechaCreacion]) VALUES (N'cfd8023b-0898-4f21-a385-08b5a079d793', N'0188ddee-16d1-4d81-9e00-fce457f12a40', CAST(N'2024-02-20T22:06:10.830' AS DateTime))
INSERT [dbo].[UsuarioPatente] ([IdUsuario], [IdPatente], [FechaCreacion]) VALUES (N'cfd8023b-0898-4f21-a385-08b5a079d793', N'4688ac54-7fb4-46d2-89f5-0cf8fe1640cc', CAST(N'2024-02-20T22:06:31.483' AS DateTime))
INSERT [dbo].[UsuarioPatente] ([IdUsuario], [IdPatente], [FechaCreacion]) VALUES (N'cfd8023b-0898-4f21-a385-08b5a079d793', N'63b90e52-8120-4fdb-a6cb-c5ca738adbf4', CAST(N'2024-02-20T22:16:02.690' AS DateTime))
INSERT [dbo].[UsuarioPatente] ([IdUsuario], [IdPatente], [FechaCreacion]) VALUES (N'3b02589c-453c-483c-b31c-111f4d59ab98', N'0983674e-3766-496b-b057-58a309b0f9be', CAST(N'2024-03-15T19:25:25.767' AS DateTime))
INSERT [dbo].[UsuarioPatente] ([IdUsuario], [IdPatente], [FechaCreacion]) VALUES (N'cfd8023b-0898-4f21-a385-08b5a079d793', N'b4a9fdf1-0193-4f36-babd-edf3ebf5456b', CAST(N'2024-03-18T16:07:14.163' AS DateTime))
INSERT [dbo].[UsuarioPatente] ([IdUsuario], [IdPatente], [FechaCreacion]) VALUES (N'cfd8023b-0898-4f21-a385-08b5a079d793', N'575cbe4d-8350-4cac-9757-6256ae12555f', CAST(N'2024-03-18T16:07:28.930' AS DateTime))
INSERT [dbo].[UsuarioPatente] ([IdUsuario], [IdPatente], [FechaCreacion]) VALUES (N'cfd8023b-0898-4f21-a385-08b5a079d793', N'a8ed59fd-0ac5-48bb-9b59-04bc67c20466', CAST(N'2023-12-01T16:41:49.483' AS DateTime))
INSERT [dbo].[UsuarioPatente] ([IdUsuario], [IdPatente], [FechaCreacion]) VALUES (N'cfd8023b-0898-4f21-a385-08b5a079d793', N'5d2331fa-5635-4d28-9ba5-0a7f71b6e756', CAST(N'2024-03-18T16:07:46.770' AS DateTime))
GO
ALTER TABLE [dbo].[Familia_Familia]  WITH CHECK ADD  CONSTRAINT [FK_Familia_Familia_Familia] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[Familia_Familia] CHECK CONSTRAINT [FK_Familia_Familia_Familia]
GO
ALTER TABLE [dbo].[FamiliaPatente]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaPatente_Familia] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[FamiliaPatente] CHECK CONSTRAINT [FK_FamiliaPatente_Familia]
GO
ALTER TABLE [dbo].[FamiliaPatente]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaPatente_Patente] FOREIGN KEY([IdPatente])
REFERENCES [dbo].[Patente] ([IdPatente])
GO
ALTER TABLE [dbo].[FamiliaPatente] CHECK CONSTRAINT [FK_FamiliaPatente_Patente]
GO
ALTER TABLE [dbo].[UsuarioFamilia]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioFamilia_Familia] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[UsuarioFamilia] CHECK CONSTRAINT [FK_UsuarioFamilia_Familia]
GO
ALTER TABLE [dbo].[UsuarioFamilia]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioFamilia_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[UsuarioFamilia] CHECK CONSTRAINT [FK_UsuarioFamilia_Usuario]
GO
ALTER TABLE [dbo].[UsuarioPatente]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPatente_Patente] FOREIGN KEY([IdPatente])
REFERENCES [dbo].[Patente] ([IdPatente])
GO
ALTER TABLE [dbo].[UsuarioPatente] CHECK CONSTRAINT [FK_UsuarioPatente_Patente]
GO
ALTER TABLE [dbo].[UsuarioPatente]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPatente_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[UsuarioPatente] CHECK CONSTRAINT [FK_UsuarioPatente_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[BuscarPermisoPorNombre]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscarPermisoPorNombre]
    @NombrePermiso NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 * FROM [dbo].[Patente]
    WHERE [NombrePermiso] = @NombrePermiso;
END
GO
/****** Object:  StoredProcedure [dbo].[BuscarRolPorNombre]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscarRolPorNombre]
    @NombreRol NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 1 * FROM [dbo].[Familia]
    WHERE [NombreRol] = @NombreRol;
END
GO
/****** Object:  StoredProcedure [dbo].[ExisteUsuarioRol]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExisteUsuarioRol]
    @Usu_Nom VARCHAR(30),
    @NombreRol NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        DECLARE @Existencia INT;

        -- Verificar si existe el usuario con el nombre de usuario proporcionado y el rol con el nombre de rol proporcionado
        SELECT @Existencia = 
            CASE 
                WHEN EXISTS (SELECT 1 FROM Usuario WHERE Usu_nom = @Usu_Nom) AND 
                     EXISTS (SELECT 1 FROM Familia WHERE NombreRol = @NombreRol) 
                THEN 1 
                ELSE 0 
            END;

        -- Devolver el resultado (1 si existe, 0 si no existe)
        SELECT @Existencia AS ExisteUsuarioRol;
    END TRY
    BEGIN CATCH
        -- Manejar errores si ocurrieron durante la ejecución del procedimiento almacenado
        SELECT ERROR_MESSAGE() AS ErrorMessage;
    END CATCH;
END

GO
/****** Object:  StoredProcedure [dbo].[Familia_FamiliaInsert]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Familia_FamiliaInsert] (
	@IdFamilia uniqueidentifier,
	@IdFamiliaHijo uniqueidentifier,
	@FechaCreacionFF datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Familia_Familia] (
	[IdFamilia],
	[IdFamiliaHijo],
	[FechaCreacionFF]
) VALUES (
	@IdFamilia,
	@IdFamiliaHijo,
	@FechaCreacionFF
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[Familia_FamiliaSelectByIdFamilia]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Familia_FamiliaSelectByIdFamilia] (
	@IdFamilia uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdFamilia],
	[IdFamiliaHijo],
	[FechaCreacionFF]
FROM
	[Familia_Familia]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaDelete]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaDelete] (
	@IdFamilia uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Familia]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaInsert]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaInsert] (
	@IdFamilia uniqueidentifier,
	@NombreRol varchar(1000),
	@Fecha_Familia datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Familia] (
	[IdFamilia],
	[NombreRol],
	[Fecha_Familia]
) VALUES (
	@IdFamilia,
	@NombreRol,
	@Fecha_Familia
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaPatenteDeleteByIdFamilia]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteDeleteByIdFamilia] (
	@IdFamilia uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[FamiliaPatente]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaPatenteDeleteByIdPatente]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteDeleteByIdPatente] (
	@IdPatente uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[FamiliaPatente]
WHERE
	[IdPatente] = @IdPatente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaPatenteInsert]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteInsert] (
	@IdFamilia uniqueidentifier,
	@IdPatente uniqueidentifier,
	@FechaCreacionFP datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [FamiliaPatente] (
	[IdFamilia],
	[IdPatente],
	[FechaCreacionFP]
) VALUES (
	@IdFamilia,
	@IdPatente,
	@FechaCreacionFP
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaPatenteSelect]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteSelect] 

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdFamilia],
	[IdPatente],
	[FechaCreacionFP]
FROM
	[FamiliaPatente]



IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaPatenteSelectByIdFamilia]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteSelectByIdFamilia] (
	@IdFamilia uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdFamilia],
	[IdPatente],
	[FechaCreacionFP]
FROM
	[FamiliaPatente]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaPatenteSelectByIdPatente]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaPatenteSelectByIdPatente] (
	@IdPatente uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdFamilia],
	[IdPatente],
	[FechaCreacionFP]
FROM
	[FamiliaPatente]
WHERE
	[IdPatente] = @IdPatente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaSelect]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaSelect] (
	@IdFamilia uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdFamilia],
	[Nombre],
	[Fecha_Familia]
FROM
	[Familia]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaSelectAll]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdFamilia],
	[NombreRol],
	[Fecha_Familia]
FROM
	[Familia]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaSelectById]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaSelectById] (
	@IdFamilia uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdFamilia],
	[NombreRol],
	[Fecha_Familia]
FROM
	[Familia]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaUpdate]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaUpdate] (
	@IdFamilia uniqueidentifier,
	@NombreRol varchar(1000),
	@Fecha_Familia datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Familia]
SET
	[NombreRol] = @NombreRol,
	[Fecha_Familia] = @Fecha_Familia
WHERE
	 [IdFamilia] = @IdFamilia

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[LogInsert]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LogInsert] (
	@idlog uniqueidentifier,
	@message nvarchar(100),
	@severity nvarchar(50),
	@fecha_txr datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Log] (
	[idlog],
	[message],
	[severity],
	[fecha_txr]
) VALUES (
	@idlog,
	@message,
	@severity,
	@fecha_txr
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
GO
/****** Object:  StoredProcedure [dbo].[LogSelectAll]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LogSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idlog],
	[message],
	[severity],
	[fecha_txr]
FROM
	[Log]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
GO
/****** Object:  StoredProcedure [dbo].[PatenteDelete]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PatenteDelete] (
	@IdPatente uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Patente]
WHERE
	[IdPatente] = @IdPatente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[PatenteInsert]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PatenteInsert] (
	@IdPatente uniqueidentifier,
	@NombrePermiso varchar(1000),
	@Vista varchar(1000),
	@Fecha_Patente datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Patente] (
	[IdPatente],
	[NombrePermiso],
	[Vista],
	[Fecha_Patente]
) VALUES (
	@IdPatente,
	@NombrePermiso,
	@Vista,
	@Fecha_Patente
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[PatenteSelect]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PatenteSelect] (
	@IdPatente uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdPatente],
	[NombrePermiso],
	[Vista],
	[Fecha_Patente]
FROM
	[Patente]
WHERE
	[IdPatente] = @IdPatente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[PatenteSelectAll]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PatenteSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdPatente],
	[NombrePermiso],
	[Vista],
	[Fecha_Patente]
FROM
	[Patente]
GROUP BY
	[IdPatente],
	[NombrePermiso],
	[Vista],
	[Fecha_Patente]

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[PatenteUpdate]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PatenteUpdate] (
	@IdPatente uniqueidentifier,
	@Nombre varchar(1000),
	@Vista varchar(1000),
	@Fecha_Patente datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Patente]
SET
	[Nombre] = @Nombre,
	[Vista] = @Vista,
	[Fecha_Patente] = @Fecha_Patente
WHERE
	 [IdPatente] = @IdPatente

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[UsuarioDelete]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioDelete] (
	@IdUsuario uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Usuario]
WHERE
	[IdUsuario] = @IdUsuario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[UsuarioFamiliaDeleteByIdFamilia]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaDeleteByIdFamilia] (
	@IdFamilia uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[UsuarioFamilia]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[UsuarioFamiliaDeleteByIdUsuario]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaDeleteByIdUsuario] (
	@IdUsuario uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[UsuarioFamilia]
WHERE
	[IdUsuario] = @IdUsuario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[UsuarioFamiliaInsert]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaInsert] (
	@IdUsuario uniqueidentifier,
	@IdFamilia uniqueidentifier,
	@FechaCreacionUF datetime,
	@Usu_nom varchar(30),
	@NombreRol varchar(100)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [UsuarioFamilia] (
	[IdUsuario],
	[IdFamilia],
	[FechaCreacionUF],
	[Usu_nom],
	[NombreRol]
) VALUES (
	@IdUsuario,
	@IdFamilia,
	@FechaCreacionUF,
	@Usu_nom,
	@NombreRol

)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[UsuarioFamiliaSelect]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaSelect]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdUsuario],
	[IdFamilia],
	[FechaCreacionUF],
	[Usu_nom],
	[NombreRol]
FROM
	[UsuarioFamilia]



IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[UsuarioFamiliaSelectByIdFamilia]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaSelectByIdFamilia] (
	@IdFamilia uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdUsuario],
	[IdFamilia],
	[FechaCreacionUF]
FROM
	[UsuarioFamilia]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[UsuarioFamiliaSelectByIdUsuario]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioFamiliaSelectByIdUsuario] (
	@IdUsuario uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdUsuario],
	[IdFamilia],
	[FechaCreacionUF],
	[Usu_nom],
	[NombreRol]

FROM
	[UsuarioFamilia]
WHERE
	[IdUsuario] = @IdUsuario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[UsuarioInsert]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioInsert] (
    @IdUsuario uniqueidentifier,
    @Usu_nom varchar(30),
    @Contrasenia varchar(MAX),
    @Nombre_Completo nvarchar(1000),
    @Email varchar(30),
    @TipoDocumento varchar(30),
    @NroDocumento varchar(30),
    @FechaCreacion_Usu datetime,
    @Activo char(1),
	@EsAdmin char(1)
)
AS
BEGIN
    -- Verificar si @Usu_nom es nulo o cadena vacía
    IF @Usu_nom IS NULL OR LTRIM(RTRIM(@Usu_nom)) = ''
    BEGIN
        -- Generar un error personalizado y mostrar un mensaje
        THROW 51000, 'El campo Usuario no puede ser nulo o una cadena vacía.', 1;
    END

    SET NOCOUNT ON

    DECLARE @DBID INT, @DBNAME NVARCHAR(128);
    SET @DBID = DB_ID();
    SET @DBNAME = DB_NAME();

    INSERT INTO [Usuario] (
        [IdUsuario],
        [Usu_nom],
        [Contrasenia],
        [Nombre_Completo],
        [Email],
        [TipoDocumento],
        [NroDocumento],
        [FechaCreacion_Usu],
        [Activo],
		[EsAdmin]
    ) VALUES (
        @IdUsuario,
        @Usu_nom,
        @Contrasenia,
        @Nombre_Completo,
        @Email,
        @TipoDocumento,
        @NroDocumento,
        @FechaCreacion_Usu,
        @Activo,
		@EsAdmin
    )

    IF (@@ERROR <> 0)
        THROW 51000, 'Se produjo un error durante la inserción de datos.', 1;
END
GO
/****** Object:  StoredProcedure [dbo].[UsuarioPatenteDeleteByIdUsuario]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioPatenteDeleteByIdUsuario] (
	@IdUsuario uniqueidentifier,
	@IdPatente uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[UsuarioPatente]
WHERE
	[IdUsuario] = @IdUsuario AND
	[IdPatente] = @IdPatente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[UsuarioPatenteInsert]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioPatenteInsert] (
	@IdUsuario uniqueidentifier,
	@IdPatente uniqueidentifier,
	@FechaCreacion datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [UsuarioPatente] (
	[IdUsuario],
	[IdPatente],
	[FechaCreacion]
) VALUES (
	@IdUsuario,
	@IdPatente,
	@FechaCreacion
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[UsuarioPatenteSelectALL]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioPatenteSelectALL]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT UP.IdUsuario, UP.IdPatente, UP.FechaCreacion, P.NombrePermiso, P.Vista, U.Usu_nom, U.Nombre_Completo
    FROM UsuarioPatente UP
    LEFT OUTER JOIN Patente P ON P.IdPatente = UP.IdPatente
    LEFT OUTER JOIN Usuario U ON U.IdUsuario = UP.IdUsuario
	ORDER BY U.Usu_nom;
END;
GO
/****** Object:  StoredProcedure [dbo].[UsuarioPatenteSelectByIdUsuario]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioPatenteSelectByIdUsuario] (
	@IdUsuario uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdUsuario],
	[IdPatente],
	[FechaCreacion]
FROM
	[UsuarioPatente]
WHERE
	[IdUsuario] = @IdUsuario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[UsuarioSelect]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioSelect] (
	@IdUsuario uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdUsuario],
	[Usu_nom],
	[Contrasenia],
	[Nombre_Completo],
	[Email],
	[TipoDocumento],
	[NroDocumento],
	[FechaCreacion_Usu],
	[Activo],
	[EsAdmin]
FROM
	[Usuario]
WHERE
	[IdUsuario] = @IdUsuario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[UsuarioSelectAll]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdUsuario],
	[Usu_nom],
	[Contrasenia],
	[Nombre_Completo],
	[Email],
	[TipoDocumento],
	[NroDocumento],
	[FechaCreacion_Usu],
	[Activo],
	[EsAdmin]
FROM
	[Usuario]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[UsuarioSelectByName]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioSelectByName]
    @NombreUsuario NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [IdUsuario],
        [Usu_nom],
        [Contrasenia],
        [Nombre_Completo],
        [Email],
        [TipoDocumento],
        [NroDocumento],
        [FechaCreacion_Usu],
        [Activo],
		[EsAdmin]
    FROM 
        [SeguridadDB].[dbo].[Usuario]
    WHERE 
        [Usu_nom] = @NombreUsuario;
END





GO
/****** Object:  StoredProcedure [dbo].[UsuarioSesion]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioSesion]
    @NombreUsuario NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [IdUsuario],
        [Usu_nom],
        [Contrasenia],
        [Nombre_Completo],
        [Email],
        [TipoDocumento],
        [NroDocumento],
        [FechaCreacion_Usu],
        [Activo],
		[EsAdmin]
    FROM 
        [SeguridadDB].[dbo].[Usuario]
    WHERE 
        [Usu_nom] = @NombreUsuario
		AND Activo = 'S'
END





GO
/****** Object:  StoredProcedure [dbo].[UsuarioUpdate]    Script Date: 19/3/2024 09:04:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioUpdate] (
	@IdUsuario uniqueidentifier,
	@Usu_nom varchar(30),
	@Contrasenia varchar(MAX),
	@Nombre_Completo nvarchar(1000),
	@Email varchar(30),
	@TipoDocumento varchar(30),
	@NroDocumento varchar(30),
	@FechaCreacion_Usu datetime,
	@Activo char(1),
	@EsAdmin char(1)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Usuario]
SET
	[Usu_nom] = @Usu_nom,
	[Contrasenia] = @Contrasenia,
	[Nombre_Completo] = @Nombre_Completo,
	[Email] = @Email,
	[TipoDocumento] = @TipoDocumento,
	[NroDocumento] = @NroDocumento,
	[FechaCreacion_Usu] = @FechaCreacion_Usu,
	[Activo] = @Activo,
	[EsAdmin] = @EsAdmin
WHERE
	 [IdUsuario] = @IdUsuario

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
