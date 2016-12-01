CREATE TABLE [dbo].[tblRekening_rek]
(
	[rekId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [rekRekeningnummer] NVARCHAR(128) NOT NULL, 
    [rekToelichting] NVARCHAR(128) NULL, 
    [rekVolgnummer] INT NULL, 
    [rekActief] BIT NOT NULL DEFAULT 1,
	[rek_bhoId] UNIQUEIDENTIFIER NOT NULL, 
    [rek_tenId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK1_tblRekening_id_Tenant_id] FOREIGN KEY ([rek_tenId]) REFERENCES [dbo].[tblTenant_ten] ([tenId]),
	CONSTRAINT [FK1_tblRekening_id_tblBoekhouding_id] FOREIGN KEY ([rek_bhoId]) REFERENCES [dbo].[tblBoekhouding_bho] ([bhoId])
)
