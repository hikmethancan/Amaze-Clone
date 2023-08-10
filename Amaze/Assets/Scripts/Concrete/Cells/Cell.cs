using System;
using System.Collections;
using Abstract.Enums;
using Abstract.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Concrete.Cells
{
    [Serializable]
    public abstract class Cell : MonoBehaviour
    {
        [ShowInInspector]
        public int[,] cellIdReference = new int[0,0];
        
        [Header("References")]
        public SkinnedMeshRenderer meshRenderer;

        public bool IsInteracted { get; set; }

        private Material _tempMaterial;
        
        
    }
}