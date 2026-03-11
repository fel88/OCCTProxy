using OCCTProxy.Common.Interfaces;
using OpenTK.Mathematics;

namespace OCCTProxy.Common.Surfaces
{
    public class CylinderSurfInfo : SurfInfo, ICylinderSurfInfo
    {
        public double Radius { get; set; }
        public Vector3d Axis { get; set; }
    }
}
