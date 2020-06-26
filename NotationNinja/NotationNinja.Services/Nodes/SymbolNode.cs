using NotationNinja.Services.Symbols;
using NotationNinja.Services.NotationParsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotationNinja.Services.Nodes
{
    public class SymbolNode : Node
    {
        public Symbol Symbol { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public override void Process(List<Node> nodes, INotationParser parser)
        {
            var index = nodes.IndexOf(this);

            // 1 * ( 2 + 3 ) ==> 1 2 3 + *
            // 1 * ( 2 + 3 ) ==> * 1 + 2 3

            var leftNode = parser.GetLeftNode(nodes, index);
            var rightNode = parser.GetRightNode(nodes, index);

            Left = leftNode;
            Right = rightNode;

            if (parser.WrapOperators() && (rightNode is SymbolNode n) && n.Symbol.Priority > Symbol.Priority)
            {
                var parenth = new ParenthesisNode{ InternalNode = rightNode, Type = ParenthesisType.Wrap };
                Right = parenth;
            }

            nodes.Remove(leftNode);
            nodes.Remove(rightNode);
        }

        public override string ToPrefix()
        {
            return $"{Symbol.Character} {Left.ToPrefix()} {Right.ToPrefix()}";
        }

        public override string ToPostfix()
        {
            return $"{Left.ToPostfix()} {Right.ToPostfix()} {Symbol.Character}";
        }

        public override string ToInfix()
        {
            return $"{Left.ToInfix()} {Symbol.Character} {Right.ToInfix()}";
        }
    }
}
