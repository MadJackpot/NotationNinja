using NotationNinja.Services.NotationParsers;
using NotationNinja.Services.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotationNinja.Services.Nodes
{
    public class ParenthesisNode : Node
    {
        public Node InternalNode { get; set; }

        public ParenthesisType Type { get; set; }

        public override void Process(List<Node> nodes, INotationParser parser)
        {
            throw new NotImplementedException();
        }

        public override string ToInfix()
        {
            return $"( {InternalNode.ToInfix()} )";
        }

        public override string ToPostfix()
        {
            return InternalNode.ToPostfix();
        }

        public override string ToPrefix()
        {
            return InternalNode.ToPrefix();
        }
    }
}
