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
            var grid = new LifeGrid(25, 65);
            grid.Randomize();

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
            int rowLength = currentState.GetUpperBound(1) + 1;

            var output = new StringBuilder();

            // Draw our grid, row by row
            foreach (var state in currentState)
            {
                output.Append(state == CellState.Alive ? "O" : ".");
                x++;
                if (x >= rowLength)
                {
                    x = 0;
                    output.AppendLine();
                }
            }
            Console.WriteLine(output.ToString());
        }
    }
}
