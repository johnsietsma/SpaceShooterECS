using UnityEngine;
using Unity.Entities;

[RequireComponent(typeof(ShipDataBehaviour))]
public class ShipManager_HybridECS : MonoBehaviour
{

    public GameObject shipPrefab;

    EntityManager manager;
    ShipDataBehaviour shipData;

    public void AddShips(int shipCount)
    {
        for (int i = 0; i < shipCount; i++)
        {
            Vector3 pos = shipData.GetRandomTopSpawnPos(10);
            Quaternion rot = Quaternion.Euler(0f, 180f, 0f);
            var enemyShip = Instantiate(shipPrefab, pos, rot) as GameObject;
            var movement = enemyShip.GetComponent<MovementHybrid>();
            movement.topBound = shipData.data.topBound;
            movement.bottomBound = shipData.data.bottomBound;
            movement.speed = shipData.data.shipSpeed;
        }
    }

    void Awake()
    {
        manager = World.Active.GetOrCreateManager<EntityManager>();
        shipData = GetComponent<ShipDataBehaviour>();
    }
}
