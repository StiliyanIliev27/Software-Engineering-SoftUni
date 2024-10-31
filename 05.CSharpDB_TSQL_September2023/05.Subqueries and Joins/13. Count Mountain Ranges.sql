SELECT
	co.CountryCode
	,COUNT(m.MountainRange) AS MountainRanges
FROM Countries co
	JOIN MountainsCountries mc ON mc.CountryCode = co.CountryCode
	JOIN Mountains m ON m.Id = mc.MountainId
WHERE co.CountryCode IN('BG', 'RU', 'US')
GROUP BY co.CountryCode