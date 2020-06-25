using NotationNinja.Models.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotationNinja.Models.Nodes
{
    public class SymbolNode : Node
    {
        public Symbol Symbol { get; set; }

        public override void Process(List<Node> nodes)
        {
            var index = nodes.IndexOf(this);
        }
    }
}
