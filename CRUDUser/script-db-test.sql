USE [test]
CREATE TABLE [dbo].[usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NameUsuario] [char](10) NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
)
