CREATE TABLE [dbo].[Portfolio] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [ClientId] INT          NOT NULL,
    CONSTRAINT [PK_Portfolio] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Portfolio_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id])
);

