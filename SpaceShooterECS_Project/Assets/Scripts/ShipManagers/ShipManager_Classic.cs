using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipDataBehaviour))]
public class ShipManager_Classic : MonoBehaviour {

    public GameObject shipPrefab;

    ShipDataBehaviour shipData;

    public void AddShips( int shipCount)
    {
        for (int i = 0; i < shipCount; i++)
        {
            Vector3 pos = shipData.GetRandomTopSpawnPos(10);
            Quaternion rot = Quaternion.Euler(0f, 180f, 0f);
            var enemyShip = Instantiate(shipPrefab, pos, rot) as GameObject;
            var movement = enemyShip.GetComponent<Movement>();
            movement.topBound = shipData.data.topBound;
            movement.bottomBound = shipData.data.bottomBound;
            movement.speed = shipData.data.shipSpeed;
        }
    }

    private void Awake()
    {
        shipData = GetComponent<ShipDataBehaviour>();
    }
}
