CREATE TABLE [dbo].[tblFactuurType_fty]
(
	[ftyId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [ftyNaam] NVARCHAR(128) NOT NULL, 
    [ftyDescription] TEXT NOT NULL
)
