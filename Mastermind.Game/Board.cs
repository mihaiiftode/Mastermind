using System.Collections;
using System.Collections.Generic;

namespace Mastermind.Game
{
    public class Board
    {
        public Stack<CodeBreaker> BoardHistory { get; }

        public Board(int size = 12) => BoardHistory = new Stack<CodeBreaker>(size);

        public void ClearHistory() => BoardHistory.Clear();
    }
}