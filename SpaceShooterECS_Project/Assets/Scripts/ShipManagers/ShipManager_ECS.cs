using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[RequireComponent(typeof(ShipDataBehaviour))]
public class ShipManager_ECS : MonoBehaviour
{
    public GameObject shipPrefab;

    EntityManager manager;
    ShipData shipData;

    public void AddShips(int amount)
    {
        NativeArray<Entity> entities = new NativeArray<Entity>(amount, Allocator.Temp);
        manager.Instantiate(shipPrefab, entities);
        var shipTag = new ShipTag_ECS();

        for (int i = 0; i < amount; i++)
        {
            float xVal = Random.Range(shipData.leftBound, shipData.rightBound);
            float zVal = Random.Range(0f, 10f);
            manager.SetComponentData(entities[i], new Position { Value = new float3(xVal, 0f, shipData.topBound + zVal) });
            manager.SetComponentData(entities[i], new Rotation { Value = new quaternion(0, 1, 0, 0) });
            manager.SetComponentData(entities[i], new MoveSpeed { speed = shipData.shipSpeed });
            manager.AddSharedComponentData(entities[i], shipData);
            manager.AddSharedComponentData(entities[i], shipTag);
        }
        entities.Dispose();
    }

    void Awake()
    {
        manager = World.Active.GetOrCreateManager<EntityManager>();
        shipData = GetComponent<ShipDataBehaviour>().data;
    }
}
