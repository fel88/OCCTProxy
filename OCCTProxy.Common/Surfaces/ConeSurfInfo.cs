using OCCTProxy.Common.Interfaces;

namespace OCCTProxy.Common.Surfaces
{
    public class ConeSurfInfo : SurfInfo, IConeSurfInfo
    {
        public double Radius1 { get; set; }
        public double Radius2 { get; set; }
        public double SemiAngle { get; set; }
    }
}
