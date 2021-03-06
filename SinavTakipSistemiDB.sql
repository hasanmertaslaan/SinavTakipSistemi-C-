USE [master]
GO
/****** Object:  Database [SinavTakipSistemiDB]    Script Date: 18.05.2021 15:32:28 ******/
CREATE DATABASE [SinavTakipSistemiDB]
GO
USE [SinavTakipSistemiDB]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 18.05.2021 15:32:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[AdSoyad] [nvarchar](50) NOT NULL,
	[Sifre] [nvarchar](50) NOT NULL,
	[Telefon] [nvarchar](20) NOT NULL,
	[Tc] [nvarchar](11) NOT NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sinavlar]    Script Date: 18.05.2021 15:32:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sinavlar](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SinavAdi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sinavlar] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinavSonuclari]    Script Date: 18.05.2021 15:32:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinavSonuclari](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciId] [int] NOT NULL,
	[SoruId] [int] NOT NULL,
	[Cevap] [char](1) NOT NULL,
 CONSTRAINT [PK_SinavSonuclari] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sorular]    Script Date: 18.05.2021 15:32:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sorular](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SinavId] [int] NOT NULL,
	[Sual] [nvarchar](1000) NOT NULL,
	[A] [nvarchar](1000) NOT NULL,
	[B] [nvarchar](1000) NOT NULL,
	[C] [nvarchar](1000) NOT NULL,
	[D] [nvarchar](1000) NOT NULL,
	[E] [nvarchar](1000) NOT NULL,
	[Cevap] [char](1) NOT NULL,
 CONSTRAINT [PK_Sorular] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SinavSonuclari]  WITH CHECK ADD  CONSTRAINT [FK_SinavSonuclari_Kullanicilar] FOREIGN KEY([KullaniciId])
REFERENCES [dbo].[Kullanicilar] ([Id])
GO
ALTER TABLE [dbo].[SinavSonuclari] CHECK CONSTRAINT [FK_SinavSonuclari_Kullanicilar]
GO
ALTER TABLE [dbo].[SinavSonuclari]  WITH CHECK ADD  CONSTRAINT [FK_SinavSonuclari_Sorular] FOREIGN KEY([SoruId])
REFERENCES [dbo].[Sorular] ([Id])
GO
ALTER TABLE [dbo].[SinavSonuclari] CHECK CONSTRAINT [FK_SinavSonuclari_Sorular]
GO
ALTER TABLE [dbo].[Sorular]  WITH CHECK ADD  CONSTRAINT [FK_Sorular_Sinavlar] FOREIGN KEY([SinavId])
REFERENCES [dbo].[Sinavlar] ([Id])
GO
ALTER TABLE [dbo].[Sorular] CHECK CONSTRAINT [FK_Sorular_Sinavlar]
GO
USE [master]
GO
ALTER DATABASE [SinavTakipSistemiDB] SET  READ_WRITE 
GO
