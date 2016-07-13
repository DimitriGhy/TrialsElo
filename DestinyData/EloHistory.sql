CREATE TABLE [dbo].[EloHistory]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MembershipId] NCHAR(10) NOT NULL, 
    [Date] VARCHAR(20) NULL, 
    [Elo] INT NULL, 
    [Mode] INT NULL 
)
