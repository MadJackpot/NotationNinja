using NotationNinja.Services.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotationNinja.Services.Nodes
{
    public static class NodeFactory
    {
        public static Node GenerateNode(string nodeValue)
        {
            if (double.TryParse(nodeValue, out var _))
            {
                return new NumberNode { Value = nodeValue };
            }

            if (nodeValue.Length == 1 && SymbolLookup.IsSymbol(nodeValue[0]))
            {
                return new SymbolNode { Symbol = nodeValue[0].ToSymbol() };
            }

            if (nodeValue.Length == 1 && SymbolLookup.IsParenthesis(nodeValue[0]))
            {
                return new ParenthesisNode { Type = nodeValue[0].IsOpenParenthesis() ? ParenthesisType.Open : ParenthesisType.Close };
            }

            throw new InvalidOperationException("No valid symbol");
        }
    }
}
