using ScriptableObjectArchitecture;
using UnityEngine;

namespace Screpository.Variables
{
    [CreateAssetMenu(fileName = "GridPositionVariable.asset", menuName = "Variables/GridPosition")]
    public class GridPositionVariable : BaseVariable<Vector3Int>
    {
    }
}