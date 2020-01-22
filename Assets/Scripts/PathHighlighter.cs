using System;
using System.Resources;
using Screpository.Grid;
using Screpository.References;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Screpository
{
    public class PathHighlighter : MonoBehaviour
    {
        public Tilemap tilemap;
        public TileBase emptyTile;
        public TileBase highlightedTile;
        public TileBase selectedTile;
        public GridPositionReference targetLink;

        private Vector3Int _target;
        private Vector3Int _prevTarget;
        private Vector3Int[] _prevPath = { };

        void Start()
        {
            _prevTarget = _target = targetLink.Value;
            _prevPath = new[] {_target};
            Validate();
            targetLink.AddListener(OnTargetUpdate);
        }

        private void OnDestroy()
        {
            targetLink.RemoveListener(OnTargetUpdate);
        }

        private void OnTargetUpdate()
        {
            _prevTarget = _target;
            _target = targetLink.Value;
            Validate();
        }

        private void Validate()
        {
            Draw(_prevTarget, _target);
        }

        private void Draw(Vector3Int from, Vector3Int to)
        {
            ReplaceMany(_prevPath, emptyTile);
            _prevPath = GridPathfinder.FindPath(from, to, GridGeometry.Hex);
            ReplaceMany(_prevPath, highlightedTile);
            ReplaceOne(to, selectedTile);
        }

        void ReplaceMany(Vector3Int[] pos, TileBase value)
        {
            foreach (var p in pos)
            {
                ReplaceOne(p, value);
            }
        }

        void ReplaceOne(Vector3Int pos, TileBase value)
        {
            if (!tilemap.HasTile(pos))
            {
                return;
            }
            tilemap.SetTile(pos, value);
        }
    }
}
