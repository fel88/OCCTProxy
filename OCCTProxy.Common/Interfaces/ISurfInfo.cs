using OpenTK.Mathematics;

namespace OCCTProxy.Common.Interfaces
{
    public interface ISurfInfo
    {
        Vector3d COM { get; }
        Vector3d Position { get; }
        int BindId { get; }
        int AisShapeBindId { get; }
        int Type { get; set; }


    }
}
