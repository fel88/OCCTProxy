using OCCTProxy.Common;
using OpenTK.Mathematics;
using System.Collections.Generic;

namespace OCCTProxy.Common
{
    public class BlueprintPolyline : BlueprintItem
    {
        public List<Vector2d> Points = new List<Vector2d>();
        public override Vector2d Start => Points[0];
        public override Vector2d End => Points[Points.Count - 1];
    }
}
