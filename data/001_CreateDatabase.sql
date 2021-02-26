USE [master]
GO

/****** Object:  Database [MyAPI]    Script Date: 26/02/2021 17:55:38 ******/
CREATE DATABASE [MyAPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyAPI', FILENAME = N'/var/opt/mssql/data/MyAPI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyAPI_log', FILENAME = N'/var/opt/mssql/data/MyAPI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
