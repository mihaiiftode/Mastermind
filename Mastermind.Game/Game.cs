using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind.Game
{
    public class Game
    {
        public CodeBreaker Breaker { get; private set; }
        public CodeMaker Maker { get; }
        public Board Board { get; }

        public int CurrentRow { get; private set; } = 1;

        public Game(string playerName)
        {
            CheckSettings();
            Breaker = new CodeBreaker {Name = playerName};
            Maker = new CodeMaker();
            Board = new Board();
        }

        /// <summary>
        /// Checks if current <paramref name="code"/> is correct
        /// </summary>
        /// <param name="code"></param>
        /// <returns>true if correct, false if not</returns>
        public bool InputGuess(List<int> code)
        {
            CheckInput(code);
            CheckTryCount();
            CurrentRow++;
            Breaker.CurrentCode = code;
            ComputeGuesses();

            SaveHistory();

            return Breaker.HitCount == Settings.BoardHoles;
        }

        private static void CheckInput(List<int> codes)
        {
            if (!codes.TrueForAll(i => i > 0 && i <= Settings.CodePegs))
                throw new ArgumentOutOfRangeException(nameof(Settings.CodePegs));
            if (codes.Count != Settings.BoardHoles) throw new ArgumentOutOfRangeException(nameof(Settings.BoardHoles));
        }

        private void CheckTryCount()
        {
            if (CurrentRow > Settings.BoardRows) throw new ArgumentOutOfRangeException(nameof(CurrentRow));
        }

        private void ComputeGuesses()
        {
            for (var i = 0; i < Breaker.CurrentCode.Count; i++)
            {
                if (Maker.Code[i] == Breaker.CurrentCode[i]) Breaker.HitCount++;
            }
            Breaker.WrongPositionCount = Breaker.CurrentCode.Intersect(Maker.Code).Count() - Breaker.HitCount;
            Breaker.MissCount = Breaker.CurrentCode.Except(Maker.Code).Count();
        }

        private void SaveHistory()
        {
            Board.BoardHistory.Push(Breaker);

            var name = Breaker.Name;
            Breaker = new CodeBreaker {Name = name};
        }

        private void CheckSettings()
        {
            if (Settings.BoardRows > 12 || Settings.BoardRows < 6 || Settings.BoardRows % 2 != 0)
                throw new ArgumentOutOfRangeException(
                    $"Number or row is not out of (6, 12) and or not even: {Settings.BoardRows}");
            if (Settings.BoardHoles > Settings.CodePegs)
                throw new ArgumentOutOfRangeException(
                    "Board holes should be less than pegs");
        }
    }
}