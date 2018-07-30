using UnityEngine;
using Unity.Entities;

public class ShipDataBehaviour : MonoBehaviour
{
    public ShipData data = new ShipData()
    {
        topBound = 16.5f,
        bottomBound = -13.5f,
        leftBound = -23.5f,
        rightBound = 23.5f,
        shipSpeed = 1
    };

    public Vector3 GetRandomTopSpawnPos(float spawnArea)
    {
        float xVal = Random.Range(data.leftBound, data.rightBound);
        float zVal = Random.Range(0f, spawnArea);
        return new Vector3(xVal, 0f, zVal + data.topBound);
    }
}
