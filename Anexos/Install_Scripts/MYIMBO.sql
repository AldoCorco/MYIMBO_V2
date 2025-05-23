USE [MYIMBO]
GO
/****** Object:  Table [dbo].[Alquiler]    Script Date: 5/3/2024 09:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alquiler](
	[idalquiler] [uniqueidentifier] NOT NULL,
	[importe_reserva] [int] NULL,
	[garantia] [nvarchar](50) NULL,
	[importe_alquiler] [decimal](18, 2) NULL,
	[idtipo_inmueble] [uniqueidentifier] NULL,
	[Activo] [char](1) NULL,
 CONSTRAINT [PK_alquiler] PRIMARY KEY CLUSTERED 
(
	[idalquiler] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 5/3/2024 09:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idcliente] [uniqueidentifier] NOT NULL,
	[legajo_inquilino] [int] NULL,
	[nombre] [nvarchar](50) NULL,
	[apellido] [nvarchar](50) NULL,
	[dni] [int] NULL,
	[fecha_nac] [date] NULL,
	[telefono] [nvarchar](50) NULL,
	[idtipo_inmueble] [uniqueidentifier] NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comprador]    Script Date: 5/3/2024 09:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comprador](
	[idcomprador] [uniqueidentifier] NOT NULL,
	[legajo_comprador] [int] NULL,
	[nombre] [nvarchar](50) NULL,
	[apellido] [nvarchar](50) NULL,
	[dni] [int] NULL,
	[fecha_nac] [date] NULL,
	[telefono] [nvarchar](50) NULL,
	[idtipo_inmueble] [uniqueidentifier] NULL,
	[importe] [int] NULL,
	[comision] [decimal](18, 2) NULL,
	[impuesto] [decimal](18, 2) NULL,
	[total_propiedad] [decimal](18, 2) NULL,
	[Activo] [char](1) NULL,
 CONSTRAINT [PK_comprador] PRIMARY KEY CLUSTERED 
(
	[idcomprador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contrato]    Script Date: 5/3/2024 09:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contrato](
	[idcontrato] [uniqueidentifier] NOT NULL,
	[fecha_inicio] [date] NULL,
	[fecha_fin] [date] NULL,
	[idescribania] [uniqueidentifier] NULL,
	[idtipo_inmueble] [uniqueidentifier] NULL,
	[idalquiler] [uniqueidentifier] NULL,
	[idcliente] [uniqueidentifier] NULL,
 CONSTRAINT [PK_contrato] PRIMARY KEY CLUSTERED 
(
	[idcontrato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Escribania]    Script Date: 5/3/2024 09:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escribania](
	[idescribania] [uniqueidentifier] NOT NULL,
	[razon_social] [nvarchar](50) NULL,
	[direccion] [nvarchar](50) NULL,
	[telefono] [nvarchar](50) NULL,
 CONSTRAINT [PK_escribania] PRIMARY KEY CLUSTERED 
(
	[idescribania] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inmobiliaria]    Script Date: 5/3/2024 09:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inmobiliaria](
	[idinmueble] [uniqueidentifier] NOT NULL,
	[idtipo_inmueble] [uniqueidentifier] NULL,
	[idpropietario] [uniqueidentifier] NULL,
	[idcomprador] [uniqueidentifier] NULL,
	[idalquiler] [uniqueidentifier] NULL,
	[idventa] [uniqueidentifier] NULL,
	[idcontrato] [uniqueidentifier] NULL,
	[detalle] [nvarchar](50) NULL,
	[fecha_operacion] [datetime] NULL,
	[Activo] [char](1) NULL,
 CONSTRAINT [PK_inmueble] PRIMARY KEY CLUSTERED 
(
	[idinmueble] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidad]    Script Date: 5/3/2024 09:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidad](
	[idlocalidad] [uniqueidentifier] NOT NULL,
	[nom_localidad] [nvarchar](50) NULL,
	[codigo_postal] [int] NULL,
	[idpartido] [uniqueidentifier] NULL,
 CONSTRAINT [PK_localidad] PRIMARY KEY CLUSTERED 
(
	[idlocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 5/3/2024 09:52:08 ******/
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
/****** Object:  Table [dbo].[Partido]    Script Date: 5/3/2024 09:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partido](
	[idpartido] [uniqueidentifier] NOT NULL,
	[idprovincia] [uniqueidentifier] NULL,
	[nom_partido] [nvarchar](50) NULL,
 CONSTRAINT [PK_Partido] PRIMARY KEY CLUSTERED 
(
	[idpartido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Propietario]    Script Date: 5/3/2024 09:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Propietario](
	[idpropietario] [uniqueidentifier] NOT NULL,
	[legajo_propietario] [int] NULL,
	[nombre] [nvarchar](50) NULL,
	[apellido] [nvarchar](50) NULL,
	[dni] [int] NULL,
	[fecha_nac] [date] NULL,
	[telefono] [nvarchar](50) NULL,
	[idtipo_inmueble] [uniqueidentifier] NULL,
 CONSTRAINT [PK_propietario] PRIMARY KEY CLUSTERED 
(
	[idpropietario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincia]    Script Date: 5/3/2024 09:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincia](
	[idprovincia] [uniqueidentifier] NOT NULL,
	[nom_provincia] [nvarchar](50) NULL,
 CONSTRAINT [PK_Provincia] PRIMARY KEY CLUSTERED 
(
	[idprovincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasacion]    Script Date: 5/3/2024 09:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasacion](
	[idtasacion] [uniqueidentifier] NOT NULL,
	[importe_venta] [int] NULL,
	[fecha] [datetime] NULL,
	[importe_alquiler] [int] NULL,
	[idtipo_inmueble] [uniqueidentifier] NULL,
 CONSTRAINT [PK_tasacion] PRIMARY KEY CLUSTERED 
(
	[idtasacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Inmueble]    Script Date: 5/3/2024 09:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Inmueble](
	[idtipo_inmueble] [uniqueidentifier] NOT NULL,
	[tipo_inmueble] [nvarchar](50) NULL,
	[descripcion] [nvarchar](50) NULL,
	[idlocalidad] [uniqueidentifier] NULL,
	[idpartido] [uniqueidentifier] NULL,
	[idprovincia] [uniqueidentifier] NULL,
	[direccion] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tipo_Inmueble] PRIMARY KEY CLUSTERED 
(
	[idtipo_inmueble] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 5/3/2024 09:52:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[idventa] [uniqueidentifier] NOT NULL,
	[importe] [int] NULL,
	[comision] [decimal](18, 2) NULL,
	[idtipo_inmueble] [uniqueidentifier] NULL,
	[Activo] [char](1) NULL,
	[idpropietario] [uniqueidentifier] NULL,
	[tipo_inmueble] [nvarchar](50) NULL,
	[descripcion] [nvarchar](50) NULL,
	[direccion] [nvarchar](50) NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[idventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Alquiler] ([idalquiler], [importe_reserva], [garantia], [importe_alquiler], [idtipo_inmueble], [Activo]) VALUES (N'78cfdf9f-9bf2-4be8-bbae-277141e346aa', 1650, N'Garantias recibidas y aprobadas', CAST(8736.00 AS Decimal(18, 2)), N'1c5ec8d1-26bc-4b10-96df-68e512671f72', N'1')
INSERT [dbo].[Alquiler] ([idalquiler], [importe_reserva], [garantia], [importe_alquiler], [idtipo_inmueble], [Activo]) VALUES (N'5829534e-9e43-438e-9e80-38a43e953cbc', 1510, N'Garantias recibidas y aprobadas', CAST(15525.00 AS Decimal(18, 2)), N'70a7ecaa-62f2-489f-b37b-44a3f378e2f1', N'1')
INSERT [dbo].[Alquiler] ([idalquiler], [importe_reserva], [garantia], [importe_alquiler], [idtipo_inmueble], [Activo]) VALUES (N'bf2fff9c-e68c-476f-b668-4d2134369e50', 3750, N'Garantias recibidas y aprobadas', CAST(8736.00 AS Decimal(18, 2)), N'1c5ec8d1-26bc-4b10-96df-68e512671f72', N'1')
INSERT [dbo].[Alquiler] ([idalquiler], [importe_reserva], [garantia], [importe_alquiler], [idtipo_inmueble], [Activo]) VALUES (N'1ec2f45f-cce4-4013-9cc0-5b1172346ad2', 1505, N'Garantias recibidas y aprobadas', CAST(15525.00 AS Decimal(18, 2)), N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'1')
INSERT [dbo].[Alquiler] ([idalquiler], [importe_reserva], [garantia], [importe_alquiler], [idtipo_inmueble], [Activo]) VALUES (N'a2ce9b1c-b166-49c0-99f7-94bac698d0c3', 1555, N'Garantias recibidas y aprobadas', CAST(15525.00 AS Decimal(18, 2)), N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'1')
INSERT [dbo].[Alquiler] ([idalquiler], [importe_reserva], [garantia], [importe_alquiler], [idtipo_inmueble], [Activo]) VALUES (N'953e3e83-9079-462f-aa45-959ac40e9d06', 1500, N'Garantias recibidas y aprobadas', CAST(15525.00 AS Decimal(18, 2)), N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'1')
INSERT [dbo].[Alquiler] ([idalquiler], [importe_reserva], [garantia], [importe_alquiler], [idtipo_inmueble], [Activo]) VALUES (N'3bb16983-6bbd-4e0d-99f2-b98242780bc5', 3600, N'Garantias recibidas y aprobadas', CAST(8736.00 AS Decimal(18, 2)), N'1c5ec8d1-26bc-4b10-96df-68e512671f72', N'1')
INSERT [dbo].[Alquiler] ([idalquiler], [importe_reserva], [garantia], [importe_alquiler], [idtipo_inmueble], [Activo]) VALUES (N'ba49be07-bfcc-4c1c-ae49-c88d68426a28', 1500, N'Garantias recibidas y aprobadas', CAST(15525.00 AS Decimal(18, 2)), N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'1')
INSERT [dbo].[Alquiler] ([idalquiler], [importe_reserva], [garantia], [importe_alquiler], [idtipo_inmueble], [Activo]) VALUES (N'5dc6f673-a9e4-4447-8755-d2a0539fd4c3', 1510, N'Garantias recibidas y aprobadas', CAST(15525.00 AS Decimal(18, 2)), N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'1')
INSERT [dbo].[Alquiler] ([idalquiler], [importe_reserva], [garantia], [importe_alquiler], [idtipo_inmueble], [Activo]) VALUES (N'bac8b4cf-d163-40a3-b6b4-ee10093b9ff1', 1509, N'Garantias recibidas y aprobadas', CAST(15525.00 AS Decimal(18, 2)), N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'1')
INSERT [dbo].[Alquiler] ([idalquiler], [importe_reserva], [garantia], [importe_alquiler], [idtipo_inmueble], [Activo]) VALUES (N'7c6ac602-f649-42ba-9c72-f65de4c867cb', 1801, N'Garantias recibidas y aprobadas', CAST(19550.00 AS Decimal(18, 2)), N'3ced02bb-6349-4329-aad2-11cfa292ae3e', N'1')
INSERT [dbo].[Alquiler] ([idalquiler], [importe_reserva], [garantia], [importe_alquiler], [idtipo_inmueble], [Activo]) VALUES (N'dfee9029-d886-458b-8750-fc6afebd3900', 0, N'Garantias recibidas y aprobadas', CAST(140400.00 AS Decimal(18, 2)), N'75f89b21-5116-4dbb-9818-ccf86c4d4d27', N'1')
GO
INSERT [dbo].[Cliente] ([idcliente], [legajo_inquilino], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble]) VALUES (N'efc700ee-515b-4606-b6a6-1a5a7a0a4849', 2, N'Adrian', N'Varela', 27900800, CAST(N'1984-05-08' AS Date), N'1165001500', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a')
INSERT [dbo].[Cliente] ([idcliente], [legajo_inquilino], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble]) VALUES (N'fa16033c-f0cb-4458-a013-1ee46266e85c', 1, N'Fernando Adrian', N'Aguilar', 93250456, CAST(N'1990-06-07' AS Date), N'1195008200', N'3ced02bb-6349-4329-aad2-11cfa292ae3e')
INSERT [dbo].[Cliente] ([idcliente], [legajo_inquilino], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble]) VALUES (N'01020061-db99-4029-832c-997b6a89fc86', 2, N'Adrian', N'Varela', 27900800, CAST(N'1984-05-08' AS Date), N'1165001500', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a')
INSERT [dbo].[Cliente] ([idcliente], [legajo_inquilino], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble]) VALUES (N'9de6bde4-ee31-45a2-9805-9f37c5e31708', 1, N'Fernando Adrian', N'Aguilar', 93250456, CAST(N'1990-06-07' AS Date), N'1195008200', N'3ced02bb-6349-4329-aad2-11cfa292ae3e')
INSERT [dbo].[Cliente] ([idcliente], [legajo_inquilino], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble]) VALUES (N'bebff004-45ed-4855-918a-dabd591fceb0', 3, N'lkewlrjhwieoj', N'ertrrt', 7777, CAST(N'2024-02-05' AS Date), N'8888', N'70a7ecaa-62f2-489f-b37b-44a3f378e2f1')
INSERT [dbo].[Cliente] ([idcliente], [legajo_inquilino], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble]) VALUES (N'deba213a-acef-498d-bf2a-e9f20037067c', 2, N'Adrian Javier', N'Varela', 27900800, CAST(N'1984-05-08' AS Date), N'1165001500', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a')
GO
INSERT [dbo].[Comprador] ([idcomprador], [legajo_comprador], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble], [importe], [comision], [impuesto], [total_propiedad], [Activo]) VALUES (N'8663aeeb-f306-471e-8161-01e2169e1b10', 3, N'pppppp', N'kkkkkkk', 88888888, CAST(N'2024-02-29' AS Date), N'9999999', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', 150000, CAST(30000.00 AS Decimal(18, 2)), CAST(22500.00 AS Decimal(18, 2)), CAST(202500.00 AS Decimal(18, 2)), N'0')
INSERT [dbo].[Comprador] ([idcomprador], [legajo_comprador], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble], [importe], [comision], [impuesto], [total_propiedad], [Activo]) VALUES (N'be6b0696-7d6e-4b15-b5b1-1632a73c7a91', 3, N'HHHHHH', N'FFFFFF', 8888, CAST(N'2024-02-29' AS Date), N'7777', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', 150000, CAST(30000.00 AS Decimal(18, 2)), CAST(22500.00 AS Decimal(18, 2)), CAST(202500.00 AS Decimal(18, 2)), N'0')
INSERT [dbo].[Comprador] ([idcomprador], [legajo_comprador], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble], [importe], [comision], [impuesto], [total_propiedad], [Activo]) VALUES (N'd5203bf8-d318-412a-ba6a-29d549c4c0b7', 2, N'Pablo', N'Ruiz', 93444123, CAST(N'2024-02-22' AS Date), N'1144556677', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', 150000, CAST(30000.00 AS Decimal(18, 2)), CAST(22500.00 AS Decimal(18, 2)), CAST(202500.00 AS Decimal(18, 2)), N'1')
INSERT [dbo].[Comprador] ([idcomprador], [legajo_comprador], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble], [importe], [comision], [impuesto], [total_propiedad], [Activo]) VALUES (N'24cca429-c96d-4d07-9f44-2cf4281d8d74', 4, N'Paula', N'Ruiz', 14500230, CAST(N'1999-05-10' AS Date), N'1195007788', N'1c5ec8d1-26bc-4b10-96df-68e512671f72', 78000, CAST(15600.00 AS Decimal(18, 2)), CAST(11700.00 AS Decimal(18, 2)), CAST(105300.00 AS Decimal(18, 2)), N'1')
INSERT [dbo].[Comprador] ([idcomprador], [legajo_comprador], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble], [importe], [comision], [impuesto], [total_propiedad], [Activo]) VALUES (N'920f4a96-6f62-41e8-89a4-30cbd4caadb4', 3, N'Alain', N'Fox', 455678, CAST(N'2024-02-29' AS Date), N'55558877', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', 150000, CAST(30000.00 AS Decimal(18, 2)), CAST(22500.00 AS Decimal(18, 2)), CAST(202500.00 AS Decimal(18, 2)), N'1')
INSERT [dbo].[Comprador] ([idcomprador], [legajo_comprador], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble], [importe], [comision], [impuesto], [total_propiedad], [Activo]) VALUES (N'92ccab4e-afc7-496c-9cc3-35263432e9c7', 3, N'opòpòp', N'fdgtdfgfg', 4444, CAST(N'2024-02-29' AS Date), N'3333', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', 150000, CAST(30000.00 AS Decimal(18, 2)), CAST(22500.00 AS Decimal(18, 2)), CAST(202500.00 AS Decimal(18, 2)), N'1')
INSERT [dbo].[Comprador] ([idcomprador], [legajo_comprador], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble], [importe], [comision], [impuesto], [total_propiedad], [Activo]) VALUES (N'401ad4c5-119e-4be9-8f23-368982bd7500', 3, N'FFFFF', N'XXXX', 54564, CAST(N'2024-02-29' AS Date), N'000088888', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', 150000, CAST(30000.00 AS Decimal(18, 2)), CAST(22500.00 AS Decimal(18, 2)), CAST(202500.00 AS Decimal(18, 2)), N'1')
INSERT [dbo].[Comprador] ([idcomprador], [legajo_comprador], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble], [importe], [comision], [impuesto], [total_propiedad], [Activo]) VALUES (N'4d411dfb-c9bf-484a-a709-3b6f4c9656b7', 3, N'KKKKK', N'LLLLLL', 1213213, CAST(N'2024-02-13' AS Date), N'45009800', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', 150000, CAST(30000.00 AS Decimal(18, 2)), CAST(22500.00 AS Decimal(18, 2)), CAST(202500.00 AS Decimal(18, 2)), N'1')
INSERT [dbo].[Comprador] ([idcomprador], [legajo_comprador], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble], [importe], [comision], [impuesto], [total_propiedad], [Activo]) VALUES (N'a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', 5, N'Laura iris', N'Felix Galio', 27800250, CAST(N'1984-02-14' AS Date), N'1145006611', N'75f89b21-5116-4dbb-9818-ccf86c4d4d27', 308000, CAST(61600.00 AS Decimal(18, 2)), CAST(46200.00 AS Decimal(18, 2)), CAST(415800.00 AS Decimal(18, 2)), N'0')
INSERT [dbo].[Comprador] ([idcomprador], [legajo_comprador], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble], [importe], [comision], [impuesto], [total_propiedad], [Activo]) VALUES (N'f9a7f91a-9fd6-4ebf-919c-6eac8c6ce06e', 3, N'CVBCVB', N'FGFGSL', 55555, CAST(N'2024-02-29' AS Date), N'2222', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', 150000, CAST(30000.00 AS Decimal(18, 2)), CAST(22500.00 AS Decimal(18, 2)), CAST(202500.00 AS Decimal(18, 2)), N'1')
INSERT [dbo].[Comprador] ([idcomprador], [legajo_comprador], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble], [importe], [comision], [impuesto], [total_propiedad], [Activo]) VALUES (N'8ffb734a-304d-45da-af54-8b471e60a0a4', 1, N'Ariel', N'Garcia', 20345789, CAST(N'2000-02-08' AS Date), N'1180009500', N'3ced02bb-6349-4329-aad2-11cfa292ae3e', 195000, CAST(39000.00 AS Decimal(18, 2)), CAST(29250.00 AS Decimal(18, 2)), CAST(263250.00 AS Decimal(18, 2)), N'1')
INSERT [dbo].[Comprador] ([idcomprador], [legajo_comprador], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble], [importe], [comision], [impuesto], [total_propiedad], [Activo]) VALUES (N'17ebce94-5f74-452d-8da5-eb553efdb97e', 3, N'Domingo', N'Falcon', 19250456, CAST(N'1939-07-12' AS Date), N'1122550023', N'70a7ecaa-62f2-489f-b37b-44a3f378e2f1', 120000, CAST(24000.00 AS Decimal(18, 2)), CAST(18000.00 AS Decimal(18, 2)), CAST(162000.00 AS Decimal(18, 2)), N'1')
GO
INSERT [dbo].[Contrato] ([idcontrato], [fecha_inicio], [fecha_fin], [idescribania], [idtipo_inmueble], [idalquiler], [idcliente]) VALUES (N'966a62bd-b982-48a7-bd58-119fe6b6816d', CAST(N'2023-12-04' AS Date), CAST(N'2024-01-07' AS Date), N'b365b1fb-3e00-490a-be09-fefc0d011b47', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'1ec2f45f-cce4-4013-9cc0-5b1172346ad2', N'efc700ee-515b-4606-b6a6-1a5a7a0a4849')
INSERT [dbo].[Contrato] ([idcontrato], [fecha_inicio], [fecha_fin], [idescribania], [idtipo_inmueble], [idalquiler], [idcliente]) VALUES (N'12d1a0e0-b4d7-4b6b-bb07-1a5b913a1a00', CAST(N'2023-12-10' AS Date), CAST(N'2024-01-10' AS Date), N'6dae1460-73c4-49ef-a90f-f2ba7ca313f6', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'1ec2f45f-cce4-4013-9cc0-5b1172346ad2', N'efc700ee-515b-4606-b6a6-1a5a7a0a4849')
INSERT [dbo].[Contrato] ([idcontrato], [fecha_inicio], [fecha_fin], [idescribania], [idtipo_inmueble], [idalquiler], [idcliente]) VALUES (N'497b37ad-e17c-4e39-8932-86b838dac734', CAST(N'2024-02-02' AS Date), CAST(N'2024-02-04' AS Date), N'6dae1460-73c4-49ef-a90f-f2ba7ca313f6', N'3ced02bb-6349-4329-aad2-11cfa292ae3e', N'7c6ac602-f649-42ba-9c72-f65de4c867cb', N'11401ba4-d527-4f3e-9625-1c06af1f34dd')
INSERT [dbo].[Contrato] ([idcontrato], [fecha_inicio], [fecha_fin], [idescribania], [idtipo_inmueble], [idalquiler], [idcliente]) VALUES (N'9855149a-73c3-429e-b248-d173440b6292', CAST(N'2023-12-08' AS Date), CAST(N'2024-01-19' AS Date), N'c7de5b0b-a7ef-4ac2-aa73-d95c3dc8736c', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'b54b0241-e152-4ff0-8da5-0b7546a9c820', N'efc700ee-515b-4606-b6a6-1a5a7a0a4849')
INSERT [dbo].[Contrato] ([idcontrato], [fecha_inicio], [fecha_fin], [idescribania], [idtipo_inmueble], [idalquiler], [idcliente]) VALUES (N'48da3624-29c7-4963-a469-e59ba4836287', CAST(N'2024-02-02' AS Date), CAST(N'2024-02-04' AS Date), N'c7de5b0b-a7ef-4ac2-aa73-d95c3dc8736c', N'3ced02bb-6349-4329-aad2-11cfa292ae3e', N'7c6ac602-f649-42ba-9c72-f65de4c867cb', N'fa16033c-f0cb-4458-a013-1ee46266e85c')
INSERT [dbo].[Contrato] ([idcontrato], [fecha_inicio], [fecha_fin], [idescribania], [idtipo_inmueble], [idalquiler], [idcliente]) VALUES (N'5229d257-f121-46bb-9b31-f6ff1dc03e01', CAST(N'2024-02-04' AS Date), CAST(N'2024-03-08' AS Date), N'c7de5b0b-a7ef-4ac2-aa73-d95c3dc8736c', N'70a7ecaa-62f2-489f-b37b-44a3f378e2f1', N'0a69fde0-d1dd-4ce2-9c61-e28e170f2bfd', N'bebff004-45ed-4855-918a-dabd591fceb0')
GO
INSERT [dbo].[Escribania] ([idescribania], [razon_social], [direccion], [telefono]) VALUES (N'c7de5b0b-a7ef-4ac2-aa73-d95c3dc8736c', N'Urban', N'Faso 7800', N'5464')
INSERT [dbo].[Escribania] ([idescribania], [razon_social], [direccion], [telefono]) VALUES (N'6dae1460-73c4-49ef-a90f-f2ba7ca313f6', N'Frulax', N'Alisina 2500', N'48009100')
INSERT [dbo].[Escribania] ([idescribania], [razon_social], [direccion], [telefono]) VALUES (N'b365b1fb-3e00-490a-be09-fefc0d011b47', N'Tirex', N'Hamburgo 321', N'45889500')
INSERT [dbo].[Escribania] ([idescribania], [razon_social], [direccion], [telefono]) VALUES (N'785fb69b-e130-4b09-ae96-ffe8629b8344', N'GATS', N'Calle falsa 1234', N'45009877')
GO
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'8e15fb56-6ad3-49b0-9da2-161ef338353a', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', NULL, N'8663aeeb-f306-471e-8161-01e2169e1b10', NULL, NULL, NULL, N'Compra registrada', CAST(N'2024-03-03T15:31:05.337' AS DateTime), N'1')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'54bde11b-3b84-4bfb-a746-194bc6ea1513', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'd6cb00be-d2d8-4b85-a2ab-78f9d930df31', NULL, N'1ec2f45f-cce4-4013-9cc0-5b1172346ad2', NULL, NULL, N'Contrato de alquiler registrado', CAST(N'2024-03-01T23:48:10.277' AS DateTime), N'1')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'f42746a7-9d1a-4480-8500-1c58dbff7fd2', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', NULL, NULL, N'1ec2f45f-cce4-4013-9cc0-5b1172346ad2', N'5ed8e77a-9814-4970-a4db-b4e63b18c95c', NULL, N'Venta registrada', CAST(N'2024-03-03T11:19:31.160' AS DateTime), N'1')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'd6b26ad2-3e57-4804-bb87-544b04749696', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', NULL, N'8663aeeb-f306-471e-8161-01e2169e1b10', NULL, NULL, NULL, N'Registro de Compra borrado', CAST(N'2024-03-03T15:36:31.597' AS DateTime), N'0')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'b85a34a3-6cfd-4988-87c5-55b8b6aa309f', N'1c5ec8d1-26bc-4b10-96df-68e512671f72', NULL, N'24cca429-c96d-4d07-9f44-2cf4281d8d74', NULL, NULL, NULL, N'Compra registrada', CAST(N'2024-02-22T19:31:38.170' AS DateTime), N'1')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'50fa1767-c3af-466c-9f9e-7a1abede9681', N'75f89b21-5116-4dbb-9818-ccf86c4d4d27', NULL, N'a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', NULL, NULL, NULL, N'Registro de Compra borrado', CAST(N'2024-02-27T20:51:35.357' AS DateTime), N'0')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'07883df7-dd13-4a64-aded-7e3a01e359a7', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'd6cb00be-d2d8-4b85-a2ab-78f9d930df31', N'8663aeeb-f306-471e-8161-01e2169e1b10', NULL, NULL, NULL, N'Compra registrada', CAST(N'2024-02-29T16:14:27.310' AS DateTime), N'1')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'c9e34c6f-507e-4b65-868e-7f0d83bf44d9', N'3ced02bb-6349-4329-aad2-11cfa292ae3e', N'602c9485-effb-402f-9be6-1a4661afa314', NULL, NULL, N'2429c5fc-579b-4873-88e4-87834c727fa5', NULL, N'Registro de Compra borrado', CAST(N'2024-03-02T23:21:41.023' AS DateTime), N'0')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'b3879c5f-cc2e-44a8-aa76-856d86cdfb97', N'70a7ecaa-62f2-489f-b37b-44a3f378e2f1', NULL, N'17ebce94-5f74-452d-8da5-eb553efdb97e', NULL, NULL, NULL, N'Compra registrada', CAST(N'2024-02-22T10:27:19.607' AS DateTime), N'1')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'bfcbde5f-d732-4361-ba8a-97ce5fda0f83', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', NULL, N'd5203bf8-d318-412a-ba6a-29d549c4c0b7', NULL, NULL, NULL, N'Compra registrada', CAST(N'2024-02-22T10:16:17.240' AS DateTime), N'1')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'2b28bc9c-c0d7-4ea4-8bd3-a2f7575d3185', N'75f89b21-5116-4dbb-9818-ccf86c4d4d27', NULL, N'a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', NULL, NULL, NULL, N'Compra registrada', CAST(N'2024-02-22T20:32:13.900' AS DateTime), N'1')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'032393be-0143-449a-9994-a574e62e988d', N'75f89b21-5116-4dbb-9818-ccf86c4d4d27', NULL, N'a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', NULL, NULL, NULL, N'Compra eliminada', CAST(N'2024-02-27T18:28:55.897' AS DateTime), N'0')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'19aeb233-ee11-4ada-b4d7-a89bf174c12c', N'3ced02bb-6349-4329-aad2-11cfa292ae3e', NULL, N'8ffb734a-304d-45da-af54-8b471e60a0a4', NULL, NULL, NULL, N'Compra registrada', CAST(N'2024-02-22T09:54:53.363' AS DateTime), N'1')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'75091a19-b031-479b-9053-ac3f433458d7', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'd6cb00be-d2d8-4b85-a2ab-78f9d930df31', NULL, N'1ec2f45f-cce4-4013-9cc0-5b1172346ad2', NULL, NULL, N'Contrato de alquiler registrado', CAST(N'2024-03-03T16:39:50.177' AS DateTime), N'1')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'eb0ac48a-c2b7-47e7-9524-c394f240a720', N'3ced02bb-6349-4329-aad2-11cfa292ae3e', N'602c9485-effb-402f-9be6-1a4661afa314', NULL, N'7c6ac602-f649-42ba-9c72-f65de4c867cb', NULL, NULL, N'Contrato de alquiler registrado', CAST(N'2024-03-01T22:50:53.807' AS DateTime), N'1')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'17e5f578-03a4-4c7d-87dc-cd9b01c85b64', N'1c5ec8d1-26bc-4b10-96df-68e512671f72', NULL, N'24cca429-c96d-4d07-9f44-2cf4281d8d74', NULL, NULL, NULL, N'Compra registrada', CAST(N'2024-02-26T21:56:09.960' AS DateTime), N'1')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'9cb97069-024d-4607-8619-d68d1f16db01', N'3ced02bb-6349-4329-aad2-11cfa292ae3e', NULL, NULL, N'7c6ac602-f649-42ba-9c72-f65de4c867cb', N'2429c5fc-579b-4873-88e4-87834c727fa5', NULL, N'Venta registrada', CAST(N'2024-03-02T21:31:22.167' AS DateTime), N'1')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'33a9902a-06c8-4bb2-b732-e34d03fede49', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', NULL, N'be6b0696-7d6e-4b15-b5b1-1632a73c7a91', NULL, NULL, NULL, N'Registro de Compra borrado', CAST(N'2024-03-03T15:36:14.293' AS DateTime), N'0')
INSERT [dbo].[Inmobiliaria] ([idinmueble], [idtipo_inmueble], [idpropietario], [idcomprador], [idalquiler], [idventa], [idcontrato], [detalle], [fecha_operacion], [Activo]) VALUES (N'ccb88ce2-92c3-4c8f-be0f-fccc527874f2', N'75f89b21-5116-4dbb-9818-ccf86c4d4d27', NULL, N'a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', NULL, NULL, NULL, N'Registro de Compra borrado', CAST(N'2024-02-27T21:03:56.903' AS DateTime), N'0')
GO
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'6acc68e2-3ef8-4779-8dc4-008cae9b5c90', N'Almagro', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'b6454b36-3577-4715-a1f6-02c16cdb9b37', N'Mataderos', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'b20d3dc1-5e07-4174-9cf6-03d6a742decf', N'Villa Lugano', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'2ed0f839-5b16-47b4-b8b5-06a8e31fd8cc', N'Acassuso', 1641, N'd829159c-42ac-4454-b770-e099bde2b02e')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'09ec88b6-180b-44ba-a5d1-07ccbe8ea377', N'Martínez', 1640, N'd829159c-42ac-4454-b770-e099bde2b02e')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'7b9df8f6-694c-4564-8116-0ac18ce5823c', N'Coghlan', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'4217f42c-10bf-4370-a72e-0ad9b3e2d98e', N'San Telmo', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'f497fbfb-6e3a-4ab8-8524-1205fd75fe54', N'Monserrat', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'6da5f5ae-b21b-483d-ac27-15c1b534e208', N'Villa Santa Rita', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'd0a3a560-ed62-4ccd-a503-1af3e69e1647', N'Liniers', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'3d43cda0-74e8-4858-bedc-1b1e1d0a486a', N'Chacarita', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'98170300-a66e-4378-9201-1d6da63a8300', N'José León Suárez', 0, N'c29db178-fb44-4e0a-b625-8fbf0c9591c1')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'3a5feeae-d88f-4705-972e-22bb2f903ce5', N'Agronomía', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'4b968e41-eeae-4dee-9a66-24b1f10d2430', N'Munro', 0, N'c33c515e-61c6-4b77-afc9-384c304b2e8c')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'1e1efd0b-c1c0-4769-9dcd-25d38f94a940', N'Saavedra', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'7972911d-70c5-4556-9f45-26241cea8907', N'Billinghurst', 0, N'c29db178-fb44-4e0a-b625-8fbf0c9591c1')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'10e301c0-2237-4394-b626-2635fbe804de', N'Olivos', 0, N'c33c515e-61c6-4b77-afc9-384c304b2e8c')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'365f9f4d-d9ee-42dd-85a8-2a5cb21eb20a', N'Villa Ayacucho', 0, N'c29db178-fb44-4e0a-b625-8fbf0c9591c1')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'dacecfec-228e-4bf4-ba45-310e0117d26d', N'Vicente López', 0, N'c33c515e-61c6-4b77-afc9-384c304b2e8c')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'0556d057-65a4-4a20-9dec-388ad2e73925', N'La Paternal', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'1a7a944e-6670-40df-9911-409014567eb8', N'Villa Martelli', 0, N'c33c515e-61c6-4b77-afc9-384c304b2e8c')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'679ca9d2-ff00-4490-b33d-4112658d0a59', N'Villa Lynch', 0, N'c29db178-fb44-4e0a-b625-8fbf0c9591c1')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'939f9a00-a6fe-4110-ba31-459e4897ae30', N'Colegiales', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'9b3540dd-2fbf-4c7c-b113-462d2634a5b3', N'Flores', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'fb42f0ff-5e82-4930-833d-476503dc2542', N'Villa Luro', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'4dab7da0-8f47-4cb0-a1da-50199391c110', N'Villa Pueyrredón', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'06f793e7-ed96-4dde-a2d7-53ad337e3dae', N'Florida Oeste', 0, N'c33c515e-61c6-4b77-afc9-384c304b2e8c')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'eef568ba-5dd9-4c32-a7e9-58973a3f3fc5', N'Villa Devoto', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'12c531e4-ee36-40a9-8691-58e51a931db9', N'San Cristóbal', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'9cdec159-553f-43fa-86aa-59af5c91d805', N'Villa Adelina', 0, N'c33c515e-61c6-4b77-afc9-384c304b2e8c')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'e71789bc-c706-403c-9cde-5ab196d0bee5', N'Florida', 0, N'c33c515e-61c6-4b77-afc9-384c304b2e8c')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'9bf462ac-61a7-470b-838b-622f46dd6484', N'Vélez Sársfield', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'5a6ff4ae-d50c-4551-a496-62f6e29c9692', N'Caballito', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'800db65b-c49e-4442-ae44-66902ce6876e', N'San Martín', 1650, N'c29db178-fb44-4e0a-b625-8fbf0c9591c1')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'68ef1a9e-b788-41dd-90ed-66eb85e563df', N'Parque Chacabuco', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'911b27f3-0a2d-4097-abd1-72175a92b3d9', N'San Nicolás', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'b1914987-753f-4e23-9c8c-746c68de9816', N'Villa Ballester', 0, N'c29db178-fb44-4e0a-b625-8fbf0c9591c1')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'2ebdf3b6-15bd-434a-bddc-7683df3586c6', N'Villa Soldati', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'a2f09fa2-0644-4e95-8fb1-76df9a4df2b3', N'Parque Avellaneda', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'22968ae6-65da-4ea7-8dfd-786acbd5b33f', N'Belgrano', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'f4deca82-4517-45b9-90e2-786aed95ca5f', N'Boedo', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'2e129dd6-dc3f-4ad0-bc4b-7976330325a3', N'Barracas', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'a2f2579e-6552-4a8a-a0a7-79c97329cfff', N'Villa Adelina', 1607, N'd829159c-42ac-4454-b770-e099bde2b02e')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'4683520a-f3d3-4ecb-9439-8004df2072df', N'Nueva Pompeya', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'5f787302-9df7-441f-8ff4-822d8306ab80', N'Balvanera', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'57211abf-32b6-4f67-8da8-8d01834a6355', N'Villa General Mitre', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'550b6955-118d-478d-8670-8f8e32dadaee', N'La Lucila', 0, N'c33c515e-61c6-4b77-afc9-384c304b2e8c')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'80bdf9e3-72fd-4b9f-85ad-8ff7e3331a03', N'Villa Riachuelo', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'e03f9a7b-017e-4e0d-b5bd-904dcd704c46', N'Loma Hermosa', 0, N'c29db178-fb44-4e0a-b625-8fbf0c9591c1')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'40f96e54-9880-41c5-ba22-9394a24591e1', N'Retiro', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'5402bc68-089f-41e9-b612-9a9f076526aa', N'Floresta', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'ec80b8b7-0e6d-4a83-a1df-9db094d21ab3', N'Recoleta', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'06372bc4-b94b-4bc1-9c63-aa0824b08a2e', N'Constitución', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'39443019-acaa-4b4e-ba96-b30ad92d5600', N'Villa Chacabuco', 0, N'c29db178-fb44-4e0a-b625-8fbf0c9591c1')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'15664945-e2fe-497a-af6e-b4b7a9d29ad4', N'Villa Ortúzar', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'1fb12bc6-2c22-4633-b8fa-bb03d40dca1b', N'Carapachay', 0, N'c33c515e-61c6-4b77-afc9-384c304b2e8c')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'e436cfa2-0743-4876-a934-bc7f018cc575', N'Puerto Madero', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'a30153dc-5593-4679-9ee1-bcabf4c1524d', N'Villa Crespo', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'f5843853-d2e4-4664-9f21-cab722eaf8c6', N'San Andrés', 0, N'c29db178-fb44-4e0a-b625-8fbf0c9591c1')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'cd3582b0-9ecb-42a8-9af0-cc3bff5c446b', N'Villa del Parque', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'629b5651-efbd-4c44-8b35-cd3514bf073e', N'Villa Real', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'3ad26667-e5d4-4197-beba-cd468b467345', N'Parque Patricios', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'6c3a577e-77ca-4ffc-8577-d013dc9534b3', N'Boulogne Sur Mer', 1609, N'd829159c-42ac-4454-b770-e099bde2b02e')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'bda89e86-c883-4439-b971-d1cf82cb3f91', N'Versalles', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'1dbcb1db-0adc-43d3-84d7-d25b4714c878', N'Parque Chas', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'9523b058-8cda-465d-9963-d955c9e3394a', N'Palermo', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'8ca08727-61f2-4f0b-86ad-d9ee8238180e', N'Núñez', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'6f948aea-7841-49e6-81e5-e095da4a7f02', N'La Boca', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'c7d3510c-8a98-490a-934f-e5d085c16b10', N'San Isidro', 1642, N'd829159c-42ac-4454-b770-e099bde2b02e')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'085e9c51-495d-4cb2-9c8d-e786eebe3023', N'Monte Castro', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'3a1fffd7-cd93-4faf-85bf-ec4807bba6ca', N'Villa Urquiza', 0, N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'7eea1afd-315c-49de-97dc-f822de2c7382', N'Beccar', 1643, N'd829159c-42ac-4454-b770-e099bde2b02e')
INSERT [dbo].[Localidad] ([idlocalidad], [nom_localidad], [codigo_postal], [idpartido]) VALUES (N'68af5b91-3408-4519-94c1-f8455f111c50', N'Villa Maipú', 0, N'c29db178-fb44-4e0a-b625-8fbf0c9591c1')
GO
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'099b4b2e-4460-4ff2-aaec-0852152c8d91', N'Se agregó correctamente la compra con id: 00000000-0000-0000-0000-000000000000', N'Info', CAST(N'2024-02-22T10:13:57.050' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'bdbb44be-53eb-415b-8b43-092f4e127445', N'Se agregó correctamente la compra con id Inmueble: 1c5ec8d1-26bc-4b10-96df-68e512671f72', N'Info', CAST(N'2024-02-22T19:31:26.990' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'813250cb-1622-4ef9-931f-0cab63cbb1c9', N'Se actualizó correctamente el propietario: Mariana', N'Info', CAST(N'2023-12-01T12:06:11.893' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'959938e5-5320-480e-8d30-12253789fc14', N'Error al intentar borrar el propietario.', N'Error', CAST(N'2023-12-01T11:26:42.183' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'f91a304e-2c35-4b74-a3c0-1f66e103901f', N'No se encontró el propietario con ID: 96a79684-c146-4d83-aa37-36e4b4cf52fb. No se realizó la operaci', N'Warning', CAST(N'2024-03-03T09:12:50.720' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'f48c5e3b-0004-4626-95b8-24c8e8b99e83', N'Se agregó correctamente la compra con id Inmueble: cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'Info', CAST(N'2024-03-03T15:31:05.337' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'66b63fed-6d5a-4ada-a044-261e9dc7f993', N'Se modificó correctamente la compra con id: 8663aeeb-f306-471e-8161-01e2169e1b10', N'Info', CAST(N'2024-03-03T15:36:29.923' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'a7554872-eda1-4b71-9544-2724c9c9626e', N'Se agregó correctamente la compra con id Inmueble: 75f89b21-5116-4dbb-9818-ccf86c4d4d27', N'Info', CAST(N'2024-02-26T20:32:32.317' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'ec7181f5-27d9-486b-93a5-2b69d38ea211', N'Se agregó correctamente la compra con id: 3ced02bb-6349-4329-aad2-11cfa292ae3e', N'Info', CAST(N'2024-02-21T22:51:40.640' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'810f0662-2996-47f0-84c4-314dc9bbae47', N'Se agregó correctamente la compra con id Inmueble: cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'Info', CAST(N'2024-02-29T16:03:54.580' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'59d1c643-e197-47a1-a750-32bb7f9c5e73', N'Se modificó correctamente la compra con id: a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', N'Info', CAST(N'2024-02-27T20:59:26.133' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'e2ccd55c-a181-46d5-bdb4-345d89b41e16', N'Se modificó correctamente la compra con id: a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', N'Info', CAST(N'2024-02-27T08:16:22.623' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'31197f75-a0de-4734-82a7-36afd9950a57', N'Se agregó correctamente el propietario: Marisel', N'Info', CAST(N'2023-12-01T12:22:28.830' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'11ea4463-b7b0-4da5-8c16-39c76420800e', N'Se agregó correctamente el propietario: Franco', N'Info', CAST(N'2024-03-03T09:12:06.803' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'871028d1-d15e-47f5-b1f4-3fee5ce2e860', N'Se agregó correctamente el propietario: Mariana', N'Info', CAST(N'2023-12-01T12:05:29.190' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'21143458-ac5e-4b9c-b42d-4b94e7b97a27', N'Se modificó correctamente la compra con id: a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', N'Info', CAST(N'2024-02-27T10:15:56.713' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'41e8af19-a33b-4e25-adb3-50dfde107413', N'Se agregó correctamente la compra con id Inmueble: 75f89b21-5116-4dbb-9818-ccf86c4d4d27', N'Info', CAST(N'2024-02-26T20:24:33.070' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'c2d943e3-50c0-44f1-bf8a-514100b7ee5d', N'Se agregó correctamente la compra con id Inmueble: 75f89b21-5116-4dbb-9818-ccf86c4d4d27', N'Info', CAST(N'2024-02-22T20:32:02.187' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'd9d2e44b-9d5e-441c-a962-534215fcd351', N'Error al intentar borrar el propietario.', N'Error', CAST(N'2023-12-01T12:27:09.913' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'55887071-adc7-418a-bf6c-5c51435524e7', N'Se agregó correctamente la compra con id Inmueble: cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'Info', CAST(N'2024-02-29T15:51:36.803' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'a354732b-ad62-4b2d-b44c-5f95e1faf442', N'Se modificó correctamente la compra con id: a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', N'Info', CAST(N'2024-02-27T10:22:49.603' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'8a92c499-455c-4c3c-a59e-5f960060a29b', N'Se modificó correctamente la compra con id: a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', N'Info', CAST(N'2024-02-27T21:03:53.863' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'9c1befba-e538-4827-8af2-60f0e7672eff', N'Error al intentar borrar el propietario.', N'Error', CAST(N'2023-12-01T12:20:15.180' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'4e1f45c1-6c35-4a17-beb3-6ab625ae99ab', N'Se agregó correctamente la compra con id Inmueble: cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'Info', CAST(N'2024-02-29T16:04:54.237' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'0195aa0f-fea8-4cb6-8a1a-6b1119d6016f', N'Se modificó correctamente la compra con id: a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', N'Info', CAST(N'2024-02-27T09:27:21.597' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'fe8a022f-91ed-4177-91aa-70162387dda5', N'Se agregó correctamente la compra con id Inmueble: 75f89b21-5116-4dbb-9818-ccf86c4d4d27', N'Info', CAST(N'2024-02-26T20:41:40.877' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'e9600333-6acd-45ac-8ddd-707fb7caab23', N'Se modificó correctamente la compra con id: a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', N'Info', CAST(N'2024-02-27T20:51:10.000' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'bf805595-f328-47cc-9b3e-7adc0d5835d7', N'Se agregó correctamente la compra con id Inmueble: 75f89b21-5116-4dbb-9818-ccf86c4d4d27', N'Info', CAST(N'2024-02-26T20:44:25.700' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'b40b5e21-54ce-4e0f-b3e2-7c0957594903', N'No se encontró el propietario con ID: 96a79684-c146-4d83-aa37-36e4b4cf52fb. No se realizó la operaci', N'Warning', CAST(N'2024-03-03T09:25:04.907' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'fd5128a1-5832-4c86-a59f-831b982019c3', N'Se agregó correctamente la compra con id Inmueble: 70a7ecaa-62f2-489f-b37b-44a3f378e2f1', N'Info', CAST(N'2024-02-26T20:06:01.330' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'0b013dc4-bc5a-4760-8f4b-8379784081d8', N'Error al intentar borrar el propietario.', N'Error', CAST(N'2023-12-01T11:18:40.600' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'b52eab5e-d3ba-491f-87a4-87e76938c4ef', N'Se modificó correctamente la compra con id: be6b0696-7d6e-4b15-b5b1-1632a73c7a91', N'Info', CAST(N'2024-03-03T15:36:12.907' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'4ff1e6f4-cffd-4f1f-927c-8ffa71c70755', N'Se borró correctamente la compra con id: a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', N'Info', CAST(N'2024-02-27T18:28:27.363' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'60ee45da-ab6e-4e21-bdb3-9520e5e5f73c', N'Se agregó correctamente la compra con id Inmueble: 75f89b21-5116-4dbb-9818-ccf86c4d4d27', N'Info', CAST(N'2024-02-26T21:46:11.787' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'de05cdd2-c79b-4c42-8771-97085ca82ff3', N'Se borró correctamente el propietario con ID: 9d19002b-a951-4725-9678-4c1ef65db741', N'Info', CAST(N'2023-12-01T13:40:45.527' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'b5d7348b-9b7f-45f6-9afb-a44f84ba2770', N'Se modificó correctamente la compra con id: a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', N'Info', CAST(N'2024-02-27T09:21:42.880' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'4016776d-5a30-44c6-ba88-aa5d39d60422', N'Se agregó correctamente la compra con id Inmueble: 75f89b21-5116-4dbb-9818-ccf86c4d4d27', N'Info', CAST(N'2024-02-26T20:58:36.520' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'57720e48-5180-4912-90ea-b39efe3093eb', N'Se agregó correctamente la compra con id Inmueble: 1c5ec8d1-26bc-4b10-96df-68e512671f72', N'Info', CAST(N'2024-02-26T21:55:33.357' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'a69714d7-f742-48ab-9580-b3a7e11313b7', N'Se agregó correctamente la compra con id: 41f20028-917c-4457-ab75-6a15983e6a4c', N'Info', CAST(N'2024-02-21T23:30:34.263' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'45ab100f-f55f-4413-91e5-ba9a0f10419c', N'Se agregó correctamente la compra con id Inmueble: cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'Info', CAST(N'2024-02-29T16:14:27.303' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'70a91b50-2595-4bd8-99fe-bd2bdaa2d120', N'Se actualizó correctamente el propietario: Ulises', N'Info', CAST(N'2023-12-01T11:07:58.610' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'b95d1c2c-be25-41c2-b89c-bd900d195756', N'Se modificó correctamente la compra con id: a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', N'Info', CAST(N'2024-02-27T07:41:14.510' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'83172a03-6d63-4b12-8a60-becae4501652', N'Se agregó correctamente la compra con id Inmueble: cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'Info', CAST(N'2024-02-29T15:32:30.447' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'728eb243-972e-4aa8-84d8-c3438db273ff', N'Se agregó correctamente la compra con id Inmueble: 1c5ec8d1-26bc-4b10-96df-68e512671f72', N'Info', CAST(N'2024-02-26T19:55:38.253' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'8dd22812-9807-44d2-a9aa-c61ea9e71464', N'Se agregó correctamente la compra con id: 00000000-0000-0000-0000-000000000000', N'Info', CAST(N'2024-02-22T09:54:08.377' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'c5a8a6f9-9c9d-44e5-bdf2-d0d7c68ad03b', N'Se agregó correctamente la compra con id Inmueble: 75f89b21-5116-4dbb-9818-ccf86c4d4d27', N'Info', CAST(N'2024-02-26T20:37:34.957' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'b7c354aa-6998-44c6-bb39-d6e739c3e7e2', N'Se agregó correctamente la compra con id: 00000000-0000-0000-0000-000000000000', N'Info', CAST(N'2024-02-22T10:27:14.553' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'e91afd65-2105-4b3e-aa99-d722e731c612', N'Se agregó correctamente la compra con id: 3a11311d-5d6f-480e-9fb9-0c2a7ea061b3', N'Info', CAST(N'2024-02-21T23:36:03.410' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'8e4da2d9-8225-43c5-83fd-d7fc23c3a0df', N'Se agregó correctamente la compra con id Inmueble: cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'Info', CAST(N'2024-02-29T15:55:03.503' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'4346193b-6898-4a7a-a416-da23a0c52018', N'Se actualizó correctamente el propietario: Marisel', N'Info', CAST(N'2023-12-01T12:22:51.927' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'22d9ae48-52af-4abc-b50b-dcbd527bbcf2', N'Se agregó correctamente el propietario: Anibal', N'Info', CAST(N'2024-03-03T15:23:51.710' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'f5eddc31-e4ed-447c-b310-df4fbd29ef07', N'No se encontró el propietario con ID: 96a79684-c146-4d83-aa37-36e4b4cf52fb. No se realizó la operaci', N'Warning', CAST(N'2024-03-03T09:20:05.867' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'4d053c3b-12b1-4517-b66f-e30ca1f3accc', N'Se borró correctamente el propietario con ID: 96a79684-c146-4d83-aa37-36e4b4cf52fb', N'Info', CAST(N'2024-03-03T09:30:31.817' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'f6741207-927b-4e6d-97e7-f41bb4075c08', N'Se agregó correctamente la compra con id Inmueble: 1c5ec8d1-26bc-4b10-96df-68e512671f72', N'Info', CAST(N'2024-02-26T21:27:45.637' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'2448ca14-d04a-47a7-a3dd-f553c14f84e2', N'Se agregó correctamente el propietario: Fabiana', N'Info', CAST(N'2023-12-01T13:40:03.840' AS DateTime))
INSERT [dbo].[Log] ([idlog], [message], [severity], [fecha_txr]) VALUES (N'b09aaf09-46eb-41e8-be8f-f8e8d9b5b627', N'Se modificó correctamente la compra con id: a5500d9c-c778-4b1a-9cf5-3e1f946f98c5', N'Info', CAST(N'2024-02-27T08:24:41.307' AS DateTime))
GO
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'ef7d7fde-ac1a-4c04-ab6b-0515c81d3479', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Tigre')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'40b4fc9c-9e9d-4993-bf53-29d4c074d378', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Malvinas Argentinas')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'c33c515e-61c6-4b77-afc9-384c304b2e8c', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Vicente López')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'5a8ee281-9c76-4d8d-a3ce-41b765143c58', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Esteban Echeverría')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'48c0e9fb-a9e0-47ec-88fa-4f744fe9e112', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Lomas de Zamora')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'5db0d7c7-e45f-4796-b017-7729cdc8ab7f', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'José C. Paz')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'3b753d81-1843-4b4c-8057-8772106011bb', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Quilmes')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'c29db178-fb44-4e0a-b625-8fbf0c9591c1', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'General San Martín')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'c0a0c059-daa2-49b2-8f16-93bcdfdd86c6', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'San Fernando')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'0dc2b798-f681-42e0-99b7-b6d890af4b69', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Morón')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'494781cd-f21f-43fe-8bd1-ba6ca456a1a3', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Lanús')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'08c2500b-bcb8-4413-b669-c4251e2a89df', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Tres de Febrero')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'CABA')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'59da2153-4488-4b90-9a72-c5c02f2b02b0', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'La Matanza')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'97bda36b-a6a2-4337-bbff-da21d4cecd6c', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Almirante Brown')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'7eeebf9b-8ad0-4a04-b212-de89788e7a42', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Moreno')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'd829159c-42ac-4454-b770-e099bde2b02e', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'San Isidro')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'2cc5ee10-3320-4c68-a4dc-f1393c139080', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Florencio Varela')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'935158e5-d47a-415e-8081-f64de52a81aa', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Merlo')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'5e5a3a3d-9a17-456b-8abe-f8c28aedd25d', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Avellaneda')
INSERT [dbo].[Partido] ([idpartido], [idprovincia], [nom_partido]) VALUES (N'2ff0b3c1-a23b-4448-bed2-fe40dba80832', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'San Miguel')
GO
INSERT [dbo].[Propietario] ([idpropietario], [legajo_propietario], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble]) VALUES (N'602c9485-effb-402f-9be6-1a4661afa314', 1, N'Javier Uriel', N'Boch', 28510987, CAST(N'1995-02-07' AS Date), N'45902277', N'3ced02bb-6349-4329-aad2-11cfa292ae3e')
INSERT [dbo].[Propietario] ([idpropietario], [legajo_propietario], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble]) VALUES (N'd6cb00be-d2d8-4b85-a2ab-78f9d930df31', 2, N'Ulises', N'Sach', 22450832, CAST(N'1982-07-22' AS Date), N'15943322', N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a')
INSERT [dbo].[Propietario] ([idpropietario], [legajo_propietario], [nombre], [apellido], [dni], [fecha_nac], [telefono], [idtipo_inmueble]) VALUES (N'e1596326-b3ef-402a-b8f7-e15b747b879d', 3, N'Anibal', N'Pelotazo', 4444, CAST(N'2024-03-03' AS Date), N'777', N'70a7ecaa-62f2-489f-b37b-44a3f378e2f1')
GO
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'017fc774-fd43-45eb-92bf-08b2568646e3', N'Santa Fe')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'd0720960-a458-47db-acc6-09e377433e52', N'Tierra del Fuego')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'823bae08-e7dd-4bf2-ace2-225a6fe04a1b', N'Chubut')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'83d22e1a-10c5-4683-a6b9-2917b6ea8c1e', N'Córdoba')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'f1b9c051-7587-464b-826a-313f88d5c084', N'Santiago del Estero')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'011b9318-c230-4f92-a2e3-320ae69da53b', N'Formosa')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'cfd79da2-9acd-4952-a0e1-49cb3afe9ffc', N'Salta')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Buenos Aires-GBA')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'9389fe3b-0473-46b0-86a8-58219795e408', N'Jujuy')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'cf9dc145-e09c-4803-b141-5d2618944712', N'Santa Cruz')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'242beb0d-9a2b-4d93-a74a-639a05e9d27d', N'Río Negro')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'95cd1001-5669-476c-b5d8-67763fada88e', N'San Juan')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'e0c73708-779c-48d7-8a5b-6ea21672d42c', N'Corrientes')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'edc218c6-6061-4c70-af54-7c589872b215', N'San Luis')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'576b656b-ef9d-4614-a49f-82c9e91b3af9', N'Neuquén')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'31a5df3e-7bea-4a4f-8997-9ca72a3b6920', N'Misiones')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'19df8f08-24a2-4ad4-991c-b3d0676274ed', N'Chaco')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'68bfdbdb-aa4a-4cce-ae43-d6580e160315', N'La Rioja')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'6489265e-66c6-410f-a936-ddeb59122c19', N'Entre Ríos')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'd5d5489a-d728-4f3f-a693-e0fb4d6a58d9', N'Tucumán')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'48f70927-809d-4f6f-9ee4-e711f843d62a', N'Mendoza')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'ab44aa77-dd92-42ac-a611-f4bae5aacf0d', N'Buenos Aires')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'6dc3019b-1fc3-4c29-b0b4-f5af46471430', N'La Pampa')
INSERT [dbo].[Provincia] ([idprovincia], [nom_provincia]) VALUES (N'907f07c1-0009-4a80-b3cd-f5f163893612', N'Catamarca')
GO
INSERT [dbo].[Tasacion] ([idtasacion], [importe_venta], [fecha], [importe_alquiler], [idtipo_inmueble]) VALUES (N'c4b98ca4-580d-412f-8208-153fd9200f9e', 308000, CAST(N'2023-10-24T19:22:17.303' AS DateTime), 120000, N'75f89b21-5116-4dbb-9818-ccf86c4d4d27')
INSERT [dbo].[Tasacion] ([idtasacion], [importe_venta], [fecha], [importe_alquiler], [idtipo_inmueble]) VALUES (N'02ae539a-6bc8-4bb8-842d-32d021a37d48', 150000, CAST(N'2023-10-24T08:50:11.323' AS DateTime), 13500, N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a')
INSERT [dbo].[Tasacion] ([idtasacion], [importe_venta], [fecha], [importe_alquiler], [idtipo_inmueble]) VALUES (N'1e21cbe7-b5e6-4e5c-b45f-718a25ad97ea', 125000, CAST(N'2024-03-03T16:02:02.070' AS DateTime), 12500, N'859e9d27-308b-4c61-ad35-6e12214036ec')
INSERT [dbo].[Tasacion] ([idtasacion], [importe_venta], [fecha], [importe_alquiler], [idtipo_inmueble]) VALUES (N'075c9fd5-a4b9-4a2b-9f9f-b0f1a12ea7db', 120000, CAST(N'2023-10-24T09:17:07.430' AS DateTime), 11250, N'70a7ecaa-62f2-489f-b37b-44a3f378e2f1')
INSERT [dbo].[Tasacion] ([idtasacion], [importe_venta], [fecha], [importe_alquiler], [idtipo_inmueble]) VALUES (N'8a3e347c-693f-499f-b056-b739626de691', 195000, CAST(N'2023-11-28T11:05:10.873' AS DateTime), 17000, N'3ced02bb-6349-4329-aad2-11cfa292ae3e')
INSERT [dbo].[Tasacion] ([idtasacion], [importe_venta], [fecha], [importe_alquiler], [idtipo_inmueble]) VALUES (N'ae6562e8-e28a-48ee-94a7-ee7d4abf2f9a', 78000, CAST(N'2023-10-24T19:21:01.987' AS DateTime), 7800, N'1c5ec8d1-26bc-4b10-96df-68e512671f72')
GO
INSERT [dbo].[Tipo_Inmueble] ([idtipo_inmueble], [tipo_inmueble], [descripcion], [idlocalidad], [idpartido], [idprovincia], [direccion]) VALUES (N'3ced02bb-6349-4329-aad2-11cfa292ae3e', N'Departamento', N'2 ambientes', N'dacecfec-228e-4bf4-ba45-310e0117d26d', N'0dc2b798-f681-42e0-99b7-b6d890af4b69', N'017fc774-fd43-45eb-92bf-08b2568646e3', N'Husal 2370')
INSERT [dbo].[Tipo_Inmueble] ([idtipo_inmueble], [tipo_inmueble], [descripcion], [idlocalidad], [idpartido], [idprovincia], [direccion]) VALUES (N'70a7ecaa-62f2-489f-b37b-44a3f378e2f1', N'Terreno', N'5 hectareas', N'fb42f0ff-5e82-4930-833d-476503dc2542', N'd829159c-42ac-4454-b770-e099bde2b02e', N'011b9318-c230-4f92-a2e3-320ae69da53b', N'Humbold 7912')
INSERT [dbo].[Tipo_Inmueble] ([idtipo_inmueble], [tipo_inmueble], [descripcion], [idlocalidad], [idpartido], [idprovincia], [direccion]) VALUES (N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'Departamento', N'1 ambiente', N'6acc68e2-3ef8-4779-8dc4-008cae9b5c90', N'f228e2f4-cd93-4d8c-8924-c4df8a7f4aad', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Lima 420')
INSERT [dbo].[Tipo_Inmueble] ([idtipo_inmueble], [tipo_inmueble], [descripcion], [idlocalidad], [idpartido], [idprovincia], [direccion]) VALUES (N'1c5ec8d1-26bc-4b10-96df-68e512671f72', N'Local', N'Local de 10 x 40 metros', N'629b5651-efbd-4c44-8b35-cd3514bf073e', N'2cc5ee10-3320-4c68-a4dc-f1393c139080', N'ab44aa77-dd92-42ac-a611-f4bae5aacf0d', N'Alsina 1233')
INSERT [dbo].[Tipo_Inmueble] ([idtipo_inmueble], [tipo_inmueble], [descripcion], [idlocalidad], [idpartido], [idprovincia], [direccion]) VALUES (N'859e9d27-308b-4c61-ad35-6e12214036ec', N'Departamento', N'3 ambientes', N'4217f42c-10bf-4370-a72e-0ad9b3e2d98e', N'48c0e9fb-a9e0-47ec-88fa-4f744fe9e112', N'94013a0d-4d3f-4519-be92-531cb25abdb8', N'Facil 123')
INSERT [dbo].[Tipo_Inmueble] ([idtipo_inmueble], [tipo_inmueble], [descripcion], [idlocalidad], [idpartido], [idprovincia], [direccion]) VALUES (N'75f89b21-5116-4dbb-9818-ccf86c4d4d27', N'Casa', N'5 ambientes', N'b1914987-753f-4e23-9c8c-746c68de9816', N'c29db178-fb44-4e0a-b625-8fbf0c9591c1', N'ab44aa77-dd92-42ac-a611-f4bae5aacf0d', N'Pacifico 5230')
GO
INSERT [dbo].[Venta] ([idventa], [importe], [comision], [idtipo_inmueble], [Activo], [idpropietario], [tipo_inmueble], [descripcion], [direccion]) VALUES (N'2429c5fc-579b-4873-88e4-87834c727fa5', 195000, CAST(3900000.00 AS Decimal(18, 2)), N'3ced02bb-6349-4329-aad2-11cfa292ae3e', N'0', N'602c9485-effb-402f-9be6-1a4661afa314', N'Departamento', N'2 ambientes', N'Husal 2370')
INSERT [dbo].[Venta] ([idventa], [importe], [comision], [idtipo_inmueble], [Activo], [idpropietario], [tipo_inmueble], [descripcion], [direccion]) VALUES (N'5ed8e77a-9814-4970-a4db-b4e63b18c95c', 150000, CAST(3000000.00 AS Decimal(18, 2)), N'cc1f7513-8d2c-45db-9e74-44c5d26ea74a', N'1', N'd6cb00be-d2d8-4b85-a2ab-78f9d930df31', N'Departamento', N'1 ambiente', N'Lima 420')
INSERT [dbo].[Venta] ([idventa], [importe], [comision], [idtipo_inmueble], [Activo], [idpropietario], [tipo_inmueble], [descripcion], [direccion]) VALUES (N'23c7e8a4-68b3-4fde-8577-d2b48344e260', 120000, CAST(2400000.00 AS Decimal(18, 2)), N'70a7ecaa-62f2-489f-b37b-44a3f378e2f1', N'1', N'e1596326-b3ef-402a-b8f7-e15b747b879d', N'Terreno', N'5 hectareas', N'Humbold 7912')
GO
ALTER TABLE [dbo].[Contrato]  WITH CHECK ADD  CONSTRAINT [FK_contrato_escribania] FOREIGN KEY([idescribania])
REFERENCES [dbo].[Escribania] ([idescribania])
GO
ALTER TABLE [dbo].[Contrato] CHECK CONSTRAINT [FK_contrato_escribania]
GO
ALTER TABLE [dbo].[Inmobiliaria]  WITH CHECK ADD  CONSTRAINT [FK_inmueble_alquiler] FOREIGN KEY([idalquiler])
REFERENCES [dbo].[Alquiler] ([idalquiler])
GO
ALTER TABLE [dbo].[Inmobiliaria] CHECK CONSTRAINT [FK_inmueble_alquiler]
GO
ALTER TABLE [dbo].[Inmobiliaria]  WITH CHECK ADD  CONSTRAINT [FK_inmueble_comprador] FOREIGN KEY([idcomprador])
REFERENCES [dbo].[Comprador] ([idcomprador])
GO
ALTER TABLE [dbo].[Inmobiliaria] CHECK CONSTRAINT [FK_inmueble_comprador]
GO
ALTER TABLE [dbo].[Inmobiliaria]  WITH CHECK ADD  CONSTRAINT [FK_inmueble_contrato] FOREIGN KEY([idcontrato])
REFERENCES [dbo].[Contrato] ([idcontrato])
GO
ALTER TABLE [dbo].[Inmobiliaria] CHECK CONSTRAINT [FK_inmueble_contrato]
GO
ALTER TABLE [dbo].[Inmobiliaria]  WITH CHECK ADD  CONSTRAINT [FK_inmueble_propietario] FOREIGN KEY([idpropietario])
REFERENCES [dbo].[Propietario] ([idpropietario])
GO
ALTER TABLE [dbo].[Inmobiliaria] CHECK CONSTRAINT [FK_inmueble_propietario]
GO
ALTER TABLE [dbo].[Inmobiliaria]  WITH CHECK ADD  CONSTRAINT [FK_inmueble_venta] FOREIGN KEY([idventa])
REFERENCES [dbo].[Venta] ([idventa])
GO
ALTER TABLE [dbo].[Inmobiliaria] CHECK CONSTRAINT [FK_inmueble_venta]
GO
ALTER TABLE [dbo].[Localidad]  WITH CHECK ADD  CONSTRAINT [FK_Localidad_Partido] FOREIGN KEY([idpartido])
REFERENCES [dbo].[Partido] ([idpartido])
GO
ALTER TABLE [dbo].[Localidad] CHECK CONSTRAINT [FK_Localidad_Partido]
GO
ALTER TABLE [dbo].[Partido]  WITH CHECK ADD  CONSTRAINT [FK_Partido_Provincia] FOREIGN KEY([idprovincia])
REFERENCES [dbo].[Provincia] ([idprovincia])
GO
ALTER TABLE [dbo].[Partido] CHECK CONSTRAINT [FK_Partido_Provincia]
GO
ALTER TABLE [dbo].[Tasacion]  WITH CHECK ADD  CONSTRAINT [FK_Tasacion_Tipo_Inmueble] FOREIGN KEY([idtipo_inmueble])
REFERENCES [dbo].[Tipo_Inmueble] ([idtipo_inmueble])
GO
ALTER TABLE [dbo].[Tasacion] CHECK CONSTRAINT [FK_Tasacion_Tipo_Inmueble]
GO
ALTER TABLE [dbo].[Tipo_Inmueble]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_Inmueble_Localidad] FOREIGN KEY([idlocalidad])
REFERENCES [dbo].[Localidad] ([idlocalidad])
GO
ALTER TABLE [dbo].[Tipo_Inmueble] CHECK CONSTRAINT [FK_Tipo_Inmueble_Localidad]
GO
ALTER TABLE [dbo].[Tipo_Inmueble]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_Inmueble_Partido] FOREIGN KEY([idpartido])
REFERENCES [dbo].[Partido] ([idpartido])
GO
ALTER TABLE [dbo].[Tipo_Inmueble] CHECK CONSTRAINT [FK_Tipo_Inmueble_Partido]
GO
ALTER TABLE [dbo].[Tipo_Inmueble]  WITH CHECK ADD  CONSTRAINT [FK_Tipo_Inmueble_Provincia] FOREIGN KEY([idprovincia])
REFERENCES [dbo].[Provincia] ([idprovincia])
GO
ALTER TABLE [dbo].[Tipo_Inmueble] CHECK CONSTRAINT [FK_Tipo_Inmueble_Provincia]
GO
/****** Object:  StoredProcedure [dbo].[AlquilerInsert]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AlquilerInsert] (
	@idalquiler uniqueidentifier,
	@importe_reserva int,
	@garantia nvarchar(50),
	@importe_alquiler decimal(18, 2),
	@idtipo_inmueble uniqueidentifier,
	@activo char(1)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Alquiler] (
	[idalquiler],
	[importe_reserva],
	[garantia],
	[importe_alquiler],
	[idtipo_inmueble],
	[activo]

) VALUES (
	@idalquiler,
	@importe_reserva,
	@garantia,
	@importe_alquiler,
	@idtipo_inmueble,
	@activo
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[AlquilerSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AlquilerSelect] (
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idalquiler],
	[importe_reserva],
	[garantia],
	[importe_alquiler],
	[idtipo_inmueble],
	[activo]
FROM
	[Alquiler]
WHERE
	[idtipo_inmueble] = @idtipo_inmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[AlquilerSelectAll]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AlquilerSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idalquiler],
	[importe_reserva],
	[garantia],
	[importe_alquiler],
	[idtipo_inmueble],
	[activo]
FROM
	[Alquiler]
WHERE
	[activo] = 1

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[AlquilerSelectReserva]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AlquilerSelectReserva] (
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idalquiler],
	[importe_reserva],
	[garantia],
	[importe_alquiler],
	[idtipo_inmueble],
	[activo]
FROM
	[Alquiler]
WHERE
	[idtipo_inmueble] = @idtipo_inmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[AlquilerUpdate]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AlquilerUpdate] (
	@idalquiler uniqueidentifier,
	@importe_reserva int,
	@garantia nvarchar(50),
	@importe_alquiler decimal(18, 2),
	@idtipo_inmueble uniqueidentifier,
	@Activo char(1)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Alquiler]
SET
	[importe_reserva] = @importe_reserva,
	[garantia] = @garantia,
	[importe_alquiler] = @importe_alquiler,
	[idtipo_inmueble] = @idtipo_inmueble,
	[Activo] = @Activo
WHERE
	 [idalquiler] = @idalquiler

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ClienteDelete]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ClienteDelete] (
	@idcliente uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Cliente]
WHERE
	[idcliente] = @idcliente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ClienteInquilinoSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ClienteInquilinoSelect] (
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idcliente],
	[legajo_inquilino],
	[nombre],
	[apellido],
	[dni],
	[fecha_nac],
	[telefono],
	[idtipo_inmueble]
FROM
	[Cliente]
WHERE
	[idtipo_inmueble] = @idtipo_inmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ClienteInsert]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ClienteInsert] (
	@idcliente uniqueidentifier,
	@legajo_inquilino int,
	@nombre nvarchar(50),
	@apellido nvarchar(50),
	@dni int,
	@fecha_nac date,
	@telefono nvarchar(50),
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Cliente] (
	[idcliente],
	[legajo_inquilino],
	[nombre],
	[apellido],
	[dni],
	[fecha_nac],
	[telefono],
	[idtipo_inmueble]
) VALUES (
	@idcliente,
	@legajo_inquilino,
	@nombre,
	@apellido,
	@dni,
	@fecha_nac,
	@telefono,
	@idtipo_inmueble
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ClienteSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ClienteSelect] (
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idcliente],
	[legajo_inquilino],
	[nombre],
	[apellido],
	[dni],
	[fecha_nac],
	[telefono],
	[idtipo_inmueble]
FROM
	[Cliente]
WHERE
	[idtipo_inmueble] = @idtipo_inmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ClienteSelectAll]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ClienteSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idcliente],
	[legajo_inquilino],
	[nombre],
	[apellido],
	[dni],
	[fecha_nac],
	[telefono],
	[idtipo_inmueble]
FROM
	[Cliente]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ClienteUpdate]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ClienteUpdate] (
	@idcliente uniqueidentifier,
	@legajo_inquilino int,
	@nombre nvarchar(50),
	@apellido nvarchar(50),
	@dni int,
	@fecha_nac date,
	@telefono nvarchar(50),
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Cliente]
SET
	[legajo_inquilino] = @legajo_inquilino,
	[nombre] = @nombre,
	[apellido] = @apellido,
	[dni] = @dni,
	[fecha_nac] = @fecha_nac,
	[telefono] = @telefono,
	[idtipo_inmueble] = @idtipo_inmueble
WHERE
	 [idcliente] = @idcliente

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[CompradorDelete]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CompradorDelete] (
	@idcomprador uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Comprador]
SET
	[Activo] = 1
WHERE
	[idcomprador] = @idcomprador


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[CompradorInsert]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CompradorInsert] (
	@idcomprador uniqueidentifier,
	@legajo_comprador int,
	@nombre nvarchar(50),
	@apellido nvarchar(50),
	@dni int,
	@fecha_nac date,
	@telefono nvarchar(50),
	@idtipo_inmueble uniqueidentifier,
	@importe int,
	@comision decimal(18, 2),
	@impuesto decimal(18, 2),
	@total_propiedad decimal(18, 2),
	@activo char(1)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Comprador] (
	[idcomprador],
	[legajo_comprador],
	[nombre],
	[apellido],
	[dni],
	[fecha_nac],
	[telefono],
	[idtipo_inmueble],
	[importe],
	[comision],
	[impuesto],
	[total_propiedad],
	[activo]
) VALUES (
	@idcomprador,
	@legajo_comprador,
	@nombre,
	@apellido,
	@dni,
	@fecha_nac,
	@telefono,
	@idtipo_inmueble,
	@importe,
	@comision,
	@impuesto,
	@total_propiedad,
	@activo
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[CompradorSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CompradorSelect] (
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idcomprador],
	[legajo_comprador],
	[nombre],
	[apellido],
	[dni],
	[fecha_nac],
	[telefono],
	[idtipo_inmueble],
	[importe],
	[comision],
	[impuesto],
	[total_propiedad],
	[activo]
FROM
	[Comprador]
WHERE
	[idtipo_inmueble] = @idtipo_inmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[CompradorSelectAll]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CompradorSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idcomprador],
	[legajo_comprador],
	[nombre],
	[apellido],
	[dni],
	[fecha_nac],
	[telefono],
	[idtipo_inmueble],
	[importe],
	[comision],
	[impuesto],
	[total_propiedad],
	[activo]
FROM
	[Comprador]
WHERE
	[activo] = 1
ORDER BY
	legajo_comprador ASC

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[CompradorUpdate]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CompradorUpdate] (
	@idcomprador uniqueidentifier,
	@legajo_comprador int,
	@nombre nvarchar(50),
	@apellido nvarchar(50),
	@dni int,
	@fecha_nac date,
	@telefono nvarchar(50),
	@idtipo_inmueble uniqueidentifier,
	@importe int,
	@comision decimal(18, 2),
	@impuesto decimal(18, 2),
	@total_propiedad decimal(18, 2),
	@Activo char(1)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Comprador]
SET
	[legajo_comprador] = @legajo_comprador,
	[nombre] = @nombre,
	[apellido] = @apellido,
	[dni] = @dni,
	[fecha_nac] = @fecha_nac,
	[telefono] = @telefono,
	[idtipo_inmueble] = @idtipo_inmueble,
	[importe] = @importe,
	[comision] = @comision,
	[impuesto] = @impuesto,
	[total_propiedad] = @total_propiedad,
	[Activo] = @Activo
WHERE
	 [idcomprador] = @idcomprador

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ContratoDelete]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContratoDelete] (
	@idcontrato uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Contrato]
WHERE
	[idcontrato] = @idcontrato


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ContratoInsert]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContratoInsert] (
	@idcontrato uniqueidentifier,
	@fecha_inicio date,
	@fecha_fin date,
	@idescribania uniqueidentifier,
	@idtipo_inmueble uniqueidentifier,
	@idalquiler uniqueidentifier,
	@idcliente uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Contrato] (
	[idcontrato],
	[fecha_inicio],
	[fecha_fin],
	[idescribania],
	[idtipo_inmueble],
	[idalquiler],
	[idcliente]

) VALUES (
	@idcontrato,
	@fecha_inicio,
	@fecha_fin,
	@idescribania,
	@idtipo_inmueble,
	@idalquiler,
	@idcliente
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ContratoSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContratoSelect] (
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idcontrato],
	[fecha_inicio],
	[fecha_fin],
	[idescribania],
	[idtipo_inmueble],
	[idalquiler],
	[idcliente]
FROM
	[Contrato]
WHERE
	[idtipo_inmueble] = @idtipo_inmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ContratoSelectAll]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContratoSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idcontrato],
	[fecha_inicio],
	[fecha_fin],
	[idescribania],
	[idtipo_inmueble],
	[idalquiler],
	[idcliente]
FROM
	[Contrato]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ContratoUpdate]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ContratoUpdate] (
	@idcontrato uniqueidentifier,
	@fecha_inicio date,
	@fecha_fin date,
	@idescribania uniqueidentifier,
	@idtipo_inmueble uniqueidentifier,
	@idalquiler uniqueidentifier,
	@idcliente uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Contrato]
SET
	[fecha_inicio] = @fecha_inicio,
	[fecha_fin] = @fecha_fin,
	[idescribania] = @idescribania,
	[idtipo_inmueble] = @idtipo_inmueble,
	[idalquiler] = @idalquiler,
	[idcliente] = @idcliente
WHERE
	 [idcontrato] = @idcontrato

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[EscribaniaDelete]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EscribaniaDelete] (
	@idescribania uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Escribania]
WHERE
	[idescribania] = @idescribania


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[EscribaniaInsert]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EscribaniaInsert] (
	@idescribania uniqueidentifier,
	@razon_social nvarchar(50),
	@direccion nvarchar(50),
	@telefono nvarchar(50)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Escribania] (
	[idescribania],
	[razon_social],
	[direccion],
	[telefono]
) VALUES (
	@idescribania,
	@razon_social,
	@direccion,
	@telefono
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[EscribaniaSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EscribaniaSelect] (
	@idescribania uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idescribania],
	[razon_social],
	[direccion],
	[telefono]
FROM
	[Escribania]
WHERE
	[idescribania] = @idescribania


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[EscribaniaSelectAll]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EscribaniaSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idescribania],
	[razon_social],
	[direccion],
	[telefono]
FROM
	[Escribania]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[EscribaniaUpdate]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EscribaniaUpdate] (
	@idescribania uniqueidentifier,
	@razon_social nvarchar(50),
	@direccion nvarchar(50),
	@telefono nvarchar(50)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Escribania]
SET
	[razon_social] = @razon_social,
	[direccion] = @direccion,
	[telefono] = @telefono
WHERE
	 [idescribania] = @idescribania

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[InmobiliariaDelete]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InmobiliariaDelete] (
	@idinmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Inmobiliaria]
WHERE
	[idinmueble] = @idinmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[InmobiliariaInsert]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InmobiliariaInsert] (
	@idinmueble uniqueidentifier,
	@idtipo_inmueble uniqueidentifier,
	@idpropietario uniqueidentifier,
	@idcomprador uniqueidentifier,
	@idalquiler uniqueidentifier,
	@idventa uniqueidentifier,
	@idcontrato uniqueidentifier,
	@detalle nvarchar(50),
	@fecha_operacion datetime,
	@Activo char(1)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Inmobiliaria] (
	[idinmueble],
	[idtipo_inmueble],
	[idpropietario],
	[idcomprador],
	[idalquiler],
	[idventa],
	[idcontrato],
	[detalle],
	[fecha_operacion],
	[Activo]
) VALUES (
	@idinmueble,
	@idtipo_inmueble,
	@idpropietario,
	@idcomprador,
	@idalquiler,
	@idventa,
	@idcontrato,
	@detalle,
	@fecha_operacion,
	@Activo
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[InmobiliariaSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InmobiliariaSelect] (
	@idinmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idinmueble],
	[idtipo_inmueble],
	[idpropietario],
	[idcomprador],
	[idalquiler],
	[idventa],
	[idcontrato],
	[detalle],
	[fecha_operacion]
FROM
	[Inmobiliaria]
WHERE
	[idinmueble] = @idinmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[InmobiliariaSelectAll]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InmobiliariaSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idinmueble],
	[idtipo_inmueble],
	[idpropietario],
	[idcomprador],
	[idalquiler],
	[idventa],
	[idcontrato],
	[detalle],
	[fecha_operacion]
FROM
	[Inmobiliaria]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[InmobiliariaUpdate]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InmobiliariaUpdate] (
	@idinmueble uniqueidentifier,
	@idtipo_inmueble uniqueidentifier,
	@idpropietario uniqueidentifier,
	@idcomprador uniqueidentifier,
	@idalquiler uniqueidentifier,
	@idventa uniqueidentifier,
	@idcontrato uniqueidentifier,
	@detalle nvarchar(50),
	@fecha_operacion datetime,
	@Activo char(1)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Inmobiliaria]
SET
	[idtipo_inmueble] = @idtipo_inmueble,
	[idpropietario] = @idpropietario,
	[idcomprador] = @idcomprador,
	[idalquiler] = @idalquiler,
	[idventa] = @idventa,
	[idcontrato] = @idcontrato,
	[detalle] = @detalle,
	[fecha_operacion] = @fecha_operacion,
	[Activo] = @Activo
WHERE
	 [idinmueble] = @idinmueble

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[LimpiarTablaLog]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento almacenado para limpiar la tabla Log cada 3 meses
CREATE PROCEDURE [dbo].[LimpiarTablaLog]
AS
BEGIN
    -- Verificar si han pasado 3 meses desde la última limpieza
    IF DATEDIFF(MONTH, (SELECT MAX(fecha_txr) FROM Log), GETDATE()) >= 3
    BEGIN
        -- Realizar la limpieza de la tabla Log
        DELETE FROM Log;

        -- Insertar un registro indicando que la limpieza se realizó
        INSERT INTO Log (idlog, message, severity, fecha_txr)
        VALUES (NEWID(), 'Tabla Log limpiada', 'Info', GETDATE());
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[LocalidadSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LocalidadSelect] (
	@idlocalidad uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idlocalidad],
	[nom_localidad],
	[codigo_postal],
	[idpartido]
FROM
	[Localidad]
WHERE
	[idlocalidad] = @idlocalidad


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[LogInsert]    Script Date: 5/3/2024 09:52:09 ******/
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
/****** Object:  StoredProcedure [dbo].[LogSelectAll]    Script Date: 5/3/2024 09:52:09 ******/
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
/****** Object:  StoredProcedure [dbo].[PartidoSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PartidoSelect] (
	@idpartido uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idpartido],
	[idprovincia],
	[nom_partido]
FROM
	[Partido]
WHERE
	[idpartido] = @idpartido


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[PropietarioDelete]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PropietarioDelete] (
	@idpropietario uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Propietario]
WHERE
	[idpropietario] = @idpropietario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[PropietarioInsert]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PropietarioInsert] (
	@idpropietario uniqueidentifier,
	@legajo_propietario int,
	@nombre nvarchar(50),
	@apellido nvarchar(50),
	@dni int,
	@fecha_nac date,
	@telefono nvarchar(50),
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Propietario] (
	[idpropietario],
	[legajo_propietario],
	[nombre],
	[apellido],
	[dni],
	[fecha_nac],
	[telefono],
	[idtipo_inmueble]
) VALUES (
	@idpropietario,
	@legajo_propietario,
	@nombre,
	@apellido,
	@dni,
	@fecha_nac,
	@telefono,
	@idtipo_inmueble
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[PropietarioSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PropietarioSelect] (
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idpropietario],
	[legajo_propietario],
	[nombre],
	[apellido],
	[dni],
	[fecha_nac],
	[telefono],
	[idtipo_inmueble]
FROM
	[Propietario]
WHERE
	[idtipo_inmueble] = @idtipo_inmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[PropietarioSelectAll]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PropietarioSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idpropietario],
	[legajo_propietario],
	[nombre],
	[apellido],
	[dni],
	[fecha_nac],
	[telefono],
	[idtipo_inmueble]
FROM
	[Propietario]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[PropietarioUpdate]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PropietarioUpdate] (
	@idpropietario uniqueidentifier,
	@legajo_propietario int,
	@nombre nvarchar(50),
	@apellido nvarchar(50),
	@dni int,
	@fecha_nac date,
	@telefono nvarchar(50),
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Propietario]
SET
	[legajo_propietario] = @legajo_propietario,
	[nombre] = @nombre,
	[apellido] = @apellido,
	[dni] = @dni,
	[fecha_nac] = @fecha_nac,
	[telefono] = @telefono,
	[idtipo_inmueble] = @idtipo_inmueble
WHERE
	 [idpropietario] = @idpropietario

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ProvinciaSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProvinciaSelect] (
	@idprovincia uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idprovincia],
	[nom_provincia]
FROM
	[Provincia]
WHERE
	[idprovincia] = @idprovincia
	order by nom_provincia asc

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ProvinciaSelectAll]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ProvinciaSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idprovincia],
	[nom_provincia]
FROM
	[Provincia]

	order by nom_provincia

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[ReportePropiedades]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Aldo Corcoglioniti>
-- Create date: <Create Date,20022024,>
-- Description:	<Description,,Reporte de Propiedades con sus precios>
-- =============================================
CREATE PROCEDURE [dbo].[ReportePropiedades] 

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT TI.tipo_inmueble, TI.descripcion, T.importe_alquiler, T.importe_venta,
           TI.direccion, P.nom_provincia, Par.nom_partido, Loc.nom_localidad
    FROM Tipo_Inmueble TI
    LEFT OUTER JOIN Tasacion T ON T.idtipo_inmueble = TI.idtipo_inmueble
    LEFT OUTER JOIN Provincia P ON P.idprovincia = TI.idprovincia
    LEFT OUTER JOIN Partido Par ON Par.idpartido = TI.idpartido
    LEFT OUTER JOIN Localidad Loc ON Loc.idlocalidad = TI.idlocalidad;
END

GO
/****** Object:  StoredProcedure [dbo].[TasacionDelete]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TasacionDelete] (
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Tasacion]
WHERE
	[idtipo_inmueble] = @idtipo_inmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[TasacionInsert]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TasacionInsert] (
	@idtasacion uniqueidentifier,
	@importe_venta int,
	@fecha datetime,
	@importe_alquiler int,
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Tasacion] (
	[idtasacion],
	[importe_venta],
	[fecha],
	[importe_alquiler],
	[idtipo_inmueble]
) VALUES (
	@idtasacion,
	@importe_venta,
	@fecha,
	@importe_alquiler,
	@idtipo_inmueble
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[TasacionSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TasacionSelect] (
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idtasacion],
	[importe_venta],
	[fecha],
	[importe_alquiler],
	[idtipo_inmueble]
FROM
	[Tasacion]
WHERE
	[idtipo_inmueble] = @idtipo_inmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[Tipo_InmuebleDelete]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Tipo_InmuebleDelete] (
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Tipo_Inmueble]
WHERE
	[idtipo_inmueble] = @idtipo_inmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[Tipo_InmuebleInsert]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Tipo_InmuebleInsert] (
	@idtipo_inmueble uniqueidentifier,
	@tipo_inmueble nvarchar(50),
	@descripcion nvarchar(50),
	@idlocalidad uniqueidentifier,
	@idpartido uniqueidentifier,
	@idprovincia uniqueidentifier,
	@direccion nvarchar(50)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Tipo_Inmueble] (
	[idtipo_inmueble],
	[tipo_inmueble],
	[descripcion],
	[idlocalidad],
	[idpartido],
	[idprovincia],
	[direccion]
) VALUES (
	@idtipo_inmueble,
	@tipo_inmueble,
	@descripcion,
	@idlocalidad,
	@idpartido,
	@idprovincia,
	@direccion
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[Tipo_InmuebleSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Tipo_InmuebleSelect] (
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idtipo_inmueble],
	[tipo_inmueble],
	[descripcion],
	[idlocalidad],
	[idpartido],
	[idprovincia],
	[direccion]
FROM
	[Tipo_Inmueble]
WHERE
	[idtipo_inmueble] = @idtipo_inmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[Tipo_InmuebleSelectAll]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Tipo_InmuebleSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

 SELECT 
        [idtipo_inmueble],
        [tipo_inmueble],
        [descripcion],
        [idlocalidad],
        [idpartido],
        [idprovincia],
        [direccion]
    FROM 
        [Tipo_Inmueble];


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[Tipo_InmuebleUpdate]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Tipo_InmuebleUpdate] (
	@idtipo_inmueble uniqueidentifier,
	@tipo_inmueble nvarchar(50),
	@descripcion nvarchar(50),
	@idlocalidad uniqueidentifier,
	@idpartido uniqueidentifier,
	@idprovincia uniqueidentifier,
	@direccion nvarchar(50)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Tipo_Inmueble]
SET
	[tipo_inmueble] = @tipo_inmueble,
	[descripcion] = @descripcion,
	[idlocalidad] = @idlocalidad,
	[idpartido] = @idpartido,
	[idprovincia] = @idprovincia,
	[direccion] = @direccion
WHERE
	 [idtipo_inmueble] = @idtipo_inmueble

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[VentaDelete]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VentaDelete] (
	@idventa uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Venta]
WHERE
	[idventa] = @idventa


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[VentaInsert]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VentaInsert] (
	@idventa uniqueidentifier,
	@importe int,
	@comision decimal(18, 2),
	@idtipo_inmueble uniqueidentifier,
	@activo char(1),
	@idpropietario uniqueidentifier,
	@tipo_inmueble nvarchar(50),
	@descripcion nvarchar(50),
	@direccion nvarchar(50)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Venta] (
	[idventa],
	[importe],
	[comision],
	[idtipo_inmueble],
	[activo],
	[idpropietario],
	[tipo_inmueble],
	[descripcion],
	[direccion]
) VALUES (
	@idventa,
	@importe,
	@comision,
	@idtipo_inmueble,
	@activo,
	@idpropietario,
	@tipo_inmueble,
	@descripcion,
	@direccion
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[VentaSelect]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VentaSelect] (
	@idtipo_inmueble uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idventa],
	[importe],
	[comision],
	[idtipo_inmueble],
	[activo],
	[idpropietario],
	[tipo_inmueble],
	[descripcion],
	[direccion]
FROM
	[Venta]
WHERE
	[idtipo_inmueble] = @idtipo_inmueble


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[VentaSelectAll]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VentaSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[idventa],
	[importe],
	[comision],
	[idtipo_inmueble],
	[Activo],
	[idpropietario],
	[tipo_inmueble],
	[descripcion],
	[direccion]
FROM
	[Venta]
WHERE
	[Activo] = 1


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[VentaUpdate]    Script Date: 5/3/2024 09:52:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VentaUpdate] (
	@idventa uniqueidentifier,
	@importe int,
	@comision decimal(18, 2),
	@idtipo_inmueble uniqueidentifier,
	@Activo char(1),
	@idpropietario uniqueidentifier,
	@tipo_inmueble nvarchar(50),
	@descripcion nvarchar(50),
	@direccion nvarchar(50)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Venta]
SET
	[importe] = @importe,
	[comision] = @comision,
	[idtipo_inmueble] = @idtipo_inmueble,
	[Activo] = @Activo,
	[idpropietario] = @idpropietario,
	[tipo_inmueble] = @tipo_inmueble,
	[descripcion] = @descripcion,
	[direccion] = @direccion

WHERE
	 [idventa] = @idventa

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
