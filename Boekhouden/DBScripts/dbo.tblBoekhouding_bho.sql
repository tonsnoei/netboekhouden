CREATE TABLE [dbo].[tblBoekhouding_bho] (
    [bhoId]       UNIQUEIDENTIFIER NOT NULL,
    [bhoName]     NVARCHAR (128)   NULL,
    [bhoTenantId] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([bhoId] ASC),
    CONSTRAINT [FK_tblBoekhouding_bho_Tenant_id] FOREIGN KEY ([bhoTenantId]) REFERENCES [dbo].[tblTenant_ten] ([tenId]) ON DELETE CASCADE
);
 
