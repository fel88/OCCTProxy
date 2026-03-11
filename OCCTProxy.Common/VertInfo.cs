using OCCTProxy.Common.Interfaces;
using OpenTK.Mathematics;

namespace OCCTProxy.Common
{
    public class VertInfo : IVertInfo
    {
        public Vector3d Position { get; set; }

        public int BindId { get; set; }
        public int AisShapeBindId { get; set; }//parent
    }
}
