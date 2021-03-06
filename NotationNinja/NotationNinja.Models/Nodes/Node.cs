﻿using System;
using System.Collections.Generic;

namespace NotationNinja.Models.Nodes
{
    public abstract class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }

        public abstract void Process(List<Node> nodes, INotationParser parser);
    }
}
