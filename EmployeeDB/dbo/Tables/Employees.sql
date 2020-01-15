﻿CREATE TABLE [dbo].[Employees] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (50)  NOT NULL,
    [Email]      VARCHAR (100) NOT NULL,
    [Department] INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

