using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Methods
    {

        public void Settings()
        {

        }

        public static void neighbourCheck()
        {
            // TODO 
            // class GameSettings() return tuple? of settings = gridSize, startRandom, grid)
            // class StartGame(tuple <int gridSize, bool startRandom, bool[,] grid>) 

            //everything to form


            int gridSize = 5;

            int livingCells = 0, l = 0, m = 0, n = 0, i, j;

            //2d array grid play area
            bool[,] grid = new bool[gridSize, gridSize];

            //changesArray stores all changes to cells that happen during round according to rules
            bool[,] changesArray = grid.Clone() as bool[,];

            //end state: all cells false check bool
            bool allFalse;

            //itercounter
            int T = 0;


            //random rand to randomise gamearea
            Random rand = new Random();

            bool cellState;


            //randomise grid and print
            Console.WriteLine("Start grid");
            for (int k = 0; k <= (gridSize - 1); k++)
            {
                for (l = 0; l <= (gridSize - 1); l++)
                {
                    grid[k, l] = rand.Next(2) == 0 ? false : true; //to randomize grid value
                    Console.Write(grid[k, l] + " "); //uncomment to draw starting grid
                }
                Console.WriteLine("\n"); //uncomment to draw starting grid
            }




            while (true)
            {
                for (i = 0; i <= (gridSize - 1); i++)
                {
                    for (j = 0; j <= (gridSize - 1); j++)
                    {
                        cellState = grid[i, j];
                        try
                        {
                            if (grid[(i - 1), (j - 1)] == true) { livingCells++; }
                        }
                        catch (System.IndexOutOfRangeException) { }
                        try
                        {
                            if (grid[(i - 1), (j)] == true) { livingCells++; }
                        }
                        catch (System.IndexOutOfRangeException) { }
                        try
                        {
                            if (grid[(i - 1), (j + 1)] == true) { livingCells++; }
                        }
                        catch (System.IndexOutOfRangeException) { }
                        try
                        {
                            if (grid[(i), (j - 1)] == true) { livingCells++; }
                        }
                        catch (System.IndexOutOfRangeException) { }
                        try
                        {
                            if (grid[(i), (j + 1)] == true) { livingCells++; }
                        }
                        catch (System.IndexOutOfRangeException) { }
                        try
                        {
                            if (grid[(i + 1), (j - 1)] == true) { livingCells++; }
                        }
                        catch (System.IndexOutOfRangeException) { }
                        try
                        {
                            if (grid[(i + 1), (j)] == true) { livingCells++; }
                        }
                        catch (System.IndexOutOfRangeException) { }
                        try
                        {
                            if (grid[(i + 1), (j + 1)] == true) { livingCells++; }
                        }
                        catch (System.IndexOutOfRangeException) { }

                        cellState = grid[i, j];

                        //match live cell number to rules and store change to changesArray


                        if (grid[i, j] == true && livingCells >= 4) //Any live cell with more than three live neighbours dies, as if by overpopulation.
                        {
                            changesArray[i, j] = !grid[i, j];
                        }
                        else if (grid[i, j] == false && livingCells == 3) //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
                        {
                            changesArray[i, j] = !grid[i, j];
                        }
                        else if (grid[i, j] == true && livingCells >= 2 && livingCells <= 3) //Any live cell with two or three live neighbours lives on to the next generation.
                        {
                            changesArray[i, j] = grid[i, j];
                        }
                        else if (grid[i, j] == true && livingCells <= 1)     //Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
                        {
                            changesArray[i, j] = !grid[i, j];
                        }
                        else
                        {
                            changesArray[i, j] = grid[i, j];
                        }
                        livingCells = 0;

                    }
                    j = 0;
                }
                //DEBUG print changesArray
                /*
                Console.WriteLine("changesarray");
                for (int k = 0; k <= (gridSize - 1); k++)
                {
                    int l = 0;
                    for (l = 0; l <= (gridSize - 1); l++)
                    {
                        Console.Write(changesArray[k, l] + " ");
                    }
                    Console.WriteLine("\n");
                }
                */

                //read round changes from changesArray[,] to grid[,] AND check if all cells are dead
                allFalse = true;
                for (m = 0; m <= (gridSize - 1); m++)
                {
                    for (n = 0; n <= (gridSize - 1); n++)
                    {

                        if (changesArray[m, n] == true)
                        {
                            allFalse = false;            //TODO is this right
                        }
                        grid[m, n] = changesArray[m, n];
                    }
                }





                //print grid
                T++;
                Console.WriteLine("Iteration: " + T);
                Console.WriteLine("grid");
                for (int k = 0; k <= (gridSize - 1); k++)
                {
                    for (l = 0; l <= (gridSize - 1); l++)
                    {
                        //Console.Write(grid[k, l] + " ");
                        if (grid[k, l] == true)
                        {
                            Console.Write("X" + " ");
                        }
                        else
                        {
                            Console.Write("_" + " ");
                        }

                    }
                    Console.WriteLine("\n");
                }




                //wait
                System.Threading.Thread.Sleep(100);
                //Console.ReadLine();
                //TODO add if changesArray == grid {end round} //stalemate 
                //* END 
                //* rule if all cells false/dead 
                if (allFalse == true || changesArray == grid)
                {
                    Console.WriteLine("game area is dead! ");
                    Console.Read();//break;
                }

            }






        }

    }
}

