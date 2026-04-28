using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace AccessorTests
{
    [TestClass]
    public sealed class BallotAccessorTests
    {
        [TestMethod]
        public void BallotAccessor_HasBallotStartAndEndDateMethods()
        {
            var type = typeof(server.Accessors.BallotAccessor);

            Assert.IsNotNull(type.GetMethod("GetBallotStartDate"), "BallotAccessor should expose GetBallotStartDate.");
            Assert.IsNotNull(type.GetMethod("SetBallotStartDate"), "BallotAccessor should expose SetBallotStartDate.");
            Assert.IsNotNull(type.GetMethod("GetBallotEndDate"), "BallotAccessor should expose GetBallotEndDate.");
            Assert.IsNotNull(type.GetMethod("SetBallotEndDate"), "BallotAccessor should expose SetBallotEndDate.");
        }

        [TestMethod]
        public void VoteAccessor_HasInsertMeasureVoteMethod()
        {
            var type = typeof(server.Accessors.VoteAccessor);
            Assert.IsNotNull(type.GetMethod("InsertMeasureVote"), "VoteAccessor should expose InsertMeasureVote.");
        }

        [TestMethod]
        public void MeasureAccessor_HasBallotMeasureMethods()
        {
            var type = typeof(server.Accessors.MeasureAccessor);
            Assert.IsNotNull(type.GetMethod("GetMeasuresForBallot"), "MeasureAccessor should expose GetMeasuresForBallot.");
            Assert.IsNotNull(type.GetMethod("InsertMeasureForBallot"), "MeasureAccessor should expose InsertMeasureForBallot.");
        }
    }
}
