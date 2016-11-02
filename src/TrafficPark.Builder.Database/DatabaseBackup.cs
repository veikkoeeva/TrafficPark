using System;
using System.Diagnostics;
using System.IO;


namespace WareSign.Core.ApiIntegrationTests
{
    /// <summary>
    /// A class that creates a database backup with the given parameters and holds on it.
    /// </summary>
    [DebuggerDisplay("TempDatabasePath = {TempDatabasePath,nq}")]
    public class DatabaseBackup: IDisposable
    {
        /// <summary>
        /// If this temporary context has been removed or not.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The default project database to back up.
        /// </summary>
        public const string DefaultDatabaseName = "WareSign.Core.OperationalDatabase";

        /// <summary>
        /// The query template used in creating the database backup.
        /// </summary>
        public const string BackupQueryTemplate = @"BACKUP DATABASE ""{0}"" TO DISK = N'{1}'";

        /// <summary>
        /// The query template used in restoring the database backup.
        /// </summary>
        public const string RestoreQueryTemplate = @"
            USE [Master];
            ALTER DATABASE ""{0}"" SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            RESTORE DATABASE ""{0}"" FROM DISK='{1}' WITH REPLACE;
            ALTER DATABASE ""{0}"" SET MULTI_USER;";

        /// <summary>
        /// The name of the backup database.
        /// </summary>
        public string DatabaseName { get; }


        /// <summary>
        /// The path and name of the backup database.
        /// </summary>
        public string TempDatabasePath { get; }


        /// <summary>
        /// The query used in creating this database backup.
        /// </summary>
        public string BackupQuery { get; }


        /// <summary>
        /// A default constructor with project default values.
        /// </summary>
        /// Uses <see cref="DefaultDatabaseName"/> as the database name.
        public DatabaseBackup(): this(DefaultDatabaseName) { }


        /// <summary>
        /// A constructor.
        /// </summary>
        /// <param name="databaseName">The name of the database to back up.</param>
        public DatabaseBackup(string databaseName)
        {
            DatabaseName = databaseName;
            TempDatabasePath = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            BackupQuery = string.Format(BackupQueryTemplate, DatabaseName, TempDatabasePath);
        }


        /// <summary>
        /// Is a backup file already produced.
        /// </summary>
        public bool IsBackup
        {
            get
            {
                //Call to Path.GetTempFileName() in the constructor creates a zero length zero initialized file already. So, File.Exists check does not suffice.
                try { return new FileInfo(TempDatabasePath).Length > 0; }
                catch { return false; }
            }
        }


        /// <summary>
        /// A standard dispose function.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// Saves the database at <see cref="TempDatabasePath"/> using <see cref="BackupQuery"/>.
        /// </summary>
        /// <remarks>All exceptions are leaked through.</remarks>
        /// <r
        public void CreateBackup()
        {
            /*using(var context = new IssuingEntities(ConnectionStringUtility.ConnectionString))
            {
                context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, BackupQuery);
            }*/
        }


        /// <summary>
        /// Restores the database stored at <see cref="TempDatabasePath"/> using <see cref="RestoreQuery"/>.
        /// </summary>
        /// <param name="destinationDatabase">The destination database to which to restore the database. Defaults to <see cref="DefaultDatabaseName"/></param>.
        /// <remarks>All exceptions are leaked through.</remarks>
        public void RestoreBackup(string destinationDatabase = DefaultDatabaseName)
        {
            /*using(var context = new IssuingEntities(ConnectionStringUtility.ConnectionString))
            {
                context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, RestoreQuery);
            }*/
        }


        /// <summary>
        /// A standard dispose function.
        /// </summary>
        /// <param name="disposing"><em>TRUE</em> if this object is being disposed already. <em>FALSE</em> otherwise.</param>
        private void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    try
                    {
                        File.Delete(TempDatabasePath);
                    }
                    catch { }
                }

                disposed = true;
            }
        }
    }
}
