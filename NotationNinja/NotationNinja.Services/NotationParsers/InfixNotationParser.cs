using NotationNinja.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotationNinja.Services.NotationParsers
{
    public class InfixNotationParser : INotationParser
    {
        public Node GetLeftNode(List<Node> nodes)
        {
            return nodes.First();
        }

        public Node GetRightNode(List<Node> nodes)
        {
        }
    }
}
