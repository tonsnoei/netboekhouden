CREATE TABLE [dbo].[tblKostenplaats_kpl]
(
	[kplId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [kplNaam] NVARCHAR(128) NOT NULL, 
    [kplVolgnummer] INT NOT NULL, 
    [kplActief] BIT NOT NULL DEFAULT 1, 
    [kpl_bhoId] UNIQUEIDENTIFIER NOT NULL, 
    [kpl_tenId] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [FK_tblKostenPlaats_id_Tenant_id] FOREIGN KEY ([kpl_tenId]) REFERENCES [dbo].[tblTenant_ten] ([tenId]),
	CONSTRAINT [FK_tblKostenPlaats_id_tblBoekhouding_id] FOREIGN KEY ([kpl_bhoId]) REFERENCES [dbo].[tblBoekhouding_bho] ([bhoId])
)
