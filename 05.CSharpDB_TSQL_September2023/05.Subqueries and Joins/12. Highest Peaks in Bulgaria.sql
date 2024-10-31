SELECT 
	co.CountryCode
	,m.MountainRange
	,p.PeakName
	,p.Elevation
FROM Countries co
	JOIN MountainsCountries mc ON co.CountryCode = mc.CountryCode
	JOIN Mountains m ON m.Id = mc.MountainId
	JOIN Peaks p ON p.MountainId = m.Id
WHERE co.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC