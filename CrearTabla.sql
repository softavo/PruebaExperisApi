USE [BD_Entrevistas]
GO

/****** Object:  Table [dbo].[Entrevistas]    Script Date: 12/03/2020 2:57:09 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Entrevistas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[NombresCompletos] [varchar](100) NOT NULL,
	[ModalidadEntrevista] [varchar](50) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Hora] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Entrevistas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


