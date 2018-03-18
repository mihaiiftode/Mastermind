using System.Collections.Generic;
using System.Linq;

namespace Mastermind.Game
{
    public class CodeBreaker
    {
        public string Name { get; set; }

        public List<int> CurrentCode { get; set; }


        public int HitCount { get; set; }
        public int WrongPositionCount { get; set; }
        public int MissCount { get; set; }


        public CodeBreaker()
        {
            CurrentCode = new List<int>();
        }
    }
}