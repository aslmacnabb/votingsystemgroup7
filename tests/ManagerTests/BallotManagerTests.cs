using Microsoft.VisualStudio.TestTools.UnitTesting;
using server.Managers;

namespace server.Tests
{
    [TestClass]
    public class BallotManagerTests
    {
        private BallotManager bm;

        [TestInitialize]
        public void Setup()
        {
            bm = new BallotManager();
        }

        [TestMethod]
        public void GetMeasuresFromElection_ReturnsList()
        {
            List<string> measures = bm.GetMeasuresFromElection("2026 Mayoral Election");
            Assert.IsNotNull(measures);
        }

        [TestMethod]
        public void GetMeasuresFromElection_ReturnsTwoMeasures()
        {
            List<string> measures = bm.GetMeasuresFromElection("2026 Mayoral Election");
            Assert.AreEqual(2, measures.Count);
        }

        [TestMethod]
        public void GetMeasuresFromElection_ContainsMeasureA()
        {
            List<string> measures = bm.GetMeasuresFromElection("2026 Mayoral Election");
            CollectionAssert.Contains(measures, "Measure A: Increase Sales Tax");
        }

        [TestMethod]
        public void GetMeasuresFromElection_ContainsMeasureB()
        {
            List<string> measures = bm.GetMeasuresFromElection("2026 Mayoral Election");
            CollectionAssert.Contains(measures, "Measure B: Park Expansion");
        }

        [TestMethod]
        public void GetMeasuresFromElection_InvalidElection_ReturnsEmptyList()
        {
            List<string> measures = bm.GetMeasuresFromElection("Nonexistent Election");
            Assert.AreEqual(0, measures.Count);
        }

        /* Tests for GetAllElectionNames                       */
        /*
        Verifies that GetAllElectionNames does not return null.
        Even if the database is empty it should return an empty list.
        */
        [TestMethod]
        public void GetAllElectionNames_ReturnsList()
        {
            List<string> elections = bm.GetAllElectionNames();
            Assert.IsNotNull(elections);
        }

        /*
        Verifies that the list contains at least one election,
        */
        [TestMethod]
        public void GetAllElectionNames_ReturnsAtLeastOneElection()
        {
            List<string> elections = bm.GetAllElectionNames();
            Assert.IsTrue(elections.Count > 0);
        }

        /*
        Verifies that the known seeded election "2026 Mayoral Election"
        is present in the returned list.
        */
        [TestMethod]
        public void GetAllElectionNames_ContainsMayoralElection()
        {
            List<string> elections = bm.GetAllElectionNames();
            CollectionAssert.Contains(elections, "2026 Mayoral Election");
        }

        /*
        Verifies that no entry in the returned list is null or empty,
        every election name should be a valid non-blank string.
        */
        [TestMethod]
        public void GetAllElectionNames_NoNullOrEmptyEntries()
        {
            List<string> elections = bm.GetAllElectionNames();
            foreach (string name in elections)
            {
                Assert.IsFalse(string.IsNullOrEmpty(name));
            }
        }
    }
}