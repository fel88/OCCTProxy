using OCCTProxy.Common.Interfaces;

namespace OCCTProxy.Common.Surfaces
{
    public class TorusSurfInfo : SurfInfo, ITorusSurfInfo
    {
        public double MajorRadius { get; set; }
        public double MinorRadius { get; set; }
    }
}
