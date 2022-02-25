CREATE TABLE [dbo].[WorkItemPriority] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (32) NOT NULL,
    CONSTRAINT [PK_WorkItemPriority] PRIMARY KEY CLUSTERED ([Id] ASC)
);

