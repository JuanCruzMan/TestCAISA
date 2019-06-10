CREATE TABLE [dbo].[Usuario] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [correoelectronico] NVARCHAR (50) NOT NULL,
    [Usuario]           NVARCHAR (50) NOT NULL,
    [pass]              NVARCHAR (50) NOT NULL,
    [nombre]            NVARCHAR (50) NOT NULL,
    [apellidoPat]       NVARCHAR (50) NOT NULL,
    [apellidoMat]       NVARCHAR (50) NOT NULL,
    [fechNac]           NVARCHAR (50) NOT NULL,
    [edad]              INT           NOT NULL,
    [direccion]         NVARCHAR (50) NOT NULL,
    [telefono]          NVARCHAR (50) NOT NULL,
    [Pass1]             NVARCHAR (50) NOT NULL,
    [Pass2]             NVARCHAR (50) NOT NULL,
    [Pass3]             NVARCHAR (50) NOT NULL
);

