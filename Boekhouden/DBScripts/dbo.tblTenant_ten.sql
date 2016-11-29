CREATE TABLE [dbo].[tblTenant_ten] (
    [tenId]           UNIQUEIDENTIFIER NOT NULL,
    [tenCreationDate] DATETIME         DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([tenId] ASC) 
);

