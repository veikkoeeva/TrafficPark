MERGE [TrafficPark].[Constant] AS TARGET
USING
(
	VALUES
	(1, 'Test')
) AS SOURCE
(
	[Id],
	[Value]
)
ON TARGET.[Id] = SOURCE.[Id]
-- Update matched rows.
WHEN MATCHED THEN UPDATE SET
	TARGET.[Value] = SOURCE.[Value]
-- Insert these as new rows.
WHEN NOT MATCHED BY TARGET THEN INSERT
(
	[Id],
	[Value]
) VALUES
(
	SOURCE.[Id],
	SOURCE.[Value]
)
-- Delete unmatched rows.
WHEN NOT MATCHED BY SOURCE THEN DELETE;

GO