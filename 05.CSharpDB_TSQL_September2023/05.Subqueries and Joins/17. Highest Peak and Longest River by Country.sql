SELECT TOP (5) * FROM
(SELECT
	CountryName
	,MAX(p.Elevation) AS HighestPeakElevation
	,MAX(r.[Length]) AS LongestRiverLength
FROM Countries c
	JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
    LEFT JOIN Peaks p ON p.MountainId = mc.MountainId
	JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
    LEFT JOIN Rivers r ON r.Id = cr.RiverId
GROUP BY CountryName) AS CoreQuery
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName