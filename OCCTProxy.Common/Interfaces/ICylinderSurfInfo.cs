using OpenTK.Mathematics;

namespace OCCTProxy.Common.Interfaces
{
    public interface ICylinderSurfInfo : ISurfInfo
    {
        Vector3d Axis { get; set; }
        double Radius { get; set; }
        Vector3d Normal { get; set; }

    }
}