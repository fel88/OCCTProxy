using OCCTProxy.Common.Interfaces;
using OpenTK.Mathematics;

namespace OCCTProxy.Common
{
    public class WireInfo : IWireInfo
    {        
        public Vector3d COM { get; set; }//center of mass
        
        public int BindId { get; set; }
        public int AisShapeBindId { get; set; }
        public int ShapeType { get; set; }
    }
}
