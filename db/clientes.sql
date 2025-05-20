IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BD_CLIENTES')
BEGIN
    CREATE DATABASE BD_CLIENTES;
END
GO

USE BD_CLIENTES;
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TiposDocumentos]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[TiposDocumentos](
        [Id] [int] IDENTITY(1,1) NOT NULL,
        [Nombre] [nvarchar](50) NOT NULL,
        [Descripcion] [nvarchar](100) NULL,
        CONSTRAINT [PK_TiposDocumentos] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
    
    INSERT INTO [dbo].[TiposDocumentos] ([Nombre], [Descripcion])
    VALUES ('DNI', 'Documento Nacional de Identidad'),
           ('Pasaporte', 'Pasaporte Nacional'),
           ('CE', 'Carnet de Extranjería');
END
GO