using OCCTProxy.Common.Interfaces;
using OpenTK.Mathematics;

namespace OCCTProxy.Common
{
    public class PlaneSurfInfo : SurfInfo, IPlaneSurfInfo
    {
        public Vector3d Normal { get; set; }
    }
}
