CREATE TABLE [dbo].[Security] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [SecurityTypeId] TINYINT      NOT NULL,
    [Symbol]         VARCHAR (5)  NOT NULL,
    [Price]          DECIMAL (18, 4) NOT NULL,
    CONSTRAINT [PK_Security] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Security_SecurityType] FOREIGN KEY ([SecurityTypeId]) REFERENCES [dbo].[SecurityType] ([Id])
);

