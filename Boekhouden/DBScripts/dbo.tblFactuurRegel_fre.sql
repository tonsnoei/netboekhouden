CREATE TABLE [dbo].[tblFactuurRegel_fre]
(
	[freId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [fre_facId] UNIQUEIDENTIFIER NOT NULL, 
    [fre_tenId] UNIQUEIDENTIFIER NOT NULL, 
    [fretProduct] NVARCHAR(256) NULL, 
    [frePrijsExBtw] DECIMAL(18, 4) NULL, 
    [fre_btwId] INT NULL, 
    [freAantal] BIGINT NULL, 
    [fre_psoId] INT NULL, 
    [freMargeInkoop] DECIMAL(18, 4) NULL,
	CONSTRAINT [FK_tblfactuurregel_Factuur_id] FOREIGN KEY ([fre_facId]) REFERENCES [dbo].[tblFactuur_fac] ([facId]),
	CONSTRAINT [FK_tblfactuurregel_Tenant_id] FOREIGN KEY ([fre_tenId]) REFERENCES [dbo].[tblTenant_ten] ([tenId]),
	CONSTRAINT [FK_tblfactuurregel_BTW_id] FOREIGN KEY ([fre_btwId]) REFERENCES [dbo].[tblBTW_btw] ([btwId]),
	CONSTRAINT [FK_tblfactuurregel_productsoort_id] FOREIGN KEY ([fre_psoId]) REFERENCES [dbo].[tblProductSoort_pso] ([psoId]),
)
