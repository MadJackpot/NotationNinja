using NotationNinja.Services.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotationNinja.Services.NotationParsers
{
    public class PostfixNotationParser : INotationParser
    {
        public Node GetLeftNode(List<Node> nodes, int index)
        {
            return nodes[index - 2];
        }

        public int GetOrderById(List<Node> nodes, Node node)
        {
            return nodes.IndexOf(node);
        }

        public Node GetRightNode(List<Node> nodes, int index)
        {
            return nodes[index - 1];
        }

        public bool WrapOperators()
        {
            return true;
        }
    }
}
