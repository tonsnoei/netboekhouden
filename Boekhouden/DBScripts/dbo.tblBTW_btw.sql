CREATE TABLE [dbo].[tblBTW_btw] (
    [btwId]         INT             NOT NULL,
    [btwNaam]       NVARCHAR (255)  NOT NULL,
    [btwPercentage] DECIMAL (18, 2) NULL,
    [btwOrder]      INT             NOT NULL, 
    PRIMARY KEY CLUSTERED ([btwId] ASC)
);

