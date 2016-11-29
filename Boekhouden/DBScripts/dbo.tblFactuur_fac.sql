CREATE TABLE [dbo].[tblFactuur_fac] (
    [facId]            UNIQUEIDENTIFIER NOT NULL,
    [fac_relId]        UNIQUEIDENTIFIER NULL,
    [facDatum]         DATETIME         NULL,
    [facFactuurNummer] NVARCHAR (128)   NULL,
    [fac_kplId]        UNIQUEIDENTIFIER NULL,
    [fac_rekId]        UNIQUEIDENTIFIER NULL,
    [facBetaald]       BIT              NULL,
    [facBetaalDatum]   DATETIME         NULL,
    [facToelichting]   NVARCHAR (1024)  NULL,
    [fac_ftyId]        UNIQUEIDENTIFIER NULL,
    [fac_tenId]        UNIQUEIDENTIFIER NOT NULL,
    [fac_bhoId] UNIQUEIDENTIFIER NOT NULL, 
    PRIMARY KEY CLUSTERED ([facId] ASC),
    CONSTRAINT [FK_tblfactuur_FactuurType_id] FOREIGN KEY ([fac_ftyId]) REFERENCES [dbo].[tblFactuurType_fty] ([ftyId]),
    CONSTRAINT [FK_tblfactuur_Kostenplaats_id] FOREIGN KEY ([fac_kplId]) REFERENCES [dbo].[tblKostenplaats_kpl] ([kplId]),
    CONSTRAINT [FK_tblfactuur_Rekening_id] FOREIGN KEY ([fac_rekId]) REFERENCES [dbo].[tblRekening_rek] ([rekId]),
    CONSTRAINT [FK_tblfactuur_Relatie_id] FOREIGN KEY ([fac_relId]) REFERENCES [dbo].[tblRelatie_rel] ([relId]),
    CONSTRAINT [FK_tblfactuur_Tenant_id] FOREIGN KEY ([fac_tenId]) REFERENCES [dbo].[tblTenant_ten] ([tenId]),
	CONSTRAINT [FK_tblfactuur_Boekhouding_id] FOREIGN KEY ([fac_bhoId]) REFERENCES [dbo].[tblBoekhouding_bho] ([bhoId])
);

