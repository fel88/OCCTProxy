using OpenTK.Mathematics;

namespace OCCTProxy.Common.Interfaces
{
    public interface IEdgeInfo : IManagedObjHandle
    {
        CurveType CurveType { get; set; }
        Vector3d COM { get; set; }//center of mass
        Vector3d Start { get; set; }
        Vector3d End { get; set; }
        double Length { get; set; }
    }
}
