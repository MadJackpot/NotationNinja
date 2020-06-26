using NotationNinja.Services.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotationNinja.Services.NotationParsers
{
    public class InfixNotationParser : INotationParser
    {
        public Node GetLeftNode(List<Node> nodes, int index)
        {
            return nodes[index - 1];
        }

        public int GetOrderById(List<Node> nodes, Node node)
        {
            return (node as SymbolNode).Symbol.Priority;
        }

        public Node GetRightNode(List<Node> nodes, int index)
        {
            return nodes[index + 1];
        }

        public bool WrapOperators()
        {
            return false;
        }
    }
}
