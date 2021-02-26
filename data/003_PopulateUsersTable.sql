/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [MyAPI_Users_ID]
      ,[MyAPI_Users_Username]
      ,[MyAPI_Users_Password]
  FROM [MyAPI].[dbo].[MyAPI_Users]