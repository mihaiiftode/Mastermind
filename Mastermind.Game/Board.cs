using System.Collections;
using System.Collections.Generic;

namespace Mastermind.Game
{
    public class Board
    {
        public Stack<CodeMaker> BoardHistory { get; }

        public Board(int size = 12) => BoardHistory = new Stack<CodeMaker>(size);

        public void ClearHistory() => BoardHistory.Clear();
    }
}