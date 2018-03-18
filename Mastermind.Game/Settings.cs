using System.IO;

namespace Mastermind.Game
{
    public static class Settings
    {
        /// <summary>
        /// Number of holes for <see cref="CodeMaker"/>
        /// </summary>
        public static int BoardHoles = 4;

        /// <summary>
        /// Number of rows of the <see cref="Board"/>, or difficulty for <see cref="CodeBreaker"/>
        /// </summary>
        public static int BoardRows = 12;

        /// <summary>
        /// Number of color coded pegs, <see langword="int"/> representation, mapping required for other types.
        /// </summary>
        public static int CodePegs = 6;
    }
}