using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;


[RequireComponent(typeof(ShipDataBehaviour))]
public class ShipManager_Jobs : MonoBehaviour
{
    public GameObject shipPrefab;

    ShipDataBehaviour shipData;

    TransformAccessArray enemyShipTransforms;
    MovementJob moveJob;
    JobHandle moveHandle;

    public void AddShips(int shipCount)
    {
        for (int i = 0; i < shipCount; i++)
        {
            Vector3 pos = shipData.GetRandomTopSpawnPos(10);
            Quaternion rot = Quaternion.Euler(0f, 180f, 0f);
            var enemyShip = Instantiate(shipPrefab, pos, rot) as GameObject;
            enemyShipTransforms.Add(enemyShip.transform);
        }
    }

    private void Awake()
    {
        shipData = GetComponent<ShipDataBehaviour>();
        enemyShipTransforms = new TransformAccessArray(0, 1);
    }

    void OnDestroy()
    {
        moveHandle.Complete();
        enemyShipTransforms.Dispose();
    }

    void Update()
    {
        if (enemyShipTransforms.length == 0) return;

        moveHandle.Complete();

        moveJob = new MovementJob()
        {
            speed = shipData.data.shipSpeed,
            topBound = shipData.data.topBound,
            bottomBound = shipData.data.bottomBound,
            deltaTime = Time.deltaTime
        };

        moveHandle = moveJob.Schedule(enemyShipTransforms);

        JobHandle.ScheduleBatchedJobs();
    }
}
