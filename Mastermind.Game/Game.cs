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
        public CodeBreaker Breaker { get; }
        public CodeMaker Maker { get; }
        public Board Board { get; }

        public Game(string playerName)
        {
            CheckSettings();
            Breaker = new CodeBreaker
            {
                Name = playerName
            };
            Maker = new CodeMaker();
            Board = new Board();
        }

        public void InputGuess(List<int> codes)
        {   
            if (codes.Count != Settings.BoardHoles) throw new ArgumentOutOfRangeException("To many pegs");
            Breaker.CurrentCode = codes;
        }

        public bool CheckCurrentInput()
        {
            var checkList = Breaker.CurrentCode.Except(Maker.Code).ToList();
            if (checkList.Count <= 0) return true;

            Breaker.HitList = Enumerable.Repeat(0, Settings.BoardHoles).ToList();
            checkList.ForEach(index => Breaker.HitList[index] = 1);
            Board.BoardHistory.Push(Maker);

            return false;
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