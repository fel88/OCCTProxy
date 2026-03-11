using OCCTProxy.Common.Interfaces;

namespace OCCTProxy.Common.Surfaces
{
    public class SphereSurfInfo : SurfInfo, ISphereSurfInfo
    {
        public double Radius { get; set; }
    }
}
