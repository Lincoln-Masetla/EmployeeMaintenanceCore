CREATE TABLE [dbo].[Person]
(
    [PersonId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [LastName] NVARCHAR(128) NOT NULL, 
    [FirstName] NVARCHAR(128) NOT NULL, 
    [BirthDate] DATE NOT NULL
)
