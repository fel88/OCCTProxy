using OCCTProxy.Common;
using System;

namespace OCCTProxy.Common
{
    public abstract class BlueprintItem
    {
        public virtual Vertex2D Start { get; set; }
        public virtual Vertex2D End { get; set; }

        public virtual void Reverse()
        {
            (Start, End) = (End, Start);
        }
    }
}
