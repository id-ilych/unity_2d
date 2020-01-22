using Screpository.References;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Screpository
{
    public sealed class PlayerInput : MonoBehaviour
    {
        public new Camera camera;
        public GridPositionReference target;
        public Tilemap tilemap;

        void Update()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            var world = camera.ScreenToWorldPoint(Input.mousePosition);
            var cell = tilemap.WorldToCell(world);
            if (!tilemap.HasTile(cell))
            {
                return;
            }

            target.Value = cell;
        }
    }
}