using OCCTProxy.Common.Interfaces;
using OpenTK.Mathematics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCCTProxy.Common
{
    public static class BREPUtils
    {
        public static string ExtractObj(IOCCTProxyInterface proxy, ITopObjHandle handle, bool wholeShapeTransform, bool applyLocalTransform, float tolerance = 1e-8f)
        {
            var poly = proxy.IteratePoly(handle, applyLocalTransform, wholeShapeTransform);
            var res1 = poly[0].Select(z => new Vector3d(z.X, z.Y, z.Z)).ToArray();
            var res2 = poly[1].Select(z => new Vector3d(z.X, z.Y, z.Z)).ToArray();

            StringBuilder sb = new StringBuilder();
            List<Vector3d> vvv = new List<Vector3d>();
            List<Vector3d> vvn = new List<Vector3d>();

            //todo fix here (optimize normals and vertices together)
            Dictionary<string, List<VecArrayPosInfo>> bucket1 = new Dictionary<string, List<VecArrayPosInfo>>();
            Dictionary<string, List<VecArrayPosInfo>> bucket2 = new Dictionary<string, List<VecArrayPosInfo>>();
            List<int> indices = new List<int>();
            List<int> nindices = new List<int>();
            for (int i = 0; i < res1.Length; i += 3)
            {
                var verts = new[] { res1[i], res1[i + 1], res1[i + 2] };
                foreach (var v in verts)
                {
                    string key = $"{(int)(v.X * 1000)};{(int)(v.Y * 1000)};{(int)(v.Z * 1000)}";
                    if (!bucket1.ContainsKey(key))
                        bucket1.Add(key, new List<VecArrayPosInfo>());

                    var fr = bucket1[key].FirstOrDefault(z => (z.Position - v).Length < tolerance);
                    if (fr != null)
                    {
                        indices.Add(fr.Index);
                        continue;
                    }

                    vvv.Add(v);
                    bucket1[key].Add(new VecArrayPosInfo() { Position = v, Index = vvv.Count });
                    indices.Add(vvv.Count);
                    sb.AppendLine($"v {v.X} {v.Y} {v.Z}".Replace(",", "."));
                }
            }
            for (int i = 0; i < res2.Length; i += 3)
            {
                var verts = new[] { res2[i], res2[i + 1], res2[i + 2] };
                foreach (var v in verts)
                {
                    string key = $"{(int)(v.X * 1000)};{(int)(v.Y * 1000)};{(int)(v.Z * 1000)}";
                    if (!bucket2.ContainsKey(key))
                        bucket2.Add(key, new List<VecArrayPosInfo>());

                    var fr = bucket2[key].FirstOrDefault(z => (z.Position - v).Length < tolerance);
                    if (fr != null)
                    {
                        nindices.Add(fr.Index);
                        continue;
                    }

                    vvn.Add(v);
                    bucket2[key].Add(new VecArrayPosInfo() { Position = v, Index = vvn.Count });
                    nindices.Add(vvn.Count);
                    sb.AppendLine($"vn {v.X} {v.Y} {v.Z}".Replace(",", "."));
                }
            }

            for (int i = 0; i < res1.Length; i += 3)
            {
                var verts = new[] { res1[i], res1[i + 1], res1[i + 2] };
                var normals = new[] { res2[i], res2[i + 1], res2[i + 2] };
                List<int> indc = new List<int>();
                List<int> indcn = new List<int>();

                for (int j = 0; j < 3; j++)
                {
                    indc.Add(indices[i + j]);
                    indcn.Add(nindices[i + j]);
                }
                if (indc.GroupBy(z => z).Any(z => z.Count() > 1))
                {
                    continue;
                    //throw duplicate face vertex
                }
                sb.AppendLine($"f {indc[0]}//{indcn[0]} {indc[1]}//{indcn[1]} {indc[2]}//{indcn[2]}");
            }

            return sb.ToString();
        }

    }
}
