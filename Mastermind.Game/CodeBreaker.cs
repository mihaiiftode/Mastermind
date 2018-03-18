using System.Collections.Generic;
using System.Linq;

namespace Mastermind.Game
{
    public class CodeBreaker
    {
        public string Name { get; set; }

        public List<int> CurrentCode { get; set; }

        public List<HitType> HitList { get; set; }

        public int HitCount => HitList.Count(item => item == HitType.Hit);
        public int HitWrongPosition => HitList.Count(item => item == HitType.WrongPosition);
        public int Miss => HitList.Count(item => item == HitType.Miss);

        public CodeBreaker()
        {
            CurrentCode = new List<int>();
            HitList = Enumerable.Repeat(HitType.Miss, Settings.BoardHoles + 1).ToList();
        }

        public enum HitType
        {
            Miss = 0,
            Hit = 1,
            WrongPosition = 2
        }
    }
}