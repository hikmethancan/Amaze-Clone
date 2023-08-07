using System.Collections.Generic;
using Concrete.Cells;
using UnityEngine;

namespace Concrete.Managers
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private List<Cell> cells;
    }
}