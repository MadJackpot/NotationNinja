using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotationNinja.Services.Symbols
{
    public static class SymbolLookup
    {
        private static Dictionary<char, int> Values = new Dictionary<char, int>()
        {
            { '+', 2 },
            { '-', 2 },
            { '*', 1 },
            { '/', 1 },
        };

        public static int GetSymbolPriority(this char character) => Values[character];

        public static bool IsSymbol(this char character) => Values.Keys.Contains(character);

        public static Symbol ToSymbol(this char character) => new Symbol { Character = character, Priority = character.GetSymbolPriority() };
    }
}
