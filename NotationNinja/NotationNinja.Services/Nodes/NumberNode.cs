using NotationNinja.Services.NotationParsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotationNinja.Services.Nodes
{
    public class NumberNode : Node
    {
        public string Value { get; set; }

        public override void Process(List<Node> nodes, INotationParser parser)
        {
            // Number nodes just have a value and have no further processing.
        }

        public override string ToPostfix()
        {
            return Value;
        }
    }
}
