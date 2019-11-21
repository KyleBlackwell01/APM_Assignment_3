CREATE TABLE [dbo].[Attendance]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Firstname] NVARCHAR(50),
	[Lastname] NVARCHAR(50),
	[StudentID] INT FOREIGN KEY REFERENCES Student,
	[Status] NVARCHAR(50),
	[timeSignedIn] DATETIME,
	[dateSignedIn] DATETIME
)
