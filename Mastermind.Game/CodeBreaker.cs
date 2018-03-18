using System.Collections.Generic;

namespace Mastermind.Game
{
    public class CodeBreaker
    {
        public string Name { get; set; }

        public List<int> CurrentCode { get; set; }

        public List<int> HitList { get; set; }

        public int HitCount => HitList.Count;
    }
}