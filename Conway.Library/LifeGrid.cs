using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Library
{
    public class LifeGrid
    {

        int gridHeight;
        int gridWidth;

        public CellState[,] CurrentState;
        private CellState[,] _nextState;

        public LifeGrid(int height, int width)
        {
            gridHeight = height;
            gridWidth = width;

            CurrentState = new CellState[gridHeight, gridWidth];
            _nextState = new CellState[gridHeight, gridWidth];

            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    CurrentState[i, j] = CellState.Dead;
                }
            }
        }

        /// <summary>
        /// Generate the future state of the cell based 
        /// on the current state as determined by the Life rules.
        /// </summary>
        public void UpdateState()
        {
            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    var liveNeighbors = GetLiveNeighbors(i, j);
                    _nextState[i, j] = LifeRules.GetNewState(CurrentState[i, j], liveNeighbors);
                }
            }
            CurrentState = _nextState;
            _nextState = new CellState[gridHeight, gridWidth];
        }

        /// <summary>
        /// Check how many neighboring cells 
        /// </summary>
        /// <param name="coordX"></param>
        /// <param name="coordY"></param>
        /// <returns></returns>
        private int GetLiveNeighbors(int coordX, int coordY)
        {
            int liveNeighbors = 0;

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    // Skip our current cell's position
                    if (x == 0 && y == 0)
                        continue;

                    int neighborX = coordX + x;
                    int neighborY = coordY + y;

                    // Make sure our "neighbor" cell is inside our grid
                    if (neighborX >= 0 && neighborX < gridHeight && 
                        neighborY >= 0 && neighborY < gridWidth)
                    {
                        if (CurrentState[neighborX, neighborY] == CellState.Alive)
                            liveNeighbors++;
                    }

                }
            }
            return liveNeighbors;
        }
    }
}
