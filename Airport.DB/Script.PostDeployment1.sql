MERGE INTO City AS Target 
USING (VALUES 
        (1, 'New York, NY (LGA)', 'LGA'), 
        (2, 'Fort Lauderdale, FL (FLL)', 'FLL'), 
        (3, 'New York, NY (JFK)', 'JFK'),
		(4, 'Miami, FL', 'MIA'),
		(5, 'Washington, D.C. (IAD)', 'IAD'),
		(6, 'Cincinnati, Kentucky', 'CVG'),
		(7, 'Cleveland, OH (CLE)', 'CLE'),
		(8, 'Newark, NJ (EWR)', 'EWR')
) 
AS Source (Id, [name], acronyms) 
ON Target.Id = Source.Id 
WHEN NOT MATCHED BY TARGET THEN 
INSERT ([name], acronyms) 
VALUES ([name], acronyms);
---------------------------
MERGE INTO Airline AS Target
USING (VALUES 
        (1, 'JetBlue'), 
        (2, 'United'), 
		(3, 'Delta'),
		(4, 'Continental')
)
AS Source (Id, [name])
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT ([name])
VALUES ([name]);
---------------------------
MERGE INTO Schedule AS Target
USING (VALUES 
        (1, 1, 2, '6:00','8:50',NULL,NULL,233,1), 
        (2, 3, 4, '6:00','11:10',5,'1:00',289,2), 
		(3, 1, 4, '6:05','11:30',6,'0:30',220,3), 
		(4, 1, 4, '6:10','11:40',6,'1:00',218,3), 
		(5, 1, 4, '6:10','11:10',5,'1:00',289,2), 
		(6, 1, 2, '6:20','12:00',7,'1:00',762,4), 
		(7, 8, 4, '6:30','9:30',NULL,NULL,239,4)
)
AS SOURCE ([Id],
    [FromCityID], [ToCityID],
    [Depart], [Arrives],
    [LayoverCityID], [LayoverTime],
    [Price], [AirlineID]
)
ON Target.ID = Source.ID
WHEN NOT MATCHED BY TARGET THEN
INSERT ([FromCityID],[ToCityID],[Depart],[Arrives],[LayoverCityID],[LayoverTime],[Price],[AirlineID])
VALUES ([FromCityID],[ToCityID],[Depart],[Arrives],[LayoverCityID],[LayoverTime],[Price],[AirlineID]);
