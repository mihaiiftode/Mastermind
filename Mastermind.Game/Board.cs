using System.Collections;
using System.Collections.Generic;

namespace Mastermind.Game
{
    public class Board
    {
        public Stack<List<int>> BoardHistory { get; }

        public Board(int size = 12) => BoardHistory = new Stack<List<int>>(size);

        public void ClearHistory() => BoardHistory.Clear();
    }
}