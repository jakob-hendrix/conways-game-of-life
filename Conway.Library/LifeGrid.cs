using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.Library
{
    public class LifeGrid
    {
        public CellState[,] CurrentState;
        private CellState[,] _nextState;

        public LifeGrid()
        {
            CurrentState = new CellState[5, 5];
            _nextState = new CellState[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
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
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var liveNeighbors = GetLiveNeighbors(i, j);
                    _nextState[i, j] = LifeRules.GetNewState(CurrentState[i, j], liveNeighbors);
                }
            }
            CurrentState = _nextState;
            _nextState = new CellState[5, 5];
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
                    if (neighborX >= 0 && neighborX < 5 && 
                        neighborY >= 0 && neighborY < 5)
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
