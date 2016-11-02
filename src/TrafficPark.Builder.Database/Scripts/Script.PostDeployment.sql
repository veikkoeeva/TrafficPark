/*
Post-Deployment Script Template
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.
 Use SQLCMD syntax to include a file in the post-deployment script.
 Example:      :r .\myfile.sql
 Use SQLCMD syntax to reference a variable in the post-deployment script.
 Example:      :setvar TableName MyTable
               SELECT * FROM [$(TableName)]
--------------------------------------------------------------------------------------
*/

SET XACT_ABORT, NOCOUNT ON;

SET XACT_ABORT, NOCOUNT ON;

:setvar __IsSqlCmdEnabled "True"

IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
BEGIN
	PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
	SET NOEXEC ON;
END

PRINT N'*** Loading TrafficPark.Constants constant data...***';
:r .\TrafficPark.Constants.sql
PRINT N'*** Done loading TrafficPark.Constants constant data.***';

IF N'$(BuildConfiguration)' = N'Debug' OR N'$(BuildConfiguration)' = N'Release'
BEGIN
	-- An assumption is made here that 'Debug' and 'Release' profiles are used only for testing in
	-- cases where recovery features or realistic features are not needed. This is done early
	-- in order to make other operations quicker.
	PRINT N'*** Setting recovery mode to ''SIMPLE''...***';
    ALTER DATABASE [$(DatabaseName)] SET RECOVERY SIMPLE;
	PRINT N'*** Setting recovery model to ''SIMPLE'' done. ***';

	PRINT N'*** Loading test data...***';
	:r .\TrafficPark.TestData.sql
	PRINT N'*** Done loading test data.***';
END

-- PRINT N'*** Disabling constraint checking while loading data... ***';
-- EXEC sp_MSforeachtable @command1="ALTER TABLE ? NOCHECK CONSTRAINT ALL";
-- PRINT N'*** Disabling constraint checking while loading data done. ***';

PRINT N'*** Loading constants... ***';
:r .\TrafficPark.Constants.sql
PRINT N'*** Done loading constants. ***';