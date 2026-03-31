using OCCTProxy.Common;
using OpenTK.Mathematics;
using System;

namespace OCCTProxy.Common
{
    public abstract class BlueprintItem
    {
        public virtual Vector2d Start { get; set; }
        public virtual Vector2d End { get; set; }

        public virtual void Reverse()
        {
            (Start, End) = (End, Start);
        }
    }
}
