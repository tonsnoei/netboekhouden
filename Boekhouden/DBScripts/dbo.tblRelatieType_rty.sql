CREATE TABLE [dbo].[tblRelatieType_rty] (
    [rtyId]            BIGINT         NOT NULL,
    [rtyNaam]          NVARCHAR (128) NOT NULL,
    [rtyIsCrediteur]   BIT            NOT NULL, 
    [rtyIsLeverancier] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([rtyId] ASC)
);

