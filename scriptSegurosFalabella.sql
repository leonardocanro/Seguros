USE [master]
GO
/****** Object:  Database [Seguros]    Script Date: 04/12/2018 04:09:57 p.m. ******/
CREATE DATABASE [Seguros]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Seguros', FILENAME = N'G:\Databases\Data\DESARROLLO\Seguros.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Seguros_log', FILENAME = N'H:\Databases\Log\Desarrollo\Seguros_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Seguros] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Seguros].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Seguros] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Seguros] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Seguros] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Seguros] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Seguros] SET ARITHABORT OFF 
GO
ALTER DATABASE [Seguros] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Seguros] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Seguros] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Seguros] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Seguros] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Seguros] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Seguros] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Seguros] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Seguros] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Seguros] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Seguros] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Seguros] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Seguros] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Seguros] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Seguros] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Seguros] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Seguros] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Seguros] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Seguros] SET RECOVERY FULL 
GO
ALTER DATABASE [Seguros] SET  MULTI_USER 
GO
ALTER DATABASE [Seguros] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Seguros] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Seguros] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Seguros] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Seguros', N'ON'
GO
USE [Seguros]
GO
/****** Object:  Table [dbo].[Agente]    Script Date: 04/12/2018 04:09:57 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Agente](
	[IdAgente] [int] IDENTITY(1,1) NOT NULL,
	[IdAseguradora] [int] NOT NULL,
	[NombreAgente] [varchar](50) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Agente] PRIMARY KEY CLUSTERED 
(
	[IdAgente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Aseguradora]    Script Date: 04/12/2018 04:09:57 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Aseguradora](
	[IdAseguradora] [int] IDENTITY(1,1) NOT NULL,
	[NombreAseguradora] [varchar](50) NOT NULL,
	[Nit] [int] NOT NULL,
	[Telefono] [int] NOT NULL,
	[Contacto] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
 CONSTRAINT [PK_Aseguradora] PRIMARY KEY CLUSTERED 
(
	[IdAseguradora] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GestionFalabella]    Script Date: 04/12/2018 04:09:57 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GestionFalabella](
	[IdGestion] [int] IDENTITY(1,1) NOT NULL,
	[IdAseguradora] [int] NOT NULL,
	[IdAgente] [int] NOT NULL,
	[NombreCliente] [varchar](50) NOT NULL,
	[Cedula] [int] NOT NULL,
	[Telefono] [int] NULL,
	[Direccion] [varchar](50) NULL,
 CONSTRAINT [PK_GestionFalabella] PRIMARY KEY CLUSTERED 
(
	[IdGestion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GestionProductos]    Script Date: 04/12/2018 04:09:57 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GestionProductos](
	[IdGestion] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
 CONSTRAINT [PK_GestionProductos] PRIMARY KEY CLUSTERED 
(
	[IdGestion] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Productos]    Script Date: 04/12/2018 04:09:57 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[IdAseguradora] [int] NOT NULL,
	[NombreProducto] [varchar](50) NOT NULL,
	[CodigoProducto] [int] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Agente] ON 

INSERT [dbo].[Agente] ([IdAgente], [IdAseguradora], [NombreAgente], [Login], [Password]) VALUES (1, 1, N'Nelson Canro', N'nlcan', N'lul')
INSERT [dbo].[Agente] ([IdAgente], [IdAseguradora], [NombreAgente], [Login], [Password]) VALUES (2, 1, N'Nelson Canro', N'admin', N'lol')
SET IDENTITY_INSERT [dbo].[Agente] OFF
SET IDENTITY_INSERT [dbo].[Aseguradora] ON 

INSERT [dbo].[Aseguradora] ([IdAseguradora], [NombreAseguradora], [Nit], [Telefono], [Contacto], [Direccion]) VALUES (1, N'Colmena', 890111345, 234234, N'Nelson', N'cl 127 45 30')
INSERT [dbo].[Aseguradora] ([IdAseguradora], [NombreAseguradora], [Nit], [Telefono], [Contacto], [Direccion]) VALUES (3, N'SURA', 234732487, 3242343, N'Maria', N'cl 212 23 33')
SET IDENTITY_INSERT [dbo].[Aseguradora] OFF
SET IDENTITY_INSERT [dbo].[GestionFalabella] ON 

INSERT [dbo].[GestionFalabella] ([IdGestion], [IdAseguradora], [IdAgente], [NombreCliente], [Cedula], [Telefono], [Direccion]) VALUES (2, 1, 2, N'asdfasdf', 1234, 234, N'cl 12 a')
INSERT [dbo].[GestionFalabella] ([IdGestion], [IdAseguradora], [IdAgente], [NombreCliente], [Cedula], [Telefono], [Direccion]) VALUES (3, 1, 2, N'Felipe', 123456, 234324, N'cl 12 a')
SET IDENTITY_INSERT [dbo].[GestionFalabella] OFF
INSERT [dbo].[GestionProductos] ([IdGestion], [IdProducto]) VALUES (2, 1)
INSERT [dbo].[GestionProductos] ([IdGestion], [IdProducto]) VALUES (2, 3)
INSERT [dbo].[GestionProductos] ([IdGestion], [IdProducto]) VALUES (3, 3)
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([IdProducto], [IdAseguradora], [NombreProducto], [CodigoProducto]) VALUES (1, 1, N'POLIZA VIDA', 1234)
INSERT [dbo].[Productos] ([IdProducto], [IdAseguradora], [NombreProducto], [CodigoProducto]) VALUES (2, 3, N'POLIZA CARRO', 12345)
INSERT [dbo].[Productos] ([IdProducto], [IdAseguradora], [NombreProducto], [CodigoProducto]) VALUES (3, 1, N'POLIZA VIVIENDA', 123456)
SET IDENTITY_INSERT [dbo].[Productos] OFF
ALTER TABLE [dbo].[Agente]  WITH CHECK ADD  CONSTRAINT [FK_Agente_Aseguradora] FOREIGN KEY([IdAseguradora])
REFERENCES [dbo].[Aseguradora] ([IdAseguradora])
GO
ALTER TABLE [dbo].[Agente] CHECK CONSTRAINT [FK_Agente_Aseguradora]
GO
ALTER TABLE [dbo].[GestionFalabella]  WITH CHECK ADD  CONSTRAINT [FK_GestionFalabella_Agente] FOREIGN KEY([IdAgente])
REFERENCES [dbo].[Agente] ([IdAgente])
GO
ALTER TABLE [dbo].[GestionFalabella] CHECK CONSTRAINT [FK_GestionFalabella_Agente]
GO
ALTER TABLE [dbo].[GestionFalabella]  WITH CHECK ADD  CONSTRAINT [FK_GestionFalabella_Aseguradora] FOREIGN KEY([IdAseguradora])
REFERENCES [dbo].[Aseguradora] ([IdAseguradora])
GO
ALTER TABLE [dbo].[GestionFalabella] CHECK CONSTRAINT [FK_GestionFalabella_Aseguradora]
GO
ALTER TABLE [dbo].[GestionProductos]  WITH CHECK ADD  CONSTRAINT [FK_GestionProductos_GestionFalabella] FOREIGN KEY([IdGestion])
REFERENCES [dbo].[GestionFalabella] ([IdGestion])
GO
ALTER TABLE [dbo].[GestionProductos] CHECK CONSTRAINT [FK_GestionProductos_GestionFalabella]
GO
ALTER TABLE [dbo].[GestionProductos]  WITH CHECK ADD  CONSTRAINT [FK_GestionProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[GestionProductos] CHECK CONSTRAINT [FK_GestionProductos_Productos]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Aseguradora] FOREIGN KEY([IdAseguradora])
REFERENCES [dbo].[Aseguradora] ([IdAseguradora])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Aseguradora]
GO
USE [master]
GO
ALTER DATABASE [Seguros] SET  READ_WRITE 
GO
