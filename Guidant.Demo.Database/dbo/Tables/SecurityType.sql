CREATE TABLE [dbo].[SecurityType] (
    [Id]          TINYINT       NOT NULL,
    [Code]        VARCHAR (5)   NOT NULL,
    [Description] VARCHAR (256) NOT NULL,
    CONSTRAINT [PK_SecurityType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

