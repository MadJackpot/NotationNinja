using System;

namespace NotationNinja.Models.Nodes
{
    public abstract class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
