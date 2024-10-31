SELECT 
	ContinentCode
	,CurrencyCode
	,CurrencyUsage
FROM 
(SELECT *,
DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) AS CountriesUsage
FROM
	(SELECT ContinentCode ,CurrencyCode ,COUNT(CurrencyCode) AS CurrencyUsage
	FROM Countries
	GROUP BY ContinentCode, CurrencyCode) AS CoreQuery
WHERE CurrencyUsage > 1) AS SecondCoreQuery
WHERE CountriesUsage = 1