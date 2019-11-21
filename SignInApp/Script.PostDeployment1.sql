/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


INSERT INTO Class (ClassID, Day, startTime, endTime, Name) Values
(56, 'Monday', '2019-11-25T08:30:00', '2019-11-25T13:30:00', 'Interface Programming'),
(57, 'Tuesday', '2019-11-25T08:30:00', '2019-11-25T13:30:00', 'OO Programming');

INSERT INTO Student (Barcode, StudentID, Name, Time) VALUES
(0101010101, 101010101, 'John', '2019-11-25T08:12:40'),
(0202020202, 202020202, 'Jack', '2019-11-25T08:12:40');

INSERT INTO Attendance (Id, Firstname, Lastname, StudentID, Status, timeSignedIn, dateSignedIn) VALUES
(2, 'John', 'Avilo', 101010101, 'Signed In', '2019-11-25T08:12:40', '2019-11-25'),
(3, 'Jack', 'Fagilo', 202020202, 'Signed In', '2019-11-25T08:10:20', '2019-11-25');