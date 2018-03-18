using System;
using System.Collections.Generic;

namespace Mastermind.Game
{
    public class CodeMaker
    {
        public int[] Code { get; private set; }

        public CodeMaker() => GenerateCode(Settings.BoardHoles);

        /// <summary>
        /// Generate a random code. each position can represent an element with
        /// a maximum of <see langword="int"/>
        /// </summary>
        /// <param name="size"></param>
        private void GenerateCode(int size)
        {
            Code = new int[Settings.BoardHoles];
            var random = new Random();
            for (var i = 0; i < size; i++)
            {
                Code[i] = random.Next(1, Settings.CodePegs + 1);
            }
        }
    }
}