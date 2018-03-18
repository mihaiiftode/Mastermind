using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Game
{
    public class Game
    {
        private CodeBreaker _codeBreaker;
        private CodeMaker _codeMaker;

        public Game(string playerName)
        {
            _codeBreaker = new CodeBreaker
            {
                Name = playerName
            };
            _codeMaker = new CodeMaker();
        }
    }
}
