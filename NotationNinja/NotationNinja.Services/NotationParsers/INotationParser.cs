using NotationNinja.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotationNinja.Services.NotationParsers
{
    public interface INotationParser
    {
        public Node GetLeftNode(List<Node> nodes);
        public Node GetRightNode(List<Node> nodes);
    }
}
