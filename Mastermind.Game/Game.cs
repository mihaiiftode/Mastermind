using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool InputGuess(List<int> code)
        {
            CheckInput(code);
            CheckTryCount();
            CurrentRow++;
            Breaker.CurrentCode = code;
            var hitList = ExtractHitList();

            SaveHistory();

            return hitList.Count == Settings.BoardHoles;
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

        private List<int> ExtractHitList()
        {
            var checkList = Breaker.CurrentCode.Except(Maker.Code).ToList();
            checkList.ForEach(index =>  Breaker.HitList[index] = index == Maker.Code[index] ? CodeBreaker.HitType.Hit : CodeBreaker.HitType.WrongPosition);
            return checkList;
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