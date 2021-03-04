USE [MyAPI]
GO

INSERT INTO [dbo].[MyAPI_Messages]
           ([MyAPI_Messages_UserID]
           ,[MyAPI_Messages_Date]
           ,[MyAPI_Messages_Subject]
           ,[MyAPI_Messages_Body])
     VALUES
           (1,'01-01-2021','Test','Testing that this works')
GO


