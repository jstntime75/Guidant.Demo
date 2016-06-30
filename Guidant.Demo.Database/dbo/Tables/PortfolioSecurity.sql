CREATE TABLE [dbo].[PortfolioSecurity] (
    [PortfolioId] INT NOT NULL,
    [SecurityId]  INT NOT NULL,
    [Count]       INT NOT NULL,
    CONSTRAINT [PK_PortfolioSecurity] PRIMARY KEY CLUSTERED ([PortfolioId] ASC, [SecurityId] ASC)
);

