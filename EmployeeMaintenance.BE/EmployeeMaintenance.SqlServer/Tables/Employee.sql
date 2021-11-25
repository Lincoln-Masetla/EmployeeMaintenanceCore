CREATE TABLE [dbo].[Employee]
(
    [EmployeeId] INT NOT NULL PRIMARY KEY IDENTITY(1, 1), 
    [PersonId] INT NOT NULL, 
    [EmployeeNum] NVARCHAR(16) NOT NULL, 
    [EmployeeDate] DATE NOT NULL, 
    [TerminatedDate] DATE NULL,
    CONSTRAINT [FK_Person_Employee] FOREIGN KEY ([PersonId]) REFERENCES [Person]([PersonId]), 
)
