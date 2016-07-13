CREATE TABLE [dbo].[User]
(
	[MembershipId] VARCHAR(200) NOT NULL PRIMARY KEY, 
    [Username] VARCHAR(50) NULL, 
    [ClanName] VARCHAR(MAX) NULL, 
    [ClanTag] NVARCHAR(50) NULL, 
    [Elo] DECIMAL(18, 2) NULL , 
    [Kills] INT NULL, 
    [Assists] INT NULL, 
    [Deaths] INT NULL, 
    [GamesPlayed] INT NULL, 
    [TimePlayed] INT NULL, 
    [MembershipType] INT NULL, 
    [LastUpdate] DATETIME NULL
)
