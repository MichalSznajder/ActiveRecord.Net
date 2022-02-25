CREATE TABLE [dbo].[WorkItemStatus] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (32) NOT NULL,
    CONSTRAINT [PK_WorkItemStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
);

