CREATE TABLE [dbo].[WorkItem] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [PersonId]       INT             NOT NULL,
    [StatusId]       INT             NOT NULL,
    [PriorityId]     INT             NOT NULL,
    [Description]    NVARCHAR (1024) NOT NULL,
    [HoursEstimated] INT             NOT NULL,
    [HoursWorked]    INT             NOT NULL,
    [HoursRemaining] INT             NOT NULL,
    CONSTRAINT [PK_WorkItem] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WorkItem_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id]),
    CONSTRAINT [FK_WorkItem_WorkItemPriority] FOREIGN KEY ([PriorityId]) REFERENCES [dbo].[WorkItemPriority] ([Id]),
    CONSTRAINT [FK_WorkItem_WorkItemStatus] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[WorkItemStatus] ([Id])
);

