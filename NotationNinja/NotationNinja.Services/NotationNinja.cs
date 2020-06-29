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

        public List<Node> ProcessParenthesis(List<Node> nodes, int indexOfParenth = 0)
        {
            var parenthNode = nodes.FirstOrDefault(x => x is ParenthesisNode n && n.Type == ParenthesisType.Open && nodes.IndexOf(x) >= indexOfParenth) as ParenthesisNode;

            while (parenthNode != null)
            {
                var index = nodes.IndexOf(parenthNode);

                ParenthesisNode close = null;
                for (var i = index + 1; i < nodes.Count; ++i)
                {
                    if (nodes[i] is ParenthesisNode x && x.Type == ParenthesisType.Open)
                    {
                        nodes = ProcessParenthesis(nodes, i);
                    }

                    if (nodes[i] is ParenthesisNode c && c.Type == ParenthesisType.Close)
                    {
                        close = c;
                        break;
                    }
                }

                var closeIndex = nodes.IndexOf(close);
                var processedNode = CreateAndProcessNodes(nodes.GetRange(index + 1, closeIndex - index - 1));

                parenthNode!.Type = ParenthesisType.Wrap;
                parenthNode.InternalNode = processedNode;

                nodes.RemoveRange(index + 1, closeIndex - index);

                parenthNode = nodes.FirstOrDefault(x => x is ParenthesisNode n && n.Type == ParenthesisType.Open && nodes.IndexOf(x) > index) as ParenthesisNode;
            }

            return nodes;
        }
    }
}
