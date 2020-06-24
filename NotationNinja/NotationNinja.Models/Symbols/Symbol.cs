using System;
using System.Collections.Generic;
using System.Text;

namespace NotationNinja.Models.Symbols
{
    public abstract class Symbol
    {
        public virtual char Character { get; }

        public virtual int Priority { get; }
    }
}
