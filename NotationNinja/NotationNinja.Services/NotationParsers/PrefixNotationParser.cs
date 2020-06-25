using NotationNinja.Services.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotationNinja.Services.NotationParsers
{
    public class PrefixNotationParser : INotationParser
    {
        public Node GetLeftNode(List<Node> nodes, int index)
        {
            return nodes[index + 1];
        }

        public Node GetRightNode(List<Node> nodes, int index)
        {
            return nodes[index + 2];
        }
    }
}
