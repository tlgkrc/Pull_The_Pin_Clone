using System;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class PoolTypeData
    {
        [Range(0, 100)] public int ObjectLimit;
        public GameObject PooledGameObject;
    }
}