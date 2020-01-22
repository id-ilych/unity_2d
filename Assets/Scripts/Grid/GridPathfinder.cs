using System.Collections.Generic;
using UnityEngine;

namespace Screpository.Grid
{
    public static class GridPathfinder
    {
        public static Vector3Int[] FindPath(Vector3Int from, Vector3Int to, GridGeometry geometry)
        {
            var traces = new Dictionary<Vector3Int, Vector3Int>();
            var counter = 0;
            traces[from] = from;
            var nextSteps = new List<Vector3Int> { from };
            var currentStep = new List<Vector3Int>();
            while (nextSteps.Count != 0 && !traces.ContainsKey(to))
            {
                var t = currentStep;
                currentStep = nextSteps;
                nextSteps = t;
                nextSteps.Clear();

                foreach (var p in currentStep)
                {
                    foreach (var n in geometry.Neighbors(p))
                    {
                        if (traces.ContainsKey(n))
                        {
                            continue;
                        }
                    
                        // TODO can check for the walls between p and n here

                        traces[n] = p;
                        nextSteps.Add(n);
                    }
                }

                counter++;
            }

            if (!traces.ContainsKey(to))
            {
                Debug.LogError("Failed to find a path");
                return null;
            }

            var cursor = to;
            var result = new Vector3Int[counter + 1];
            result[counter] = cursor;
            while (cursor != from)
            {
                counter--;
                cursor = traces[cursor];
                result[counter] = cursor;
            }

            return result;
        }
    }
}