using OpenTK.Mathematics;
using System;
using System.Collections.Generic;

namespace OCCTProxy.Common
{
    public static class BlueprintHelpers
    {
        public static Blueprint MakeNGonDraft(int n, double rad)
        {
            Blueprint ret = new Blueprint();
            List<Vector2d> pnts = new List<Vector2d>();
            for (double i = 0; i < Math.PI * 2; i += (Math.PI * 2 / n))
            {
                var xx = rad * Math.Cos(i);
                var yy = rad * Math.Sin(i);
                pnts.Add(new Vector2d(xx, yy));
            }

            for (int i = 1; i <= pnts.Count; i++)
            {
                ret.Items.Add(new Line2D()
                {
                    Start = pnts[i - 1],
                    End = pnts[i % pnts.Count]
                });
            }
            return ret;
        }
    }
}
