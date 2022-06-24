--CREATE DATABASE CfltestDb;
--CREATE LOGIN CflLogin WITH PASSWORD = '123!abc!';
--create user CflUser for login CflLogin
USE [CfltestDb]
GO
ALTER ROLE [db_owner] ADD MEMBER CflUser
GO


