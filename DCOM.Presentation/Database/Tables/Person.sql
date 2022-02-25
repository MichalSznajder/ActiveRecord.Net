CREATE TABLE [dbo].[Person] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [RoleId]       INT            NOT NULL,
    [FirstName]    NVARCHAR (32)  NOT NULL,
    [LastName]     NVARCHAR (32)  NOT NULL,
    [EmailAddress] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Person_PersonRole] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[PersonRole] ([Id])
);

