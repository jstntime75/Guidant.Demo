SET IDENTITY_INSERT dbo.[Role] ON
INSERT INTO dbo.[Role]
        ( Id, Name )
	SELECT 1, 'User'
	UNION
	SELECT 2, 'Admin'
SET IDENTITY_INSERT dbo.[Role] OFF

INSERT INTO dbo.[SecurityType]
        ( Id, Code, [Description] )
	SELECT 1, 'Fund', 'the Funds security type'
	UNION
	SELECT 2, 'Stock', 'the Stocks security type'
	UNION
	SELECT 3, 'Bond', 'the Bonds security type'
