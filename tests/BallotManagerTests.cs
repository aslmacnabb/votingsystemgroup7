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
        public void GetAllElectionNames_ReturnsList()
        {
            List<string> elections = bm.GetAllElectionNames();
            Assert.IsNotNull(elections);
        }

        [TestMethod]
        public void GetAllElectionNames_ContainsMayoralElection()
        {
            List<string> elections = bm.GetAllElectionNames();
            CollectionAssert.Contains(elections, "2026 Mayoral Election");
        }
    }
}