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

        public string ToPrefix(string input)
        {
            var nodes = CreateAndProcessNodes(input);

            return string.Join(' ', nodes.Select(x => x.ToPrefix()));
        }

        public string ToPostfix(string input)
        {
            var nodes = CreateAndProcessNodes(input);

            return string.Join(' ', nodes.Select(x => x.ToPostfix()));
        }

        public string ToInfix(string input)
        {
            var nodes = CreateAndProcessNodes(input);

            return string.Join(' ', nodes.Select(x => x.ToInfix()));
        }

        public List<Node> CreateAndProcessNodes(string input)
        {
            var nodes = input.Split(' ').Select(NodeFactory.GenerateNode).ToList();

            var node = CreateAndProcessNodes(nodes);

            return new List<Node>{node};
        }

        public Node CreateAndProcessNodes(List<Node> nodes)
        {
            nodes = ProcessParenthesis(nodes);

            nodes
               .Where(x => (x is SymbolNode n) && n.Left == null && n.Right == null)
               .Cast<SymbolNode>()
               .OrderBy(x => _parser.GetOrderById(nodes, x))
               .ToList()
               .ForEach(x =>  x.Process(nodes, _parser));

            return nodes.Single();
        }

        public List<Node> ProcessParenthesis(List<Node> nodes)
        {
            var open = nodes.Find(x => (x is ParenthesisNode p) && p.Type == ParenthesisType.Open);
            var close = nodes.Find(x => (x is ParenthesisNode p) && p.Type == ParenthesisType.Close);

            if (open == null || close == null)
            {
                return nodes;
            }

            var openIndex = nodes.IndexOf(open);
            var closeIndex = nodes.IndexOf(close);
            var internalList = nodes.GetRange(openIndex + 1, closeIndex - openIndex - 1);

            var processedInternalNode = CreateAndProcessNodes(internalList);

            openIndex = nodes.IndexOf(open);
            closeIndex = nodes.IndexOf(close);

            nodes.RemoveRange(openIndex, closeIndex - openIndex + 1);
            nodes.Insert(openIndex, processedInternalNode);

            return nodes;
        }
    }
}
