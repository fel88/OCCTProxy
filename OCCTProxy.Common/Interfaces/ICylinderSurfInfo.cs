using OpenTK.Mathematics;

namespace OCCTProxy.Common.Interfaces
{
    public interface ICylinderSurfInfo
    {
        Vector3d Axis { get; set; }
        double Radius { get; set; }
    }
}