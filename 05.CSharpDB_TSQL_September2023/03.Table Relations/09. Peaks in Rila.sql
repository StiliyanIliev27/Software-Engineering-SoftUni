SELECT
m.MountainRange, p.PeakName, p.Elevation
FROM Mountains m, Peaks p
WHERE p.MountainId = 17 AND m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC