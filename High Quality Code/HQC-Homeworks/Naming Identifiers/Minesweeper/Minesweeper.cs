using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Minesweeper
    {
        private static void Main()
        {
            var command = string.Empty;
            var field = CreateField();
            var bombs = PlaceBombs();
            var pointsCounter = 0;
            var isGameOver = false;
            var winners = new List<Player>(6);
            var row = 0;
            var column = 0;
            var introPlayed = false;
            const int maks = 35;
            var isWinner = false;

            while (command != "exit")
            {
                if (!introPlayed)
                {
                    Console.WriteLine(
                        "Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki."
                        + " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");

                    PrintField(field);
                    introPlayed = true;
                }

                Console.Write("Daj red i kolona : ");

                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= field.GetLength(0) && column <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Rating(winners);
                        break;
                    case "restart":
                        field = CreateField();
                        bombs = PlaceBombs();
                        PrintField(field);
                        isGameOver = false;
                        introPlayed = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                Turn(field, bombs, row, column);
                                pointsCounter++;
                            }

                            if (maks == pointsCounter)
                            {
                                isWinner = true;
                            }
                            else
                            {
                                PrintField(field);
                            }
                        }
                        else
                        {
                            isGameOver = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (isGameOver)
                {
                    PrintField(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " + "Daj si niknejm: ", pointsCounter);
                    var nickname = Console.ReadLine();
                    var playerInfo = new Player(nickname, pointsCounter);
                    if (winners.Count < 5)
                    {
                        winners.Add(playerInfo);
                    }
                    else
                    {
                        for (var i = 0; i < winners.Count; i++)
                        {
                            if (winners[i].Points < playerInfo.Points)
                            {
                                winners.Insert(i, playerInfo);
                                winners.RemoveAt(winners.Count - 1);
                                break;
                            }
                        }
                    }

                    winners.Sort((Player r1, Player r2) => string.Compare(r2.Name, r1.Name, StringComparison.Ordinal));
                    winners.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    Rating(winners);

                    field = CreateField();
                    bombs = PlaceBombs();
                    pointsCounter = 0;
                    isGameOver = false;
                    introPlayed = true;
                }

                if (isWinner)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");

                    PrintField(bombs);

                    Console.WriteLine("Daj si imeto, batka: ");

                    var name = Console.ReadLine();
                    var points = new Player(name, pointsCounter);

                    winners.Add(points);
                    Rating(winners);
                    field = CreateField();
                    bombs = PlaceBombs();
                    pointsCounter = 0;
                    isWinner = false;
                    introPlayed = true;
                }
            }

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void Rating(List<Player> players)
        {
            Console.WriteLine("\nTo4KI:");
            if (players.Count > 0)
            {
                for (var i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii", i + 1, players[i].Name, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void Turn(char[,] field, char[,] bombs, int row, int column)
        {
            var bombsAmount = GetBombsAmount(bombs, row, column);
            bombs[row, column] = bombsAmount;
            field[row, column] = bombsAmount;
        }

        private static void PrintField(char[,] board)
        {
            var rows = board.GetLength(0);
            var columns = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (var i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (var j = 0; j < columns; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateField()
        {
            var boardRows = 5;
            var boardColumns = 10;
            var board = new char[boardRows, boardColumns];
            for (var i = 0; i < boardRows; i++)
            {
                for (var j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            const int rows = 5;
            const int columns = 10;
            var gameField = new char[rows, columns];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            var r3 = new List<int>();
            while (r3.Count < 15)
            {
                var random = new Random();
                var asfd = random.Next(50);
                if (!r3.Contains(asfd))
                {
                    r3.Add(asfd);
                }
            }

            foreach (var i2 in r3)
            {
                var kol = i2/columns;
                var red = i2%columns;
                if (red == 0 && i2 != 0)
                {
                    kol--;
                    red = columns;
                }
                else
                {
                    red++;
                }

                gameField[kol, red - 1] = '*';
            }

            return gameField;
        }

        private static void SetRevealedPositions(char[,] field)
        {
            var column = field.GetLength(0);
            var row = field.GetLength(1);

            for (var i = 0; i < column; i++)
            {
                for (var j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        var kolkoo = GetBombsAmount(field, i, j);
                        field[i, j] = kolkoo;
                    }
                }
            }
        }

        //bombs, row, column
        private static char GetBombsAmount(char[,] bombs, int row, int column)
        {
            var amount = 0;
            var rows = bombs.GetLength(0);
            var columns = bombs.GetLength(1);

            if (row - 1 >= 0)
            {
                if (bombs[row - 1, column] == '*')
                {
                    amount++;
                }
            }

            if (row + 1 < rows)
            {
                if (bombs[row + 1, column] == '*')
                {
                    amount++;
                }
            }

            if (column - 1 >= 0)
            {
                if (bombs[row, column - 1] == '*')
                {
                    amount++;
                }
            }

            if (column + 1 < columns)
            {
                if (bombs[row, column + 1] == '*')
                {
                    amount++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (bombs[row - 1, column - 1] == '*')
                {
                    amount++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (bombs[row - 1, column + 1] == '*')
                {
                    amount++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (bombs[row + 1, column - 1] == '*')
                {
                    amount++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (bombs[row + 1, column + 1] == '*')
                {
                    amount++;
                }
            }

            return char.Parse(amount.ToString());
        }

        public class Player
        {
            public Player()
            {
            }

            public Player(string name, int points)
            {
                Name = name;
                Points = points;
            }

            public string Name { get; set; }

            public int Points { get; set; }
        }
    }
}