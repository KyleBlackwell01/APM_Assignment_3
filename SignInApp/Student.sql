﻿CREATE TABLE [dbo].[Student]
(
	[Barcode] INT NOT NULL PRIMARY KEY,
	[StudentID] INT NOT NULL,
	[Name] NVARCHAR(MAX) NOT NULL,
	[Time] DATETIME NOT NULL
)
