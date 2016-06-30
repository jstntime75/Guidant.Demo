CREATE VIEW [dbo].[vwSecurity]
AS
SELECT        s.Id, st.Code, s.Symbol, s.Price
FROM            dbo.Security AS s INNER JOIN
                         dbo.SecurityType AS st ON st.Id = s.SecurityTypeId