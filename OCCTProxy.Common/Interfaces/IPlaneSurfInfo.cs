using OpenTK.Mathematics;

namespace OCCTProxy.Common.Interfaces
{
    public interface IPlaneSurfInfo : ISurfInfo
    {
        Vector3d Normal { get; }
    }
}
