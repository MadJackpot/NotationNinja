using NotationNinja.Services.Nodes;
using NotationNinja.Services.Symbols;
using NotationNinja.Services.NotationParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotationNinja.Services
{
    public class NotationNinja
    {
        private readonly INotationParser _parser;

        public NotationNinja(INotationParser parser)
        {
            _parser = parser;
        }

        public string ToPostfix(string input)
        {
            var nodes = input.Split(' ').Select(NodeFactory.GenerateNode).ToList();

            nodes
               .Where(x => x is SymbolNode)
               .Cast<SymbolNode>()
               .OrderBy(x => x.Symbol.Priority)
               .ToList()
               .ForEach(x =>  x.Process(nodes, _parser));

            return string.Join(' ', nodes.Select(x => x.ToPostfix()));
        }
    }
}
