using NUnit.Framework;

namespace Conway.Library.Test
{
    // any live cell with fewer tan two live neighbors dies
    // any live cell with two or three live neighbors lives.
    // any live cell with more than three neighbors dies.
    // any dead cell with three neighbors becomes a live cell


    [TestFixture]
    public class LifeRulesTests
    {
        [Test]
        public void LiveCell_FewerThan2LiveNeighbors_Dies(
            [Values(0,1)] int liveNeighbors)
        {
            // Arrange
            var currentState = CellState.Alive;

            // Act
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);

            // Assert
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void LiveCell_2Or3LiveNeighbors_Lives(
            [Values(2, 3)] int liveNeighbors)
        {
            var currentState = CellState.Alive;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Alive, newState);
        }


        [Test]
        public void LiveCell_MoreThan3LiveNeighbors_Dies(
            [Range(4,10)] int liveNeighbors)
        {
            var currentState = CellState.Alive;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Dead, newState);
        }


        [Test]
        public void DeadCell_FewerThan2LiveNeighbors_StaysDead(
            [Values(0, 1)] int liveNeighbors)
        {
            var currentState = CellState.Dead;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Dead, newState);
        }

        [Test]
        public void DeadCell_3LiveNeighbors_Lives()
        {
            var currentState = CellState.Dead;
            var liveNeighbors = 3;

            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);

            Assert.AreEqual(CellState.Alive, newState);
        }

        [Test]
        public void DeadCell_MoreThan3LiveNeighbors_StaysDead(
            [Range(4, 10)] int liveNeighbors)
        {
            var currentState = CellState.Dead;
            CellState newState = LifeRules.GetNewState(currentState, liveNeighbors);
            Assert.AreEqual(CellState.Dead, newState);
        }
    }
}
