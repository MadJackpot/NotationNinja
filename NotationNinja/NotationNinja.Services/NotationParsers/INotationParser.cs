using NotationNinja.Services.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotationNinja.Services.NotationParsers
{
    public interface INotationParser
    {
        public Node GetLeftNode(List<Node> nodes, int index);
        public Node GetRightNode(List<Node> nodes, int index);
        public int GetOrderById(List<Node> nodes, Node node);
        public bool WrapOperators();
    }
}
