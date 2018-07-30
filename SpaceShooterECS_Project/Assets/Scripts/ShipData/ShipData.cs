using UnityEngine;
using Unity.Entities;

[System.Serializable]
public struct ShipData : ISharedComponentData
{
    public float topBound;
    public float bottomBound;
    public float leftBound;
    public float rightBound;
    public float shipSpeed;
}
