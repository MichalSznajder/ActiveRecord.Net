CREATE TABLE [dbo].[PersonRole] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (32) NOT NULL,
    CONSTRAINT [PK_PersonRole] PRIMARY KEY CLUSTERED ([Id] ASC)
);

