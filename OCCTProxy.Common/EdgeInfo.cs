using OCCTProxy.Common;
using OCCTProxy.Common.Interfaces;
using OpenTK.Mathematics;

namespace OCCTProxy.Common
{
    public class EdgeInfo : IEdgeInfo
    {
        public CurveType CurveType { get; set; }
        public Vector3d COM { get; set; }//center of mass
        public Vector3d Start { get; set; }
        public Vector3d End { get; set; }
        public double Length { get; set; }
        public int BindId { get; set; }
        public int AisShapeBindId { get; set; }
        public int ShapeType { get; set; }
    }
}
