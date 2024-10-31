SELECT * FROM
(SELECT 
	LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest') AS CoreQuery
GROUP BY FirstLetter
ORDER BY FirstLetter