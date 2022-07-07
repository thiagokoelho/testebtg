SELECT ReportsTo, Count(ReportsTo) AS ReportingMembers, AVG(Age) AvgAge
FROM tblHierarquia
GROUP BY ReportsTo
HAVING ReportsTo IS NOT null
ORDER BY ReportsTo