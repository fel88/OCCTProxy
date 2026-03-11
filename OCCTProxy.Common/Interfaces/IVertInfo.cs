using OpenTK.Mathematics;

namespace OCCTProxy.Common.Interfaces
{
    public interface IVertInfo
    {
        Vector3d Position { get; }
        int BindId { get; }        
        int AisShapeBindId { get; }
    }
}
