USE [master]
GO
IF (db_id('StarWars') is null)
BEGIN
    CREATE DATABASE StarWars
END
GO
