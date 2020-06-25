﻿using NotationNinja.Services.Symbols;
using NotationNinja.Services.NotationParsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotationNinja.Services.Nodes
{
    public class SymbolNode : Node
    {
        public Symbol Symbol { get; set; }

        public override void Process(List<Node> nodes, INotationParser parser)
        {
            var index = nodes.IndexOf(this);

            var leftNode = parser.GetLeftNode(nodes, index);
            var rightNode = parser.GetRightNode(nodes, index);

            Left = leftNode;
            Right = rightNode;

            nodes.Remove(leftNode);
            nodes.Remove(rightNode);
        }

        public override string ToPostfix()
        {
            return $"{Left.ToPostfix()} {Right.ToPostfix()} {Symbol.Character}";
        }
    }
}