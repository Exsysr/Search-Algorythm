using System.Text;

namespace Search
{
    class Program
{
    static char[,] Map = new char[25, 25];
    static int StartX = 0;
    static int StartY = 0;
    static int EndX = 24;
    static int EndY = 24;
    static int CurrentX = StartX;
    static int CurrentY = StartY;
    static bool WallRight = false;
    static bool WallLeft = false;
    static bool WallUp = false;
    static bool WallDown = false;
    static int MoveCount = 0;


    static void Main(string[] args)
    {
        CreateMap();
        FindPath();
        Console.WriteLine("Path Found in " + MoveCount + " moves");
        Console.ReadLine();
    }

    static int AddSnake()
    {
        Map[StartX, StartY] = 'S';
        Map[EndX, EndY] = 'E';
        return 0;
    }

    static void AddWallsX()
    {
        Map[3, 5] = '#';
        Map[4, 5] = '#';
        Map[5, 5] = '#';
        Map[6, 5] = '#';
        Map[7, 5] = '#';
        Map[8, 5] = '#';
        Map[9, 5] = '#';

        Map[14, 8] = '#';
        Map[14, 9] = '#';
        Map[14, 10] = '#';

        Map[24, 23] = '#';
    }

    static void AddWallsY()
    {
        Map[18, 18] = '#';



        Map[0, 1] = '#';
        Map[4, 10] = '#';
        Map[4, 11] = '#';
        Map[4, 12] = '#';
        Map[4, 13] = '#';

    }

    static void CreateMap()
    {
        for (int i = 0; i < Map.GetLength(0); i++)
        {
            for (int j = 0; j < Map.GetLength(1); j++)
            {
                Map[i, j] = '.'; // Set all cells to empty
            }
        }
        AddSnake();
        AddWallsX();
        AddWallsY();
    }

    static void PrintMap()
    {
        for (int i = 0; i < Map.GetLength(0); i++)
        {
            for (int j = 0; j < Map.GetLength(1); j++)
            {
                Console.Write(Map[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void FindPath()
    {
        while ((CurrentX != EndX) || (CurrentY != EndY))
        {
            if (CurrentX < EndX)
            {
                // Move Right
                CurrentX++;

            }
            else if (CurrentX > EndX)
            {
                // Move Left
                CurrentX--;
            }

            if (CurrentY < EndY)
            {
                // Move Down
                CurrentY++;
            }
            else if (CurrentY > EndY)
            {
                // Move Up
                CurrentY--;
            }

            if (WallFound())
            {
                WallAxsis();
                if (StartX < EndX && WallRight)
                {
                    CurrentX--;
                    WallRight = false;
                }
                else if (StartX > EndX && WallLeft)
                {
                    CurrentX++;
                    WallLeft = false;
                }
                else if (StartY < EndY && WallDown)
                {
                    CurrentY--;
                    WallDown = false;
                }
                else if (StartY > EndY && WallUp)
                {
                    CurrentY++;
                    WallUp = false;
                }



                if (CurrentY == EndY && StartY < EndY)
                {
                    CurrentY--;
                    CurrentX++;
                }
                else if (CurrentY == EndY && StartY > EndY)
                {
                    CurrentY++;
                    CurrentX--;
                }
            }


            if ((CurrentX != StartX && CurrentX != EndX) || (CurrentY != StartY && CurrentY != EndY))
            {
                Map[CurrentY, CurrentX] = 'X';
                Console.WriteLine($"At ({CurrentX}, {CurrentY}): Left {WallLeft} Rigt {WallRight} UP {WallUp} Down {WallDown}");
                Console.ReadLine();
            }
            Thread.Sleep(10);
            Console.Clear();
            PrintMap();
            MoveCount++;

        }
    }

    static void WallAxsis()
    {
        if (CurrentX < EndX && Map[CurrentY, CurrentX - 1] != '#')
        {
            WallRight = true;
        }
        else if (CurrentX > EndX && Map[CurrentY, CurrentX + 1] != '#')
        {
            WallLeft = true;
        }
        else if (CurrentY < EndY && Map[CurrentY - 1, CurrentX] != '#')
        {
            WallDown = true;
        }
        else if (CurrentY > EndY && Map[CurrentY + 1, CurrentX] != '#')
        {
            WallUp = true;
        }
    }

    static bool WallFound()
    {
        if (Map[CurrentY, CurrentX] == '#')
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
}