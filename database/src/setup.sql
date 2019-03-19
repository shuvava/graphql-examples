USE [master]
GO
IF (db_id('StarWars') is null)
BEGIN
    CREATE DATABASE StarWars
END
GO
USE [master]
GO
IF (db_id('GraphQLDemo') is null)
BEGIN
    CREATE DATABASE GraphQLDemo
END
GO
USE [GraphQLDemo]
GO
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Employee' and xtype='U')
BEGIN
	SET ANSI_NULLS ON    
	SET QUOTED_IDENTIFIER ON  
	CREATE TABLE [dbo].[Employee](  
		[Id] [bigint] IDENTITY(1,1) NOT NULL,  
		[Name] [varchar](100) NULL,  
		[Email] [varchar](50) NULL,  
		[Mobile] [varchar](50) NULL,  
		[Company] [varchar](100) NULL,  
		[Address] [varchar](100) NULL,  
		[ShortDescription] [varchar](1000) NULL,  
		[LongDescription] [text] NULL,  
	 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED   
	(  
		[Id] ASC  
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]    
	SET IDENTITY_INSERT [dbo].[Employee] ON   
	INSERT [dbo].[Employee] ([Id], [Name], [Email], [Mobile], [Company], [Address], [ShortDescription], [LongDescription]) VALUES (1, N'Akshay', N'akshayblevel@gmail.com', N'9999999999', N'Dotnetbees', N'Hyderabad', N'Short Description', N'Long Description')    
	INSERT [dbo].[Employee] ([Id], [Name], [Email], [Mobile], [Company], [Address], [ShortDescription], [LongDescription]) VALUES (2, N'Panth', N'panth@gmail.com', N'8888888888', N'Radix', N'Vadodara', N'SD', N'LD')    
	SET IDENTITY_INSERT [dbo].[Employee] OFF  
END
GO