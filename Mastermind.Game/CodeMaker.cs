using System;
using System.Collections.Generic;

namespace Mastermind.Game
{
    public class CodeMaker
    {
        public List<int> Code { get; } = new List<int>();

        public CodeMaker() => GenerateCode(Settings.BoardHoles);

        private void GenerateCode(int size)
        {
            var random = new Random();
            Code.Clear();
            Code.Add(0);
            for (var i = 1; i <= size; i++)
            {
                Code.Add(random.Next(1, Settings.CodePegs + 1));
            }
        }
    }
}