using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind.Game;

namespace ConsoleApp1
{
    class Program
    {
        private static Game _game;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter player name:");
            var playerName = Console.ReadLine();

            ChangeSettings();
            _game = new Game(playerName);

            while (_game.CurrentRow <= Settings.BoardRows)
            {
                Console.Clear();
                Console.WriteLine($"Current row:{_game.CurrentRow}. PLAYER: {_game.Breaker.Name}");
                _game.Maker.Code.ToList().ForEach(Console.Write); // Debug info only
                Console.WriteLine();
                WriteHistory();
                if (_game.InputGuess(GetInput()))
                    Console.WriteLine("You Won!");
            }

            if (_game.CurrentRow < Settings.BoardRows) return;

            Console.WriteLine("You lost! Wanna try again? Press Y");
            if(Console.ReadKey().Key == ConsoleKey.Y) Main(null);
        }

        private static void ChangeSettings()
        {
            Console.WriteLine("Do you wish to change settings? y/n");
            if (Console.ReadKey().Key != ConsoleKey.Y) return;

            Console.WriteLine($"Current number of rows:{Settings.BoardRows}, (6,8,10,12)");
            Console.WriteLine("New Value: ");
            Settings.BoardRows = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine($"Current number of code pegs:{Settings.CodePegs}");
            Console.WriteLine("New Value, more than holes: ");
            Settings.CodePegs = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine($"Current number of holes:{Settings.BoardHoles}");
            Console.WriteLine("New Value, less than pegs: ");
            Settings.BoardHoles = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        }

        private static void WriteHistory()
        {
            Console.WriteLine(">");
            _game.Board.BoardHistory.ToList().ForEach(codeMaker =>
            {
                codeMaker.CurrentCode.ForEach(i => Console.Write($" {i}"));
                Console.WriteLine(
                    $"/ Hit:{codeMaker.HitCount}, Wrong Pos:{codeMaker.WrongPositionCount}, Miss:{codeMaker.MissCount}");
            });
        }

        public static List<int> GetInput()
        {
            var list = new List<int>();
            for (var i = 0; i < Settings.BoardHoles; i++)
            {
                int value;
                Console.Write($"Peg {i + 1}: ");
                while (!int.TryParse(Console.ReadLine(), out value) || value > Settings.CodePegs || value < 1) ;
                list.Add(value);
            }
            return list;
        }
    }
}