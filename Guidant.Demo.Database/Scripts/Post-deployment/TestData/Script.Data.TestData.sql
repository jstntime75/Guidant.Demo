SET IDENTITY_INSERT dbo.[Security] ON
INSERT INTO [dbo].[Security]
           ([Id]
		   ,[SecurityTypeId]
           ,[Symbol]
           ,[Price])
     VALUES
           (1, 1, 'F1', 20.51),
           (2, 1, 'F2', 30.52),
           (3, 1, 'F3', 40.53),
           (4, 2, 'S1', 10.22),
           (5, 2, 'S2', 11.33),
           (6, 2, 'S3', 12.44),
           (7, 3, 'B1', 1.23),
           (8, 3, 'B2', 4.56),
           (9, 3, 'B3', 7.89)
SET IDENTITY_INSERT dbo.[Security] OFF

SET IDENTITY_INSERT dbo.[Client] ON
INSERT INTO [dbo].[Client]
           ([Id], [Name])
     VALUES
           (1, 'Client 1'),
           (2, 'Client 2')
SET IDENTITY_INSERT dbo.[Client] OFF

SET IDENTITY_INSERT dbo.[Portfolio] ON
INSERT INTO [dbo].[Portfolio]
           ([Id]
		   ,[Name]
           ,[ClientId])
     VALUES
           (1 ,'Portfolio 1' ,1),
           (2 ,'Portfolio 2' ,2),
           (3 ,'Portfolio 3' ,1),
           (4 ,'Portfolio 4' ,2),
           (5 ,'Portfolio 5' ,1)
SET IDENTITY_INSERT dbo.[Portfolio] OFF

INSERT INTO [dbo].[PortfolioSecurity]
           ([PortfolioId]
           ,[SecurityId]
           ,[Count])
     VALUES
           (1, 1, 10),
           (1, 5, 20),
           (1, 9, 30),
           (2, 2, 100),
           (2, 6, 200),
           (2, 8, 300),
           (3, 2, 12),
           (3, 4, 44),
           (3, 7, 87),
           (4, 3, 5),
           (4, 4, 5),
           (4, 8, 5),
           (5, 2, 1000),
           (5, 6, 500),
           (5, 7, 250)

SET IDENTITY_INSERT dbo.[User] ON
INSERT INTO [dbo].[User]
           ([Id]
		   ,[Email]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEndDateUtc]
           ,[LockoutEnabled]
           ,[AccessFailedCount]
           ,[UserName]
		   ,[ClientId])
     VALUES
			-- all passwords are P@ssw0rd1
           (1, 'user1@test.com', 1, 'AM25A0OTOyonedl2r05dqcXvvaR2VYn3ExpVH8sicvqM4aW/JbgoyWmrP9HkeCnxgQ==', '7db78073-52d8-4569-8217-16b377323243', NULL, 0, 0, NULL, 0, 0, 'user1', 1),
           (2, 'user2@test.com', 1, 'ALPNNTK5xb4w7l4zCRSaHBsgGewiN7uUQR1SU7QPnagKXhFujbGqsAgpidy40NCB7A==', '943aba15-b3d5-433e-8be1-334f9367eb9b', NULL, 0, 0, NULL, 0, 0, 'user2', 2)
SET IDENTITY_INSERT dbo.[User] OFF

INSERT INTO [dbo].[UserRole]
           ([UserId]
           ,[RoleId])
     VALUES
           (1, 1),
           (1, 2),
           (2, 1)

