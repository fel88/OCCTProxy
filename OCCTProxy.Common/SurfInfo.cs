using OCCTProxy.Common.Interfaces;
using OpenTK.Mathematics;

namespace OCCTProxy.Common
{
    public class SurfInfo : ISurfInfo
    {

        public Vector3d COM { get; set; }
        public Vector3d Position { get; set; }
        public int BindId { get; set; }
        public int AisShapeBindId { get; set; }//parent
        public int Type { get; set; }
        public Vector3d Normal { get; set; }
        public Vector3d NormalOrigin { get; set; }

    }
}
