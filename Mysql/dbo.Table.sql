CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Date of birth] DATE NULL, 
    [Address] NVARCHAR(50) NULL, 
    [Years of Experience] INT NULL, 
    [Phone] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Date of joining] DATE NULL
)
