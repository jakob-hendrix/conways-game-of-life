using Conway.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new LifeGrid(5, 5);

            // Seed our organism
            grid.CurrentState[1, 2] = CellState.Alive;
            grid.CurrentState[2, 2] = CellState.Alive;
            grid.CurrentState[3, 2] = CellState.Alive;

            ShowGrid(grid.CurrentState);

            while(Console.ReadLine().ToLower() != "q")
            {
                grid.UpdateState();
                ShowGrid(grid.CurrentState);
            }
        }

        private static void ShowGrid(CellState[,] currentState)
        {
            Console.Clear();
            int x = 0;
            int rowLength = currentState.GetUpperBound(0) + 1;

            // Draw our grid, row by row
            foreach (var state in currentState)
            {
                var output = state == CellState.Alive ? "O" : ".";
                Console.Write(output);
                x++;
                if (x >= rowLength)
                {
                    x = 0;
                    Console.WriteLine();
                }
            }
        }
    }
}
