using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrafficPark.DatabaseUnitTests
{
    [TestClass()]
    public class DeploymentSetupTests: SqlDatabaseTestClass
    {

        public DeploymentSetupTests()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        [TestMethod()]
        public void Setup()
        {
            SqlDatabaseTestActions testActions = this.SetupData;
            // Execute the pre-test script
            //
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            // Execute the test script
            //
            System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
            SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            // Execute the post-test script
            //
            System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
            SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
        }

        #region Designer support code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction Setup_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeploymentSetupTests));
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition ReadCommittedSnapshotIsOn;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition SnapshotIsolationStateIsOn;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition MemoryOptimizedElevatedSnapshotIsOn;
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition CollationIsLatin1GeneralBin2;
            this.SetupData = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            Setup_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
            ReadCommittedSnapshotIsOn = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            SnapshotIsolationStateIsOn = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            MemoryOptimizedElevatedSnapshotIsOn = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            CollationIsLatin1GeneralBin2 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ScalarValueCondition();
            // 
            // Setup_TestAction
            // 
            Setup_TestAction.Conditions.Add(ReadCommittedSnapshotIsOn);
            Setup_TestAction.Conditions.Add(SnapshotIsolationStateIsOn);
            Setup_TestAction.Conditions.Add(MemoryOptimizedElevatedSnapshotIsOn);
            Setup_TestAction.Conditions.Add(CollationIsLatin1GeneralBin2);
            resources.ApplyResources(Setup_TestAction, "Setup_TestAction");
            // 
            // ReadCommittedSnapshotIsOn
            // 
            ReadCommittedSnapshotIsOn.ColumnNumber = 1;
            ReadCommittedSnapshotIsOn.Enabled = true;
            ReadCommittedSnapshotIsOn.ExpectedValue = "1";
            ReadCommittedSnapshotIsOn.Name = "ReadCommittedSnapshotIsOn";
            ReadCommittedSnapshotIsOn.NullExpected = false;
            ReadCommittedSnapshotIsOn.ResultSet = 1;
            ReadCommittedSnapshotIsOn.RowNumber = 1;
            // 
            // SnapshotIsolationStateIsOn
            // 
            SnapshotIsolationStateIsOn.ColumnNumber = 1;
            SnapshotIsolationStateIsOn.Enabled = true;
            SnapshotIsolationStateIsOn.ExpectedValue = "1";
            SnapshotIsolationStateIsOn.Name = "SnapshotIsolationStateIsOn";
            SnapshotIsolationStateIsOn.NullExpected = false;
            SnapshotIsolationStateIsOn.ResultSet = 2;
            SnapshotIsolationStateIsOn.RowNumber = 1;
            // 
            // MemoryOptimizedElevatedSnapshotIsOn
            // 
            MemoryOptimizedElevatedSnapshotIsOn.ColumnNumber = 1;
            MemoryOptimizedElevatedSnapshotIsOn.Enabled = true;
            MemoryOptimizedElevatedSnapshotIsOn.ExpectedValue = "1";
            MemoryOptimizedElevatedSnapshotIsOn.Name = "MemoryOptimizedElevatedSnapshotIsOn";
            MemoryOptimizedElevatedSnapshotIsOn.NullExpected = false;
            MemoryOptimizedElevatedSnapshotIsOn.ResultSet = 3;
            MemoryOptimizedElevatedSnapshotIsOn.RowNumber = 1;
            // 
            // CollationIsLatin1GeneralBin2
            // 
            CollationIsLatin1GeneralBin2.ColumnNumber = 1;
            CollationIsLatin1GeneralBin2.Enabled = true;
            CollationIsLatin1GeneralBin2.ExpectedValue = "1";
            CollationIsLatin1GeneralBin2.Name = "CollationIsLatin1GeneralBin2";
            CollationIsLatin1GeneralBin2.NullExpected = false;
            CollationIsLatin1GeneralBin2.ResultSet = 4;
            CollationIsLatin1GeneralBin2.RowNumber = 1;
            // 
            // SetupData
            // 
            this.SetupData.PosttestAction = null;
            this.SetupData.PretestAction = null;
            this.SetupData.TestAction = Setup_TestAction;
        }

        #endregion


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        #endregion

        private SqlDatabaseTestActions SetupData;
    }
}
