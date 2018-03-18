using System;
using System.Collections.Generic;

namespace Mastermind.Game
{
    public class CodeMaker
    {
        public List<int> Code { get; } = new List<int>();

        public CodeMaker()
        {
            GenerateCode(Settings.BoardHoles);
        }

        public void GenerateCode(int size)
        {
            var random = new Random();
            Code.Clear();
            for (var i = 0; i < size; i++)
            {
                Code.Add(random.Next(1, Settings.CodePegs + 1));
            }
        }
    }
}