using System.Collections.Generic;
using UnityEngine;

namespace Screpository.Grid
{
    public abstract class GridGeometry
    {
        public static GridGeometry Hex => _hex ?? (_hex = new HexGridGeometry());
        private static GridGeometry _hex;
        
        public abstract IEnumerable<Vector3Int> Neighbors(Vector3Int pos);
        
        private sealed class HexGridGeometry : GridGeometry
        {
            public override IEnumerable<Vector3Int> Neighbors(Vector3Int pos)
            {
                if (pos.y % 2 == 0)
                {
                    yield return new Vector3Int(pos.x - 1, pos.y + 1, pos.z);
                    yield return new Vector3Int(pos.x, pos.y + 1, pos.z);
                    yield return new Vector3Int(pos.x - 1, pos.y, pos.z);
                    yield return new Vector3Int(pos.x + 1, pos.y, pos.z);
                    yield return new Vector3Int(pos.x - 1, pos.y - 1, pos.z);
                    yield return new Vector3Int(pos.x, pos.y - 1, pos.z);
                }
                else
                {
                    yield return new Vector3Int(pos.x, pos.y + 1, pos.z);
                    yield return new Vector3Int(pos.x + 1, pos.y + 1, pos.z);
                    yield return new Vector3Int(pos.x - 1, pos.y, pos.z);
                    yield return new Vector3Int(pos.x + 1, pos.y, pos.z);
                    yield return new Vector3Int(pos.x, pos.y - 1, pos.z);
                    yield return new Vector3Int(pos.x + 1, pos.y - 1, pos.z);
                }
            }
        }
    }
}